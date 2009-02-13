using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Clustered_NN.Classes;
using System.Threading;
using Clustered_NN.Classes.ImageProvider;

namespace Clustered_NN.Forms
{
    public partial class DetectForm : Form
    {
        /// <summary>
        /// holds the imported form elemets,
        /// you also need following controls: lblTooltip + pnlContentHolder !
        /// </summary>
        private ToolStripContainer _toolStripContainer = new ToolStripContainer();

        private CNNProjectHolder _cnnProjectHolder;
        private ImageProvider _imageProvider;
        
        private TrainForm _parentForm;



        /// <summary>
        /// Initializes a new instance of the <see cref="DetectForm"/> class.
        /// </summary>
        public DetectForm(CNNProjectHolder cnnProjectHolder, TrainForm parentForm)
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

            this.cmbImageProvider.Items.AddRange(ImageProvider.GetAvailableProviders());
            this.cmbImageProvider.SelectedIndex = 0;


            this._cnnProjectHolder.ProjectChanged += new CNNProjectHolder.ProjectChangedDelegate(CnnProjectHolder_ProjectChanged);

        }


        /// <summary>
        /// closes the parentForm
        /// </summary>
        private void DetectForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (_imageProvider != null)
            {
                _imageProvider.StopPresentation();
            }

            _parentForm.Close();

        }


        /// <summary>
        /// shows the parentForm
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (_imageProvider != null)
            {
                _imageProvider.StopPresentation();
            }

            this.Hide();

            _parentForm.Show();

        }


        /// <summary>
        /// The project has changed, we have to re-reference and rebuild some things
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CnnProjectHolder_ProjectChanged(object sender, EventArgs e)
        {
            // nothing to do
        }


        /// <summary>
        /// ...
        /// </summary>
        private void ImageProvider_OnFrame(object sender, OnFrameEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// Used by TrainForm to reactivate the presentation after a next-click
        /// </summary>
        public void ImageProviderStartPresentation()
        {
            if (_imageProvider != null)
            {
                _imageProvider.StartPresentation();
            }
        }


        /// <summary>
        /// Handles the Click event of the btnStartScan control.
        /// </summary>
        private void btnStartScan_Click(object sender, EventArgs e)
        {

            _cnnProjectHolder.CNNProject.ImgDetectionNN.StartDetectPattern(
                pictureBox,
                _cnnProjectHolder.CNNProject.ImagePatternSize,
                currentImage,
                currentImageSmall);

            threadListRefreshTimer.Start();


        }


        /// <summary>
        /// Rebuilds the threadList 
        /// </summary>
        public void RefreshThreadList()
        {
            threadList.Clear();

            foreach (ImageDetectionNeuralNetwork_DetectThreadWork threadWork in _cnnProjectHolder.CNNProject.ImgDetectionNN.ThreadWorkList)
            {
                threadList.Items.Add(
                       threadWork.Name + " (Loops " + threadWork.CurrentLoop + "/" + threadWork.TotalLoops + ")"
                    + (threadWork.Match ? 
                        "- MATCHED at Point " + threadWork.ObservedArea.X + " / " + threadWork.ObservedArea.Y
                        : "")             
                );
            }

            threadList.Invalidate();
        }


        /// <summary>
        /// Handles the Tick event of the threadListRefreshTimer control.
        /// Calls RefreshThreadList
        /// </summary>
       private void threadListRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshThreadList();
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbImageProvider control.
        /// Initialises the different ImageProviders
        /// </summary>
        /// <remarks>
        /// same function as in CollectForm.cs
        /// </remarks>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cmbImageProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this._imageProvider != null)
            {
                this._imageProvider.StopPresentation();
            }

            // our favourite provider - webcam & tv-cards
            if (cmbImageProvider.SelectedIndex == 0)
            {
                this._imageProvider = new MultithreadedVFWImageProvider(
                    this.pictureBox,
                    this.pnlDeviceControl,
                    this.Handle
                );
            }
            else if (cmbImageProvider.SelectedIndex == 1)
            {
                this._imageProvider = new DirectShowImageProvider(
                    this.pictureBox,
                    this.pnlDeviceControl
                );
            }

            // whoops!
            else
            {
                throw new NotImplementedException("No code was defined for the ImageProvider with the number " + cmbImageProvider.SelectedIndex + "!");

            }

            this._imageProvider.OnFrame += new ImageProvider.OnFrameDelegate(ImageProvider_OnFrame);
            this._imageProvider.StartPresentation();
        }



    }
}