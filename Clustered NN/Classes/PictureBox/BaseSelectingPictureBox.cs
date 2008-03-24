using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// basic functions for ImageSelectingPictureBox 
    /// </summary>
    public class BaseSelectingPictureBox : PictureBox
    {
        private bool _bSquareOnly; // only squares are possible (no rectangles)

        protected Rectangle _rectangleFinalShape;
        protected Pen _penDashedLine;
        protected Brush _brushFillColor;


        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedPictureBox"/> class.
        /// </summary>
        public BaseSelectingPictureBox()
        {
            _bSquareOnly = true; // !!

            _penDashedLine = new Pen(Color.Red, 1);
            _penDashedLine.DashStyle = DashStyle.DashDotDot;
            _brushFillColor = new SolidBrush(Color.FromArgb(50, 255, 0, 0));

            this.Resize += new System.EventHandler(ImageSelectingPictureBox_Resize);

            ResetRectangle(ref _rectangleFinalShape);
        }


        /// <summary>
        /// Return the rectangle that goes through the two points passed to it
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        /// <returns>rectangle object</returns>
        protected Rectangle GetRectangle(Point point1, Point point2)
        {
            return GetRectangle(point1, point2, 0);
        }


        /// <summary>
        /// Return the rectangle that goes through the two points passed to 
        /// and that is a square (_bSquareOnly true)
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        /// <param name="amountInflate">The amount inflate.</param>
        /// <returns>rectangle object</returns>
        protected Rectangle GetRectangle(Point point1, Point point2, int amountInflate)
        {
            Rectangle rect = new Rectangle();
            int left = 0;
            int top = 0;
            int right = 0;
            int bottom = 0;

            #region right order
            if (point1.X < point2.X)
            {
                left = point1.X;
                right = point2.X;
            }
            else
            {
                left = point2.X;
                right = point1.X;
            }

            if (point1.Y < point2.Y)
            {
                top = point1.Y;
                bottom = point2.Y;
            }
            else
            {
                top = point2.Y;
                bottom = point1.Y;
            }

            if (left == right)
            {
                right += 1;
            }
            if (top == bottom)
            {
                bottom += 1;
            }
            #endregion

            // TODO: avoid dropping out of the image
            #region square only
            if (_bSquareOnly)
            {
                
                int width = right - left;
                int height = bottom - top;

                // *** horizontal ***
                //
                // +- left
                // |top
                //
                // +---------+          +---------+
                // |         |    -->   |         |
                // +---------+          |         |
                //                      |         |
                //           +-right    +---------+
                //           |bottom
                if (width > height)
                {
                    bottom = top + width;
                }
                // *** diagonal *** 
                //
                // +----+          +---------+
                // |    |    -->   |         |
                // |    |          |         |
                // |    |          |         |
                // +----+          +---------+
                //                           
                else if (height > width)
                {
                    right = left + height;
                }
            }
            #endregion

            rect = Rectangle.FromLTRB(left, top, right, bottom);
            rect.Inflate(amountInflate, amountInflate);
            return rect;
        }


        /// <summary>
        /// Handles the Resize event of the ImageSelectingPictureBox control.
        /// Defaults the final rectangle
        /// </summary>
        private void ImageSelectingPictureBox_Resize(object sender, EventArgs e)
        {
            DefaultRectangle(ref _rectangleFinalShape);
        }


        /// <summary>
        /// Draws the final rectangle with a new graphic object
        /// </summary>
        protected void DrawFinalRectangle()
        {
            //Create a graphics object
            Graphics g = this.CreateGraphics();

            //Draw the Final rectangle
            DrawFinalRectangle(g);

            //Dispose of the graphics object
            g.Dispose();
        }


        /// <summary>
        /// Draws the final rectangle on the given graphic object
        /// </summary>
        /// <param name="g">The changed graphic</param>
        protected void DrawFinalRectangle(Graphics g)
        {
            g.DrawRectangle(_penDashedLine, _rectangleFinalShape);
            g.FillRectangle(_brushFillColor, _rectangleFinalShape);
        }


        /// <summary>
        /// Corrects the coords so that the points values are not greater than the PictureBox 
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>changed point</returns>
        protected void AdjustCoords(ref Point point)
        {

            //Check LEFT/RIGHT (X) boundary
            if (point.X < 0)
            {
                //The boundary has reached the left border
                point.X = 0;
            }
            else if (point.X > this.Width - 3) // <- ??
            {
                //The boundary has reached the right border
                point.X = this.Width - 3;
            }

            //Check TOP/BOTTOM (Y) boundary
            if (point.Y < 0)
            {
                //The boundary has reached the top border
                point.Y = 0;
            }
            else if (point.Y > this.Height - 3)
            {
                //The boundary has reached the bottom border
                point.Y = this.Height - 3;
            }
        }

        
        /// <summary>
        /// Resets all values of the given rectanlge to zero
        /// </summary>
        /// <param name="rect">The rectangle</param>
        protected void ResetRectangle(ref Rectangle rect)
        {
            rect.Height = 0;
            rect.Width = 0;
            rect.X = 0;
            rect.Y = 0;
        }


        /// <summary>
        /// Defaults the rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        protected void DefaultRectangle(ref Rectangle rect)
        {
            Point point1 = new Point(this.Width / 2 - 75, this.Height / 2 - 75);
            Point point2 = new Point(this.Width / 2 + 75, this.Height / 2 + 75);
            
            Rectangle tempRect = GetRectangle(point1, point2);

            rect.Height = tempRect.Height;
            rect.Width = tempRect.Width;
            rect.X = tempRect.X;
            rect.Y = tempRect.Y;
        }


        /// <summary>
        /// Determines if the given point stays within the given rectangle
        /// (the rectangles INNER border is ignored)
        /// </summary>
        /// <param name="p">The ppoint</param>
        /// <param name="rect">The rectangle</param>
        /// <param name="borderWidth">Width of the rectangles INNER border</param>
        protected static bool PointWithinRectangle(Point p, Rectangle rect, int innerBorderWidth)
        {
            if (p.X >= rect.Left + innerBorderWidth &&
                p.X <= rect.Right - innerBorderWidth &&
                p.Y >= rect.Top + innerBorderWidth &&
                p.Y <= rect.Bottom - innerBorderWidth)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Gets the selected area as an image 
        /// </summary>
        /// <value>The selected area.</value>
        public Image SelectedArea
        {
            get
            {
                if (this.Image == null) {
                    throw new ImageNotInitializedException();
                }

                return ImageHandling.CropImage(this.Image, this._rectangleFinalShape);
            }
        }
        
        
        /// <summary>
        /// Resized version of SelectedArea
        /// </summary>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        public Image GetResizedSelectedArea(Size size)
        {
            return ImageHandling.ResizeImage(SelectedArea, size);
        }


    }


    /// <summary>
    /// Thrown by Image.SelectedArea
    /// </summary>
    class ImageNotInitializedException : Exception
    {

        /// <summary>
        /// Gets a message that describes the current exception.
        /// Thrown by Image.SelectedArea
        /// </summary>
        /// <value></value>
        /// <returns>The error message that explains the reason for the exception</returns>
        public override string Message
        {
            get
            {
                return "There is currently no image loaded!"  + StaticClasses.NL
                     + "Is the device connected properly?";
            }
        }
    }

}
