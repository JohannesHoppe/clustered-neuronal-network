using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Clustered_NN.Classes;

namespace Clustered_NN.Forms
{
    public partial class MasterForm : Form
    {
        private string _showPermanentText;
        private bool _showPermanentEntered;


        private Form _parentForm;
        private CNNProjectHolder _cnnProjectHolder;



        public MasterForm()
        {
            throw new Exception("Please provide the parentForm and the cnnProject!");
        }


        public MasterForm(Form parentForm, CNNProjectHolder cnnProjectHolder)
        {
            InitializeComponent();

            _parentForm = parentForm;
            _cnnProjectHolder = cnnProjectHolder;
        }


        #region ballon tooltip for electric bulb

        /// <summary>
        /// Shows the ballon tooltip on the electric bulb icon (pictureBox1)
        /// </summary>
        /// <param name="newText">The new text.</param>
        /// <param name="time">The time in milliseconds</param>
        /// <param name="parent">The generating form (since we redirect the controls)</param>
        /// <param name="permanent">if set to <c>true</c> the tooltip will come again</param>
        public void ShowPictureBoxBallon(string newText, int time, Form parent, bool permanent) {

            balloonToolTipInfo.SetBalloonText(
                this.pbxIcon,
                newText
            );

            // ???
            Point point = parent.PointToScreen(pbxIcon.PointToScreen(pbxIcon.Location));
            point.X += 5;

            balloonToolTipInfo.Show(this.pbxIcon, point);

            timerToolTip.Interval = time;
            timerToolTip.Enabled = true;

            if (permanent)
            {
                _showPermanentText = newText;
                _showPermanentEntered = false;
                pbxIcon.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
                pbxIcon.MouseLeave += new EventHandler(pictureBox1_MouseLeave);
            }
        }


        /// <summary>
        /// Hides the showed ballon tooltip again after fade in
        /// </summary>
        private void timerToolTip_Tick(object sender, EventArgs e)
        {
            balloonToolTipInfo.Hide(this.pbxIcon);
            timerToolTip.Enabled = false;
        }


        /// <summary>
        /// Shows the ballon tooltip immedeately
        /// </summary>
        void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (_showPermanentEntered == false)
            {
                // ??? ???
                Point point = pbxIcon.PointToScreen(pbxIcon.Location);
                point.X += 8;
                point.Y += 22;

                balloonToolTipInfo.Show(this.pbxIcon, point);

                _showPermanentEntered = true;
            }
        }


        /// <summary>
        /// Hides the ballon tooltip immedeately
        /// </summary>
        void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            balloonToolTipInfo.Hide(this.pbxIcon);
            _showPermanentEntered = false;
        }

        #endregion


        /// <summary>
        /// Imports the toolstripContainer with all his nice controls into the given form
        /// also adds the controls from this.pnlContentHolder to masterFormContents.pnlContentHolder
        /// </summary>
        public static void InitializeContent(Form newForm,
                                             Label lblTooltip,
                                             ToolStripContainer toolStripContainer,
                                             Panel pnlContentHolder,
                                             CNNProjectHolder cnnProjectHolder)
        {
            MasterForm masterFormContents = new MasterForm(newForm, cnnProjectHolder);

            // import
            toolStripContainer = masterFormContents.toolStripContainer1;
            newForm.Controls.Add(toolStripContainer);

            // control replacement
            newForm.Controls.Remove(pnlContentHolder);
            newForm.Controls.Remove(lblTooltip);
            masterFormContents.pnlContentHolder.Controls.Clear();

            foreach (Control control in pnlContentHolder.Controls)
            {
                masterFormContents.pnlContentHolder.Controls.Add(control);
            }

            int time = (cnnProjectHolder.CNNProject.ExpertMode) ? 1 : 5000;

            masterFormContents.ShowPictureBoxBallon(lblTooltip.Text, time, newForm, true);
            masterFormContents.lblHeading.Text = newForm.Text;

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _parentForm.Close();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.Save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.Open();
        }

    }
}