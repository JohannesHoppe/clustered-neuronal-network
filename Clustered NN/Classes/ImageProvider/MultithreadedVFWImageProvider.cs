using System;
using System.Collections.Generic;
using System.Text;
using WebCamera;
using System.Windows.Forms;
using System.Threading;


namespace Clustered_NN.Classes.ImageProvider
{
    /// <summary>
    /// Provides an interface to VFW (Video for Windows)
    ///
    /// This old multimedia framework provides a fast and easy way to access WebCams and TV Cards
    /// over the 'Microsoft WDM Image Capture' driver, which provides the necessary backwards
    /// compatibility to VFW
    /// 
    /// This class relies on the WebCamera project! (which fits to TV Cards, too)
    /// </summary>
    class MultithreadedVFWImageProvider : ImageProvider
    {

        private int _frameWidth = 352;
        private int _frameHeight = 288;

        private int _time = 0;
        private bool _bRunning = false;
        private WebCameraDevice _camDevice;

        private PictureBox _pictureBox;
        private FlowLayoutPanel _pnlDeviceControl;
        private IntPtr _controlHandle;
        
        //public delegate void OnFrameDelegate(object sender, WebCameraEventArgs e);
        override public event OnFrameDelegate OnFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultithreadedVFWImageProvider"/> class.
        /// </summary>
        /// <param name="pictureBox">image that is used to display the video</param>
        /// <param name="pnlDeviceControl">a panel that will hold all device specific controls</param>
        /// <param name="controlHandle">pointer to the controlHandle of the form</param>
        public MultithreadedVFWImageProvider(PictureBox pictureBox,
                                   FlowLayoutPanel pnlDeviceControl,
                                   IntPtr controlHandle)
        {
          
            this._pictureBox = pictureBox;
            this._pnlDeviceControl = pnlDeviceControl;
            this._controlHandle = controlHandle;

            InitializeComponent();

            this._pictureBox.Width = this.FrameWidth;
            this._pictureBox.Height = this.FrameHeight;
            this._pictureBox.Image = null;
            
            WebCameraDeviceManager camManager = new WebCameraDeviceManager();
            cmbDevices.Items.AddRange(camManager.Devices);
            cmbDevices.SelectedIndex = 0;
        }


        /// <summary>
        /// required function that starts the webcam video
        /// </summary>
        override public void StartPresentation()
        {

            if (this._bRunning == false)
            {
                _camDevice = new WebCameraDevice(this.FrameWidth, this.FrameHeight, 25, cmbDevices.SelectedIndex, _controlHandle.ToInt32());
                _camDevice.OnCameraFrame += new WebCameraFrameDelegate(camDevice_OnCameraFrame);
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                _camDevice.Start();

                btnDeviceProperties.Enabled = true;
                btnStart.Text = "Stop";

                this._bRunning = true; 
            }
        }


        /// <summary>
        /// required function that stops the webcam video
        /// </summary>
        override public void StopPresentation()
        {
            if (this._bRunning == true)
            {
                _camDevice.Stop();

                btnDeviceProperties.Enabled = false;
                btnStart.Text = "Start";

                this._bRunning = false;
            }

        }


        /// <summary>
        /// Handles the Click event of the btnDevice control.
        /// shows the winodws-in-build device properties
        /// </summary>
        private void btnDeviceProperties_Click(object sender, EventArgs e)
        {
            _camDevice.ShowVideoDialog();
        }


        /// <summary>
        /// Handles the OnCameraFrame event of the camDevice control.
        /// </summary>
        void camDevice_OnCameraFrame(object sender, WebCameraEventArgs e)
        {
            // img processing: 20-30 ms
            Filters.Flip(e.Frame, false, true);
            _camDevice.Set();

            //pictureBox.Image = chkGrayScale.Checked ?
            //ImageProcessing.Filters.ToGrayScale(e.Frame) :
            //e.Frame;
            _pictureBox.Image = e.Frame;

            try
            {
                this.lblDeviceInfo.Text = "FPS: " + (1000 / (Environment.TickCount - _time)).ToString();
            }
            catch (DivideByZeroException)
            { 
                // this only happens when changing the device
            }
            _time = Environment.TickCount;


            if (OnFrame != null)
            {
                OnFrame(this, new OnFrameEventArgs(e.Frame));
            }

        }


        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// starts or stops the video
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this._bRunning == false)
            {
                StartPresentation();
            }
            else
            {
                StopPresentation();
            }
        }


        /// <summary>
        /// Gets the width of the video frame.
        /// </summary>
        /// <value>The width of the video frame.</value>
        override public int FrameWidth
        {
            // TODO: get correct frame width automatically !!            
            get
            {

                /*
                WebCameraDevice.BITMAPINFO BmpFormat = new WebCameraDevice.BITMAPINFO();
                WebCameraDevice.capSetVideoFormat(cmbDevices.SelectedIndex,
                                                  ref BmpFormat,
                                                  Microsoft.VisualBasic.Strings.Len(BmpFormat));
                 */

                return this._frameWidth;
            }
        }


        /// <summary>
        /// Gets the height of the video frame.
        /// </summary>
        /// <value>The height of the video frame.</value>
        override public int FrameHeight
        {
            // TODO: get correct frame height automatically !!            
            get
            {
                return this._frameHeight;
            }
        }


        #region Create form elements

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Button btnDeviceProperties;
        private System.Windows.Forms.Label lblDeviceInfo;
 

        /// <summary>
        /// Initializes the component. (acts like the well-known InitializeComponent from Forms)
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.btnDeviceProperties = new System.Windows.Forms.Button();
            this.lblDeviceInfo = new System.Windows.Forms.Label();

            this._pnlDeviceControl.Controls.Clear();
            this._pnlDeviceControl.Controls.Add(this.btnStart);
            this._pnlDeviceControl.Controls.Add(this.cmbDevices);
            this._pnlDeviceControl.Controls.Add(this.btnDeviceProperties);
            this._pnlDeviceControl.Controls.Add(this.lblDeviceInfo);

            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGray;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 24);
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(120, 21);

            // 
            // btnDeviceProperties
            // 
            this.btnDeviceProperties.Enabled = false;
            this.btnDeviceProperties.BackColor = System.Drawing.Color.LightGray;
            this.btnDeviceProperties.Name = "btnDeviceProperties";
            this.btnDeviceProperties.Size = new System.Drawing.Size(120, 24);
            this.btnDeviceProperties.Text = "Device";
            this.btnDeviceProperties.UseVisualStyleBackColor = false;
            this.btnDeviceProperties.Click += new System.EventHandler(this.btnDeviceProperties_Click);

            // 
            // lblDeviceInfo
            // 
            this.lblDeviceInfo.AutoSize = true;
            this.lblDeviceInfo.Location = new System.Drawing.Point(3, 214);
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            this.lblDeviceInfo.Size = new System.Drawing.Size(35, 13);
            this.lblDeviceInfo.TabIndex = 7;
            this.lblDeviceInfo.Text = "Device Info...";

        }
        #endregion

    }
}
