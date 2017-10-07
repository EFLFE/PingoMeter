using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PingoMeter
{
    public sealed class NotificationIcon
    {
        private static Setting settingWindow;

        private static int maxPing = 250;
        private static int delay = 3000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        private static IntPtr Hicon;

        private static Pen bgColor;
        private static Pen goodPing;
        private static Pen normalPing;
        private static Pen badPing;

        private static NotificationIcon self;

        private NotifyIcon notifyIcon;
        private ContextMenu notificationMenu;

        private IntPtr HiconOriginal;
        private Image originalImage;
        private Bitmap drawable;
        private Graphics g;

        public NotificationIcon()
        {
            self = this;

            Config.Load();
            SyncFromConfig();

            notifyIcon = new NotifyIcon();
            notificationMenu = new ContextMenu(InitializeMenu());

            originalImage = Image.FromFile("Resources\\none.png");
            drawable = Properties.Resources.none;
            HiconOriginal = Properties.Resources.none.GetHicon();

            g = Graphics.FromImage(drawable);

            setIcon();
            notifyIcon.ContextMenu = notificationMenu;
        }

        ~NotificationIcon()
        {
            DestroyIcon(Hicon);
            DestroyIcon(HiconOriginal);
            g.Dispose();
        }

        public static void SyncFromConfig()
        {
            maxPing = Config.MaxPing;
            delay = Config.Delay;

            bgColor = new Pen(Config.BgColor);
            goodPing = new Pen(Config.GoodColor);
            normalPing = new Pen(Config.NormalColor);
            badPing = new Pen(Config.BadColor);
        }

        private void setIcon()
        {
            Hicon = drawable.GetHicon();
            notifyIcon.Icon = Icon.FromHandle(Hicon);
            DestroyIcon(Hicon);
        }

        private void drawGraph(long value)
        {
            if (value == -1)
            {
                notifyIcon.Icon = Icon.FromHandle(HiconOriginal);
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
                if (value > maxPing)
                {
                    value = maxPing;
                }
                float newValue = value * 14f / maxPing + 1f;

                g.DrawLine(bgColor, 15, 15, 15, 1);

                if (value < maxPing / 3)
                {
                    g.DrawLine(goodPing, 15, 15, 15, 15 - newValue);
                }
                else if (value < maxPing / 2)
                {
                    g.DrawLine(normalPing, 15, 15, 15, 15 - newValue);
                }
                else
                {
                    g.DrawLine(badPing, 15, 15, 15, 15 - newValue);
                }
            }

            g.DrawImage(drawable, -1f, 0f);
            g.DrawRectangle(Pens.Black, 0, 0, 15, 15);
            setIcon();
        }

        private MenuItem[] InitializeMenu()
        {
            MenuItem[] menu = new MenuItem[] {
                new MenuItem("Setting", menuSetting),
                new MenuItem("Exit", menuExitClick)
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

                bool isFirstInstance;
                // Please use a unique name for the mutex to prevent conflicts with other programs
                using (Mutex mtx = new Mutex(true, "PingoMeter", out isFirstInstance))
                {
                    if (isFirstInstance)
                    {
                        NotificationIcon notificationIcon = new NotificationIcon();
                        notificationIcon.notifyIcon.Visible = true;

                        ThreadPool.QueueUserWorkItem(pingPool, null);

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

        private static void pingPool(object nil)
        {
            Thread.Sleep(999);
            try
            {
                Ping p = new Ping();
                var buffer = new byte[4];

                while (true)
                {
                    try
                    {
                        long t = p.Send("212.109.218.166", 9999, buffer).RoundtripTime;
                        if (t == 0L)
                            t = maxPing;
                        self.drawGraph(t);
                    }
                    catch (Exception ex)
                    {
                        self.drawGraph(-1L);
                        self.notifyIcon.Text = ex.Message;
                    }

                    Thread.Sleep(delay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        // Event Handlers
        private void menuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuSetting(object sender, EventArgs e)
        {
            if (settingWindow == null)
            {
                settingWindow = new Setting();
                settingWindow.ShowDialog();
                settingWindow.Dispose();
                settingWindow = null;
            }
            else settingWindow.Focus();
        }

    }
}
