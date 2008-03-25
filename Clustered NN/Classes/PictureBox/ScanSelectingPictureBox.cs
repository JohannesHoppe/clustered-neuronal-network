using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// a PictureBox that has a image selecting rectangle
    /// used in the working threads, not for real displaying on forms
    /// </summary>
    public class ScanSelectingPictureBox : BaseSelectingPictureBox
    {

        Size _observeSize;
        int _stepSize;

        public ScanSelectingPictureBox()
        {

        }


        public ScanSelectingPictureBox(Image image, Size oberserveSize, int stepSize)
        {
            this.Image = image;
            this.Width = image.Width;
            this.Height = image.Height;

            _observeSize = oberserveSize;
            _stepSize = stepSize;
        }

        #region not needed
        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedPictureBox"/> class.
        /// </summary>
        public ScanSelectingPictureBox() : base()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(ScanSelectingPictureBox_Paint);
        }

        /// <summary>
        /// Draw the Final rectangle again, as a repaint was issued
        /// </summary>
        private void ScanSelectingPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawFinalRectangle(e.Graphics);
        }
        */
        #endregion


        /// <summary>
        /// Resets the used configurated vars
        /// </summary>
        /// <param name="observeSize">Size of the observed area</param>
        public void ResetScan()
        {
            // area at point 0/0
            Point point1 = new Point(0, 0);
            Point point2 = new Point(_observeSize.Width, _observeSize.Height);
            _rectangleFinalShape = GetRectangle(point1, point2);

        }


        /// <summary>
        /// Sets RectangleFinalShape to the next Area 
        /// </summary>
        /// <returns>false if we have reached end; otherwise true</returns>
        public bool ScanNext()
        {

            // one step right, as long as we are not at the right border
            if (_rectangleFinalShape.X + _rectangleFinalShape.Width + _stepSize < this.Width)
            {
                _rectangleFinalShape.X += _stepSize;
            }
            else
            {

                // one step down, as long as we are not at the bottom border
                if (_rectangleFinalShape.Y + _rectangleFinalShape.Height + _stepSize < this.Height)
                {
                    _rectangleFinalShape.Y += _stepSize;
                    _rectangleFinalShape.X = 0;
                }

                // we are at the end
                else
                {
                    return false;
                }

            }

            return true;
        }


    }
}
