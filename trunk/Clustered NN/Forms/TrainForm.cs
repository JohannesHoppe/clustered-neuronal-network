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
    public partial class TrainForm : Form
    {

        private CNNProjectHolder _cnnProjectHolder;
        private CollectForm _parentForm;

        private ToolStripContainer _toolStripContainer = new ToolStripContainer();


        public TrainForm(CNNProjectHolder cnnProjectHolder, CollectForm parentForm)
        {
       
            InitializeComponent();

            this._cnnProjectHolder = cnnProjectHolder;
            this._parentForm = parentForm;


            MasterForm.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder,
                 this._cnnProjectHolder);
        }

        /// <summary>
        /// Sets needed form vars for the NN
        /// </summary>
        private void TrainForm_Load(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.SetVars(this.pbTrain, this.lblTrainInfo);
            UpdateNetworkStatus();
        }

        /// <summary>
        /// Stops the training and closes the parentForm
        /// </summary>
        private void TrainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.StopTraining = true; // important!
            _parentForm.Close();
        }

        
        private void btnPrev_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.StopTraining = true; // important!
            this.Hide();

            _parentForm.Show();
            _parentForm.ImageProviderStartPresentation();
        }





        /// <summary>
        /// Starts the training
        /// </summary>
        private void cmdTrain_Click(object sender, EventArgs e)
        {

            lblTrainStart.Text = "Training started at: " + DateTime.Now.ToShortTimeString();
            lblTrainInfo.Text = "";
            pnlControl.Enabled = false;
            cmdCancel.Enabled = true;

            //Start the training
            try
            {
                // this will hold on the execution:
                _cnnProjectHolder.CNNProject.ImgDetectionNN.TrainPattern(_cnnProjectHolder.CNNProject, Convert.ToInt32(this.txtTrainTimes.Text));
                _cnnProjectHolder.CNNProject.ImgDetectionNN.StopTraining = true; //TODO: necessary?!

                MessageBox.Show("Training of the neuronal network completed at " + DateTime.Now,
                                "Training Completed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                StaticClasses.ShowException(ex);
            }


            pnlControl.Enabled = true;
            cmdCancel.Enabled = false;

            //Reset the progress bar
            this.pbTrain.Value = 0;

        }


        /// <summary>
        /// Sets the StopTraining prop that indicates a stop of the network training
        /// </summary>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.StopTraining = true;
        }


        /// <summary>
        /// Loads network data from file
        /// </summary>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.LoadFromFile();
            UpdateNetworkStatus();
        }


        /// <summary>
        /// Serialize network to a file
        /// </summary>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.SaveToFile();
        }


        /// <summary>
        /// Resets the network with default data after confirmation
        /// </summary>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really want to reset the network?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Hand) == DialogResult.Yes) {

                        _cnnProjectHolder.CNNProject.ImgDetectionNN.InitNetwork(_cnnProjectHolder.CNNProject.ImagePatternSize);
            }

        }


        public void UpdateNetworkStatus()
        {
            this.lblNetworkStatus.Text =
                "Network Initialized: " + _cnnProjectHolder.CNNProject.ImgDetectionNN.NetworkInitialized + StaticClasses.NL +
                "Total training rounds: " + _cnnProjectHolder.CNNProject.ImgDetectionNN.TotalTrainingRounds;
        }



        /// <summary>
        /// Handles the TextChanged event of the lblTrainInfo control.
        /// </summary>
        private void lblTrainInfo_TextChanged(object sender, EventArgs e)
        {
            UpdateNetworkStatus();
        }


    }
}