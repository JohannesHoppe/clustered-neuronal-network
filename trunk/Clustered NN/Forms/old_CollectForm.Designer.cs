using Clustered_NN.Classes;
namespace Clustered_NN.Forms
{
    partial class old_CollectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(old_CollectForm));
            this.lbl_intro = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.lbl_heading = new System.Windows.Forms.Label();
            this.gbTrainingQueue = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lvMatching = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imlMatching = new System.Windows.Forms.ImageList(this.components);
            this.btnCursor = new System.Windows.Forms.Button();
            this.lvNotMatching = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imlNotMatching = new System.Windows.Forms.ImageList(this.components);
            this.chkMatching = new System.Windows.Forms.CheckBox();
            this.chkNotMatching = new System.Windows.Forms.CheckBox();
            this.gbImageProvider = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDeviceControl = new System.Windows.Forms.FlowLayoutPanel();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Capture = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pictureBox = new Clustered_NN.Classes.ImageSelectingPictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.gbTrainingQueue.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.gbImageProvider.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_intro
            // 
            this.lbl_intro.AutoSize = true;
            this.lbl_intro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_intro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_intro.Location = new System.Drawing.Point(3, 16);
            this.lbl_intro.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_intro.MaximumSize = new System.Drawing.Size(660, 0);
            this.lbl_intro.Name = "lbl_intro";
            this.lbl_intro.Size = new System.Drawing.Size(629, 39);
            this.lbl_intro.TabIndex = 0;
            this.lbl_intro.Text = resources.GetString("lbl_intro.Text");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.7907F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.2093F));
            this.tableLayoutPanel2.Controls.Add(this.pbxIcon, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_heading, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbTrainingQueue, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.gbImageProvider, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gbInfo, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.0303F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.9697F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(692, 761);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbxIcon.Image")));
            this.pbxIcon.Location = new System.Drawing.Point(30, 25);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(20, 15, 0, 0);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(49, 50);
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            // 
            // lbl_heading
            // 
            this.lbl_heading.AutoSize = true;
            this.lbl_heading.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_heading.ForeColor = System.Drawing.Color.Gray;
            this.lbl_heading.Location = new System.Drawing.Point(105, 45);
            this.lbl_heading.Margin = new System.Windows.Forms.Padding(10, 35, 3, 0);
            this.lbl_heading.Name = "lbl_heading";
            this.lbl_heading.Size = new System.Drawing.Size(301, 23);
            this.lbl_heading.TabIndex = 3;
            this.lbl_heading.Text = "1. Collecting Training Data";
            // 
            // gbTrainingQueue
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gbTrainingQueue, 2);
            this.gbTrainingQueue.Controls.Add(this.tableLayoutPanel4);
            this.gbTrainingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTrainingQueue.Location = new System.Drawing.Point(13, 490);
            this.gbTrainingQueue.Name = "gbTrainingQueue";
            this.gbTrainingQueue.Size = new System.Drawing.Size(666, 220);
            this.gbTrainingQueue.TabIndex = 7;
            this.gbTrainingQueue.TabStop = false;
            this.gbTrainingQueue.Text = "Training Queue";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lvMatching, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnCursor, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lvNotMatching, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.chkMatching, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkNotMatching, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.43575F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.54305F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.91391F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(660, 201);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // lvMatching
            // 
            this.lvMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMatching.Location = new System.Drawing.Point(3, 63);
            this.lvMatching.Name = "lvMatching";
            this.lvMatching.Size = new System.Drawing.Size(309, 97);
            this.lvMatching.SmallImageList = this.imlMatching;
            this.lvMatching.TabIndex = 4;
            this.lvMatching.UseCompatibleStateImageBehavior = false;
            this.lvMatching.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 40;
            // 
            // imlMatching
            // 
            this.imlMatching.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlMatching.ImageSize = new System.Drawing.Size(16, 16);
            this.imlMatching.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnCursor
            // 
            this.btnCursor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCursor.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel4.SetColumnSpan(this.btnCursor, 3);
            this.btnCursor.Location = new System.Drawing.Point(293, 4);
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(73, 22);
            this.btnCursor.TabIndex = 0;
            this.btnCursor.Text = "Capture!";
            this.btnCursor.UseVisualStyleBackColor = false;
            this.btnCursor.Click += new System.EventHandler(this.btnCursor_Click);
            // 
            // lvNotMatching
            // 
            this.lvNotMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvNotMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNotMatching.Location = new System.Drawing.Point(346, 63);
            this.lvNotMatching.Name = "lvNotMatching";
            this.lvNotMatching.Size = new System.Drawing.Size(311, 97);
            this.lvNotMatching.SmallImageList = this.imlNotMatching;
            this.lvNotMatching.TabIndex = 3;
            this.lvNotMatching.UseCompatibleStateImageBehavior = false;
            this.lvNotMatching.View = System.Windows.Forms.View.List;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 40;
            // 
            // imlNotMatching
            // 
            this.imlNotMatching.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlNotMatching.ImageSize = new System.Drawing.Size(16, 16);
            this.imlNotMatching.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chkMatching
            // 
            this.chkMatching.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMatching.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMatching.AutoSize = true;
            this.chkMatching.BackColor = System.Drawing.Color.LightGray;
            this.chkMatching.Checked = true;
            this.chkMatching.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMatching.Image = ((System.Drawing.Image)(resources.GetObject("chkMatching.Image")));
            this.chkMatching.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMatching.Location = new System.Drawing.Point(119, 33);
            this.chkMatching.Name = "chkMatching";
            this.chkMatching.Size = new System.Drawing.Size(76, 23);
            this.chkMatching.TabIndex = 10;
            this.chkMatching.Text = "Matching     ";
            this.chkMatching.UseVisualStyleBackColor = false;
            this.chkMatching.CheckedChanged += new System.EventHandler(this.chkMatching_CheckedChanged);
            // 
            // chkNotMatching
            // 
            this.chkNotMatching.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkNotMatching.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkNotMatching.AutoSize = true;
            this.chkNotMatching.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkNotMatching.Image = ((System.Drawing.Image)(resources.GetObject("chkNotMatching.Image")));
            this.chkNotMatching.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNotMatching.Location = new System.Drawing.Point(453, 33);
            this.chkNotMatching.Name = "chkNotMatching";
            this.chkNotMatching.Size = new System.Drawing.Size(96, 23);
            this.chkNotMatching.TabIndex = 11;
            this.chkNotMatching.Text = "Not Matching     ";
            this.chkNotMatching.UseVisualStyleBackColor = false;
            this.chkNotMatching.CheckedChanged += new System.EventHandler(this.chkNotMatching_CheckedChanged);
            // 
            // gbImageProvider
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gbImageProvider, 2);
            this.gbImageProvider.Controls.Add(this.tableLayoutPanel3);
            this.gbImageProvider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageProvider.Location = new System.Drawing.Point(13, 200);
            this.gbImageProvider.Name = "gbImageProvider";
            this.gbImageProvider.Size = new System.Drawing.Size(666, 284);
            this.gbImageProvider.TabIndex = 8;
            this.gbImageProvider.TabStop = false;
            this.gbImageProvider.Text = "Image Provider";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.38461F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61539F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.pnlDeviceControl, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(660, 265);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // pnlDeviceControl
            // 
            this.pnlDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeviceControl.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pnlDeviceControl.Location = new System.Drawing.Point(3, 3);
            this.pnlDeviceControl.Name = "pnlDeviceControl";
            this.pnlDeviceControl.Size = new System.Drawing.Size(161, 259);
            this.pnlDeviceControl.TabIndex = 6;
            // 
            // gbInfo
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gbInfo, 2);
            this.gbInfo.Controls.Add(this.lbl_intro);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Location = new System.Drawing.Point(13, 112);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(666, 82);
            this.gbInfo.TabIndex = 9;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Capture, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_Capture
            // 
            this.btn_Capture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Capture.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel1.SetColumnSpan(this.btn_Capture, 2);
            this.btn_Capture.Location = new System.Drawing.Point(62, 3);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(75, 14);
            this.btn_Capture.TabIndex = 0;
            this.btn_Capture.Text = "Capture!";
            this.btn_Capture.UseVisualStyleBackColor = false;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(692, 761);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(692, 761);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(170, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(352, 259);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // CollectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 761);
            this.Controls.Add(this.toolStripContainer1);
            this.MinimumSize = new System.Drawing.Size(630, 491);
            this.Name = "CollectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1. Collecting Training Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CollectForm_FormClosed);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.gbTrainingQueue.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.gbImageProvider.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_intro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbxIcon;
        private System.Windows.Forms.Label lbl_heading;
        //private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox gbTrainingQueue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnCursor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Capture;
        private System.Windows.Forms.GroupBox gbImageProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ImageSelectingPictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel pnlDeviceControl;
        internal System.Windows.Forms.ListView lvMatching;
        internal System.Windows.Forms.ListView lvNotMatching;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.CheckBox chkMatching;
        private System.Windows.Forms.CheckBox chkNotMatching;
        private System.Windows.Forms.ImageList imlNotMatching;
        private System.Windows.Forms.ImageList imlMatching;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}

