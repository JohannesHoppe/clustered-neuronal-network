﻿namespace Clustered_NN.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectForm));
            this.lblTooltip = new System.Windows.Forms.Label();
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.tblNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.gbImageProvider = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDeviceControl = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox = new Clustered_NN.Classes.ImageSelectingPictureBox();
            this.pnlContentHolder.SuspendLayout();
            this.tblContent.SuspendLayout();
            this.tblNavigation.SuspendLayout();
            this.gbImageProvider.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.pnlContentHolder.Size = new System.Drawing.Size(761, 525);
            this.pnlContentHolder.TabIndex = 6;
            // 
            // tblContent
            // 
            this.tblContent.ColumnCount = 1;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.Controls.Add(this.tblNavigation, 0, 2);
            this.tblContent.Controls.Add(this.gbImageProvider, 0, 0);
            this.tblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContent.Location = new System.Drawing.Point(0, 0);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 3;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblContent.Size = new System.Drawing.Size(759, 523);
            this.tblContent.TabIndex = 0;
            // 
            // tblNavigation
            // 
            this.tblNavigation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tblNavigation.ColumnCount = 2;
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblNavigation.Controls.Add(this.btnPrev, 0, 0);
            this.tblNavigation.Location = new System.Drawing.Point(260, 486);
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
            // 
            // gbImageProvider
            // 
            this.gbImageProvider.Controls.Add(this.tableLayoutPanel3);
            this.gbImageProvider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageProvider.Location = new System.Drawing.Point(3, 3);
            this.gbImageProvider.Name = "gbImageProvider";
            this.gbImageProvider.Size = new System.Drawing.Size(753, 319);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(747, 300);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // pnlDeviceControl
            // 
            this.pnlDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeviceControl.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pnlDeviceControl.Location = new System.Drawing.Point(3, 3);
            this.pnlDeviceControl.Name = "pnlDeviceControl";
            this.pnlDeviceControl.Size = new System.Drawing.Size(183, 294);
            this.pnlDeviceControl.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(192, 3);
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
            this.ClientSize = new System.Drawing.Size(786, 578);
            this.Controls.Add(this.pnlContentHolder);
            this.Controls.Add(this.lblTooltip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3. Detect pattern";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetectForm_FormClosed);
            this.pnlContentHolder.ResumeLayout(false);
            this.tblContent.ResumeLayout(false);
            this.tblNavigation.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tblNavigation;
        private System.Windows.Forms.Button btnPrev;
    }
}