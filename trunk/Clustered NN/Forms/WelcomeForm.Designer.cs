namespace Clustered_NN.Forms
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_3_info = new System.Windows.Forms.Label();
            this.lbl_2_info = new System.Windows.Forms.Label();
            this.lbl_1_info = new System.Windows.Forms.Label();
            this.lbl_intro = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.lbl_heading = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_start = new System.Windows.Forms.Button();
            this.timerClickOnStart = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_3_info, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_2_info, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_1_info, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_intro, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(445, 204);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_3
            // 
            this.lbl_3.AutoSize = true;
            this.lbl_3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_3.ForeColor = System.Drawing.Color.Gray;
            this.lbl_3.Location = new System.Drawing.Point(40, 169);
            this.lbl_3.Margin = new System.Windows.Forms.Padding(40, 15, 15, 15);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(31, 20);
            this.lbl_3.TabIndex = 9;
            this.lbl_3.Text = "3.";
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_2.ForeColor = System.Drawing.Color.Gray;
            this.lbl_2.Location = new System.Drawing.Point(40, 119);
            this.lbl_2.Margin = new System.Windows.Forms.Padding(40, 15, 15, 15);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(31, 20);
            this.lbl_2.TabIndex = 8;
            this.lbl_2.Text = "2.";
            // 
            // lbl_3_info
            // 
            this.lbl_3_info.AutoSize = true;
            this.lbl_3_info.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_3_info.Location = new System.Drawing.Point(95, 174);
            this.lbl_3_info.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.lbl_3_info.Name = "lbl_3_info";
            this.lbl_3_info.Size = new System.Drawing.Size(238, 16);
            this.lbl_3_info.TabIndex = 6;
            this.lbl_3_info.Text = "Using the NN for pattern detection";
            // 
            // lbl_2_info
            // 
            this.lbl_2_info.AutoSize = true;
            this.lbl_2_info.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_2_info.Location = new System.Drawing.Point(95, 114);
            this.lbl_2_info.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.lbl_2_info.Name = "lbl_2_info";
            this.lbl_2_info.Size = new System.Drawing.Size(257, 32);
            this.lbl_2_info.TabIndex = 5;
            this.lbl_2_info.Text = "Training of the neuronal network with\r\na clustered server";
            // 
            // lbl_1_info
            // 
            this.lbl_1_info.AutoSize = true;
            this.lbl_1_info.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_1_info.Location = new System.Drawing.Point(95, 74);
            this.lbl_1_info.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.lbl_1_info.Name = "lbl_1_info";
            this.lbl_1_info.Size = new System.Drawing.Size(244, 16);
            this.lbl_1_info.TabIndex = 2;
            this.lbl_1_info.Text = "Collecting training data via webcam";
            // 
            // lbl_intro
            // 
            this.lbl_intro.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_intro, 2);
            this.lbl_intro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_intro.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_intro.Location = new System.Drawing.Point(3, 3);
            this.lbl_intro.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_intro.Name = "lbl_intro";
            this.lbl_intro.Size = new System.Drawing.Size(439, 48);
            this.lbl_intro.TabIndex = 0;
            this.lbl_intro.Text = "This is the start screen for a new neuronal network project.\r\nEvery project consi" +
                "sts of three consecutive steps:";
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_1.ForeColor = System.Drawing.Color.Gray;
            this.lbl_1.Location = new System.Drawing.Point(40, 69);
            this.lbl_1.Margin = new System.Windows.Forms.Padding(40, 15, 15, 15);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(31, 20);
            this.lbl_1.TabIndex = 7;
            this.lbl_1.Text = "1.";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.51663F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.48337F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbxIcon, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_heading, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.23588F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.76412F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(471, 349);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbxIcon.Image")));
            this.pbxIcon.Location = new System.Drawing.Point(30, 25);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(20, 15, 0, 0);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(49, 58);
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            // 
            // lbl_heading
            // 
            this.lbl_heading.AutoSize = true;
            this.lbl_heading.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_heading.ForeColor = System.Drawing.Color.Gray;
            this.lbl_heading.Location = new System.Drawing.Point(99, 30);
            this.lbl_heading.Margin = new System.Windows.Forms.Padding(10, 20, 3, 0);
            this.lbl_heading.Name = "lbl_heading";
            this.lbl_heading.Size = new System.Drawing.Size(208, 46);
            this.lbl_heading.TabIndex = 3;
            this.lbl_heading.Text = "Clustered\r\nNeuronal Network";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_start, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 307);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(451, 32);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.LightGray;
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_start.Location = new System.Drawing.Point(178, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(94, 26);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timerClickOnStart
            // 
            this.timerClickOnStart.Enabled = true;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(471, 349);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clustered Neuronal Network - Start";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_intro;
        private System.Windows.Forms.Label lbl_1_info;
        private System.Windows.Forms.Label lbl_3_info;
        private System.Windows.Forms.Label lbl_2_info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbxIcon;
        private System.Windows.Forms.Label lbl_heading;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timerClickOnStart;

    }
}

