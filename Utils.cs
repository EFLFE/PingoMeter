using System;
using Microsoft.Win32;

namespace PingoMeter
{
    public static class Utils
    {
        /// <summary>
        /// Return true if app running on Windows 8 or next versions.
        /// </summary>
        public static bool IsWindows8Next()
        {
            try
            {
                string productName = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName");
                return productName.StartsWith("Windows 8") || productName.StartsWith("Windows 10");
            }
            catch
            {
                return false;
            }
        }
    }
}
