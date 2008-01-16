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

            // formats column with to the exact needed space
            try
            {
                lvMatching.Columns[0].Width = this._cnnProject.ImagePatternSize.Width + 40;
                lvNotMatching.Columns[0].Width = this._cnnProject.ImagePatternSize.Width + 40;
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
        private void btnCapture_Click(object sender, EventArgs e)
        {

            ListView lvUsed = (chkMatching.Checked) ? lvMatching : lvNotMatching;
            CNNProject.Counter counterUsed = (chkMatching.Checked) ? this._cnnProject.MatchingCounter : this._cnnProject.NotMatchingCounter;

            CaptureNewImage(lvUsed, counterUsed);
        }


        /// <summary>
        /// Handles the Click event of the openToolStripButton_Matching control.
        /// </summary>
        private void openToolStripButton_Matching_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                foreach (string fileName in openFileDialog.FileNames)
                {
                    throw new NotImplementedException("Tara!!");
                }
            }

        }


        private void saveToolStripButton_Matching_Click(object sender, EventArgs e)
        {
            ImageList imlUsed = this._cnnProject.Matching;
            ListView lvUsed = lvMatching;

            SaveSelectedImages(lvUsed);
        }


        #region image actions


        /// <summary>
        /// Captures the the current selected area in the PictureBox
        /// </summary>
        /// <param name="lvUsed">one of the both ListViews</param>
        /// <param name="counterUsed">one of the both Counters</param>

        private void CaptureNewImage(ListView lvUsed, CNNProject.Counter counterUsed)
        {
            
            ImageList imlUsed = lvUsed.SmallImageList;

            try
            {
                Image selectedImage = pictureBox.GetResizedSelectedArea(_cnnProject.ImagePatternSize);

                // makes the image easier identifiable
                selectedImage = ImageHandling.GeneralizeImage(selectedImage);


                string imageName = (counterUsed.Value + 1).ToString().PadLeft(3, '0');

                imlUsed.Images.Add(imageName, selectedImage);

                ListViewItem lvi = lvUsed.Items.Add(
                    imageName + ".",
                    imlUsed.Images.Count - 1);


                // not to forget, increments the counter
                counterUsed.Increment();

                // scroll down in list (and select the last itemn, too)
                lvi.Selected = true;
                lvi.EnsureVisible();

            }
            catch (RectangleDoesNotFitToImageException ex)
            {
                StaticClasses.ShowError(ex.Message);
            }
            catch (ImageNotInitializedException ex)
            {
                StaticClasses.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                StaticClasses.ShowException(ex);
            }
        }


        /// <summary>
        /// Saves the selected images.
        /// </summary>
        /// <param name="lvUsed">The used ListView</param>
        private void SaveSelectedImages(ListView lvUsed)
        {

            List<string> imageKeys = GetSelectedItemImageKeys(lvUsed);

            if (imageKeys.Count > 0) {

                // just asks for the first file name
                saveFileDialog.FileName = imageKeys[0].ToString() + ".jpg";


                // Save was pressed
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    List<Image> images = GetSelectedItemImages(lvUsed);

                    for(int i = 0; i < images.Count; i++)
                    {

                        string fileName;

                        // first time: we use the provided name
                        if (i == 0)
                        {
                            fileName = saveFileDialog.FileName;
                        }
                        // second time: we use the counting number
                        else
                        {
                            string path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                            fileName = path + "\\" + imageKeys[i].ToString() + ".jpg";
                        }


                        ImageHandling.SaveJpeg(
                           fileName,
                           new Bitmap(images[i]),
                           0);
                    }
                }

            } else {

                MessageBox.Show("Please select an image file first!",
                                "No Selection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
               
        }


        /// <summary>
        /// Gets the selected image keys of the selected items in the list
        /// </summary>
        /// <param name="lvUsed">The listView</param>
        /// <returns>the keys</returns>
        private List<string> GetSelectedItemImageKeys(ListView lvUsed)
        {

            List<string> imageKeys = new List<string>();

            ImageList imlUsed = lvUsed.SmallImageList;
            ListView.SelectedListViewItemCollection collection = lvUsed.SelectedItems;

            foreach (ListViewItem item in collection)
            {
                int imageIndex = item.ImageIndex;
                imageKeys.Add(imlUsed.Images.Keys[imageIndex]);
            }

            return imageKeys;
        }


        /// <summary>
        /// Gets the selected images of the selected items in the list
        /// </summary>
        /// <param name="lvUsed">The listView</param>
        /// <returns>the images</returns>
        private List<Image> GetSelectedItemImages(ListView lvUsed)
        {

            List<Image> images = new List<Image>();

            ImageList imlUsed = lvUsed.SmallImageList;
            ListView.SelectedListViewItemCollection collection = lvUsed.SelectedItems;
            foreach (ListViewItem item in collection)
            {
                int imageIndex = item.ImageIndex;
                images.Add(imlUsed.Images[imageIndex]);
            }

            return images;
        }
           

        #endregion





    }
}