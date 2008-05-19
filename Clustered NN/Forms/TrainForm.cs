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
        /// <summary>
        /// holds the imported form elements,
        /// you also need following controls: lblTooltip + pnlContentHolder !
        /// </summary>
        private ToolStripContainer _toolStripContainer = new ToolStripContainer();

        private CNNProjectHolder _cnnProjectHolder;
        
        private CollectForm _parentForm;
        private DetectForm _nextForm;


        /// <summary>
        /// Initializes a new instance of the <see cref="TrainForm"/> class.
        /// </summary>
        /// <param name="cnnProjectHolder">The CNN project holder.</param>
        /// <param name="parentForm">The parent form.</param>
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

            this._cnnProjectHolder.ProjectChanged += new CNNProjectHolder.ProjectChangedDelegate(CnnProjectHolder_ProjectChanged);

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


        /// <summary>
        /// Handles the Click event of the btnPrev control.
        /// stops training, hides form, goes back to CollectForm
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.StopTraining = true; // important!
            this.Hide();

            _parentForm.Show();
            _parentForm.ImageProviderStartPresentation();
        }


        /// <summary>
        /// Handles the Click event of the btnNext control.
        /// stops training, hides form, goes to further to DetectForm
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.StopTraining = true; // important!
            this.Hide();

            if (_nextForm == null || _nextForm.IsDisposed)
            {
                _nextForm = new DetectForm(_cnnProjectHolder, this);
            }

            _nextForm.Show();
            _nextForm.Focus();

            _nextForm.ImageProviderStartPresentation();
        }


        /// <summary>
        /// The project has changed, we have to re-reference and rebuild some things
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CnnProjectHolder_ProjectChanged(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.SetVars(pbTrain, lblTrainInfo);
            UpdateNetworkStatus();
            lblTrainStart.Text = "";
            lblTrainInfo.Text = "";
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
            _cnnProjectHolder.CNNProject.ImgDetectionNN.LoadFromFile(_cnnProjectHolder.DefaultNetworkFileFilter);
            UpdateNetworkStatus();
        }


        /// <summary>
        /// Serialize network to a file
        /// </summary>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            _cnnProjectHolder.CNNProject.ImgDetectionNN.SaveToFile(
                _cnnProjectHolder.DefaultNetworkFileFilter,
                _cnnProjectHolder.DefaultNetworkFileExt,
                _cnnProjectHolder.DefaultNetworkFileName);
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

                lblTrainStart.Text = "Training not started";
                lblTrainInfo.Text = "Network initialized";
            }

        }


        /// <summary>
        /// Changes the text in lblNetworkStatus
        /// </summary>
        public void UpdateNetworkStatus()
        {
            this.lblNetworkStatus.Text =
                "Network Initialized: " + _cnnProjectHolder.CNNProject.ImgDetectionNN.NetworkInitialized + StaticClasses.NL +
                "Total training rounds: " + _cnnProjectHolder.CNNProject.ImgDetectionNN.TotalTrainingRounds;
        }


        /// <summary>
        /// Handles the TextChanged event of the lblTrainInfo control.
        /// calls the UpdateNetworkStatus
        /// </summary>
        private void lblTrainInfo_TextChanged(object sender, EventArgs e)
        {
            UpdateNetworkStatus();
        }


    }
}