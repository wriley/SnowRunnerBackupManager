using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Zip;
using System.Globalization;
using System.Linq;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SnowRunnerBackupManager
{
    public partial class frmMain : Form
    {
        public string backupFolder;
        private string saveGamePath;
        private string saveGamePathRoot;
        private string timestampString = "yyyyMMdd-HHmmss";
        private string accountId;
        private List<TreeNode> unselectableSaveNodes = new List<TreeNode>();
        private List<TreeNode> unselectableBackupNodes = new List<TreeNode>();
        private List<SnowRunnerSaveGame> mySaveGames = new List<SnowRunnerSaveGame>();
        private List<SnowRunnerSaveGame> backupSaveGames = new List<SnowRunnerSaveGame>();

        private struct SnowRunnerSaveGame
        {
            public string backupName;
            public DateTime saveDate;
            public string rank;
            public string experience;
            public string money;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();

            if (!Directory.Exists(backupFolder))
            {
                MessageBox.Show("You need to set your options");
                frmOptions frmOptions = new frmOptions(this);
                frmOptions.Show(this);
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DebugLog("Found My Documents path: " + path);
            // C:\Users\Computer User\Documents\My Games\SnowRunner\base\storage\cfe0fa55393049d0b040dc143ae99585
            saveGamePathRoot = path + Path.DirectorySeparatorChar + "My Games" + Path.DirectorySeparatorChar + 
                "SnowRunner" + Path.DirectorySeparatorChar + "base" + Path.DirectorySeparatorChar + "storage";
            const string keyName = "HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Identifiers";
            accountId = (string) Registry.GetValue(keyName, "AccountId", "NONE");

            if (accountId == "NONE")
            {
                DebugLog("Error: accountId not found in registry, is SnowRunner installed?");
            }
            else
            {
                saveGamePath = saveGamePathRoot + Path.DirectorySeparatorChar + accountId;
                RefreshLists();
            }
        }

        private void LoadSettings()
        {
            backupFolder = Properties.Settings.Default.backupFolder;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.backupFolder = backupFolder;
            Properties.Settings.Default.Save();
            saveGamePath = saveGamePathRoot;
            GetBackupFiles();
            RefreshLists();
        }

        private void DebugLog(string msg)
        {
            textBoxDebug.AppendText(msg + "\r\n");
        }

        private string GetStringFromJObject(JObject jObject, string tokenPath)
        {
            JToken jToken = jObject.SelectToken(tokenPath);
            return jToken.ToString();
        }

        private void GetSaveGameInfo()
        {
            if(!Directory.Exists(saveGamePath))
            {
                DebugLog("Save game path not found, check options!");
                return;
            }

            SnowRunnerSaveGame saveGame = new SnowRunnerSaveGame();

            string jsonFile = saveGamePath + Path.DirectorySeparatorChar + "CompleteSave.dat";
            if(File.Exists(jsonFile))
            {
                using (StreamReader file = File.OpenText(jsonFile))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject saveGameData = (JObject)JToken.ReadFrom(reader);

                        labelSaveDate.Text = File.GetLastWriteTime(jsonFile).ToString("MM/dd/yyyy hh:mm tt");
                        labelRank.Text = GetStringFromJObject(saveGameData, "CompleteSave.SslValue.persistentProfileData.rank");
                        labelExperience.Text = GetStringFromJObject(saveGameData, "CompleteSave.SslValue.persistentProfileData.experience");
                        labelMoney.Text = String.Format("{0:n0}", Int32.Parse(GetStringFromJObject(saveGameData, "CompleteSave.SslValue.persistentProfileData.money")));
                    }

                }
            }

            DateTime latest = GetLatestZipDate();
            if (latest.CompareTo(saveGame.saveDate) >= 0)
            {
                labelSaveDateLabel.ForeColor = System.Drawing.Color.Green;
                labelSaveDate.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labelSaveDateLabel.ForeColor = new System.Drawing.Color();
                labelSaveDate.ForeColor = new System.Drawing.Color();
            }
        }

        private void GetBackupFiles()
        {
            if (!Directory.Exists(backupFolder))
            {
                DebugLog("Backup folder not found, check options!");
                return;
            }
            string[] backupFiles = Directory.GetFiles(backupFolder);
            backupSaveGames = new List<SnowRunnerSaveGame>();
            Regex r = new Regex(@"^SnowRunner_[0-9]{8}-[0-9]{6}.zip$");
            Match m;
            foreach (string backupFile in backupFiles)
            {
                if (File.Exists(backupFile))
                {
                    string fileName = new FileInfo(backupFile).Name;
                    m = r.Match(fileName);
                    if (m.Success && m.Groups[1].Value != null)
                    {
                        DebugLog("Getting info from zip " + fileName);
                        using (ZipInputStream s = new ZipInputStream(File.OpenRead(backupFile)))
                        {
                            ZipEntry theEntry;
                            while ((theEntry = s.GetNextEntry()) != null)
                            {
                                if (theEntry.Name == "CompleteSave.dat")
                                {
                                    StreamReader sReader = new StreamReader(s);
                                    JsonTextReader reader = new JsonTextReader(sReader);
                                    JObject saveGameData = (JObject)JToken.ReadFrom(reader);

                                    SnowRunnerSaveGame save = new SnowRunnerSaveGame();
                                    save.backupName = fileName;
                                    save.saveDate = File.GetCreationTime(backupFile);
                                    save.rank = GetStringFromJObject(saveGameData, "CompleteSave.SslValue.persistentProfileData.rank");
                                    save.experience = GetStringFromJObject(saveGameData, "CompleteSave.SslValue.persistentProfileData.experience");
                                    save.money = String.Format("{0:n0}", Int32.Parse(GetStringFromJObject(saveGameData, "CompleteSave.SslValue.persistentProfileData.money")));
                                    backupSaveGames.Add(save);
                                   
                                }
                            }
                            s.Close();
                        }
                    }
                }
            }
            backupSaveGames = backupSaveGames.OrderBy(sel => sel.saveDate.ToString(), new OrdinalStringComparer()).ToList();
            treeViewBackups.BeginUpdate();
            treeViewBackups.Nodes.Clear();
            unselectableBackupNodes.Clear();
            for (int i = 0; i < backupSaveGames.Count; i++)
            {
                TreeNode newParentNode = treeViewBackups.Nodes.Add(String.Format("{0}", backupSaveGames[i].backupName));

                TreeNode newChildNode = newParentNode.Nodes.Add(String.Format("Rank: {0}", backupSaveGames[i].rank));
                unselectableBackupNodes.Add(newChildNode);
                newChildNode = newParentNode.Nodes.Add(String.Format("Money: {0:n0}", backupSaveGames[i].money));
                unselectableBackupNodes.Add(newChildNode);
                newChildNode = newParentNode.Nodes.Add(String.Format("Experience: {0:n0}", backupSaveGames[i].experience));
                unselectableBackupNodes.Add(newChildNode);
            }
            treeViewBackups.EndUpdate();
        }

        private DateTime GetLatestZipDate()
        {
            DateTime latest = DateTime.MinValue;
            DateTime lastDate = DateTime.MinValue;
            for (int i = 0; i < backupSaveGames.Count; i++)
            {
                Regex r = new Regex(@"^SnowRunner_([0-9]{8}-[0-9]{6}).zip$");
                Match m = r.Match("");
                if (m.Success)
                {
                    DateTime zipDate = new DateTime();
                    DateTime.TryParseExact(m.Groups[2].Value, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out zipDate);
                    if (zipDate != DateTime.MinValue && zipDate.CompareTo(lastDate) == 1)
                    {
                        latest = zipDate;
                    }
                }
            }
            return latest;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            textBoxDebug.SelectionStart = textBoxDebug.Text.Length;
            textBoxDebug.ScrollToCaret();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions frmOptions = new frmOptions(this);
            frmOptions.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog(this);
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(backupFolder))
            {
                DebugLog("Backup folder not found, check options!");
                return;
            }
            
            showUI(false);
            SaveGame();
            showUI(true);
            RefreshLists();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(saveGamePath))
            {
                DebugLog("Save game path not found, check options!");
                return;
            }
            if (treeViewBackups.SelectedNode != null)
            {
                string backupName = treeViewBackups.SelectedNode.Text;
                showUI(false);
                RestoreGame(backupName);
                showUI(true);
                RefreshLists();
            }
            else
            {
                DebugLog("No backup file selected to restore!");
            }
        }

        private void SaveGame()
        {
            DebugLog("Saving game");
            if (Directory.Exists(saveGamePath))
            {
                string dateString = DateTime.Now.ToString(timestampString);
                string zipFilePath = backupFolder + Path.DirectorySeparatorChar + "SnowRunner_" + dateString + ".zip";
                DebugLog("zipping to " + zipFilePath);
                ZipFolder(saveGamePath, zipFilePath);
                GetBackupFiles();
                DebugLog("SaveGame complete");
            }
            else
            {
                DebugLog("Error: Directory not found " + saveGamePath);
            }
        }

        private void ZipFolder(string sourceDir, string zipFile)
        {
            try
            {
                string[] filenames = Directory.GetFiles(sourceDir);

                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFile)))
                {
                    s.SetLevel(3);
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        var entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                DebugLog("Exception during zip file creation: " + ex.Message);
            }
        }

        private void UnzipFile(string zipFile, string targetDir)
        {
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);

                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(Path.Combine(targetDir, directoryName));
                        }

                        if (fileName != string.Empty)
                        {
                            var filePath = Path.Combine(targetDir, fileName);
                            using (FileStream streamWriter = File.Create(filePath))
                            {
                                int size = 2048;
                                byte[] data = new byte[size];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLog("Exception while unzipping file: " + ex.Message);
            }
        }

        private void RestoreGame(string backupName)
        {
            DebugLog("Restoring game " + backupName);
            string dirNameFull = new FileInfo(backupName).Name;
            Regex r = new Regex(@"^SnowRunner_[0-9]{8}-[0-9]{6}.zip$");
            Match m = r.Match(dirNameFull);
            DebugLog("dirNameFull " + dirNameFull);
            if (m.Success)
            {
                string zipFilePath = backupFolder + Path.DirectorySeparatorChar + backupName;
                DebugLog("Unzipping from " + zipFilePath);
                UnzipFile(zipFilePath, saveGamePath);
                GetSaveGameInfo();
                DebugLog("RestoreGame complete");
            }
        }

        private void buttonRemoveBackup_Click(object sender, EventArgs e)
        {
            if (treeViewBackups.SelectedNode != null)
            {
                string backupName = treeViewBackups.SelectedNode.Text;
                string zipFilePath = backupFolder + Path.DirectorySeparatorChar + backupName;
                if (File.Exists(zipFilePath))
                {
                    DialogResult result = MessageBox.Show("Remove backup file " + backupName + "?", "Remove backup?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(zipFilePath);
                        GetBackupFiles();
                        DebugLog("RemoveBackup complete");
                    }
                }
            }
            else
            {
                DebugLog("No backup selected to remove!");
            }
        }

        private void treeViewSavegames_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (unselectableSaveNodes.Contains(e.Node))
            {
                e.Cancel = true;
            }
        }

        private void treeViewBackups_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (unselectableBackupNodes.Contains(e.Node))
            {
                e.Cancel = true;
            }
        }

        private void showUI(bool show)
        {
            treeViewBackups.Enabled = show;
            buttonBackup.Enabled = show;
            buttonRestore.Enabled = show;
            buttonRemoveBackup.Enabled = show;
            buttonOpenBackupLocation.Enabled = show;
            buttonRefresh.Enabled = show;
        }

        // https://www.codeproject.com/Questions/852563/How-to-open-file-explorer-at-given-location-in-csh
        private void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");
                startInfo.Arguments = folderPath;

                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            }
        }

        private void buttonOpenBackupLocation_Click(object sender, EventArgs e)
        {
            OpenFolder(backupFolder);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void RefreshLists()
        {
            showUI(false);
            GetBackupFiles();
            GetSaveGameInfo();
            showUI(true);
        }
    }

    // https://code.msdn.microsoft.com/windowsdesktop/Ordinal-String-Sorting-1cbac582
    public class OrdinalStringComparer : IComparer<string>
    {
        private bool _ignoreCase = true;

        /// <summary>
        /// Creates an instance of <c>OrdinalStringComparer</c> for case-insensitive string comparison.
        /// </summary>
        public OrdinalStringComparer()
            : this(true)
        {
        }

        /// <summary>
        /// Creates an instance of <c>OrdinalStringComparer</c> for case comparison according to the value specified in input.
        /// </summary>
        /// <param name="ignoreCase">true to ignore case during the comparison; otherwise, false.</param>
        public OrdinalStringComparer(bool ignoreCase)
        {
            _ignoreCase = ignoreCase;
        }

        /// <summary>
        /// Compares two strings and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first string to compare.</param>
        /// <param name="y">The second string to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x and y, as in the Compare method in the <c>IComparer&lt;T&gt;</c> interface.</returns>
        public int Compare(string x, string y)
        {
            // check for null values first: a null reference is considered to be less than any reference that is not null
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            StringComparison comparisonMode = _ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;

            string[] splitX = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
            string[] splitY = Regex.Split(y.Replace(" ", ""), "([0-9]+)");

            int comparer = 0;

            for (int i = 0; comparer == 0 && i < splitX.Length; i++)
            {
                if (splitY.Length <= i)
                {
                    comparer = 1; // x > y
                }

                int numericX = -1;
                int numericY = -1;
                if (int.TryParse(splitX[i], out numericX))
                {
                    if (int.TryParse(splitY[i], out numericY))
                    {
                        comparer = numericX - numericY;
                    }
                    else
                    {
                        comparer = 1; // x > y
                    }
                }
                else
                {
                    comparer = String.Compare(splitX[i], splitY[i], comparisonMode);
                }
            }

            return comparer;
        }
    }
}