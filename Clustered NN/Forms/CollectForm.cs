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

        private CNNProjectHolder _cnnProjectHolder;
        private ImageProvider _imageProvider;

        private TrainForm _nextForm;


        /// <summary>
        /// Initializes a new instance of the <see cref="CollectForm"/> class.
        /// </summary>
        public CollectForm()
        {

            this._cnnProjectHolder = new CNNProjectHolder();

            if (_cnnProjectHolder.CNNProject.ExpertMode == false)
            {
                WelcomeForm welcomeForm = new WelcomeForm();
                welcomeForm.ShowDialog();
            }


            InitializeComponent();

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


            this.lvMatching.SmallImageList = this._cnnProjectHolder.CNNProject.Matching;
            this.lvNotMatching.SmallImageList = this._cnnProjectHolder.CNNProject.NotMatching;

            // formats column with to the exact needed space
            try
            {
                lvMatching.Columns[0].Width = this._cnnProjectHolder.CNNProject.ImagePatternSize.Width + 40;
                lvNotMatching.Columns[0].Width = this._cnnProjectHolder.CNNProject.ImagePatternSize.Width + 40;
            }
            catch (Exception) { }

        }


        #region form events

        /// <summary>
        /// Handles the Click event of the btnCapture control.
        /// </summary>
        private void btnCapture_Click(object sender, EventArgs e)
        {

            ListView lvUsed = (chkMatching.Checked) ? lvMatching : lvNotMatching;
            Counter counterUsed = (chkMatching.Checked) ? this._cnnProjectHolder.CNNProject.MatchingCounter : this._cnnProjectHolder.CNNProject.NotMatchingCounter;

            CaptureNewImage(lvUsed, counterUsed);
        }


        /// <summary>
        /// Open and includes a image for lvMatching
        /// </summary>
        private void openToolStripButton_Matching_Click(object sender, EventArgs e)
        {
            OpenImages(lvMatching, this._cnnProjectHolder.CNNProject.MatchingCounter);
        }


        /// <summary>
        /// Open and includes a image for lvNotMatching
        /// </summary>
        private void openToolStripButton_NotMatching_Click(object sender, EventArgs e)
        {
            OpenImages(lvNotMatching, this._cnnProjectHolder.CNNProject.NotMatchingCounter);
        }


        /// <summary>
        /// Saves the selected images from lvMatching
        /// </summary>
        private void saveToolStripButton_Matching_Click(object sender, EventArgs e)
        {
            SaveSelectedImages(lvMatching);
        }


        /// <summary>
        /// Saves the selected images from lvNotMatching
        /// </summary>
        private void saveToolStripButton_NotMatching_Click(object sender, EventArgs e)
        {
            SaveSelectedImages(lvNotMatching);
        }


        /// <summary>
        /// Deletes the selected images from lvMatching
        /// </summary>
        private void deleteToolStripButton_Matching_Click(object sender, EventArgs e)
        {
            DeleteSelectedImages(lvMatching);
        }


        /// <summary>
        /// Deletes the selected images from lvNotMatching
        /// </summary>
        private void deleteToolStripButton_NotMatching_Click(object sender, EventArgs e)
        {
            DeleteSelectedImages(lvNotMatching);
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
        /// At the moment I don't know for what I need this Event :-)
        /// </summary>
        private void ImageProvider_OnFrame(object sender, OnFrameEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// The project has changed, we have to rereference and rebuild some things
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CnnProjectHolder_ProjectChanged(object sender, EventArgs e)
        {
            this.lvMatching.SmallImageList = this._cnnProjectHolder.CNNProject.Matching;
            this.lvNotMatching.SmallImageList = this._cnnProjectHolder.CNNProject.NotMatching;

            RebuildListView(lvMatching);
            RebuildListView(lvNotMatching);
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
        }


        /// <summary>
        /// Handles the Click event of the btnNext control.
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            _imageProvider.StopPresentation();
            this.Hide();

            if (_nextForm == null || _nextForm.IsDisposed)
            {
                _nextForm = new TrainForm(_cnnProjectHolder, this);
            }

            _nextForm.Show();
            _nextForm.Focus();
        }


        #endregion


        #region image actions


        /// <summary>
        /// Captures the the current selected area in the PictureBox
        /// </summary>
        /// <param name="lvUsed">one of the both ListViews</param>
        /// <param name="counterUsed">one of the both Counters</param>
        private void CaptureNewImage(ListView lvUsed, Counter counterUsed)
        {

            try
            {
                Image selectedImage = pictureBox.GetResizedSelectedArea(_cnnProjectHolder.CNNProject.ImagePatternSize);

                string imageName = (counterUsed.Value + 1).ToString().PadLeft(4, '0');

                // !
                AddImageToList(lvUsed, selectedImage, imageName, counterUsed);

            }
            catch (RectangleDoesNotFitToImageException ex)
            {
                StaticClasses.ShowError(ex.Message);
            }
            catch (ImageNotInitializedException ex)
            {
                StaticClasses.ShowError(ex.Message);
            }
            // TODO: Do not handle errors by catching non-specific exceptions
            catch (Exception ex)
            {
                StaticClasses.ShowException(ex);
            }
        }


        /// <summary>
        /// Opens some images and includes them to the ListView and ImageList
        /// </summary>
        /// <param name="lvUsed">The lv used.</param>
        /// <param name="counterUsed">The counter used.</param>
        private void OpenImages(ListView lvUsed, Counter counterUsed)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    try
                    {
                        // uses the next free number
                        string imageName = (counterUsed.Value + 1).ToString().PadLeft(4, '0');

                        Image selectedImage = Image.FromFile(fileName);

                        // !
                        AddImageToList(lvUsed, selectedImage, imageName, counterUsed);

                    }
                    // TODO: Do not handle errors by catching non-specific exceptions
                    catch (Exception ex)
                    {
                        StaticClasses.ShowException(ex);
                    }
                }
            }
        }


        /// <summary>
        /// Adds the image to the given ListView as well to the connected ImageList
        /// called by CaptureNewImage and OpenImages
        /// </summary>
        /// <param name="lvUsed">The lv used.</param>
        /// <param name="selectedImage">The selected image.</param>
        /// <param name="imageName">Name of the image.</param>
        /// <param name="counterUsed">One of the both counters</param>
        private void AddImageToList(ListView lvUsed, Image selectedImage, string imageName, Counter counterUsed)
        {

            // first: add to ImageList
            ImageList imlUsed = lvUsed.SmallImageList;
            imlUsed.Images.Add(imageName, selectedImage);

            // second: add to ListView
            ListViewItem lvi = lvUsed.Items.Add(imageName + ".", imlUsed.Images.Count - 1);

            // not to forget, increments the counter !
            counterUsed.Increment();

            // scroll down in list (and select the last itemn, too)
            lvi.Selected = true;
            lvi.EnsureVisible();
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

                        // finally saves the image in best quality
                        ImageHandling.SaveJpeg(fileName, new Bitmap(images[i]), 100L);
                    }
                }

            } else {

                MessageBox.Show("Please select an image first!",
                                "No Selection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Deletes the selected images.
        /// </summary>
        /// <param name="lvUsed">The used ListView</param>
        private void DeleteSelectedImages(ListView lvUsed)
        {

            List<string> imageKeys = GetSelectedItemImageKeys(lvUsed);

            if (imageKeys.Count > 0)
            {

                #region imageKeysConnected
                string imageKeysConnected = "";
                foreach (string imageKey in imageKeys)
                {
                    imageKeysConnected += " '" + imageKey + "'";
                }
                imageKeysConnected = imageKeysConnected.Trim();
                #endregion

                if (MessageBox.Show(
                    "Do you really want to delete the following images from the list?" + StaticClasses.NL + imageKeysConnected,
                    "Confirm Deleting",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    ImageList imlUsed = lvUsed.SmallImageList;


                    // first: removes the stored images in the ImageList
                    foreach (string imageKey in imageKeys)
                    {
                        imlUsed.Images.RemoveByKey(imageKey);
                    }

                    // second: rebuilds list view (not nice but working!)
                    RebuildListView(lvUsed);

                }

            }
            else
            {

                MessageBox.Show("Please select an image first!",
                                "No Selection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// rebuilds list view
        /// </summary>
        private void RebuildListView(ListView lvUsed)
        {

            ImageList imlUsed = lvUsed.SmallImageList;

            lvUsed.Items.Clear();
            ListViewItem lvi = new ListViewItem();
            int max = imlUsed.Images.Count;

            for (int i = 0; i < max; i++)
            {
                lvi = lvUsed.Items.Add(imlUsed.Images.Keys[i] + ".", i);
            }


            // scroll down in list (and select the last itemn, too)
            lvi.Selected = true;
            lvi.EnsureVisible();

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



        /// <summary>
        /// Used by TrainForm to reactivate the presentation after a prev-click
        /// </summary>
        public void ImageProviderStartPresentation()
        {
            if (_imageProvider != null)
            {
                _imageProvider.StartPresentation();
            }
        }

    }
}