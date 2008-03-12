using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using ICSharpCode.SharpZipLib.Zip;
using System.Drawing;
using System.Drawing.Imaging;
using BrainNet.NeuralFramework;


namespace Clustered_NN.Classes
{
    /// <summary>
    /// This class is used to easily change the project
    /// without struggling with wrong references
    /// </summary>
    public class CNNProjectHolder
    {
        
        // config                                   
        private string _defaultProjectFileName = "project.cnn.zip";
        private string _defaultNetworkFileName = "network.cnn.xml";

        private string _defaultProjectFileExt = "cnn.zip";
        private string _defaultNetworkFileExt = "cnn.xml";

        private string _defaultProjectFileFilter = "Project Zip Files|*.cnn.zip";
        private string _defaultNetworkFileFilter = "Clustered NN XML Files|*.cnn.xml";

        private string _internZipProjectFileName = "project.xml";

        // config        


        private string _projectFileName = null;
        
        private bool _projectIsSaved = false;
        // not used at the moment
        private CNNProject _cnnProject;

        
        // used by the forms to reset their content
        public delegate void ProjectChangedDelegate(object sender, EventArgs e);
        public event ProjectChangedDelegate ProjectChanged;


        public CNNProjectHolder()
        {
            _cnnProject = new CNNProject();
        }


        public CNNProject CNNProject
        {
            get { return _cnnProject; }
            set { _cnnProject = value; }
        }

        #region a lot of properties

        public string DefaultProjectFileName
        {
            get { return _defaultProjectFileName; }
        }

        public string DefaultNetworkFileName
        {
            get { return _defaultNetworkFileName; }
        }

        public string DefaultProjectFileExt
        {
            get { return _defaultProjectFileExt; }
        }

        public string DefaultNetworkFileExt
        {
            get { return _defaultNetworkFileExt; }
        }

        public string DefaultProjectFileFilter
        {
            get { return _defaultProjectFileFilter; }
        }

        public string DefaultNetworkFileFilter
        {
            get { return _defaultNetworkFileFilter; }
        }

        public string ProjectFileName
        {
            get { return _projectFileName; }
            set { _projectFileName = value; }
        }

        public bool ProjectIsSaved
        {
            get { return _projectIsSaved; }
            set { _projectIsSaved = value; }
        }

        #endregion


        /// <summary>
        /// Saves the containing project to file and shows a SaveFileDialog
        /// </summary>
        public void SaveFileAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = this.DefaultProjectFileFilter;
            dialog.DefaultExt = this.DefaultProjectFileExt;

            if (this._projectFileName != null)
            {
                dialog.FileName = this._projectFileName;
            }
            else
            {
                dialog.FileName = this.DefaultProjectFileName;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile(dialog.FileName);
                this._projectFileName = dialog.FileName;
            }
        }


        /// <summary>
        /// Saves the containing project to file and shows a SaveFileDialog
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void SaveFile(string fileName)
        {
            try
            {

                Stream fileStream = File.OpenWrite(fileName);
                ZipOutputStream zip = new ZipOutputStream(fileStream);

                // 0 [no] - 9 [highest]
                zip.SetLevel(9);


                ZipFileEntry.ImageListToZip(CNNProject.Matching, zip, "Matching");
                ZipFileEntry.ImageListToZip(CNNProject.NotMatching, zip, "NotMatching");
                ZipFileEntry.NetworkToZip(CNNProject.ImgDetectionNN.Network, zip, this.DefaultNetworkFileName);
                ZipFileEntry.ProjectToZip(CNNProject, zip, this._internZipProjectFileName);


                zip.Finish();
                zip.Close();

                fileStream.Close();

            }
            catch (Exception ex)
            {
                StaticClasses.ShowException(ex);
            }
        }


        /// <summary>
        /// Opens a project from file
        /// </summary>
        public void Open()
        {
            try
            {
                // stops the training, if it is still running
                CNNProject.ImgDetectionNN.StopTraining = true;
                CNNProject.ImgDetectionNN.StopTrainingSilently = true;


                OpenFileDialog dialog = new OpenFileDialog();
                dialog.SupportMultiDottedExtensions = true;
                dialog.Filter = this.DefaultProjectFileFilter;
                dialog.DefaultExt = this.DefaultProjectFileExt;
                dialog.FileName = "*." + this.DefaultProjectFileExt;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = File.OpenRead(dialog.FileName);
                    ZipInputStream zip = new ZipInputStream(fileStream);

                    // temp vars
                    List<TmpImageListItem> tmpImageList = new List<TmpImageListItem>();
                    CNNProject tmpCNNProject = null;
                    INeuralNetwork tmpNetwork = null;

                    ZipEntry entry;
                    while ((entry = zip.GetNextEntry()) != null)
                    {
                        ZipFileEntry zipFileEntry = new ZipFileEntry(zip, entry);

                        
                        if (zipFileEntry.IsImage)
                        {
                            tmpImageList.Add(new TmpImageListItem(zipFileEntry.GetImage(), zipFileEntry.FileNameWithoutExtension, zipFileEntry.DirectoryName));
                        }
                        else if (zipFileEntry.FileName == this._internZipProjectFileName)
                        {
                            tmpCNNProject = zipFileEntry.GetProject();

                        }
                        else if (zipFileEntry.FileName == this.DefaultNetworkFileName)
                        {    
                            tmpNetwork = zipFileEntry.GetNetwork();
                        }


                    }

                    zip.Close();
                    fileStream.Close();


                    if (tmpCNNProject != null && tmpNetwork != null)
                    {
                        // now we have everything together, so we can rebuild the project
                        _cnnProject = tmpCNNProject;
                        _cnnProject.ResetNonSerializableAttributes();
                        _cnnProject.ImgDetectionNN.Network = tmpNetwork;

                        // adds images
                        foreach (TmpImageListItem item in tmpImageList)
                        {
                            if (item.Directory == "Matching")
                            {
                                _cnnProject.Matching.Images.Add(item.Name, item.Image);
                            }
                            else if (item.Directory == "NotMatching")
                            {
                                _cnnProject.NotMatching.Images.Add(item.Name, item.Image);
                            }

                        }


                        // fires the event
                        if (ProjectChanged != null)
                        {
                            ProjectChanged(this, new EventArgs());
                        }
                    }
                    else
                    {
                        MessageBox.Show("This zip file does not contains all necessary items!",
                                        "Zip Project File Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                StaticClasses.ShowException(ex);
            }

        }


        /// <summary>
        /// just holds an image from the zip file temporarily
        /// </summary>
        private class TmpImageListItem
        {
            private Image _image;
            private string _name;

            public TmpImageListItem(Image image, string name, string directory)
            {
                _image = image;
                _name = name;
                _directory = directory;
            }

            public Image Image
            {
                get { return _image; }
                set { _image = value; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private string _directory;

            public string Directory
            {
                get { return _directory; }
                set { _directory = value; }
            }
	
	    }



    }
}


