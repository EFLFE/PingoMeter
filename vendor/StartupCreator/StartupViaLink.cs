using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Shell32;


namespace PingoMeter.vendor.StartupCreator
{
    public class StartupViaLink : StartupCreator
    {
        private string icoPath;
        private string startUpFolderPath;

        public StartupViaLink(string icoPath)
        {
            this.icoPath = icoPath;

            startUpFolderPath =
              Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        }

        public bool IsInStartup()
        {
            var fi = getExistingLink();
            return (fi != null);
        }

        public bool RemoveFromStartup()
        {
            var fi = getExistingLink();
            if (fi != null)
            {
                System.IO.File.Delete(fi.FullName);
                return true;
            }

            return false;
        }

        public bool RunOnStartup()
        {
            WshShellClass wshShell = new WshShellClass();
            IWshRuntimeLibrary.IWshShortcut shortcut;

            try
            {
                // Create the shortcut
                shortcut =
                  (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(
                      getLinkPath()
                    );

                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                //shortcut.Description = "Launch My Application";
                shortcut.IconLocation = this.icoPath;
                shortcut.Save();
                return true;
            }
            catch { }

            return false;
        }

        private string getLinkPath()
        {
            return startUpFolderPath + "\\" +
                    Application.ProductName + ".lnk";
        }

        public string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);

            Shell32.Shell shell = new Shell32.ShellClass();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link =
                  (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return String.Empty; // Not found
        }

        private FileInfo getExistingLink()
        {
            var targetExeName = Application.ExecutablePath;

            DirectoryInfo di = new DirectoryInfo(startUpFolderPath);
            FileInfo[] files = di.GetFiles("*.lnk");

            foreach (FileInfo fi in files)
            {
                string shortcutTargetFile = GetShortcutTargetFile(fi.FullName);

                if (shortcutTargetFile.EndsWith(targetExeName,
                      StringComparison.InvariantCultureIgnoreCase))
                {
                    return fi;
                }
            }
            return null;
        }
    }
}
