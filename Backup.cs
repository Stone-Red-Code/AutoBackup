using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBackup
{
    class Backup
    {
        volatile public int processCount = 0;
        public List<string> currentStatus = new List<string>();
        public bool windowVisible = false;


        List<string> sourceFolders = new List<string>();
        List<List<string>> destinationFolders = new List<List<string>>();
        List<ulong[]> optionsList = new List<ulong[]>();
        List<bool> isRunning = new List<bool>();
        readonly Stopwatch stopwatch;
        readonly Timer timer;
        bool isON = false;

        public Backup()
        {
            stopwatch = new Stopwatch();
            timer = new Timer();

            timer.Tick += Timer_Tick;
            timer.Interval = 100;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ulong milliseconds = (ulong)stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();
            for (int index = 0; index < optionsList.Count; index++)
            {
                if (isRunning[index] == false)
                {
                    optionsList[index][1] += milliseconds;
                }
            }
            CheckIfBackupRequired();
            /*
            else if (stopwatch.IsRunning)
            {
                //TimeSpan timeSpan = TimeSpan.FromMilliseconds(waitTimeMilliseconds - stopwatch.ElapsedMilliseconds + offset);
                //currentStatus = "Time remaining to next Backup:" + timeSpan.ToString(@"dd\:hh\:mm\:ss");
                //Console.WriteLine(waitTimeMilliseconds + "-" + stopwatch.ElapsedMilliseconds);
            }
            else if (isRunning == false)
            {
                currentStatus = "OFF";
            }
            */
        }

        void CheckIfFilesChanged()
        {

        }

        public void OFF()
        {
            isON = false;
            stopwatch.Stop();
            timer.Stop();
        }

        public void ON(List<string> _sourceFolders, List<List<string>> _destinationFolders, List<int[]> _optionsList)
        {
            sourceFolders.Clear();
            destinationFolders.Clear();
            optionsList.Clear();
            isRunning.Clear();
            currentStatus.Clear();

            destinationFolders.AddRange(_destinationFolders);
            sourceFolders.AddRange(_sourceFolders);

            //sourceFolders = _sourceFolders;
            //destinationFolders = _destinationFolders;

            int index = 0;
            foreach (int[] timeOption in _optionsList)
            {
                ulong milliseconds = 0;
                if (timeOption[1] == 0)
                {
                    milliseconds = (ulong)timeOption[0] * 1000;
                }
                else if (timeOption[1] == 1)
                {
                    milliseconds = (ulong)timeOption[0] * 60 * 1000;
                }
                else if (timeOption[1] == 2)
                {
                    milliseconds = (ulong)timeOption[0] * 60 * 60 * 1000;
                }
                else if (timeOption[1] == 3)
                {
                    milliseconds = (ulong)timeOption[0] * 24 * 60 * 60 * 1000;
                }
                else if (timeOption[1] == 4)
                {
                    milliseconds = (ulong)timeOption[0] * 7 * 24 * 60 * 60 * 1000;
                }
                optionsList.Add(new ulong[3]);
                optionsList[index][0] = milliseconds;
                optionsList[index][2] = (ulong)_optionsList[index][2];
                isRunning.Add(false);
                currentStatus.Add(index + "_...");
                index++;
            }

            isON = true;
            stopwatch.Start();
            timer.Start();
        }

        public void CheckIfBackupRequired()
        {
            for (int index = 0; index < optionsList.Count; index++)
            {
                if (optionsList[index][0] < optionsList[index][1] && isRunning[index] == false)
                {
                    isRunning[index] = true;
                    optionsList[index][1] = 0;
                    BackupFolder(index, optionsList[index][2]);
                }
                if (isRunning[index] == false)
                {
                    TimeSpan timeSpan = TimeSpan.FromMilliseconds(optionsList[index][0] - optionsList[index][1]);
                    currentStatus[index] = "Time remaining to next Backup:" + timeSpan.ToString(@"dd\:hh\:mm\:ss") + "   (" + sourceFolders[index] + ")";
                }
            }
        }

        void BackupFolder(int index, ulong maxBackupFolders)
        {
            if (index < destinationFolders.Count)
            {
                Task.Run(() =>
                {
                    processCount++;
                    
                    foreach (string destinationFolder in destinationFolders[index])
                    {
                        if (Directory.Exists(destinationFolder))
                        {
                            while ((ulong)Directory.GetDirectories(destinationFolder).Length > maxBackupFolders - 1 && maxBackupFolders > 0)
                            {
                                currentStatus[index] = "Deleting old backups";
                                FileSystemInfo fileInfo = new DirectoryInfo(destinationFolder).GetFileSystemInfos().OrderBy(fi => fi.CreationTime).First();
                                try
                                {
                                    DeleteDirectory(fileInfo.FullName);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(destinationFolder + " Does not exist!");
                        }
                        CopyDirecotory(sourceFolders[index], destinationFolder + "\\Backup " + DateTime.Now.ToString().Replace(":", "-").Replace("/",".").Replace("\\","."), index, GetFileCount(sourceFolders[index]));
                    }
                    processCount--;

                    isRunning[index] = false;
                });
            }
        }

        void DeleteDirectory(string targetDir)
        {
            File.SetAttributes(targetDir, FileAttributes.Normal);

            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(targetDir, false);
        }

        int CopyDirecotory(string sourcePath, string destinationPath, int index, int fileCount, int filesCopied = 0)
        {
            if (isON == false) return 0;
            if (!HasReadAccessToFolder(sourcePath)) return 0;
            if (!Directory.Exists(destinationPath.Remove(destinationPath.LastIndexOf("\\"))))
            {
                Directory.CreateDirectory(destinationPath);
            }
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            try
            {
                foreach (string file in Directory.GetFiles(sourcePath))
                {
                    if (isON == false) return 0;
                   
                    if (windowVisible)
                    {
                        if (fileCount > 0)
                        {
                            currentStatus[index] = "Copying: (" + (Math.Round(100f / (float)fileCount * (float)filesCopied, 2)).ToString("0.0") + "%)   " + file;
                        }
                        else
                        {
                            currentStatus[index] = "Copying: (???%)   " + file;
                        }
                    }
                    try
                    {
                        File.Copy(file, destinationPath + file.Substring(file.LastIndexOf("\\")), true);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            File.AppendAllText(destinationPath + "\\ErrorLog.txt", "\n" + ex);
                        }
                        catch { }
                    }
                    filesCopied++;
                }

                foreach (string directory in Directory.GetDirectories(sourcePath))
                {
                    filesCopied = CopyDirecotory(directory, destinationPath + directory.Substring(directory.LastIndexOf("\\")), index, fileCount, filesCopied);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    File.AppendAllText(destinationPath + "\\ErrorLog.txt", "\n" + ex);
                }
                catch { }
            }
            return filesCopied;
        }

        int GetFileCount(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            }
            catch
            {
                return -1;
            }
        }

        private bool HasReadAccessToFolder(string directoryPath)
        {
            bool hasAccess = true;
            try
            {
                AuthorizationRuleCollection collection = Directory.
                                            GetAccessControl(directoryPath)
                                            .GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                foreach (FileSystemAccessRule rule in collection)
                {
                    if ((rule.FileSystemRights & System.Security.AccessControl.FileSystemRights.ReadData) > 0)
                    {
                        return hasAccess;
                    }
                }
            }
            catch (Exception ex)
            {
                hasAccess = false;
            }
            return hasAccess;

        }
    }
}
