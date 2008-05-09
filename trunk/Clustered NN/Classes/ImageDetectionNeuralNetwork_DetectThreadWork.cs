using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Clustered_NN.Classes.SelectingPictureBox;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// Class that holds a function for threaded image detection
    /// each thread (can or better: should) is working on one scaled version of the 
    /// </summary>
    public class ImageDetectionNeuralNetwork_DetectThreadWork
    {

        private ScanSelectingPictureBox _scanSelectingPictureBox;
        private Size _imagePatternSize;
        private ImageDetectionNeuralNetwork.DetectPatternDelegate _detectPatternDelegate;
        private String _name;
        private bool _match;

        public Counter TotalLoops;
        public Counter CurrentLoop;

        private PictureBox _currentImage;
        private PictureBox _currentImageSmall;


        /// <summary>
        /// Initializes a new instance of the <see cref="ImageDetectionNeuralNetworkDetectThreadWork"/> class.
        /// </summary>
        /// <param name="image">The complete image on which the pattern should be searched</param>
        /// <param name="imagePatternSize">Working size of a detection pattern (as defined in _cnnProjectHolder.CNNProject.ImagePatternSize)</param>
        /// <param name="oberserveSize">the 'scalation' - size of the rectangle that scans over the image</param>
        /// <param name="stepSize">pixel-size of one step to move the rectangle to right and down</param>
        /// <param name="detectPatternDelegate">The detect pattern delegate.</param>
        /// <param name="currentImage">Just for testing: pictureBox to display the current image (original size)</param>
        /// <param name="currentImageSmall">Just for testing: PictureBox to display the current resized and generalized image - as it gets feeded to the network</param>
        public ImageDetectionNeuralNetwork_DetectThreadWork(Image image,
                                                     Size imagePatternSize,
                                                     Size oberserveSize,
                                                     int stepSize,
                                                     ImageDetectionNeuralNetwork.DetectPatternDelegate detectPatternDelegate,
                                                     PictureBox currentImage,
                                                     PictureBox currentImageSmall)
        {
            _scanSelectingPictureBox = new ScanSelectingPictureBox(image, oberserveSize, stepSize);
            _imagePatternSize = imagePatternSize;
            _detectPatternDelegate = detectPatternDelegate;
            _currentImage = currentImage;
            _currentImageSmall = currentImageSmall;

            TotalLoops = new Counter();
            CurrentLoop = new Counter();
        }


        /// <summary>
        /// Enumerates all possibles areas until a match 
        /// </summary>
        public void ThreadWork()
        {

            // gets the max number of loops
            #region max number
            _scanSelectingPictureBox.ResetScan();
            TotalLoops.Reset();
            while (_scanSelectingPictureBox.ScanNext())
            {
                TotalLoops.Increment();
            }

            // TODO: make this nicer
            UpdateCurrentImageBorder(_currentImage, Color.Red);
            UpdateCurrentImageBorder(_currentImageSmall, Color.Red);
            #endregion


            // the real detection process
            _scanSelectingPictureBox.ResetScan();
            CurrentLoop.Reset();
            while (_scanSelectingPictureBox.ScanNext())
            {
                CurrentLoop.Increment();

                // also possible:
                //Image smallImage = _scanSelectingPictureBox.GetResizedSelectedArea(_imagePatternSize);

                Image bigImage = _scanSelectingPictureBox.SelectedArea;
                Image smallImage = ImageHandling.GeneralizeImage(ImageHandling.ResizeImage(bigImage, _imagePatternSize));

                UpdateCurrentImage(_currentImage, bigImage);
                UpdateCurrentImage(_currentImageSmall, smallImage);
                

                bool match = _detectPatternDelegate(smallImage);

                if (match)
                {
                    Match = true;
                    UpdateCurrentImageBorder(_currentImage, Color.Green);
                    UpdateCurrentImageBorder(_currentImageSmall, Color.Green);
                    break;
                }

            }

        }


        /// <summary>
        /// Gets or sets the name of this worker
        /// </summary>
        /// <value>The name.</value>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the pattern matched
        /// </summary>
        /// <value><c>true</c> if match; otherwise, <c>false</c>.</value>
        public bool Match
        {
            get { return _match; }
            set { _match = value; }
        }


        private delegate void UpdateCurrentImageDelegate(PictureBox invokedPictureBox, Image newImage);

        public void UpdateCurrentImage(PictureBox invokedPictureBox, Image newImage)
        {
            if (!invokedPictureBox.InvokeRequired)
            {
                invokedPictureBox.Image = newImage;
                invokedPictureBox.Width = newImage.Width + 2 * 3;
                invokedPictureBox.Height = newImage.Height + 2 * 3;
            }
            else
            {
                invokedPictureBox.Invoke(
                    new UpdateCurrentImageDelegate(UpdateCurrentImage),
                        new object[] { invokedPictureBox, newImage }
                    );
            }



        }


        private delegate void UpdateCurrentImageBorderDelegate(PictureBox invokedPictureBox, Color newColor);

        public void UpdateCurrentImageBorder(PictureBox invokedPictureBox, Color newColor)
        {
            if (!invokedPictureBox.InvokeRequired)
            {
                invokedPictureBox.BackColor = newColor;
                invokedPictureBox.Padding = new System.Windows.Forms.Padding(3);
            }
            else
            {
                invokedPictureBox.Invoke(
                    new UpdateCurrentImageBorderDelegate(UpdateCurrentImageBorder),
                        new object[] { invokedPictureBox, newColor }
                    );
            }



        }

        


    }
}
