using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Clustered_NN.Classes;
using System.Threading;

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

            this._imageProvider = new MultithreadedVFWImageProvider(

                this.pictureBox,
                this.pnlDeviceControl,
                this.Handle

            );

            this._imageProvider.OnFrame += new ImageProvider.OnFrameDelegate(ImageProvider_OnFrame);
            this._imageProvider.StartPresentation();


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
        /// The project has changed, we have to rereference and rebuild some things
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

            foreach (ImageDetectionNeuralNetworkThreadWork threadWork in _cnnProjectHolder.CNNProject.ImgDetectionNN.ThreadWorkList)
            {
                threadList.Items.Add(threadWork.Name + " (" + threadWork.CurrentLoop + "/" + threadWork.TotalLoops + ")"
                    + (threadWork.Match ? "- MATCHED!" : "")
                
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



    }
}