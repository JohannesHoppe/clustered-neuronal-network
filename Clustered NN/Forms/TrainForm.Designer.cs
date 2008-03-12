namespace Clustered_NN.Forms
{
    partial class TrainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainForm));
            this.lblTooltip = new System.Windows.Forms.Label();
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTrainStart = new System.Windows.Forms.Label();
            this.lblTrainInfo = new System.Windows.Forms.Label();
            this.pbTrain = new System.Windows.Forms.ProgressBar();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmdTrain = new System.Windows.Forms.Button();
            this.txtTrainTimes = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tblNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.gbNetworkStatus = new System.Windows.Forms.GroupBox();
            this.lblNetworkStatus = new System.Windows.Forms.Label();
            this.pnlContentHolder.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tblNavigation.SuspendLayout();
            this.gbNetworkStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTooltip.Location = new System.Drawing.Point(12, 9);
            this.lblTooltip.MaximumSize = new System.Drawing.Size(600, 60);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(412, 28);
            this.lblTooltip.TabIndex = 4;
            this.lblTooltip.Text = "The collected images are now used to train a Backward Propagation Neural Network." +
                "\r\nPlease stay tuned!";
            // 
            // pnlContentHolder
            // 
            this.pnlContentHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContentHolder.Controls.Add(this.tableLayoutPanel1);
            this.pnlContentHolder.Location = new System.Drawing.Point(12, 65);
            this.pnlContentHolder.Name = "pnlContentHolder";
            this.pnlContentHolder.Size = new System.Drawing.Size(576, 409);
            this.pnlContentHolder.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbTrain, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlControl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdCancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tblNavigation, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.gbNetworkStatus, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.19178F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.05479F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.98901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.109589F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.68493F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(574, 407);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTrainStart);
            this.panel1.Controls.Add(this.lblTrainInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(89, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 106);
            this.panel1.TabIndex = 19;
            // 
            // lblTrainStart
            // 
            this.lblTrainStart.Location = new System.Drawing.Point(3, 3);
            this.lblTrainStart.Name = "lblTrainStart";
            this.lblTrainStart.Size = new System.Drawing.Size(218, 17);
            this.lblTrainStart.TabIndex = 18;
            this.lblTrainStart.Text = "Training not started";
            // 
            // lblTrainInfo
            // 
            this.lblTrainInfo.AutoSize = true;
            this.lblTrainInfo.Location = new System.Drawing.Point(3, 26);
            this.lblTrainInfo.Name = "lblTrainInfo";
            this.lblTrainInfo.Size = new System.Drawing.Size(252, 13);
            this.lblTrainInfo.TabIndex = 1;
            this.lblTrainInfo.Text = "Please click on \"Start Training\" to train the network!";
            this.lblTrainInfo.TextChanged += new System.EventHandler(this.lblTrainInfo_TextChanged);
            // 
            // pbTrain
            // 
            this.pbTrain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbTrain.BackColor = System.Drawing.Color.LightGray;
            this.pbTrain.Location = new System.Drawing.Point(89, 207);
            this.pbTrain.Name = "pbTrain";
            this.pbTrain.Size = new System.Drawing.Size(395, 21);
            this.pbTrain.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlControl.Controls.Add(this.Label2);
            this.pnlControl.Controls.Add(this.cmdTrain);
            this.pnlControl.Controls.Add(this.txtTrainTimes);
            this.pnlControl.Location = new System.Drawing.Point(159, 163);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(254, 32);
            this.pnlControl.TabIndex = 16;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(205, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 18);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Times";
            // 
            // cmdTrain
            // 
            this.cmdTrain.BackColor = System.Drawing.Color.LightGray;
            this.cmdTrain.Location = new System.Drawing.Point(42, 3);
            this.cmdTrain.Name = "cmdTrain";
            this.cmdTrain.Size = new System.Drawing.Size(100, 24);
            this.cmdTrain.TabIndex = 13;
            this.cmdTrain.Text = "Start Training";
            this.cmdTrain.UseVisualStyleBackColor = false;
            this.cmdTrain.Click += new System.EventHandler(this.cmdTrain_Click);
            // 
            // txtTrainTimes
            // 
            this.txtTrainTimes.Location = new System.Drawing.Point(148, 6);
            this.txtTrainTimes.Name = "txtTrainTimes";
            this.txtTrainTimes.Size = new System.Drawing.Size(51, 20);
            this.txtTrainTimes.TabIndex = 14;
            this.txtTrainTimes.Text = "1000";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdCancel.BackColor = System.Drawing.Color.LightGray;
            this.cmdCancel.Enabled = false;
            this.cmdCancel.Location = new System.Drawing.Point(490, 206);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(51, 24);
            this.cmdCancel.TabIndex = 17;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(490, 170);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(79, 25);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&Neu";
            this.newToolStripButton.ToolTipText = "Reset Network";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Ö&ffnen";
            this.openToolStripButton.ToolTipText = "Open Network File";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Speichern";
            this.saveToolStripButton.ToolTipText = "Save Network to File";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // tblNavigation
            // 
            this.tblNavigation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tblNavigation.ColumnCount = 2;
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.Controls.Add(this.btnNext, 1, 0);
            this.tblNavigation.Controls.Add(this.btnPrev, 0, 0);
            this.tblNavigation.Location = new System.Drawing.Point(167, 369);
            this.tblNavigation.Name = "tblNavigation";
            this.tblNavigation.RowCount = 1;
            this.tblNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblNavigation.Size = new System.Drawing.Size(238, 34);
            this.tblNavigation.TabIndex = 21;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.BackColor = System.Drawing.Color.LightGray;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(128, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnNext.Size = new System.Drawing.Size(100, 24);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next Step";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrev.BackColor = System.Drawing.Color.LightGray;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(9, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrev.Size = new System.Drawing.Size(100, 24);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Prev Step";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // gbNetworkStatus
            // 
            this.gbNetworkStatus.AutoSize = true;
            this.gbNetworkStatus.Controls.Add(this.lblNetworkStatus);
            this.gbNetworkStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.gbNetworkStatus.Location = new System.Drawing.Point(98, 3);
            this.gbNetworkStatus.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.gbNetworkStatus.Name = "gbNetworkStatus";
            this.gbNetworkStatus.Padding = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.gbNetworkStatus.Size = new System.Drawing.Size(113, 46);
            this.gbNetworkStatus.TabIndex = 23;
            this.gbNetworkStatus.TabStop = false;
            this.gbNetworkStatus.Text = "Network Status";
            // 
            // lblNetworkStatus
            // 
            this.lblNetworkStatus.AutoSize = true;
            this.lblNetworkStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.lblNetworkStatus.Location = new System.Drawing.Point(6, 20);
            this.lblNetworkStatus.Name = "lblNetworkStatus";
            this.lblNetworkStatus.Size = new System.Drawing.Size(101, 13);
            this.lblNetworkStatus.TabIndex = 1;
            this.lblNetworkStatus.Text = "... NetworkStatus ...";
            // 
            // TrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 486);
            this.Controls.Add(this.pnlContentHolder);
            this.Controls.Add(this.lblTooltip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2. Train the Neuronal Network";
            this.Load += new System.EventHandler(this.TrainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrainForm_FormClosed);
            this.pnlContentHolder.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tblNavigation.ResumeLayout(false);
            this.gbNetworkStatus.ResumeLayout(false);
            this.gbNetworkStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.Panel pnlContentHolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar pbTrain;
        private System.Windows.Forms.Label lblTrainInfo;
        private System.Windows.Forms.Panel pnlControl;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button cmdTrain;
        internal System.Windows.Forms.TextBox txtTrainTimes;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Label lblTrainStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.TableLayoutPanel tblNavigation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblNetworkStatus;
        private System.Windows.Forms.GroupBox gbNetworkStatus;

    }
}