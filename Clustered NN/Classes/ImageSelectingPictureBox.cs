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
    /// </summary>
    class ImageSelectingPictureBox : PictureBox
    {

        private bool _bMouseIsDown;
        private bool _bMoveRectangle;
        private bool _bSquareOnly;

        private Rectangle _rectangleFinalShape;
        private Rectangle _rectangleTempShape;

        private Point _pointMouseDown;
        private Point _pointMouseLast;
        private Point _pointMouseCurrent;
        private Point _pointMouseUp;

        private Pen _penDashedLine;
        private Brush _brushFillColor;
        private Cursor _cursorCross;


        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedPictureBox"/> class.
        /// </summary>
        public ImageSelectingPictureBox()
        {
            _bMouseIsDown = false;
            _bSquareOnly = true; // !!

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(ImageSelectingPictureBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(ImageSelectingPictureBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(ImageSelectingPictureBox_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(ImageSelectingPictureBox_Paint);
            this.Resize += new System.EventHandler(ImageSelectingPictureBox_Resize);

            _penDashedLine = new Pen(Color.Red, 1);
            _penDashedLine.DashStyle = DashStyle.DashDotDot;

            _brushFillColor = new SolidBrush(Color.FromArgb(50, 255, 0, 0));
            _cursorCross = CreateCrossCursor();

            ResetRectangle(ref _rectangleFinalShape);
        }


        /// <summary>
        /// Return the rectangle that goes through the two points passed to it
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        /// <returns>rectangle object</returns>
        public Rectangle GetRectangle(Point point1, Point point2)
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
        public Rectangle GetRectangle(Point point1, Point point2, int amountInflate)
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
        /// Soon as the mouse is pressed down the coords are used for drawing a selection in MouseMove
        /// or for changing the rectangles position
        /// </summary>
        private void ImageSelectingPictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Set the flag for changes enabled
            _bMouseIsDown = true;


            //Set the points for MouseDown and Last (same)
            _pointMouseDown = new Point(e.X, e.Y);
            AdjustCoords(ref _pointMouseDown);
            _pointMouseLast = _pointMouseDown;


            // we want to create a new rectangle
            if (!PointWithinRectangle(_pointMouseCurrent, _rectangleFinalShape, 0))
            {
                _bMoveRectangle = false;
                
                //Clear the previous rectangle shape
                ResetRectangle(ref _rectangleFinalShape);

                this.Cursor = Cursors.SizeNWSE;
            }
            // we want to move the existing rect
            else
            {
                _bMoveRectangle = true;

                _rectangleTempShape = _rectangleFinalShape;

                this.Cursor = Cursors.SizeAll; // not really needed
            }
        }


        /// <summary>
        /// If the change flag is set (_bMouseIsDown)
        /// then track coords and draw a selection rectangle from the first point to the current position
        /// or change the temp rectangles position
        /// </summary>
        private void ImageSelectingPictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            _pointMouseCurrent = new Point(e.X, e.Y);
            AdjustCoords(ref _pointMouseCurrent);

            // Change flag enabled?
            if (_bMouseIsDown == true)
            {
                
                //Draw a temporary rectangle from MouseDown to MouseCurrent
                if (_bMoveRectangle == false)
                {
                    this.Invalidate(GetRectangle(_pointMouseDown, _pointMouseLast, 2));
                    this.Refresh();

                    //Create a new rectangle object, store globally
                    _rectangleTempShape = GetRectangle(_pointMouseDown, _pointMouseCurrent);

                }

                else
                {
                    Point pointRectTemp1 = new Point(_rectangleTempShape.Left, _rectangleTempShape.Top);
                    Point pointRectTemp2 = new Point(_rectangleTempShape.Right, _rectangleTempShape.Bottom);

                    this.Invalidate(GetRectangle(pointRectTemp1, pointRectTemp2, 2));
                    this.Refresh();

                    int changeX = _pointMouseLast.X - _pointMouseCurrent.X;
                    int changeY = _pointMouseLast.Y - _pointMouseCurrent.Y;

                    Point pointNewRectTemp1 = new Point(pointRectTemp1.X - changeX, pointRectTemp1.Y - changeY);
                    Point pointNewRectTemp2 = new Point(pointRectTemp2.X - changeX, pointRectTemp2.Y - changeY);

                    _rectangleTempShape = GetRectangle(pointNewRectTemp1, pointNewRectTemp2);
                    
                }

                DrawTempRectangle();

                //Update the lastpoint to current point
                _pointMouseLast = _pointMouseCurrent;

            }

            else
            {
                #region change cursor
                if (PointWithinRectangle(_pointMouseCurrent, _rectangleFinalShape, 0))
                {
                    this.Cursor = Cursors.SizeAll;
                }
                else
                {
                    this.Cursor = _cursorCross;
                }
                #endregion
            }
            
        }


        /// <summary>
        /// When the mouse is released, a final rectangle will be drawn
        /// </summary>
        private void ImageSelectingPictureBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Turn off change flag
            _bMouseIsDown = false;

            if (_bMoveRectangle == false)
            {

                //Set the mouse up point
                _pointMouseUp = new Point(e.X, e.Y);
                AdjustCoords(ref _pointMouseUp);

                //Create a new rectangle object
                _rectangleFinalShape = GetRectangle(_pointMouseDown, _pointMouseUp);

            }
            else
            {
                _bMoveRectangle = false;
                _rectangleFinalShape = _rectangleTempShape;
            }


            DrawFinalRectangle();

            this.Cursor = _cursorCross;
        }


        /// <summary>
        /// Draw the Final / Temp rectangle again, as a repaint was issued
        /// </summary>
        private void ImageSelectingPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (_bMouseIsDown == true)
            {
                DrawTempRectangle(e.Graphics);
            }
            else
            {
                DrawFinalRectangle(e.Graphics);
            }
        }


        /// <summary>
        /// Sets a default final rectangle
        /// </summary>
        private void ImageSelectingPictureBox_Resize(object sender, EventArgs e)
        {
            DefaultRectangle(ref _rectangleFinalShape);
        }


        /// <summary>
        /// Draws the temporary rectangle with a new graphic object
        /// </summary>
        private void DrawTempRectangle()
        {
            //Create a graphics object
            Graphics g = this.CreateGraphics();

            //Draw the Temp rectangle
            DrawTempRectangle(g);

            //Dispose of the object, as no longer required
            g.Dispose();

        }


        /// <summary>
        /// Draws the final rectangle with a new graphic object
        /// </summary>
        private void DrawFinalRectangle()
        {
            //Create a graphics object
            Graphics g = this.CreateGraphics();

            //Draw the Final rectangle
            DrawFinalRectangle(g);

            //Dispose of the graphics object
            g.Dispose();
        }


        /// <summary>
        /// Draws the temporary rectangle on the given graphic object
        /// </summary>
        /// <param name="g">The changed graphic</param>
        private void DrawTempRectangle(Graphics g)
        {
            g.DrawRectangle(_penDashedLine, _rectangleTempShape);
        }


        /// <summary>
        /// Draws the final rectangle on the given graphic object
        /// </summary>
        /// <param name="g">The changed graphic</param>
        private void DrawFinalRectangle(Graphics g)
        {
            g.DrawRectangle(_penDashedLine, _rectangleFinalShape);
            g.FillRectangle(_brushFillColor, _rectangleFinalShape);
        }


        /// <summary>
        /// Corrects the coords so that the rectangle stays within the picture
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>changed point</returns>
        private void AdjustCoords(ref Point point) {

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
        private void ResetRectangle(ref Rectangle rect)
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
        private void DefaultRectangle(ref Rectangle rect)
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
        /// Determines if the given point stays wihtin the rectangle
        /// the rectangles INNER border is ignored
        /// </summary>
        /// <param name="p">The ppoint</param>
        /// <param name="rect">The rectangle</param>
        /// <param name="borderWidth">Width of the rectangles INNER border</param>
        private bool PointWithinRectangle(Point p, Rectangle rect, int innerBorderWidth)
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
        /// Creates a improved cross cursor
        /// </summary>
        /// <returns></returns>
        public static Cursor CreateCrossCursor() {

            Bitmap b = new Bitmap(25,25);
            Graphics g = Graphics.FromImage(b);
            //g.Clear(Color.White); // optional drawing white background

            Pen whitePen = new Pen(Color.White, 3.0F);
            Pen blackPen = new Pen(Color.Black, 1.0F);

            g.DrawLine(whitePen, new Point(13, 0), new Point(13, 25)); // vertical line
            g.DrawLine(whitePen, new Point(0, 13), new Point(25, 13)); // horizontal line

            g.DrawLine(blackPen, new Point(13, 1), new Point(13, 23)); // vertical line
            g.DrawLine(blackPen, new Point(1, 13), new Point(23, 13)); // horizontal line

            g.Flush();

            IntPtr ptr = b.GetHicon();
            return new Cursor(ptr);
        }


        /// <summary>
        /// Gets the selected area as an image 
        /// </summary>
        /// <value>The selected area.</value>
        public Image SelectedArea
        {
            get
            {
                return ImageHandling.cropImage(this.Image, this._rectangleFinalShape);
            }
        }
        
        
        /// <summary>
        /// Resized version of SelectedArea
        /// </summary>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        public Image GetResizedSelectedArea(Size size)
        {
            return ImageHandling.resizeImage(SelectedArea, size);
        }


    }
}
