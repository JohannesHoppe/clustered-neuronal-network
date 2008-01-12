﻿namespace Clustered_NN.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectForm));
            this.lblTooltip = new System.Windows.Forms.Label();
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.gbTrainingQueue = new System.Windows.Forms.GroupBox();
            this.tblTrainingQueue = new System.Windows.Forms.TableLayoutPanel();
            this.lvMatching = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imlMatching = new System.Windows.Forms.ImageList(this.components);
            this.btnCapture = new System.Windows.Forms.Button();
            this.lvNotMatching = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imlNotMatching = new System.Windows.Forms.ImageList(this.components);
            this.chkMatching = new System.Windows.Forms.CheckBox();
            this.chkNotMatching = new System.Windows.Forms.CheckBox();
            this.gbImageProvider = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDeviceControl = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox = new Clustered_NN.Classes.ImageSelectingPictureBox();
            this.pnlContentHolder.SuspendLayout();
            this.tblContent.SuspendLayout();
            this.gbTrainingQueue.SuspendLayout();
            this.tblTrainingQueue.SuspendLayout();
            this.gbImageProvider.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            this.pnlContentHolder.Size = new System.Drawing.Size(666, 588);
            this.pnlContentHolder.TabIndex = 2;
            // 
            // tblContent
            // 
            this.tblContent.ColumnCount = 1;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.Controls.Add(this.gbTrainingQueue, 0, 1);
            this.tblContent.Controls.Add(this.gbImageProvider, 0, 0);
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(0, 0);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 2;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.Size = new System.Drawing.Size(664, 586);
            this.tblContent.TabIndex = 0;
            // 
            // gbTrainingQueue
            // 
            this.gbTrainingQueue.Controls.Add(this.tblTrainingQueue);
            this.gbTrainingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTrainingQueue.Location = new System.Drawing.Point(3, 328);
            this.gbTrainingQueue.Name = "gbTrainingQueue";
            this.gbTrainingQueue.Size = new System.Drawing.Size(658, 255);
            this.gbTrainingQueue.TabIndex = 10;
            this.gbTrainingQueue.TabStop = false;
            this.gbTrainingQueue.Text = "Training Queue";
            // 
            // tblTrainingQueue
            // 
            this.tblTrainingQueue.ColumnCount = 3;
            this.tblTrainingQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tblTrainingQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblTrainingQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTrainingQueue.Controls.Add(this.lvMatching, 0, 2);
            this.tblTrainingQueue.Controls.Add(this.btnCapture, 0, 0);
            this.tblTrainingQueue.Controls.Add(this.lvNotMatching, 2, 2);
            this.tblTrainingQueue.Controls.Add(this.chkMatching, 0, 1);
            this.tblTrainingQueue.Controls.Add(this.chkNotMatching, 2, 1);
            this.tblTrainingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTrainingQueue.Location = new System.Drawing.Point(3, 16);
            this.tblTrainingQueue.Name = "tblTrainingQueue";
            this.tblTrainingQueue.RowCount = 4;
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.43575F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.54305F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.91391F));
            this.tblTrainingQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tblTrainingQueue.Size = new System.Drawing.Size(652, 236);
            this.tblTrainingQueue.TabIndex = 7;
            // 
            // lvMatching
            // 
            this.lvMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMatching.Location = new System.Drawing.Point(3, 76);
            this.lvMatching.Name = "lvMatching";
            this.lvMatching.Size = new System.Drawing.Size(305, 119);
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
            // btnCapture
            // 
            this.btnCapture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCapture.BackColor = System.Drawing.Color.LightGray;
            this.tblTrainingQueue.SetColumnSpan(this.btnCapture, 3);
            this.btnCapture.Location = new System.Drawing.Point(289, 5);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(73, 25);
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
            this.lvNotMatching.Location = new System.Drawing.Point(342, 76);
            this.lvNotMatching.Name = "lvNotMatching";
            this.lvNotMatching.Size = new System.Drawing.Size(307, 119);
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
            this.chkMatching.Location = new System.Drawing.Point(117, 43);
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
            this.chkNotMatching.Location = new System.Drawing.Point(447, 43);
            this.chkNotMatching.Name = "chkNotMatching";
            this.chkNotMatching.Size = new System.Drawing.Size(96, 23);
            this.chkNotMatching.TabIndex = 11;
            this.chkNotMatching.Text = "Not Matching     ";
            this.chkNotMatching.UseVisualStyleBackColor = false;
            this.chkNotMatching.CheckedChanged += new System.EventHandler(this.chkNotMatching_CheckedChanged);
            // 
            // gbImageProvider
            // 
            this.gbImageProvider.Controls.Add(this.tableLayoutPanel3);
            this.gbImageProvider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageProvider.Location = new System.Drawing.Point(3, 3);
            this.gbImageProvider.Name = "gbImageProvider";
            this.gbImageProvider.Size = new System.Drawing.Size(658, 319);
            this.gbImageProvider.TabIndex = 9;
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
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(652, 300);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // pnlDeviceControl
            // 
            this.pnlDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeviceControl.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pnlDeviceControl.Location = new System.Drawing.Point(3, 3);
            this.pnlDeviceControl.Name = "pnlDeviceControl";
            this.pnlDeviceControl.Size = new System.Drawing.Size(159, 294);
            this.pnlDeviceControl.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(168, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(352, 288);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // CollectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 723);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.pnlContentHolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1. Collecting Training Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CollectForm_FormClosed);
            this.pnlContentHolder.ResumeLayout(false);
            this.tblContent.ResumeLayout(false);
            this.gbTrainingQueue.ResumeLayout(false);
            this.tblTrainingQueue.ResumeLayout(false);
            this.tblTrainingQueue.PerformLayout();
            this.gbImageProvider.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.Panel pnlContentHolder;
        private System.Windows.Forms.TableLayoutPanel tblContent;
        private System.Windows.Forms.GroupBox gbImageProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Clustered_NN.Classes.ImageSelectingPictureBox pictureBox;
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
        private System.Windows.Forms.ImageList imlMatching;
        private System.Windows.Forms.ImageList imlNotMatching;
    }
}