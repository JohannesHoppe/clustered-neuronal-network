namespace Clustered_NN.Forms
{
    partial class DetectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectForm));
            this.lblTooltip = new System.Windows.Forms.Label();
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.tblNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.gbImageProvider = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDeviceControl = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.threadList = new System.Windows.Forms.ListView();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.threadListRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.currentImageSmall = new System.Windows.Forms.PictureBox();
            this.pictureBox = new Clustered_NN.Classes.ScanSelectingPictureBox();
            this.pnlContentHolder.SuspendLayout();
            this.tblContent.SuspendLayout();
            this.tblNavigation.SuspendLayout();
            this.gbImageProvider.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentImageSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTooltip.Location = new System.Drawing.Point(12, 9);
            this.lblTooltip.MaximumSize = new System.Drawing.Size(600, 60);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(24, 15);
            this.lblTooltip.TabIndex = 5;
            this.lblTooltip.Text = "xxx";
            // 
            // pnlContentHolder
            // 
            this.pnlContentHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContentHolder.Controls.Add(this.tblContent);
            this.pnlContentHolder.Location = new System.Drawing.Point(12, 40);
            this.pnlContentHolder.Name = "pnlContentHolder";
            this.pnlContentHolder.Size = new System.Drawing.Size(666, 628);
            this.pnlContentHolder.TabIndex = 6;
            // 
            // tblContent
            // 
            this.tblContent.ColumnCount = 1;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.Controls.Add(this.tblNavigation, 0, 2);
            this.tblContent.Controls.Add(this.gbImageProvider, 0, 0);
            this.tblContent.Controls.Add(this.panel1, 0, 1);
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(0, 0);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 3;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblContent.Size = new System.Drawing.Size(664, 626);
            this.tblContent.TabIndex = 0;
            // 
            // tblNavigation
            // 
            this.tblNavigation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tblNavigation.ColumnCount = 2;
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.Controls.Add(this.btnPrev, 0, 0);
            this.tblNavigation.Location = new System.Drawing.Point(213, 589);
            this.tblNavigation.Name = "tblNavigation";
            this.tblNavigation.RowCount = 1;
            this.tblNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblNavigation.Size = new System.Drawing.Size(238, 34);
            this.tblNavigation.TabIndex = 22;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.currentImageSmall);
            this.panel1.Controls.Add(this.currentImage);
            this.panel1.Controls.Add(this.threadList);
            this.panel1.Controls.Add(this.btnStartScan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 255);
            this.panel1.TabIndex = 23;
            // 
            // threadList
            // 
            this.threadList.Location = new System.Drawing.Point(20, 17);
            this.threadList.Name = "threadList";
            this.threadList.Size = new System.Drawing.Size(188, 212);
            this.threadList.TabIndex = 1;
            this.threadList.UseCompatibleStateImageBehavior = false;
            this.threadList.View = System.Windows.Forms.View.List;
            // 
            // btnStartScan
            // 
            this.btnStartScan.BackColor = System.Drawing.Color.LightGray;
            this.btnStartScan.Location = new System.Drawing.Point(498, 106);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnStartScan.TabIndex = 0;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.UseVisualStyleBackColor = false;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // threadListRefreshTimer
            // 
            this.threadListRefreshTimer.Tick += new System.EventHandler(this.threadListRefreshTimer_Tick);
            // 
            // currentImage
            // 
            this.currentImage.Location = new System.Drawing.Point(219, 52);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(20, 20);
            this.currentImage.TabIndex = 2;
            this.currentImage.TabStop = false;
            // 
            // currentImageSmall
            // 
            this.currentImageSmall.Location = new System.Drawing.Point(219, 17);
            this.currentImageSmall.Name = "currentImageSmall";
            this.currentImageSmall.Size = new System.Drawing.Size(20, 20);
            this.currentImageSmall.TabIndex = 3;
            this.currentImageSmall.TabStop = false;
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
            // DetectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 743);
            this.Controls.Add(this.pnlContentHolder);
            this.Controls.Add(this.lblTooltip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetectForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3. Detect pattern";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetectForm_FormClosed);
            this.pnlContentHolder.ResumeLayout(false);
            this.tblContent.ResumeLayout(false);
            this.tblNavigation.ResumeLayout(false);
            this.gbImageProvider.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentImageSmall)).EndInit();
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
        private Clustered_NN.Classes.ScanSelectingPictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel pnlDeviceControl;
        private System.Windows.Forms.TableLayoutPanel tblNavigation;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.ListView threadList;
        private System.Windows.Forms.Timer threadListRefreshTimer;
        private System.Windows.Forms.PictureBox currentImage;
        private System.Windows.Forms.PictureBox currentImageSmall;
    }
}