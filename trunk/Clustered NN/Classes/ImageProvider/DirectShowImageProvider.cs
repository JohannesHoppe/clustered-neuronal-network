using System;
using System.Collections.Generic;
using System.Text;
using WebCamera;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using DexterLib;
using System.Drawing;


namespace Clustered_NN.Classes.ImageProvider
{
    /// <summary>
    /// Provides an interface to DirectX / DirectShow
    /// 
    /// Warning: hacked in a no-sleep-lots-of-redbull-near-deadline night!
    ///
    /// This class extracts single frames from movie files which have to be
    /// supported by the installed codecs on the local machine.
    /// 
    /// Uses the managed assembly Interop.DexterLib.dll that is
    /// wrapping the qedit.dll from the DirectShow Developer Runtime.
    /// see: http://www.codeproject.com/KB/directx/picturesfrommovie.aspx
    /// </summary>
    class DirectShowImageProvider : ImageProvider
    {
        // common video format
        //private int _frameWidth = 320;
        //private int _frameHeight = 240;

        private int _frameWidth = 384;
        private int _frameHeight = 288;
        

        //private int _time = 0;
        private bool _bRunning = false;

        private PictureBox _pictureBox;
        private FlowLayoutPanel _pnlDeviceControl;

        //needed to extract pictures
        MediaDetClass md;          
        string _fileName;
        
        override public event OnFrameDelegate OnFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowImageProvider"/> class.
        /// </summary>
        /// <param name="pictureBox">image that is used to display the video</param>
        /// <param name="pnlDeviceControl">a panel that will hold all device specific controls</param>
        public DirectShowImageProvider(PictureBox pictureBox,
                                       FlowLayoutPanel pnlDeviceControl)
        {
          
            this._pictureBox = pictureBox;
            this._pnlDeviceControl = pnlDeviceControl;

            InitializeComponent();

            this._pictureBox.Width = this.FrameWidth;
            this._pictureBox.Height = this.FrameHeight;
            this._pictureBox.Image = null;

            this.trackBarTime.Enabled = false;
            this.btnBackward.Enabled = false;
            this.btnForward.Enabled = false;
        }


        /// <summary>
        /// required function that starts the video
        /// </summary>
        override public void StartPresentation()
        {

            if (this._bRunning == false)
            {

                //TODO: currently this provider just shows still images

                this._bRunning = true; 
            }
        }


        /// <summary>
        /// required function that stops the video
        /// </summary>
        override public void StopPresentation()
        {
            if (this._bRunning == true)
            {

                //TODO: currently this provider just shows still images

                this._bRunning = false;
            }

        }


        /// <summary>
        /// Handles the Click event of the btnFileOpen_Click control.
        /// opens a video file
        /// </summary>
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _fileName = dialog.FileName;

                    //create the MediaDetClass and set its properties
                    md = new MediaDetClass();
                    md.Filename = _fileName;
                    md.CurrentStream = 0;
                    int streamLength = (int)md.StreamLength;

                    
                    //fix a few Gui stuff
                    lblFileInfo.Text = Path.GetFileName(_fileName) + StaticClasses.NL
                                       + "Length: " + streamLength.ToString() + "s";

                    this.trackBarTime.Enabled = true;
                    this.btnBackward.Enabled = true;
                    this.btnForward.Enabled = true;
                    
                    trackBarTime.Minimum = 0;
                    trackBarTime.Maximum = streamLength;
                    trackBarTime.Value = 0;

