using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Clustered_NN.Classes;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// holds all configuration as well as usage data of a complete project
    /// </summary>
    public class CNNProject
    {
        // config
        public Size _imagePatternSize = new Size(20, 20);
        // config
        
        private ImageList _imlMatching;
        private ImageList _imlNotMatching;
        
        private Counter _matchingCounter;
        private Counter _notMatchingCounter;

        private ImageDetectionNeuralNetwork _imgDetectionNN;


        /// <summary>
        /// Initializes a new instance of the <see cref="CNNProject"/> class.
        /// </summary>
        public CNNProject()
        {

            this._imlMatching = new ImageList();
            this._imlMatching.ColorDepth = ColorDepth.Depth8Bit;
            this._imlMatching.ImageSize = this._imagePatternSize;
            this._imlMatching.TransparentColor = Color.Transparent;

            this._imlNotMatching = new ImageList();
            this._imlNotMatching.ColorDepth = ColorDepth.Depth8Bit;
            this._imlNotMatching.ImageSize = this._imagePatternSize;
            this._imlNotMatching.TransparentColor = Color.Transparent;

            this._matchingCounter = new Counter();
            this._notMatchingCounter = new Counter();

            this._imgDetectionNN = new ImageDetectionNeuralNetwork();
            this._imgDetectionNN.InitNetwork(this._imagePatternSize);
        }


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


        /// <summary>
        /// A list with matching images
        /// </summary>
        /// <value>The matching.</value>
        public ImageList Matching
        {
            get { return _imlMatching; }
            set { _imlMatching = value; }
        }


        /// <summary>
        /// Gets the matching counter.
        /// </summary>
        /// <value>The matching counter.</value>
        public Counter MatchingCounter
        {
            get { return _matchingCounter; }
        }


        /// <summary>
        ///A list with images that don't match
        /// </summary>
        /// <value>The not matching.</value>
        public ImageList NotMatching
        {
            get { return _imlNotMatching; }
            set { _imlNotMatching = value; }
        }


        /// <summary>
        /// Gets the not matching counter.
        /// </summary>
        /// <value>The not matching counter.</value>
        public Counter NotMatchingCounter
        {
            get { return _notMatchingCounter; }
        }


        /// <summary>
        /// Stores the Neuronal Network
        /// </summary>
        /// <value>The img detection NN.</value>
        public ImageDetectionNeuralNetwork ImgDetectionNN {

            get { return _imgDetectionNN; }
            set { _imgDetectionNN = value; }
        }

    }
}