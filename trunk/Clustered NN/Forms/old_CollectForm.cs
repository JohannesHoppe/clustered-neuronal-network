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
    /// <summary>
    /// This form is shown in the first step
    /// immages are collected
    /// </summary>
    public partial class old_CollectForm : Form
    {
        private ImageProvider _imageProvider;
        private MainForm _parentForm;
        private CNNProject _cnnProject;

        public old_CollectForm()
        {
            InitializeComponent();
        }

        public old_CollectForm(MainForm parentForm, CNNProject cnnProject)
        {
            InitializeComponent();

            this._parentForm = parentForm;
            this._cnnProject = cnnProject;

            this._imageProvider = new MultithreadedVFWImageProvider(

                this.pictureBox,
                this.pnlDeviceControl,
                this.Handle
                
            );

            this._imageProvider.OnFrame += new ImageProvider.OnFrameDelegate(ImageProvider_OnFrame);
            this._imageProvider.StartPresentation();

            // adjust storable size
            imlMatching.ImageSize = _cnnProject.ImagePatternSize;
            imlNotMatching.ImageSize = _cnnProject.ImagePatternSize;

            try
            {
                lvMatching.Columns[0].Width = _cnnProject.ImagePatternSize.Width + 20;
                lvNotMatching.Columns[0].Width = _cnnProject.ImagePatternSize.Width + 20;
            }
            catch (Exception) { }

        }

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
        /// Handles the Click event of the btnCursor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCursor_Click(object sender, EventArgs e)
        {
            ImageList imlUsed = (chkMatching.Checked) ? imlMatching : imlNotMatching;
            ListView lvUsed = (chkMatching.Checked) ? lvMatching : lvNotMatching;

            Image selectedImage;

            try
            {
                selectedImage = pictureBox.GetResizedSelectedArea(_cnnProject.ImagePatternSize);

                // makes an image easier identifiable
                selectedImage = ImageHandling.GeneralizeImage(selectedImage);


                imlUsed.Images.Add(selectedImage);
                ListViewItem lvi = lvUsed.Items.Add(imlUsed.Images.Count.ToString() + ".", imlUsed.Images.Count - 1);


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


    }
}