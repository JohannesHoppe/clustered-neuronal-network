namespace Clustered_NN.Forms
{
    partial class MasterForm
    {

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblHeading = new System.Windows.Forms.TableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReplaced = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripProject = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inhaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProject = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.hilfeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.timerToolTip = new System.Windows.Forms.Timer(this.components);
            this.balloonToolTipInfo = new Clustered_NN.Classes.BalloonToolTip();
            this.timerBackgroundImageEnabler = new System.Windows.Forms.Timer(this.components);
            this.tblMain.SuspendLayout();
            this.tblHeading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlContentHolder.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStripProject.SuspendLayout();
            this.toolStripProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.Color.Transparent;
            this.balloonToolTipInfo.SetBalloonText(this.tblMain, null);
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblHeading, 0, 0);
            this.tblMain.Controls.Add(this.pnlContentHolder, 0, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(683, 356);
            this.tblMain.TabIndex = 2;
            // 
            // tblHeading
            // 
            this.tblHeading.BackColor = System.Drawing.Color.Transparent;
            this.balloonToolTipInfo.SetBalloonText(this.tblHeading, null);
            this.tblHeading.ColumnCount = 2;
            this.tblHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tblHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHeading.Controls.Add(this.pbxIcon, 0, 0);
            this.tblHeading.Controls.Add(this.lblHeading, 1, 0);
            this.tblHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHeading.Location = new System.Drawing.Point(3, 3);
            this.tblHeading.Name = "tblHeading";
            this.tblHeading.RowCount = 1;
            this.tblHeading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHeading.Size = new System.Drawing.Size(677, 67);
            this.tblHeading.TabIndex = 0;
            // 
            // pbxIcon
            // 
            this.balloonToolTipInfo.SetBalloonText(this.pbxIcon, null);
            this.pbxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbxIcon.Image")));
            this.pbxIcon.Location = new System.Drawing.Point(20, 5);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(49, 58);
            this.pbxIcon.TabIndex = 5;
            this.pbxIcon.TabStop = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.balloonToolTipInfo.SetBalloonText(this.lblHeading, null);
            this.lblHeading.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Gray;
            this.lblHeading.Location = new System.Drawing.Point(85, 25);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(10, 25, 3, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(179, 23);
            this.lblHeading.TabIndex = 4;
            this.lblHeading.Text = "Master Heading";
            // 
            // pnlContentHolder
            // 
            this.pnlContentHolder.BackColor = System.Drawing.Color.Transparent;
            this.balloonToolTipInfo.SetBalloonText(this.pnlContentHolder, null);
            this.pnlContentHolder.Controls.Add(this.label1);
            this.pnlContentHolder.Controls.Add(this.lblReplaced);
            this.pnlContentHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentHolder.Location = new System.Drawing.Point(3, 76);
            this.pnlContentHolder.Name = "pnlContentHolder";
            this.pnlContentHolder.Size = new System.Drawing.Size(677, 277);
            this.pnlContentHolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.balloonToolTipInfo.SetBalloonText(this.label1, null);
            this.label1.Location = new System.Drawing.Point(96, 100);
            this.label1.MaximumSize = new System.Drawing.Size(500, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 91);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lblReplaced
            // 
            this.lblReplaced.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblReplaced.AutoSize = true;
            this.balloonToolTipInfo.SetBalloonText(this.lblReplaced, null);
            this.lblReplaced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaced.Location = new System.Drawing.Point(206, 30);
            this.lblReplaced.Name = "lblReplaced";
            this.lblReplaced.Size = new System.Drawing.Size(235, 13);
            this.lblReplaced.TabIndex = 2;
            this.lblReplaced.Text = "All panel contents will be replaced here!";
            // 
            // toolStripContainer1
            // 
            this.balloonToolTipInfo.SetBalloonText(this.toolStripContainer1, null);
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.balloonToolTipInfo.SetBalloonText(this.toolStripContainer1.BottomToolStripPanel, null);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripContainer1.ContentPanel.BackgroundImage")));
            this.toolStripContainer1.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.balloonToolTipInfo.SetBalloonText(this.toolStripContainer1.ContentPanel, null);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tblMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(683, 356);
            this.toolStripContainer1.ContentPanel.Resize += new System.EventHandler(this.toolStripContainer1_ContentPanel_Resize);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.balloonToolTipInfo.SetBalloonText(this.toolStripContainer1.LeftToolStripPanel, null);
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.balloonToolTipInfo.SetBalloonText(this.toolStripContainer1.RightToolStripPanel, null);
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(683, 427);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.balloonToolTipInfo.SetBalloonText(this.toolStripContainer1.TopToolStripPanel, null);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStripProject);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripProject);
            // 
            // statusStrip
            // 
            this.balloonToolTipInfo.SetBalloonText(this.statusStrip, null);
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(683, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // menuStripProject
            // 
            this.balloonToolTipInfo.SetBalloonText(this.menuStripProject, null);
            this.menuStripProject.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStripProject.Location = new System.Drawing.Point(0, 0);
            this.menuStripProject.Name = "menuStripProject";
            this.menuStripProject.Size = new System.Drawing.Size(683, 24);
            this.menuStripProject.TabIndex = 0;
            this.menuStripProject.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(163, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inhaltToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.suchenToolStripMenuItem,
            this.toolStripSeparator5,
            this.infoToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            // 
            // inhaltToolStripMenuItem
            // 
            this.inhaltToolStripMenuItem.Name = "inhaltToolStripMenuItem";
            this.inhaltToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.inhaltToolStripMenuItem.Text = "I&nhalt";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // suchenToolStripMenuItem
            // 
            this.suchenToolStripMenuItem.Name = "suchenToolStripMenuItem";
            this.suchenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.suchenToolStripMenuItem.Text = "&Suchen";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(117, 6);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.infoToolStripMenuItem.Text = "Inf&o...";
            // 
            // toolStripProject
            // 
            this.balloonToolTipInfo.SetBalloonText(this.toolStripProject, null);
            this.toolStripProject.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator7,
            this.hilfeToolStripButton});
            this.toolStripProject.Location = new System.Drawing.Point(3, 24);
            this.toolStripProject.Name = "toolStripProject";
            this.toolStripProject.Size = new System.Drawing.Size(108, 25);
            this.toolStripProject.TabIndex = 1;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // hilfeToolStripButton
            // 
            this.hilfeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hilfeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("hilfeToolStripButton.Image")));
            this.hilfeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hilfeToolStripButton.Name = "hilfeToolStripButton";
            this.hilfeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.hilfeToolStripButton.Text = "Hi&lfe";
            // 
            // timerToolTip
            // 
            this.timerToolTip.Tick += new System.EventHandler(this.timerToolTip_Tick);
            // 
            // balloonToolTipInfo
            // 
            this.balloonToolTipInfo.BackColor = System.Drawing.Color.White;
            this.balloonToolTipInfo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.balloonToolTipInfo.MaximumWidth = 450;
            this.balloonToolTipInfo.Title = "";
            // 
            // timerBackgroundImageEnabler
            // 
            this.timerBackgroundImageEnabler.Interval = 1000;
            this.timerBackgroundImageEnabler.Tick += new System.EventHandler(this.timerBackgroundImageEnabler_Tick);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 427);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStripProject;
            this.Name = "MasterForm";
            this.Text = "MasterFormContents";
            this.tblMain.ResumeLayout(false);
            this.tblHeading.ResumeLayout(false);
            this.tblHeading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlContentHolder.ResumeLayout(false);
            this.pnlContentHolder.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStripProject.ResumeLayout(false);
            this.menuStripProject.PerformLayout();
            this.toolStripProject.ResumeLayout(false);
            this.toolStripProject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        internal System.Windows.Forms.TableLayoutPanel tblMain;
        internal System.Windows.Forms.TableLayoutPanel tblHeading;
        internal System.Windows.Forms.Label lblHeading;
        internal System.Windows.Forms.ToolStripContainer toolStripContainer1;
        internal System.Windows.Forms.MenuStrip menuStripProject;

        internal System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        internal System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        
        internal System.Windows.Forms.PictureBox pbxIcon;
        internal System.Windows.Forms.Label lblReplaced;
        internal System.Windows.Forms.StatusStrip statusStrip;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.Panel pnlContentHolder;
        internal System.Windows.Forms.Timer timerToolTip;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label1;
        internal Clustered_NN.Classes.BalloonToolTip balloonToolTipInfo;
        internal System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem inhaltToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem suchenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        internal System.Windows.Forms.ToolStrip toolStripProject;
        internal System.Windows.Forms.ToolStripButton newToolStripButton;
        internal System.Windows.Forms.ToolStripButton openToolStripButton;
        internal System.Windows.Forms.ToolStripButton saveToolStripButton;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        internal System.Windows.Forms.ToolStripButton hilfeToolStripButton;
        private System.Windows.Forms.Timer timerBackgroundImageEnabler;
    }
}