using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;


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


        public void SaveAndSerialize()
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = "Project XML Files|*.proj.xml";
            dialog.DefaultExt = "proj.xml";
            dialog.FileName = "default.proj.xml";


            if (dialog.ShowDialog() == DialogResult.OK)
            {

                Stream stream = File.OpenWrite(dialog.FileName);
                SoapFormatter formater = new SoapFormatter();
                formater.Serialize(stream, CNNProject);
                stream.Close();


                //XmlSerializer xs = new XmlSerializer();
                ////xs.IgnoreSerialisationErrors = true;
                //xs.IgnoreSerializableAttribute = true;
                //xs.SerializationIgnoredAttributeType = typeof(SYSTEMXML.XmlIgnoreAttribute);
                //xs.Serialize(_cnnProject, dialog.FileName);


                //SYSTEMXML.XmlSerializer serializer = new SYSTEMXML.XmlSerializer(_cnnProject.GetType());

                //FileStream fs = new FileStream(dialog.FileName, FileMode.Create);
                //TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                //serializer.Serialize(writer, _cnnProject);
                //writer.Close();
            }

        }

    }
}