                    // loads first frame into the pictureBox
                    _pictureBox.Image = CaptureFrame(trackBarTime.Value);
                
                }
                catch (Exception ex) {
                    StaticClasses.ShowException(ex);
                }
            }  
        }


        /// <summary>
        /// Handles the ValueChanged event of the trackBar1 control.
        /// refreshes to pictureBox
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void trackBarTime_ValueChanged(object sender, System.EventArgs e)
        {
            // nothing to do if no video was loaded
            if (md == null)
            {
                return;
            }

            _pictureBox.Image.Dispose();
            lblFileInfo.Text = "Cur Pos: " + trackBarTime.Value.ToString() + StaticClasses.NL + " ";

            _pictureBox.Image = CaptureFrame(trackBarTime.Value);
        }


        /// <summary>
        /// goes one second backward
        /// </summary>
        private void btnBackward_Click(object sender, System.EventArgs e)
        {
            if (trackBarTime.Value >= trackBarTime.Minimum + 1)
            {
                trackBarTime.Value = trackBarTime.Value - 1;
            }
        }

        /// <summary>
        /// goes one second forward
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnForward_Click(object sender, System.EventArgs e)
        {
            if (trackBarTime.Value <= trackBarTime.Maximum - 1)
            {
                trackBarTime.Value = trackBarTime.Value + 1;
            }
        }


        /// <summary>
        /// Retrieves a video frame at the specified media time (and writes it to a temp file)
        /// </summary>
        /// <remarks>
        /// GetBitmapBits would be nicer, but is harder to handle
        /// see: http://www.codeproject.com/KB/graphics/ExtractVideoFrames.aspx
        /// see: http://www.informikon.com/blog/using-imediadet-getbitmapbits-in-c.html
        /// see: http://www.half-lime.com/faq/?fid=ad7406b6-5a86-458c-abf3-e42c92e3d637
        /// </remarks>
        /// <returns>captured frame</returns>
        private Image CaptureFrame(double streamTime)
        {
            string tmpFileName = Application.StartupPath + "\\tmp.bmp";
            md.WriteBitmapBits(streamTime, _frameWidth, _frameHeight, tmpFileName);
            Image img = new Bitmap(tmpFileName);

            // does not work, since other process hasn't released it
            //File.Delete(tmpFileName);

            return img;
        }


        /// <summary>
        /// Handles the OnCameraFrame event of the camDevice control.
        /// </summary>
        void camDevice_OnCameraFrame(object sender, WebCameraEventArgs e)
        {

            // TODO:
            _pictureBox.Image = e.Frame;

            if (OnFrame != null)
            {
                OnFrame(this, new OnFrameEventArgs(e.Frame));
            }

            throw new NotImplementedException();

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

        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.FlowLayoutPanel pnlMediaControls;

 

        /// <summary>
        /// Initializes the component. (acts like the well-known InitializeComponent from Forms)
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.pnlMediaControls = new System.Windows.Forms.FlowLayoutPanel();


            this._pnlDeviceControl.Controls.Clear();
            this._pnlDeviceControl.Controls.Add(this.btnFileOpen);
            this._pnlDeviceControl.Controls.Add(this.lblFileInfo);
            this._pnlDeviceControl.Controls.Add(this.trackBarTime);
            this._pnlDeviceControl.Controls.Add(this.pnlMediaControls);

            this.pnlMediaControls.Controls.Add(this.btnBackward);
            this.pnlMediaControls.Controls.Add(this.btnForward);


            // btnStart
            // 
            this.btnFileOpen.BackColor = System.Drawing.Color.LightGray;
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(120, 24);
            this.btnFileOpen.Text = "Open File";
            this.btnFileOpen.UseVisualStyleBackColor = false;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);

            // 
            // lblFileInfo
            // 
            this.lblFileInfo.AutoSize = true;
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(35, 13);
            this.lblFileInfo.Text = " " + StaticClasses.NL + "Choose a video file!";

            // trackBarTime
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(120, 45);
            this.trackBarTime.ValueChanged += new System.EventHandler(this.trackBarTime_ValueChanged);

            //
            // pnlMediaControls
            //
            this.pnlMediaControls.Name = "pnlMediaControls";
            this.pnlMediaControls.Padding = new Padding(0);
            this.pnlMediaControls.Margin = new Padding(0);
            this.pnlMediaControls.Size = new System.Drawing.Size(120, 30);


            // 
            // backward
            // 
            this.btnBackward.BackColor = System.Drawing.Color.LightGray;
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(40, 24);
            this.btnBackward.Text = "<";
            this.btnBackward.UseVisualStyleBackColor = false;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnBackward, "one second backward");

            // 
            // forward
            // 
            this.btnForward.BackColor = System.Drawing.Color.LightGray;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(40, 24);
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);

            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.btnForward, "one second forward");

        }
        #endregion

    }
}
