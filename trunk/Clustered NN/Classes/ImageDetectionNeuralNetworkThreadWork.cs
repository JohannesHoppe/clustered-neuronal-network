using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Clustered_NN.Classes
{
    public class ImageDetectionNeuralNetworkThreadWork
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


        public ImageDetectionNeuralNetworkThreadWork(Image image,
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
            _scanSelectingPictureBox.ResetScan();
            TotalLoops.Reset();
            while (_scanSelectingPictureBox.ScanNext())
            {
                TotalLoops.Increment();
            }

            UpdateCurrentImageBorder(_currentImage, Color.Red);
            UpdateCurrentImageBorder(_currentImageSmall, Color.Red);

            // the real detection process
            _scanSelectingPictureBox.ResetScan();
            CurrentLoop.Reset();
            while (_scanSelectingPictureBox.ScanNext())
            {
                CurrentLoop.Increment();

                //Image image = _scanSelectingPictureBox.GetResizedSelectedArea(_imagePatternSize);

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
