using Clustered_NN.Classes;
namespace Clustered_NN.Forms
{
    partial class MasterFormExample
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
            this.pnlContentHolder = new System.Windows.Forms.Panel();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContentHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContentHolder
            // 
            this.pnlContentHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContentHolder.Controls.Add(this.label1);
            this.pnlContentHolder.Location = new System.Drawing.Point(12, 84);
            this.pnlContentHolder.Name = "pnlContentHolder";
            this.pnlContentHolder.Size = new System.Drawing.Size(668, 356);
            this.pnlContentHolder.TabIndex = 0;
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTooltip.Location = new System.Drawing.Point(13, 13);
            this.lblTooltip.MaximumSize = new System.Drawing.Size(670, 60);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(360, 15);
            this.lblTooltip.TabIndex = 1;
            this.lblTooltip.Text = "This this text is shown in the ballon tooltip. It should be a short introduction." +
                "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "All control inside this panel, like this one, are going to be copied to the new p" +
                "anel inside a the cool ToolStripContainer.";
            // 
            // MasterFormExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 464);
            this.Controls.Add(this.lblTooltip);
            this.Controls.Add(this.pnlContentHolder);
            this.MinimumSize = new System.Drawing.Size(630, 491);
            this.Name = "MasterFormExample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "This text will be used for the Heading, too";
            this.pnlContentHolder.ResumeLayout(false);
            this.pnlContentHolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContentHolder;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.Label label1;




    }
}

