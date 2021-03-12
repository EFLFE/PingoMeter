using PingoMeter.vendor;
using PingoMeter.vendor.StartupCreator;

using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PingoMeter
{
    internal sealed class NotificationIcon
    {
        const int BALLOON_TIP_TIME_OUT = 3000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        IntPtr hicon;

        NotifyIcon notifyIcon;
        ContextMenu notificationMenu;

        IntPtr hiconOriginal;
        Image originalImage;
        Icon noneIcon;
        Bitmap drawable;
        Graphics g;
        Font font;
        Font font100;

        SoundPlayer SFXConnectionLost;
        SoundPlayer SFXTimeOut;
        SoundPlayer SFXResumed;

        enum PingHealthEnum
        {
            Good,
            Normal,
            Bad
        }

        enum AlarmEnum
        {
            None,
            ConnectionLost,
            TimeOut,
            Resumed,
            OK
        }

        AlarmEnum alarmStatus;

        StartupCreator startupManager = new StartupViaLink(Application.StartupPath + @"\Resources\op.ico");

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

            SFXConnectionLost = new SoundPlayer();
            SFXTimeOut        = new SoundPlayer();
            SFXResumed        = new SoundPlayer();

            var apppath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            originalImage = Image.FromFile(System.IO.Path.Combine(apppath, "Resources\\none.png"));
            drawable = Properties.Resources.none;
            hiconOriginal = Properties.Resources.none.GetHicon();
            noneIcon = Icon.FromHandle(hiconOriginal);
            g = Graphics.FromImage(drawable);
            font = new Font("Consolas", 9f, FontStyle.Bold);
            font100 = new Font("Consolas", 7f, FontStyle.Bold);;
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
            // Update the notification icon to use our new icon,
            // and destroy the old icon so we don't leak memory.
            Icon oldIcon = notifyIcon.Icon;

            hicon = drawable.GetHicon();
            notifyIcon.Icon = Icon.FromHandle(hicon);

            if (oldIcon != null)
            {
                DestroyIcon(oldIcon.Handle);
                oldIcon.Dispose();
            }
        }

        private DateTime? offlineTimer = null;
        /// <summary>
        /// Drawing icon.
        /// </summary>
        /// <param name="value"> Current ping. If the value is less that 0 - no ping. </param>
        private void DrawGraph(long value)
        {
            if (value < 0)
            {
                if (!Config.OfflineCounter)
                {
                    notifyIcon.Icon = noneIcon;
                }
                else
                {

                    // Show offline seconds on icon
                    long offlineElapsed = 0;
                    if (!offlineTimer.HasValue)
                    {
                        offlineTimer = DateTime.Now;
                    }
                    else
                    {
                        offlineElapsed = (long)(DateTime.Now - offlineTimer).Value.TotalSeconds;
                    }

                    var useFont = font;
                    if (offlineElapsed > 100) useFont = font100;
                    if (offlineElapsed > 999) offlineElapsed = 999;

                    g.FillRectangle(Brushes.Red, 0, 0, 16, 16);
                    g.DrawString(offlineElapsed.ToString(), useFont, Brushes.Black, -1, 1);
                    SetIcon();
                }
            }
            else
            {
                notifyIcon.Text = $"Ping [{Config.GetIPName}]: {value.ToString()} ms";

                offlineTimer = null;
                var pingHealth = PingHealthEnum.Bad;

                if (value < Config.MaxPing / 3)
                {
                    pingHealth = PingHealthEnum.Good;
                }
                else if (value < Config.MaxPing / 2)
                {
                    pingHealth = PingHealthEnum.Normal;
                }

                if (Config.UseNumbers)
                {
                    Brush bgBrush = null;
                    Brush fontBrush = null;

                    /*
                    if(value>99)
                    {
                        bgBrush = Brushes.Red;
                        fontBrush = Brushes.Black;
                    }
                    else if(value >= 50)
                    {
                        bgBrush = Brushes.Orange;
                        fontBrush = Brushes.Black;
                    }
                    else
                    {
                        bgBrush = Brushes.Green;
                        fontBrush = Brushes.White;
                    }
                     */

                    switch (pingHealth)
                    {
                        case PingHealthEnum.Good:
                            bgBrush = Brushes.Green;
                            fontBrush = Brushes.White;
                            break;

                        case PingHealthEnum.Normal:
                            bgBrush = Brushes.Orange;
                            fontBrush = Brushes.Black;
                            break;

                        case PingHealthEnum.Bad:
                            bgBrush = Brushes.Red;
                            fontBrush = Brushes.Black;
                            break;
                    }

                    if (value > 99)
                        value = 99;

                    g.FillRectangle(bgBrush, 0, 0, 16, 16);
                    g.DrawString(value.ToString(), font, fontBrush, -1, 1);
                    SetIcon();
                }
                else
                {
                    Pen lineColor = null;

                    switch (pingHealth)
                    {
                        case PingHealthEnum.Good:
                            lineColor = Config.GoodColor;
                            break;

                        case PingHealthEnum.Normal:
                            lineColor = Config.NormalColor;
                            break;

                        case PingHealthEnum.Bad:
                            lineColor = Config.BadColor;
                            break;
                    }

                    // from 1 to 15
                    value = Math.Min(value, Config.MaxPing);
                    float newValue = value * 14f / Config.MaxPing + 1f;

                    g.DrawLine(Config.BgColor, 15, 15, 15, 1);

                    g.DrawLine(lineColor, 15, 15, 15, 15 - newValue);
                    g.DrawImage(drawable, -1f, 0f);
                    g.DrawRectangle(Pens.Black, 0, 0, 15, 15);
                    SetIcon();
                }
            }
        }

        // Ping on thread pool
        private void PingPool(object _)
        {
            Thread.Sleep(999);

            try
            {
                var p = new Ping();
                byte[] buffer = new byte[4];

                // I have so much bad Internet that the timeout alarm goes out all the time. So, check twice.
                bool timeOutAgain = false;

                for (; ; )
                {
                    try
                    {
                        PingReply reply = p.Send(Config.TheIPAddress, 5000, buffer);

                        switch (reply.Status)
                        {
                            case IPStatus.TimedOut:
                                DrawGraph(-1L);

                                if (timeOutAgain)
                                {
                                    notifyIcon.Text = "Status: Time out";
                                    if (alarmStatus == AlarmEnum.OK)
                                    {
                                        if (Config.AlarmTimeOut)
                                            notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Ping time out", ToolTipIcon.Warning);

                                        PlaySound(SFXTimeOut, Config.SFXTimeOut);
                                    }

                                    alarmStatus = AlarmEnum.TimeOut;
                                }
                                else
                                {
                                    notifyIcon.Text = "Status: Time out?";
                                    timeOutAgain = true;
                                }
                                break;

                            case IPStatus.Success:
                                DrawGraph(reply.RoundtripTime);

                                if (alarmStatus != AlarmEnum.None && alarmStatus != AlarmEnum.OK)
                                {
                                    PlaySound(SFXResumed, Config.SFXResumed);

                                    if (Config.AlarmResumed)
                                        notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Ping resumed", ToolTipIcon.Info);
                                }

                                alarmStatus = AlarmEnum.OK;
                                timeOutAgain = false;
                                break;

                            default:

                                DrawGraph(-1L);
                                var statusName = GetIPStatusName(reply.Status);
                                notifyIcon.Text = "Status: " + statusName;



                                if (alarmStatus != AlarmEnum.ConnectionLost)
                                {
                                    PlaySound(SFXConnectionLost, Config.SFXConnectionLost);

                                    if (Config.AlarmConnectionLost)
                                        notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", statusName, ToolTipIcon.Error);
                                }

                                alarmStatus = AlarmEnum.ConnectionLost;
                                break;
                        }
                    }
                    catch (PingException)
                    {
                        DrawGraph(-1L);
                        notifyIcon.Text = "Status: Connection lost.";

                        if (alarmStatus != AlarmEnum.ConnectionLost)
                        {
                            PlaySound(SFXConnectionLost, Config.SFXConnectionLost);

                            if (Config.AlarmConnectionLost)
                                notifyIcon.ShowBalloonTip(BALLOON_TIP_TIME_OUT, "PingoMeter", "Connection lost", ToolTipIcon.Error);
                        }

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

        private void PlaySound(SoundPlayer soundPlayer, string pathToSound)
        {
            if (!string.IsNullOrWhiteSpace(pathToSound) && pathToSound != Config.NONE_SFX)
            {
                if (soundPlayer.SoundLocation == null || soundPlayer.SoundLocation != pathToSound)
                {
                    // new sound
                    try
                    {
                        soundPlayer.SoundLocation = pathToSound;
                        soundPlayer.Load();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\nFile: " + pathToSound, "Load sound error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (soundPlayer.IsLoadCompleted)
                    soundPlayer.Play();
            }
        }

        // Event Handlers
        private void MenuExitClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void MenuSetting(object sender, EventArgs e)
        {
            var dlgResult = new Setting().ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (Config.RunOnStartup)
                {
                    if (!startupManager.IsInStartup())
                    {
                        if (!startupManager.RunOnStartup())
                        {
                            MessageBox.Show("Adding to autorun is failed!");
                        }
                    }
                }
                else
                {
                    if (startupManager.IsInStartup())
                    {
                        if (!startupManager.RemoveFromStartup())
                        {
                            MessageBox.Show("Failed on disabling autorun!");
                        }
                    }
                }
            }
        }

        private string GetIPStatusName(IPStatus status)
        {
            switch (status)
            {
                case IPStatus.DestinationNetworkUnreachable:
                    return "Destination network unreachable";

                case IPStatus.DestinationHostUnreachable:
                    return "Destination host unreachable";

                case IPStatus.DestinationProtocolUnreachable:
                    return "Destination protocol unreachable";

                case IPStatus.DestinationPortUnreachable:
                    return "Destination port unreachable";

                //case IPStatus.DestinationProhibited:
                //    return "";

                case IPStatus.NoResources:
                    return "No resources";

                case IPStatus.BadOption:
                    return "Bad option";

                case IPStatus.HardwareError:
                    return "Hardware error";

                case IPStatus.PacketTooBig:
                    return "Packet too big";

                case IPStatus.TimedOut:
                    return "Timed out";

                case IPStatus.BadRoute:
                    return "Bad route";

                case IPStatus.TtlExpired:
                    return "TTL expired";

                case IPStatus.TtlReassemblyTimeExceeded:
                    return "TTL reassembly time exceeded";

                case IPStatus.ParameterProblem:
                    return "Parameter problem";

                case IPStatus.SourceQuench:
                    return "Source quench";

                case IPStatus.BadDestination:
                    return "Bad destination";

                case IPStatus.DestinationUnreachable:
                    return "Destination unreachable";

                case IPStatus.TimeExceeded:
                    return "Time exceeded";

                case IPStatus.BadHeader:
                    return "Bad header";

                case IPStatus.UnrecognizedNextHeader:
                    return "Unrecognized next header";

                case IPStatus.IcmpError:
                    return "ICMP error";

                case IPStatus.DestinationScopeMismatch:
                    return "Destination scope mismatch";

                default:
                    return status.ToString();
            }
        }

    }
}
