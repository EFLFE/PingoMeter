using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PingoMeter
{
    public sealed class NotificationIcon
    {
        private static Setting settingWindow;
        private const int BALLOON_TIP_TIME_OUT = 3000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        private static IntPtr hicon;

        private static NotificationIcon self;

        private NotifyIcon notifyIcon;
        private ContextMenu notificationMenu;

        private IntPtr hiconOriginal;
        private Image originalImage;
        private Bitmap drawable;
        private Graphics g;

        private enum AlarmEnum
        {
            None,
            ConnectionLost,
            TimeOut,
            Resumed,
            OK
        }
        private static AlarmEnum alarmStatus = AlarmEnum.None;

        public NotificationIcon()
        {
            self = this;

            Config.Load();

            notifyIcon = new NotifyIcon();
            notificationMenu = new ContextMenu(InitializeMenu());

            originalImage = Image.FromFile("Resources\\none.png");
            drawable = Properties.Resources.none;
            hiconOriginal = Properties.Resources.none.GetHicon();

            g = Graphics.FromImage(drawable);

            SetIcon();
            notifyIcon.ContextMenu = notificationMenu;
        }

        ~NotificationIcon()
        {
            DestroyIcon(hicon);
            DestroyIcon(hiconOriginal);
            g.Dispose();
        }

        private void SetIcon()
        {
            hicon = drawable.GetHicon();
            notifyIcon.Icon = Icon.FromHandle(hicon);
            DestroyIcon(hicon);
        }

        private void DrawGraph(long value)
        {
            if (value == -1)
            {
                notifyIcon.Icon = Icon.FromHandle(hiconOriginal);
                return;
            }
            if (value == 0L)
            {
                //g.DrawLine(Pens.Black, 15, 15, 15, 1);
                notifyIcon.Text = "Ping: none";
            }
            else
            {
                notifyIcon.Text = "Ping: " + value;

                // from 1 to 15
                if (value > Config.MaxPing)
                {
                    value = Config.MaxPing;
                }
                float newValue = value * 14f / Config.MaxPing + 1f;

                g.DrawLine(Config.BgColor, 15, 15, 15, 1);

                if (value < Config.MaxPing / 3)
                {
                    g.DrawLine(Config.GoodColor, 15, 15, 15, 15 - newValue);
                }
                else if (value < Config.MaxPing / 2)
                {
                    g.DrawLine(Config.NormalColor, 15, 15, 15, 15 - newValue);
                }
                else
                {
                    g.DrawLine(Config.BadColor, 15, 15, 15, 15 - newValue);
                }
            }

            g.DrawImage(drawable, -1f, 0f);
            g.DrawRectangle(Pens.Black, 0, 0, 15, 15);
            SetIcon();
        }

        private MenuItem[] InitializeMenu()
        {
            MenuItem[] menu = new MenuItem[] {
                new MenuItem("Setting", MenuSetting),
                new MenuItem("Exit", MenuExitClick)
            };
            return menu;
        }

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (Mutex mtx = new Mutex(true, "PingoMeter", out bool isFirstInstance))
                {
                    if (isFirstInstance)
                    {
                        NotificationIcon notificationIcon = new NotificationIcon();
                        notificationIcon.notifyIcon.Visible = true;

                        ThreadPool.QueueUserWorkItem(PingPool, null);

                        Application.Run();
                        notificationIcon.notifyIcon.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("PingoMeter already running.", "PingoMeter");
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("error.txt", "[PingoMeter crash log]\n\n" + ex.ToString());
                Process.Start("error.txt");
            }
        }

        // Ping here
        private static void PingPool(object nil)
        {
            Thread.Sleep(999);
            try
            {
                Ping p = new Ping();
                byte[] buffer = new byte[4];

                while (true)
                {
                    try
                    {
                        PingReply reply = p.Send(Config.TheIPAddress, 5000, buffer);
                        long t = reply.RoundtripTime;

                        switch (reply.Status)
                        {
                            case IPStatus.TimedOut:
                                self.DrawGraph(-1L);
                                self.notifyIcon.Text = "Status: Time out.";

                                if (alarmStatus == AlarmEnum.OK && Config.AlarmTimeOut)
                                    self.notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Ping time out", ToolTipIcon.Warning);

                                alarmStatus = AlarmEnum.TimeOut;
                                break;

                            default:
                                self.DrawGraph(t);

                                if (alarmStatus != AlarmEnum.None && alarmStatus != AlarmEnum.OK && Config.AlarmResumed)
                                    self.notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Ping resumed", ToolTipIcon.Info);

                                alarmStatus = AlarmEnum.OK;
                                break;
                        }
                    }
                    catch (PingException)
                    {
                        self.DrawGraph(-1L);
                        self.notifyIcon.Text = "Status: Connection lost.";

                        if (alarmStatus == AlarmEnum.OK && Config.AlarmConnectionLost)
                            self.notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Connection lost.", ToolTipIcon.Error);

                        alarmStatus = AlarmEnum.ConnectionLost;
                    }
                    catch (Exception ex)
                    {
                        self.DrawGraph(-1L);
                        self.notifyIcon.Text = ex.Message;
                        self.notifyIcon.Text = "Status: Error.";

                        self.notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Error: " + ex.Message, ToolTipIcon.Error);

                        alarmStatus = AlarmEnum.None;
                    }

                    Thread.Sleep(Config.Delay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "PingoMeter crash message");
                alarmStatus = AlarmEnum.None;
            }
        }

        // Event Handlers
        private void MenuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuSetting(object sender, EventArgs e)
        {
            if (settingWindow == null)
            {
                settingWindow = new Setting();
                settingWindow.ShowDialog();
                settingWindow.Dispose();
                settingWindow = null;
            }
            else
                settingWindow.Focus();
        }

    }
}
