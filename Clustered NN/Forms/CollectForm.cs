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
    public partial class CollectForm : Form
    {
        /// <summary>
        /// holds the imported form elemets,
        /// you also need following controls: lblTooltip + pnlContentHolder !
        /// </summary>
        private ToolStripContainer _toolStripContainer = new ToolStripContainer();

        private MainForm _parentForm;
        private CNNProject _cnnProject;
        private ImageProvider _imageProvider;


        public CollectForm()
        {
            InitializeComponent();

            MasterFormContents.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder);
        }


        /// <summary>
        /// This constructor should be used!
        /// </summary>
        /// <param name="parentForm">The parent form.</param>
        /// <param name="cnnProject">The CNN project.</param>
        public CollectForm(MainForm parentForm, CNNProject cnnProject) : this()
        {
            this._parentForm = parentForm;
            this._cnnProject = cnnProject;
            this._imageProvider = new MultithreadedVFWImageProvider(

                this.pictureBox,
                this.pnlDeviceControl,
                this.Handle
                
            );

            this._imageProvider.OnFrame += new ImageProvider.OnFrameDelegate(ImageProvider_OnFrame);
            this._imageProvider.StartPresentation();


            this.lvMatching.SmallImageList = this._cnnProject.Matching;
            this.lvNotMatching.SmallImageList = this._cnnProject.NotMatching;

            try
            {
                lvMatching.Columns[0].Width = this._cnnProject.ImagePatternSize.Width + 20;
                lvNotMatching.Columns[0].Width = this._cnnProject.ImagePatternSize.Width + 20;
            }
            catch (Exception) { }

        }


        /// <summary>
        /// At the moment I don't know for what I need this Event
        /// </summary>
        private void ImageProvider_OnFrame(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// Stops the video if the form isn't available anymore
        /// </summary>
        private void CollectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_imageProvider != null)
            {
                _imageProvider.StopPresentation();
            }

            _parentForm.Close();
        }


        #region checkbox toggle
        /// <summary>
        /// toggles beetwen chkMatching and chkNotMatching
        /// </summary>
        private void chkMatching_CheckedChanged(object sender, EventArgs e)
        {
            chkNotMatching.Checked = !chkMatching.Checked;
            ChangeButtonColors();
        }


        /// <summary>
        /// toggles beetwen chkMatching and chkNotMatching
        /// </summary>
        private void chkNotMatching_CheckedChanged(object sender, EventArgs e)
        {
            chkMatching.Checked = !chkNotMatching.Checked;
            ChangeButtonColors();
        }


        /// <summary>
        /// Changes the colors of chkMatching and chkNotMatching
        /// </summary>
        private void ChangeButtonColors()
        {
            Color shinyGray = Color.FromArgb(245, 245, 245);

            chkMatching.BackColor = (chkMatching.Checked) ? Color.LightGray : shinyGray;
            chkNotMatching.BackColor = (chkNotMatching.Checked) ? Color.LightGray : shinyGray;
        }
        #endregion


        /// <summary>
        /// Handles the Click event of the btnCapture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCapture_Click(object sender, EventArgs e)
        {
            ImageList imlUsed = (chkMatching.Checked) ? this._cnnProject.Matching : this._cnnProject.NotMatching;
            ListView lvUsed = (chkMatching.Checked) ? lvMatching : lvNotMatching;

            Image selectedImage;

            try
            {
                selectedImage = pictureBox.GetResizedSelectedArea(_cnnProject.ImagePatternSize);

                // makes an image easier identifiable
                selectedImage = ImageHandling.GeneralizeImage(selectedImage);


                string imageName = (imlUsed.Images.Count + 1).ToString() + ".";

                imlUsed.Images.Add(imageName, selectedImage);

                ListViewItem lvi = lvUsed.Items.Add(
                    imageName,
                    imlUsed.Images.Count - 1);


                // scroll down in list
                lvi.Selected = true;
                lvi.EnsureVisible();

            }
            catch (RectangleDoesNotFitToImageException ex)
            {
                StaticClasses.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                StaticClasses.ShowException(ex);
            }
        }

        private void openToolStripButton_Matching_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            foreach (string fileName in openFileDialog.FileNames)
            {
                throw new NotImplementedException("Tara!!");
            }
            
        }


    }
}