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
        private CNNProject _cnnProject;


        public CNNProjectHolder()
        {
            _cnnProject = new CNNProject();
        }


        public CNNProject CNNProject
        {
            get { return _cnnProject; }
            set { _cnnProject = value; }
        }

        #region Project Saving
        
        /// <summary>
        /// Saves the containing project to file
        /// </summary>
        public void Save()
        {
            try
            {

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.SupportMultiDottedExtensions = true;
                dialog.Filter = "Project Zip Files|*.proj.zip";
                dialog.DefaultExt = "proj.zip";
                dialog.FileName = "default.proj.zip";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = File.OpenWrite(dialog.FileName);
                    ZipOutputStream zip = new ZipOutputStream(fileStream);

                    // 0 [no] - 9 [highest]
                    zip.SetLevel(9);


                    ImageListToZip(CNNProject.Matching, zip, "Matching");
                    ImageListToZip(CNNProject.NotMatching, zip, "NotMatching");
                    NetworkToZip(CNNProject.ImgDetectionNN.Network, zip);
                    ProjectToZip(CNNProject, zip);


                    zip.Finish();
                    zip.Close();

                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                StaticClasses.ShowException(ex);
            }

        }


        /// <summary>
        /// For each image in the list a zip entry (png) is created
        /// </summary>
        /// <param name="imlUsed">The used imagelist</param>
        /// <param name="zip">The zip stream</param>
        /// <param name="path">The path within the zip file</param>
        private static void ImageListToZip(ImageList imlUsed, ZipOutputStream zip, string path)
        {

            int max = imlUsed.Images.Count;
            for (int i = 0; i < max; i++)
            {

                byte[] buffer = ImageHandling.ConvertImageToByteArray(imlUsed.Images[i], ImageFormat.Png);

                PutZipEntry(zip, buffer, path + "\\" + imlUsed.Images.Keys[i] + ".png");
                
            }
        }


        /// <summary>
        /// BrainNet network object to zip stream
        /// </summary>
        /// <param name="network">The network.</param>
        /// <param name="zip">The zip stream<param>
        private static void NetworkToZip(INeuralNetwork network, ZipOutputStream zip)
        {
            
            // in this case we have to use a temp file
            string tempFileName = System.IO.Path.GetTempFileName();
            NetworkSerializer serializer = new NetworkSerializer();
            serializer.SaveNetwork(tempFileName, network);


            FileStream fileStream = File.OpenRead(tempFileName);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            PutZipEntry(zip, buffer, "network.cnn.xml");
            fileStream.Close();


            // cleans up
            File.Delete(tempFileName);

        }


        /// <summary>
        /// Project object to zip stream
        /// </summary>
        /// <param name="cnnProject">The CNNProject</param>
        /// <param name="zip">The zip stream</param>
        private static void ProjectToZip(CNNProject cnnProject, ZipOutputStream zip)
        {

            byte[] buffer;
            using (MemoryStream stream = new MemoryStream())
            {
                new SoapFormatter().Serialize(stream, cnnProject);
                buffer = stream.GetBuffer();
            }

            PutZipEntry(zip, buffer, "default.proj.xml");
        }


        /// <summary>
        /// Puts a byte buffer as a new zip entry to the zip stream
        /// </summary>
        /// <param name="zip">The zip stream</param>
        /// <param name="buffer">The byte buffer.</param>
        /// <param name="entryName">Name of the entry.</param>
        private static void PutZipEntry(ZipOutputStream zip, byte[] buffer, string entryName)
        {
            ZipEntry entry = new ZipEntry(entryName);
            
            //avoids a 'this file is not in the standard Zip 2.0 format' error in WinZip
            entry.Size = buffer.Length; 
            
            zip.PutNextEntry(entry);
            zip.Write(buffer, 0, buffer.Length);
        }

        #endregion
    
    }
}
