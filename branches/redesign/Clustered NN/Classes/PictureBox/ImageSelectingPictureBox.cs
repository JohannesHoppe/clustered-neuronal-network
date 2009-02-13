using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Clustered_NN.Classes.SelectingPictureBox
{
    /// <summary>
    /// a PictureBox that has a image selecting rectangle
    /// </summary>
    class ImageSelectingPictureBox : BaseSelectingPictureBox
    {

        private bool _bMouseIsDown;
        private bool _bMoveRectangle;

        // additional rectangle used for creating new rectangle or while moving existing final rectangle
        private Rectangle _rectangleTempShape;

        private Point _pointMouseDown;
        private Point _pointMouseLast;
        private Point _pointMouseCurrent;
        private Point _pointMouseUp;

        private Cursor _cursorCross;


        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedPictureBox"/> class.
        /// </summary>
        public ImageSelectingPictureBox() : base()
        {
            _bMouseIsDown = false;

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(ImageSelectingPictureBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(ImageSelectingPictureBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(ImageSelectingPictureBox_MouseUp);
            
            this.Paint += new System.Windows.Forms.PaintEventHandler(ImageSelectingPictureBox_Paint);

            _cursorCross = CreateCrossCursor();
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
        /// Draws the temporary rectangle on the given graphic object
        /// </summary>
        /// <param name="g">The changed graphic</param>
        private void DrawTempRectangle(Graphics g)
        {
            g.DrawRectangle(_penDashedLine, _rectangleTempShape);
        }


        /// <summary>
        /// Creates an improved cross cursor
        /// </summary>
        /// <returns></returns>
        private static Cursor CreateCrossCursor() {

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

    }
}
