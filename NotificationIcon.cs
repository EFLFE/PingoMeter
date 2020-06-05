using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PingoMeter
{
    internal sealed class NotificationIcon
    {
        const int BALLOON_TIP_TIME_OUT = 3000;
        Setting settingWindow;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        IntPtr hicon;

        NotifyIcon notifyIcon;
        ContextMenu notificationMenu;

        IntPtr hiconOriginal;
        Image originalImage;
        Bitmap drawable;
        Graphics g;

        enum AlarmEnum
        {
            None,
            ConnectionLost,
            TimeOut,
            Resumed,
            OK
        }

        AlarmEnum alarmStatus;

        public NotificationIcon()
        {
            Config.Load();
            alarmStatus = AlarmEnum.None;

            notificationMenu = new ContextMenu(
                new MenuItem[]
                {
                    new MenuItem("Setting", MenuSetting),
                    new MenuItem("Exit", MenuExitClick)
                });

            notifyIcon = new NotifyIcon
            {
                ContextMenu = notificationMenu,
                Visible = true
            };

            originalImage = Image.FromFile("Resources\\none.png");
            drawable = Properties.Resources.none;
            hiconOriginal = Properties.Resources.none.GetHicon();
            g = Graphics.FromImage(drawable);
            SetIcon();
        }

        ~NotificationIcon()
        {
            DestroyIcon(hicon);
            DestroyIcon(hiconOriginal);
            g.Dispose();
        }

        public void Run()
        {
            notifyIcon.Visible = true;
            ThreadPool.QueueUserWorkItem(PingPool, null);
            Application.Run();
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

        // Ping on thread pool
        private void PingPool(object _)
        {
            Thread.Sleep(999);

            try
            {
                var p = new Ping();
                byte[] buffer = new byte[4];

                // У меня на столько хреновый интернет, что timeout вылазиет постоянно.
                // Так что нужно проверять дважды.
                bool timeOutAgain = false;

                while (true)
                {
                    try
                    {
                        /*
                         * Ping.Send на самом деле внутри достаточно сложно устроен.
                         * Но точно известно, что там есть try catch.
                         * Если интернет выключен/недоступен, то каждый вызов будет создавать исключение.
                         * Мне это не очень нравится и хотелось бы узнать пинг без использования исключений,
                         * или хотя бы заранее узнать о наличии доступа к сети.
                         */

                        PingReply reply = p.Send(Config.TheIPAddress, 5000, buffer);

                        switch (reply.Status)
                        {
                            case IPStatus.TimedOut:
                                DrawGraph(-1L);

                                if (timeOutAgain)
                                {
                                    notifyIcon.Text = "Status: Time out";
                                    if (alarmStatus == AlarmEnum.OK && Config.AlarmTimeOut)
                                        notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Ping time out", ToolTipIcon.Warning);

                                    alarmStatus = AlarmEnum.TimeOut;
                                }
                                else
                                {
                                    notifyIcon.Text = "Status: Time out?";
                                    timeOutAgain = true;
                                }
                                break;

                            default:
                                // OK. В остальных случиях получим исключение
                                DrawGraph(reply.RoundtripTime);

                                if (alarmStatus != AlarmEnum.None && alarmStatus != AlarmEnum.OK && Config.AlarmResumed)
                                    notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Ping resumed", ToolTipIcon.Info);

                                alarmStatus = AlarmEnum.OK;
                                timeOutAgain = false;
                                break;
                        }
                    }
                    catch (PingException)
                    {
                        DrawGraph(-1L);
                        notifyIcon.Text = "Status: Connection lost.";

                        if (alarmStatus == AlarmEnum.OK && Config.AlarmConnectionLost)
                            notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Connection lost", ToolTipIcon.Error);

                        alarmStatus = AlarmEnum.ConnectionLost;
                    }
                    catch (Exception ex)
                    {
                        DrawGraph(-1L);
                        notifyIcon.Text = ex.Message;
                        notifyIcon.Text = "Status: Error.";

                        notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Error: " + ex.Message, ToolTipIcon.Error);

                        alarmStatus = AlarmEnum.None;
                    }

                    Thread.Sleep(Config.Delay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "PingoMeter crash log");
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
