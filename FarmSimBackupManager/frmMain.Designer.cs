namespace SnowRunnerBackupManager
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewBackups = new System.Windows.Forms.TreeView();
            this.labelBackups = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSaveGames = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonRemoveBackup = new System.Windows.Forms.Button();
            this.buttonOpenBackupLocation = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelExperience = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.labelRank = new System.Windows.Forms.Label();
            this.labelSaveDate = new System.Windows.Forms.Label();
            this.labelExperienceLabel = new System.Windows.Forms.Label();
            this.labelMoneyLabel = new System.Windows.Forms.Label();
            this.labelRankLabel = new System.Windows.Forms.Label();
            this.labelSaveDateLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(12, 423);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ReadOnly = true;
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDebug.Size = new System.Drawing.Size(900, 124);
            this.textBoxDebug.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // treeViewBackups
            // 
            this.treeViewBackups.Location = new System.Drawing.Point(498, 32);
            this.treeViewBackups.Name = "treeViewBackups";
            this.treeViewBackups.Size = new System.Drawing.Size(399, 355);
            this.treeViewBackups.TabIndex = 0;
            this.treeViewBackups.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewBackups_BeforeSelect);
            // 
            // labelBackups
            // 
            this.labelBackups.AutoSize = true;
            this.labelBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackups.Location = new System.Drawing.Point(498, 0);
            this.labelBackups.Name = "labelBackups";
            this.labelBackups.Size = new System.Drawing.Size(56, 13);
            this.labelBackups.TabIndex = 2;
            this.labelBackups.Text = "Backups";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.labelSaveGames, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBackups, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeViewBackups, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRefresh, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.30769F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 390);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelSaveGames
            // 
            this.labelSaveGames.AutoSize = true;
            this.labelSaveGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaveGames.Location = new System.Drawing.Point(3, 0);
            this.labelSaveGames.Name = "labelSaveGames";
            this.labelSaveGames.Size = new System.Drawing.Size(117, 13);
            this.labelSaveGames.TabIndex = 1;
            this.labelSaveGames.Text = "Current Save Game";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonBackup);
            this.flowLayoutPanel1.Controls.Add(this.buttonRestore);
            this.flowLayoutPanel1.Controls.Add(this.buttonRemoveBackup);
            this.flowLayoutPanel1.Controls.Add(this.buttonOpenBackupLocation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(408, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 355);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(3, 3);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 23);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "Backup >>";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(3, 32);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 1;
            this.buttonRestore.Text = "<< Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonRemoveBackup
            // 
            this.buttonRemoveBackup.ForeColor = System.Drawing.Color.Red;
            this.buttonRemoveBackup.Location = new System.Drawing.Point(3, 61);
            this.buttonRemoveBackup.Name = "buttonRemoveBackup";
            this.buttonRemoveBackup.Size = new System.Drawing.Size(75, 38);
            this.buttonRemoveBackup.TabIndex = 2;
            this.buttonRemoveBackup.Text = "Remove Backup";
            this.buttonRemoveBackup.UseVisualStyleBackColor = true;
            this.buttonRemoveBackup.Click += new System.EventHandler(this.buttonRemoveBackup_Click);
            // 
            // buttonOpenBackupLocation
            // 
            this.buttonOpenBackupLocation.Location = new System.Drawing.Point(3, 105);
            this.buttonOpenBackupLocation.Name = "buttonOpenBackupLocation";
            this.buttonOpenBackupLocation.Size = new System.Drawing.Size(75, 49);
            this.buttonOpenBackupLocation.TabIndex = 3;
            this.buttonOpenBackupLocation.Text = "Open Backup Folder";
            this.buttonOpenBackupLocation.UseVisualStyleBackColor = true;
            this.buttonOpenBackupLocation.Click += new System.EventHandler(this.buttonOpenBackupLocation_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(408, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelExperience);
            this.panel1.Controls.Add(this.labelMoney);
            this.panel1.Controls.Add(this.labelRank);
            this.panel1.Controls.Add(this.labelSaveDate);
            this.panel1.Controls.Add(this.labelExperienceLabel);
            this.panel1.Controls.Add(this.labelMoneyLabel);
            this.panel1.Controls.Add(this.labelRankLabel);
            this.panel1.Controls.Add(this.labelSaveDateLabel);
            this.panel1.Location = new System.Drawing.Point(3, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 355);
            this.panel1.TabIndex = 5;
            // 
            // labelExperience
            // 
            this.labelExperience.Location = new System.Drawing.Point(79, 46);
            this.labelExperience.Name = "labelExperience";
            this.labelExperience.Size = new System.Drawing.Size(140, 15);
            this.labelExperience.TabIndex = 7;
            this.labelExperience.Text = "----";
            this.labelExperience.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoney
            // 
            this.labelMoney.Location = new System.Drawing.Point(79, 32);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(140, 15);
            this.labelMoney.TabIndex = 6;
            this.labelMoney.Text = "----";
            this.labelMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRank
            // 
            this.labelRank.Location = new System.Drawing.Point(79, 18);
            this.labelRank.Name = "labelRank";
            this.labelRank.Size = new System.Drawing.Size(140, 15);
            this.labelRank.TabIndex = 5;
            this.labelRank.Text = "----";
            this.labelRank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSaveDate
            // 
            this.labelSaveDate.Location = new System.Drawing.Point(79, 3);
            this.labelSaveDate.Name = "labelSaveDate";
            this.labelSaveDate.Size = new System.Drawing.Size(140, 15);
            this.labelSaveDate.TabIndex = 4;
            this.labelSaveDate.Text = "----";
            this.labelSaveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExperienceLabel
            // 
            this.labelExperienceLabel.Location = new System.Drawing.Point(3, 48);
            this.labelExperienceLabel.Name = "labelExperienceLabel";
            this.labelExperienceLabel.Size = new System.Drawing.Size(70, 13);
            this.labelExperienceLabel.TabIndex = 3;
            this.labelExperienceLabel.Text = "Experience:";
            this.labelExperienceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMoneyLabel
            // 
            this.labelMoneyLabel.Location = new System.Drawing.Point(3, 33);
            this.labelMoneyLabel.Name = "labelMoneyLabel";
            this.labelMoneyLabel.Size = new System.Drawing.Size(70, 15);
            this.labelMoneyLabel.TabIndex = 2;
            this.labelMoneyLabel.Text = "Money:";
            this.labelMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRankLabel
            // 
            this.labelRankLabel.Location = new System.Drawing.Point(3, 18);
            this.labelRankLabel.Name = "labelRankLabel";
            this.labelRankLabel.Size = new System.Drawing.Size(70, 15);
            this.labelRankLabel.TabIndex = 1;
            this.labelRankLabel.Text = "Rank:";
            this.labelRankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSaveDateLabel
            // 
            this.labelSaveDateLabel.Location = new System.Drawing.Point(3, 3);
            this.labelSaveDateLabel.Name = "labelSaveDateLabel";
            this.labelSaveDateLabel.Size = new System.Drawing.Size(70, 15);
            this.labelSaveDateLabel.TabIndex = 0;
            this.labelSaveDateLabel.Text = "Last Played:";
            this.labelSaveDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "SnowRunnerBackupManager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewBackups;
        private System.Windows.Forms.Label labelBackups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button buttonRemoveBackup;
        private System.Windows.Forms.Button buttonOpenBackupLocation;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelSaveGames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelExperience;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Label labelRank;
        private System.Windows.Forms.Label labelSaveDate;
        private System.Windows.Forms.Label labelExperienceLabel;
        private System.Windows.Forms.Label labelMoneyLabel;
        private System.Windows.Forms.Label labelRankLabel;
        private System.Windows.Forms.Label labelSaveDateLabel;
    }
}

