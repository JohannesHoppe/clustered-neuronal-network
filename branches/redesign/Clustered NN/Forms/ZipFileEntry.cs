using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using ICSharpCode.SharpZipLib.Zip;
using System.Drawing;
using System.Windows.Forms;
using BrainNet.NeuralFramework;
using System.IO;
using System.Drawing.Imaging;

namespace Clustered_NN.Classes
{
    public class ZipFileEntry
    {

        private byte[] _buffer;
        private string _path;


        public ZipFileEntry(ZipInputStream zip, ZipEntry entry)
        {
            _path = entry.Name;
            _buffer = new byte[zip.Length];
            zip.Read(_buffer, 0, _buffer.Length);
        }


        #region Properties

        /// <summary>
        /// Contains the data of the entry
        /// </summary>
        /// <value>The buffer.</value>
        public byte[] Buffer
        {
            get { return _buffer; }
            set { _buffer = value; }
        }


        /// <summary>
        /// Full path of the entry (DirectoryName + FileName)
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get { return _path; }
        }


        /// <summary>
        /// Gets the name of the entries directory within the zip file
        /// </summary>
        /// <value>The name of the directory.</value>
        public string DirectoryName
        {
            get { return System.IO.Path.GetDirectoryName(_path); }
        }


        /// <summary>
        /// Gets the name of the entries file name within the zip file
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get { return System.IO.Path.GetFileName(_path); }
        }


        /// <summary>
        /// Gets the name of the entries file name without extension. within the zip file
        /// </summary>
        /// <value>The file name without extension.</value>
        public string FileNameWithoutExtension
        {
            get { return System.IO.Path.GetFileNameWithoutExtension(_path); }
        }


        /// <summary>
        /// Gets the entries file extension
        /// </summary>
        /// <value>The file extension.</value>
        public string FileExtension
        {
            get { return System.IO.Path.GetExtension(_path); }
        }


        /// <summary>
        /// Gets a value indicating whether this instance is an image.
        /// </summary>
        /// <value><c>true</c> if this instance is an image; otherwise, <c>false</c>.</value>
        public bool IsImage
        {
            get
            {
                return (FileExtension == ".png") ? true : false;
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance is a XML file
        /// </summary>
        /// <value><c>true</c> if this instance is a XML file; otherwise, <c>false</c>.</value>
        public bool IsXML
        {
            get
            {
                return (FileExtension == ".xml") ? true : false;
            }
        }

        #endregion


        /// <summary>
        /// Returns an Image or null if the entry does not continue the PNG file extension
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            if (!IsImage) { return null; }

            MemoryStream memstream = new MemoryStream(_buffer);
            Image img = Image.FromStream(memstream);
            
            return img;
        }


        public CNNProject GetProject()
        {
            if (!IsXML) { return null; }

            MemoryStream memstream = new MemoryStream(_buffer);
            CNNProject proj = (CNNProject) new SoapFormatter().Deserialize(memstream);

            return proj;

        }


        public INeuralNetwork GetNetwork()
        {
            if (!IsXML) { return null; }


            // in this case we have to use a temp file
            string tempFileName = System.IO.Path.GetTempFileName();
            FileStream fileStream = File.Create(tempFileName);
            fileStream.Write(_buffer, 0, _buffer.Length);
            fileStream.Close();

            NetworkSerializer serializer = new NetworkSerializer();

            //TODO: to be noted, this is not the interface here
            INeuralNetwork network = new NeuralNetwork();
            serializer.LoadNetwork(tempFileName, ref network);

            // cleans up
            File.Delete(tempFileName);

            return network;


        }





        #region Static methods used to save zip data

        /// <summary>
        /// For each image in the list a zip entry (png) is created
        /// </summary>
        /// <param name="imlUsed">The used imagelist</param>
        /// <param name="zip">The zip stream</param>
        /// <param name="path">The path within the zip file</param>
        public static void ImageListToZip(ImageList imlUsed, ZipOutputStream zip, string path)
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
        /// <param name="zip">The zip.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void NetworkToZip(INeuralNetwork network, ZipOutputStream zip, string fileName)
        {

            // in this case we have to use a temp file
            string tempFileName = System.IO.Path.GetTempFileName();
            NetworkSerializer serializer = new NetworkSerializer();
            serializer.SaveNetwork(tempFileName, network);


            FileStream fileStream = File.OpenRead(tempFileName);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            PutZipEntry(zip, buffer, fileName);
            fileStream.Close();


            // cleans up
            File.Delete(tempFileName);

        }


        /// <summary>
        /// Project object to zip stream
        /// </summary>
        /// <param name="cnnProject">The CNNProject</param>
        /// <param name="zip">The zip stream</param>
        /// <param name="fileName">Name of the file within the zip archive</param>
        public static void ProjectToZip(CNNProject cnnProject, ZipOutputStream zip, string fileName)
        {

            byte[] buffer;
            using (MemoryStream stream = new MemoryStream())
            {
                new SoapFormatter().Serialize(stream, cnnProject);
                buffer = stream.GetBuffer();
            }

            PutZipEntry(zip, buffer, fileName);
        }


        /// <summary>
        /// Puts a byte buffer as a new zip entry to the zip stream
        /// </summary>
        /// <param name="zip">The zip stream</param>
        /// <param name="buffer">The byte buffer.</param>
        /// <param name="entryName">Name of the entry.</param>
        public static void PutZipEntry(ZipOutputStream zip, byte[] buffer, string entryName)
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
