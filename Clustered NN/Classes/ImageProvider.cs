using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Clustered_NN.Classes
{
    abstract class ImageProvider
    {
        abstract public void StartPresentation();
        abstract public void StopPresentation();

        abstract public int FrameWidth
        {
            get;
        }
        abstract public int FrameHeight
        {
            get;
        }

        public delegate void OnFrameDelegate(object sender, OnFrameEventArgs e);
        abstract public event OnFrameDelegate OnFrame;
        
    }


    /// <summary>
    /// containts the current bitmap frame
    /// </summary>
    public class OnFrameEventArgs : EventArgs
    {
        Bitmap frame;

        public OnFrameEventArgs(Bitmap frame)
        {
            this.frame = frame;
        }

        public Bitmap Frame
        {
            get { return frame; }
        }
    }
}
