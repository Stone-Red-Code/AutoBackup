using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBackup
{
    public partial class MainForm : Form
    {
        List<string> sourceFolders = new List<string>();
        List<List<string>> destinationFolders = new List<List<string>>();
        List<int[]> optionsList = new List<int[]>();
        readonly Backup backup;

        bool addSourceFolder = true;
        bool blockWrite = false;

        readonly string localApplicationDataPath;

        const string AppName = "AutoBackup";
        const string registrykey = "HKEY_CURRENT_USER\\" + AppName;

        public MainForm()
        {
            InitializeComponent();

            localApplicationDataPath = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\" + AppName;

            LoadFolders();

            backup = new Backup();

            if (!Directory.Exists(localApplicationDataPath))
            {
                Directory.CreateDirectory(localApplicationDataPath);
            }

            try
            {
                if ((string)Registry.GetValue(registrykey, "OnOff", "Off") == "On")
                {
                    OnOffToggleButton_Click(null, null);
                    this.ShowInTaskbar = false;
                    this.Visible = false;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            catch { }

            MainForm_SizeChanged(null, null);
            MainTimer.Start();

            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = true;
            notifyIcon.Text = this.Text;

            toolTip.SetToolTip(maxBackupsNumericUpDown, "0 = no limit");

            statusLabel.Location = new Point(13,13);
            //CopyDirecotory("D:\\Test","D:\\TestCopy");
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (sourceFoldersListBox.SelectedIndex > -1)
            {
                addDestinationFolderButton.Enabled = true;
                removeSourceFolderButton.Enabled = true;
                optionsPanel.Enabled = true;
            }
            else
            {
                addDestinationFolderButton.Enabled = false;
                removeSourceFolderButton.Enabled = false;
                optionsPanel.Enabled = false;
            }

            if (destinationFoldersListBox.SelectedIndex > -1)
            {
                removeDestinationFolderButton.Enabled = true;
            }
            else
            {
                removeDestinationFolderButton.Enabled = false;
            }

            //statusLabel.Text = backup.processCount.ToString();
            //statusLabel.Text = "";
            string textToDisplay = "";
            List<string> statusList = new List<string>();
            statusList.AddRange(backup.currentStatus);
            foreach (string status in statusList)
            {
                textToDisplay += status + "\n";
            }
            statusLabel.Text = textToDisplay;
        }

        void LoadFolders()
        {
            if (!File.Exists(localApplicationDataPath + "\\data.save"))
                return;

            int index = 0;
            string[] lines = File.ReadAllLines(localApplicationDataPath + "\\data.save");

            sourceFoldersListBox.Items.Clear();
            destinationFoldersListBox.Items.Clear();
            sourceFolders.Clear();
            destinationFolders.Clear();
            optionsList.Clear();

            foreach (string _line in lines)
            {
                string line = _line;
                destinationFolders.Add(new List<string>());
                optionsList.Add(new int[3]);

                string options = line.Substring(line.LastIndexOf(">"));
                line = line.Replace(options, "");

                string o3 = options.Substring(options.LastIndexOf(";")+1);
                options = options.Remove(options.LastIndexOf(";"));
                string o2 = options.Substring(options.LastIndexOf(";"));
                options = options.Replace(o2, "");
                string o1 = options.Replace(">", "");

                optionsList[index][2] = int.Parse(o3);
                optionsList[index][1] = int.Parse(o2.Replace(";", ""));
                optionsList[index][0] = int.Parse(o1);
                
                while (line.Contains("|"))
                {
                    string folder = line.Substring(line.LastIndexOf("|"));
                    line = line.Replace(folder, "");

                    destinationFolders[index].Add(folder.Remove(0, 1));
                }
                sourceFolders.Add(line);
                index++;
            }
            sourceFoldersListBox.Items.AddRange(sourceFolders.ToArray());
        }

        private void AddSourceFolderButton_Click(object sender, EventArgs e)
        {
            addSourceFolder = true;
            addFolderPopup.Visible = true;
            addFolderPopup.BringToFront();
        }

        private void RemoveSourceFolderButton_Click(object sender, EventArgs e)
        {
            if (sourceFoldersListBox.SelectedIndex > -1)
            {
                List<string> lines = File.ReadAllLines(localApplicationDataPath + "\\data.save").ToList();
                lines.RemoveAt(sourceFoldersListBox.SelectedIndex);
                File.WriteAllLines(localApplicationDataPath + "\\data.save", lines.ToArray());
                LoadFolders();
            }
        }

        private void AddDestinationFolderButton_Click(object sender, EventArgs e)
        {
            addSourceFolder = false;
            addFolderPopup.Visible = true;
        }

        private void RemoveDestinationFolderButton_Click(object sender, EventArgs e)
        {
            if (destinationFoldersListBox.SelectedIndex > -1)
            {
                List<string> destFolders = destinationFolders[sourceFoldersListBox.SelectedIndex];
                destFolders.RemoveAt(destinationFoldersListBox.SelectedIndex);

                string[] lines = File.ReadAllLines(localApplicationDataPath + "\\data.save");
                string options = lines[sourceFoldersListBox.SelectedIndex].Substring(lines[sourceFoldersListBox.SelectedIndex].LastIndexOf(">"));

                lines[sourceFoldersListBox.SelectedIndex] = sourceFolders[sourceFoldersListBox.SelectedIndex];
                //lines[sourceFoldersListBox.SelectedIndex] = lines[sourceFoldersListBox.SelectedIndex].Replace(options, "");

                foreach (string folder in destFolders)
                {
                    lines[sourceFoldersListBox.SelectedIndex] += "|" + folder;
                }

                lines[sourceFoldersListBox.SelectedIndex] += options;
                File.WriteAllLines(localApplicationDataPath + "\\data.save", lines);
                LoadFolders();
            }
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectFolderPathTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(selectFolderPathTextBox.Text))
            {
                if (!File.Exists(localApplicationDataPath + "\\data.save"))
                {
                    File.Create(localApplicationDataPath + "\\data.save").Close();
                }
                if (addSourceFolder == true)
                {
                    File.AppendAllText(localApplicationDataPath + "\\data.save", selectFolderPathTextBox.Text + ">1;1;1" + "\n");
                }
                else
                {
                    string[] lines = File.ReadAllLines(localApplicationDataPath + "\\data.save");
                    string options = lines[sourceFoldersListBox.SelectedIndex].Substring(lines[sourceFoldersListBox.SelectedIndex].LastIndexOf(">"));
                    lines[sourceFoldersListBox.SelectedIndex] = lines[sourceFoldersListBox.SelectedIndex].Replace(options, "");
                    lines[sourceFoldersListBox.SelectedIndex] += "|" + selectFolderPathTextBox.Text + options;
                    File.WriteAllLines(localApplicationDataPath + "\\data.save", lines);
                }
                addFolderPopup.Visible = false;
                LoadFolders();
            }
            else
            {
                MessageBox.Show("Folder does not Exsit!");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            addFolderPopup.Visible = false;
        }

        private void SelectFolderPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(selectFolderPathTextBox.Text))
            {
                selectFolderPathTextBox.ForeColor = Color.Black;
            }
            else
            {
                selectFolderPathTextBox.ForeColor = Color.Red;
            }
        }

        private void AddFolderPopup_VisibleChanged(object sender, EventArgs e)
        {
            selectFolderPathTextBox.Text = "";
        }

        private void SourceFoldersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            destinationFoldersListBox.Items.Clear();
            if (sourceFoldersListBox.SelectedIndex < destinationFolders.Count && sourceFoldersListBox.SelectedIndex > -1)
            {
                blockWrite = true;
                destinationFoldersListBox.Items.AddRange(destinationFolders[sourceFoldersListBox.SelectedIndex].ToArray());
                backupTimeNumericUpDown.Value = optionsList[sourceFoldersListBox.SelectedIndex][0];
                timeUnitComboBox.SelectedIndex = optionsList[sourceFoldersListBox.SelectedIndex][1];
                maxBackupsNumericUpDown.Value = optionsList[sourceFoldersListBox.SelectedIndex][2];
                blockWrite = false;
            }
        }

        private void OnOffToggleButton_Click(object sender, EventArgs e)
        {
            if (onOffToggleButton.BackColor == Color.Red)
            {
                onOffToggleButton.BackColor = Color.Green;
                onOffToggleButton.BackgroundImage = Properties.Resources.ON;
                mainPanel.Visible = false;
                addFolderPopup.Visible = false;
                statusLabel.Visible = true;
                backup.ON(sourceFolders, destinationFolders, optionsList);
                Registry.SetValue(registrykey, "OnOff", "On");
            }
            else
            {
                onOffToggleButton.BackColor = Color.Red;
                onOffToggleButton.BackgroundImage = Properties.Resources.OFF;
                mainPanel.Visible = true;
                statusLabel.Visible = false;
                backup.OFF();
                Registry.SetValue(registrykey, "OnOff", "Off");
            }
        }

        private void BackupTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (blockWrite) return;
            //Registry.SetValue(registrykey, "backupTime", backupTimeNumericUpDown.Value);
            string[] lines = File.ReadAllLines(localApplicationDataPath + "\\data.save");
            string options = lines[sourceFoldersListBox.SelectedIndex].Substring(lines[sourceFoldersListBox.SelectedIndex].LastIndexOf(">"));
            lines[sourceFoldersListBox.SelectedIndex] = lines[sourceFoldersListBox.SelectedIndex].Replace(options, "");
            lines[sourceFoldersListBox.SelectedIndex] += ">" + backupTimeNumericUpDown.Value + ";" + timeUnitComboBox.SelectedIndex + ";" + maxBackupsNumericUpDown.Value;
            File.WriteAllLines(localApplicationDataPath + "\\data.save", lines);

            optionsList[sourceFoldersListBox.SelectedIndex][0] = (int)backupTimeNumericUpDown.Value;
            optionsList[sourceFoldersListBox.SelectedIndex][1] = timeUnitComboBox.SelectedIndex;
            optionsList[sourceFoldersListBox.SelectedIndex][2] = (int)maxBackupsNumericUpDown.Value;
        }

        private void TimeUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blockWrite) return;
            //Registry.SetValue(registrykey, "timeUnit", timeUnitComboBox.SelectedIndex);
            string[] lines = File.ReadAllLines(localApplicationDataPath + "\\data.save");
            string options = lines[sourceFoldersListBox.SelectedIndex].Substring(lines[sourceFoldersListBox.SelectedIndex].LastIndexOf(">"));
            lines[sourceFoldersListBox.SelectedIndex] = lines[sourceFoldersListBox.SelectedIndex].Replace(options, "");
            lines[sourceFoldersListBox.SelectedIndex] += ">" + backupTimeNumericUpDown.Value + ";" + timeUnitComboBox.SelectedIndex + ";" + maxBackupsNumericUpDown.Value;
            File.WriteAllLines(localApplicationDataPath + "\\data.save", lines);

            optionsList[sourceFoldersListBox.SelectedIndex][0] = (int)backupTimeNumericUpDown.Value;
            optionsList[sourceFoldersListBox.SelectedIndex][1] = timeUnitComboBox.SelectedIndex;
            optionsList[sourceFoldersListBox.SelectedIndex][2] = (int)maxBackupsNumericUpDown.Value;
        }

        private void MaxBackupsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (blockWrite) return;
            //Registry.SetValue(registrykey, "timeUnit", timeUnitComboBox.SelectedIndex);
            string[] lines = File.ReadAllLines(localApplicationDataPath + "\\data.save");
            string options = lines[sourceFoldersListBox.SelectedIndex].Substring(lines[sourceFoldersListBox.SelectedIndex].LastIndexOf(">"));
            lines[sourceFoldersListBox.SelectedIndex] = lines[sourceFoldersListBox.SelectedIndex].Replace(options, "");
            lines[sourceFoldersListBox.SelectedIndex] += ">" + backupTimeNumericUpDown.Value + ";" + timeUnitComboBox.SelectedIndex + ";" + maxBackupsNumericUpDown.Value;
            File.WriteAllLines(localApplicationDataPath + "\\data.save", lines);

            optionsList[sourceFoldersListBox.SelectedIndex][0] = (int)backupTimeNumericUpDown.Value;
            optionsList[sourceFoldersListBox.SelectedIndex][1] = timeUnitComboBox.SelectedIndex;
            optionsList[sourceFoldersListBox.SelectedIndex][2] = (int)maxBackupsNumericUpDown.Value;
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
            backup.windowVisible = true;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            addFolderPopup.Location = new Point(this.Width / 2 - addFolderPopup.Width / 2, this.Height / 2 - addFolderPopup.Height / 2);

            int space = 20;

            sourceFoldersListBox.Height = this.Height - 243;
            sourceFoldersListBox.Width = this.Width / 2 - 13 - space;

            destinationFoldersListBox.Height = this.Height - 243;
            destinationFoldersListBox.Location = new Point(this.Width / 2 - 15 + space, destinationFoldersListBox.Location.Y);
            destinationFoldersListBox.Width = this.Width / 2 - 13 - space;

            addSourceFolderButton.Location = new Point(sourceFoldersListBox.Location.X, sourceFoldersListBox.Height + 25);
            removeSourceFolderButton.Location = new Point(sourceFoldersListBox.Location.X + sourceFoldersListBox.Width - removeSourceFolderButton.Width, sourceFoldersListBox.Height + 25);

            addDestinationFolderButton.Location = new Point(destinationFoldersListBox.Location.X, destinationFoldersListBox.Height + 25);
            removeDestinationFolderButton.Location = new Point(destinationFoldersListBox.Location.X + destinationFoldersListBox.Width - removeDestinationFolderButton.Width, destinationFoldersListBox.Height + 25);

            sourceDirectoriesLabel.Location = new Point(sourceFoldersListBox.Location.X + sourceFoldersListBox.Width / 2 - sourceDirectoriesLabel.Width / 2, sourceDirectoriesLabel.Location.Y);
            destinationDirectoriesLabel.Location = new Point(destinationFoldersListBox.Location.X + destinationFoldersListBox.Width / 2 - destinationDirectoriesLabel.Width / 2, destinationDirectoriesLabel.Location.Y);

            mainPanel.Height = this.Height;

            if (WindowState == FormWindowState.Minimized && ShowInTaskbar == true)
            {
                ShowInTaskbar = false;
                backup.windowVisible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
