using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// holds all configuration as well as usage data of a complete project
    /// </summary>
    public class CNNProject
    {
        // config
        public Size _imagePatternSize = new Size(20, 20);
        //private Size _imagePatternSize = new Size(100, 100);
        // config

        /// <summary>
        /// The global size of a training pattern
        /// </summary>
        /// <value>The size of the image pattern.</value>
        public Size ImagePatternSize
        {
            get
            {
                return _imagePatternSize;
            }
        }
    }

    /// <summary>
    /// holds a list of SimpleImageItems
    /// </summary>
    public class SimpleImageList {



        private List<SimpleImageItem> _items;

        public List<SimpleImageItem> Items
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }
    }

    /// <summary>
    /// Stores an image together with its name
    /// </summary>
    public class SimpleImageItem {

        private Image _image;
        private string _name;

        public SimpleImageItem(Image image, string name)
        {
            this._image = image;
            this._name = name;
        }

        public Image Image
        {
            get
            {
                return _image;
            }
        }

        public string Name {

            get  {
                return _name;
            }
        }
    }
}
