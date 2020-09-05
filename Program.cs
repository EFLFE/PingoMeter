using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PingoMeter
{
    internal static class Program
    {
        /// <summary> x.x.x program version string. </summary>
        public const string VERSION = "0.9.5";

        [STAThread]
        public static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                // [!] BSOD 0x0..76 [!]
                // Опасно! Может вызвать синий экран, если остановить процесс отладки.
                Debugger.Break();
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var notificationIcon = new NotificationIcon();
                notificationIcon.Run();
            }
            catch (Exception ex)
            {
                File.WriteAllText("error.txt", "[PingoMeter crash log]\n\n" + ex.ToString());
                Process.Start("error.txt");
            }
        }
    }
}
