namespace Clustered_NN.Forms
{
    partial class CollectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectForm));
            this.lblTooltip = new System.Windows.Forms.Label();
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.gbTrainingQueue = new System.Windows.Forms.GroupBox();
            this.tblTrainingQueue = new System.Windows.Forms.TableLayoutPanel();
            this.lvMatching = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lvNotMatching = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.chkMatching = new System.Windows.Forms.CheckBox();
            this.chkNotMatching = new System.Windows.Forms.CheckBox();
            this.toolStripMatching = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton_Matching = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton_Matching = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton_Matching = new System.Windows.Forms.ToolStripButton();
            this.toolStripNotMatching = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton_NotMatching = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton_NotMatching = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton_NotMatching = new System.Windows.Forms.ToolStripButton();
            this.gbImageProvider = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDeviceControl = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbImageProvider = new System.Windows.Forms.ComboBox();
            this.pictureBox = new Clustered_NN.Classes.SelectingPictureBox.ImageSelectingPictureBox();
            this.tblNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlContentHolder.SuspendLayout();
            this.tblContent.SuspendLayout();
            this.gbTrainingQueue.SuspendLayout();
            this.tblTrainingQueue.SuspendLayout();
            this.toolStripMatching.SuspendLayout();
            this.toolStripNotMatching.SuspendLayout();
            this.gbImageProvider.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tblNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTooltip.Location = new System.Drawing.Point(13, 15);
            this.lblTooltip.MaximumSize = new System.Drawing.Size(670, 60);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(666, 41);
            this.lblTooltip.TabIndex = 3;
            this.lblTooltip.Text = resources.GetString("lblTooltip.Text");
            // 
            // pnlContentHolder
            // 
            this.pnlContentHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContentHolder.Controls.Add(this.tblContent);
            this.pnlContentHolder.Location = new System.Drawing.Point(13, 73);
            this.pnlContentHolder.Name = "pnlContentHolder";
            this.pnlContentHolder.Size = new System.Drawing.Size(666, 668);
            this.pnlContentHolder.TabIndex = 2;
            // 
            // tblContent
            // 
            this.tblContent.ColumnCount = 1;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.Controls.Add(this.gbTrainingQueue, 0, 1);
            this.tblContent.Controls.Add(this.gbImageProvider, 0, 0);
            this.tblContent.Controls.Add(this.tblNavigation, 0, 2);
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(0, 0);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 3;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblContent.Size = new System.Drawing.Size(664, 666);
            this.tblContent.TabIndex = 0;
            // 
            // gbTrainingQueue
            // 
            this.gbTrainingQueue.Controls.Add(this.tblTrainingQueue);
            this.gbTrainingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTrainingQueue.Location = new System.Drawing.Point(3, 333);
            this.gbTrainingQueue.Name = "gbTrainingQueue";
            this.gbTrainingQueue.Size = new System.Drawing.Size(658, 290);
            this.gbTrainingQueue.TabIndex = 10;
            this.gbTrainingQueue.TabStop = false;
            this.gbTrainingQueue.Text = "Training Queue";
            // 
            // tblTrainingQueue
            // 
            this.tblTrainingQueue.ColumnCount = 3;
            this.tblTrainingQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTrainingQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblTrainingQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTrainingQueue.Controls.Add(this.lvMatching, 0, 2);
            this.tblTrainingQueue.Controls.Add(this.btnCapture, 0, 0);
            this.tblTrainingQueue.Controls.Add(this.lvNotMatching, 2, 2);
            this.tblTrainingQueue.Controls.Add(this.chkMatching, 0, 1);
            this.tblTrainingQueue.Controls.Add(this.chkNotMatching, 2, 1);
            this.tblTrainingQueue.Controls.Add(this.toolStripMatching, 0, 3);
            this.tblTrainingQueue.Controls.Add(this.toolStripNotMatching, 2, 3);
            this.tblTrainingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTrainingQueue.Location = new System.Drawing.Point(3, 16);
            this.tblTrainingQueue.Name = "tblTrainingQueue";
            this.tblTrainingQueue.RowCount = 4;
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblTrainingQueue.Size = new System.Drawing.Size(652, 271);
            this.tblTrainingQueue.TabIndex = 7;
            // 
            // lvMatching
            // 
            this.lvMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMatching.Location = new System.Drawing.Point(3, 63);
            this.lvMatching.Name = "lvMatching";
            this.lvMatching.Size = new System.Drawing.Size(306, 175);
            this.lvMatching.TabIndex = 4;
            this.lvMatching.UseCompatibleStateImageBehavior = false;
            this.lvMatching.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 40;
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCapture.BackColor = System.Drawing.Color.LightGray;
            this.tblTrainingQueue.SetColumnSpan(this.btnCapture, 3);
            this.btnCapture.Location = new System.Drawing.Point(289, 3);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(73, 24);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture!";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lvNotMatching
            // 
            this.lvNotMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvNotMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNotMatching.Location = new System.Drawing.Point(343, 63);
            this.lvNotMatching.Name = "lvNotMatching";
            this.lvNotMatching.Size = new System.Drawing.Size(306, 175);
            this.lvNotMatching.TabIndex = 3;
            this.lvNotMatching.UseCompatibleStateImageBehavior = false;
            this.lvNotMatching.View = System.Windows.Forms.View.List;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 40;
            // 
            // chkMatching
            // 
            this.chkMatching.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMatching.AutoSize = true;
            this.chkMatching.BackColor = System.Drawing.Color.LightGray;
            this.chkMatching.Checked = true;
            this.chkMatching.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMatching.Image = ((System.Drawing.Image)(resources.GetObject("chkMatching.Image")));
            this.chkMatching.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMatching.Location = new System.Drawing.Point(113, 36);
            this.chkMatching.Name = "chkMatching";
            this.chkMatching.Size = new System.Drawing.Size(85, 17);
            this.chkMatching.TabIndex = 10;
            this.chkMatching.Text = "Matching     ";
            this.chkMatching.UseVisualStyleBackColor = false;
            this.chkMatching.CheckedChanged += new System.EventHandler(this.chkMatching_CheckedChanged);
            // 
            // chkNotMatching
            // 
            this.chkNotMatching.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkNotMatching.AutoSize = true;
            this.chkNotMatching.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkNotMatching.Image = ((System.Drawing.Image)(resources.GetObject("chkNotMatching.Image")));
            this.chkNotMatching.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNotMatching.Location = new System.Drawing.Point(443, 36);
            this.chkNotMatching.Name = "chkNotMatching";
            this.chkNotMatching.Size = new System.Drawing.Size(105, 17);
            this.chkNotMatching.TabIndex = 11;
            this.chkNotMatching.Text = "Not Matching     ";
            this.chkNotMatching.UseVisualStyleBackColor = false;
            this.chkNotMatching.CheckedChanged += new System.EventHandler(this.chkNotMatching_CheckedChanged);
            // 
            // toolStripMatching
            // 
            this.toolStripMatching.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton_Matching,
            this.saveToolStripButton_Matching,
            this.deleteToolStripButton_Matching});
            this.toolStripMatching.Location = new System.Drawing.Point(3, 244);
            this.toolStripMatching.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripMatching.Name = "toolStripMatching";
            this.toolStripMatching.Size = new System.Drawing.Size(306, 24);
            this.toolStripMatching.TabIndex = 12;
            this.toolStripMatching.Text = "toolStripMatching";
            // 
            // openToolStripButton_Matching
            // 
            this.openToolStripButton_Matching.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton_Matching.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton_Matching.Image")));
            this.openToolStripButton_Matching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton_Matching.Name = "openToolStripButton_Matching";
            this.openToolStripButton_Matching.Size = new System.Drawing.Size(23, 21);
            this.openToolStripButton_Matching.Text = "&Open and Include Matching File";
            this.openToolStripButton_Matching.Click += new System.EventHandler(this.openToolStripButton_Matching_Click);
            // 
            // saveToolStripButton_Matching
            // 
            this.saveToolStripButton_Matching.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton_Matching.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton_Matching.Image")));
            this.saveToolStripButton_Matching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton_Matching.Name = "saveToolStripButton_Matching";
            this.saveToolStripButton_Matching.Size = new System.Drawing.Size(23, 21);
            this.saveToolStripButton_Matching.Text = "&Save Selected File";
            this.saveToolStripButton_Matching.Click += new System.EventHandler(this.saveToolStripButton_Matching_Click);
            // 
            // deleteToolStripButton_Matching
            // 
            this.deleteToolStripButton_Matching.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton_Matching.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton_Matching.Image")));
            this.deleteToolStripButton_Matching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton_Matching.Name = "deleteToolStripButton_Matching";
            this.deleteToolStripButton_Matching.Size = new System.Drawing.Size(23, 21);
            this.deleteToolStripButton_Matching.Text = "&Delete Selected File";
            this.deleteToolStripButton_Matching.Click += new System.EventHandler(this.deleteToolStripButton_Matching_Click);
            // 
            // toolStripNotMatching
            // 
            this.toolStripNotMatching.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton_NotMatching,
            this.saveToolStripButton_NotMatching,
            this.deleteToolStripButton_NotMatching});
            this.toolStripNotMatching.Location = new System.Drawing.Point(343, 244);
            this.toolStripNotMatching.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripNotMatching.Name = "toolStripNotMatching";
            this.toolStripNotMatching.Size = new System.Drawing.Size(306, 24);
            this.toolStripNotMatching.TabIndex = 13;
            this.toolStripNotMatching.Text = "toolStripNotMatching";
            // 
            // openToolStripButton_NotMatching
            // 
            this.openToolStripButton_NotMatching.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton_NotMatching.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton_NotMatching.Image")));
            this.openToolStripButton_NotMatching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton_NotMatching.Name = "openToolStripButton_NotMatching";
            this.openToolStripButton_NotMatching.Size = new System.Drawing.Size(23, 21);
            this.openToolStripButton_NotMatching.Text = "&Open and Include Not Matching File";
            this.openToolStripButton_NotMatching.Click += new System.EventHandler(this.openToolStripButton_NotMatching_Click);
            // 
            // saveToolStripButton_NotMatching
            // 
            this.saveToolStripButton_NotMatching.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton_NotMatching.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton_NotMatching.Image")));
            this.saveToolStripButton_NotMatching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton_NotMatching.Name = "saveToolStripButton_NotMatching";
            this.saveToolStripButton_NotMatching.Size = new System.Drawing.Size(23, 21);
            this.saveToolStripButton_NotMatching.Text = "&Save Selected File";
            this.saveToolStripButton_NotMatching.Click += new System.EventHandler(this.saveToolStripButton_NotMatching_Click);
            // 
            // deleteToolStripButton_NotMatching
            // 
            this.deleteToolStripButton_NotMatching.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton_NotMatching.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton_NotMatching.Image")));
            this.deleteToolStripButton_NotMatching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton_NotMatching.Name = "deleteToolStripButton_NotMatching";
            this.deleteToolStripButton_NotMatching.Size = new System.Drawing.Size(23, 21);
            this.deleteToolStripButton_NotMatching.Text = "&Delete Selected File";
            this.deleteToolStripButton_NotMatching.Click += new System.EventHandler(this.deleteToolStripButton_NotMatching_Click);
            // 
            // gbImageProvider
            // 
            this.gbImageProvider.Controls.Add(this.tableLayoutPanel3);
            this.gbImageProvider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageProvider.Location = new System.Drawing.Point(3, 3);
            this.gbImageProvider.Name = "gbImageProvider";
            this.gbImageProvider.Size = new System.Drawing.Size(658, 324);
            this.gbImageProvider.TabIndex = 9;
            this.gbImageProvider.TabStop = false;
            this.gbImageProvider.Text = "Image Provider";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.38461F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61539F));
            this.tableLayoutPanel3.Controls.Add(this.pnlDeviceControl, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbImageProvider, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(652, 305);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // pnlDeviceControl
            // 
            this.pnlDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeviceControl.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pnlDeviceControl.Location = new System.Drawing.Point(3, 28);
            this.pnlDeviceControl.Name = "pnlDeviceControl";
            this.pnlDeviceControl.Size = new System.Drawing.Size(159, 274);
            this.pnlDeviceControl.TabIndex = 6;
            // 
            // cmbImageProvider
            // 
            this.cmbImageProvider.FormattingEnabled = true;
            this.cmbImageProvider.Location = new System.Drawing.Point(3, 3);
            this.cmbImageProvider.Name = "cmbImageProvider";
            this.cmbImageProvider.Size = new System.Drawing.Size(120, 21);
            this.cmbImageProvider.TabIndex = 7;
            this.cmbImageProvider.SelectedIndexChanged += new System.EventHandler(this.cmbImageProvider_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(168, 3);
            this.pictureBox.Name = "pictureBox";
            this.tableLayoutPanel3.SetRowSpan(this.pictureBox, 2);
            this.pictureBox.Size = new System.Drawing.Size(352, 288);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // tblNavigation
            // 
            this.tblNavigation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tblNavigation.ColumnCount = 2;
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.Controls.Add(this.btnNext, 1, 0);
            this.tblNavigation.Location = new System.Drawing.Point(213, 629);
            this.tblNavigation.Name = "tblNavigation";
            this.tblNavigation.RowCount = 1;
            this.tblNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblNavigation.Size = new System.Drawing.Size(238, 34);
            this.tblNavigation.TabIndex = 11;
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
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "jpg";
            this.openFileDialog.FileName = "*.jpg";
            this.openFileDialog.Filter = "JPEG files|*.jpg";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Open File(s)";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.FileName = "*.jpg";
            this.saveFileDialog.Filter = "JPEG files|*.jpg";
            this.saveFileDialog.Title = "Save Files(s)";
            // 
            // CollectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 765);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.pnlContentHolder);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1. Collecting Training Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CollectForm_FormClosed);
            this.pnlContentHolder.ResumeLayout(false);
            this.tblContent.ResumeLayout(false);
            this.gbTrainingQueue.ResumeLayout(false);
            this.tblTrainingQueue.ResumeLayout(false);
            this.tblTrainingQueue.PerformLayout();
            this.toolStripMatching.ResumeLayout(false);
            this.toolStripMatching.PerformLayout();
            this.toolStripNotMatching.ResumeLayout(false);
            this.toolStripNotMatching.PerformLayout();
            this.gbImageProvider.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tblNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.Panel pnlContentHolder;
        private System.Windows.Forms.TableLayoutPanel tblContent;
        private System.Windows.Forms.GroupBox gbImageProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Clustered_NN.Classes.SelectingPictureBox.ImageSelectingPictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel pnlDeviceControl;
        private System.Windows.Forms.GroupBox gbTrainingQueue;
        private System.Windows.Forms.TableLayoutPanel tblTrainingQueue;
        internal System.Windows.Forms.ListView lvMatching;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnCapture;
        internal System.Windows.Forms.ListView lvNotMatching;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkMatching;
        private System.Windows.Forms.CheckBox chkNotMatching;
        private System.Windows.Forms.ToolStrip toolStripMatching;
        private System.Windows.Forms.ToolStripButton openToolStripButton_Matching;
        private System.Windows.Forms.ToolStripButton saveToolStripButton_Matching;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton_Matching;
        private System.Windows.Forms.ToolStrip toolStripNotMatching;
        private System.Windows.Forms.ToolStripButton openToolStripButton_NotMatching;
        private System.Windows.Forms.ToolStripButton saveToolStripButton_NotMatching;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton_NotMatching;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TableLayoutPanel tblNavigation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cmbImageProvider;

    }
}