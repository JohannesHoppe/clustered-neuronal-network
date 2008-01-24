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

        private CNNProject _cnnProject;
        private CollectForm _parentForm;

        private ToolStripContainer _toolStripContainer = new ToolStripContainer();


        public TrainForm(CNNProject cnnProject, CollectForm parentForm)
        {
            this._cnnProject = cnnProject;
            this._parentForm = parentForm;
            
            InitializeComponent();

            MasterForm.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder);
        }


        /// <summary>
        /// Stops the training and closes the parentForm
        /// </summary>
        private void TrainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cnnProject.ImgDetectionNN.StopTraining = true; // important!
            _parentForm.Close();
        }


        /// <summary>
        /// Sets needed form vars for the NN
        /// </summary>
        private void TrainForm_Load(object sender, EventArgs e)
        {
            _cnnProject.ImgDetectionNN.SetVars(this.pbTrain, this.lblTrainInfo);
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
                _cnnProject.ImgDetectionNN.TrainPattern(_cnnProject, Convert.ToInt32(this.txtTrainTimes.Text));

                _cnnProject.ImgDetectionNN.StopTraining = true; //TODO: necessary?!

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
            _cnnProject.ImgDetectionNN.StopTraining = true;
        }


        /// <summary>
        /// Loads network data from file
        /// </summary>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            _cnnProject.ImgDetectionNN.LoadFromFile();
        }


        /// <summary>
        /// Serialize network to a file
        /// </summary>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            _cnnProject.ImgDetectionNN.SaveToFile();
        }

    }
}