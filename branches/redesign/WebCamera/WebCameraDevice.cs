using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WebCamera
{
   public delegate void WebCameraFrameDelegate (object sender, WebCameraEventArgs e);

   public partial class WebCameraDevice : IDisposable
   {
      public event WebCameraFrameDelegate OnCameraFrame;
      
      AutoResetEvent autoEvent = new AutoResetEvent(false);
      Thread frameThread;

      int camHwnd, parentHwnd;
      bool bStart = false;
      object threadLock = new object();

      int preferredFPSms, camID;
      int frameWidth, frameHeight;

      #region API
      // Camera API
      const int WM_CAP_START = 1024; // WM_USER
      
      const int WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5;
      const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
      const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
      const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 42;
      const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
      const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;
      const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;
      const int WM_CAP_GRAB_FRAME = WM_CAP_START + 60;
      const int WM_CAP_GRAB_FRAME_NOSTOP = WM_CAP_START + 61;
      


      [DllImport("user32", EntryPoint = "SendMessage")]
      static extern bool SendMessage(int hWnd, uint wMsg, int wParam, int lParam);

      [DllImport("user32", EntryPoint = "SendMessage")]
      static extern int SendBitmapMessage(int hWnd, uint wMsg, int wParam, ref BITMAPINFO lParam);

      [DllImport("user32", EntryPoint = "SendMessage")]
      static extern int SendHeaderMessage(int hWnd, uint wMsg, int wParam, CallBackDelegate lParam);

      [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindow")]
      static extern int capCreateCaptureWindow(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

      
      delegate void CallBackDelegate(IntPtr hwnd, ref VIDEOHEADER hdr);
      CallBackDelegate delegateFrameCallBack;

      [StructLayout(LayoutKind.Sequential)]
      public struct VIDEOHEADER
      {
         public IntPtr lpData;
         public uint dwBufferLength;
         public uint dwBytesUsed;
         public uint dwTimeCaptured;
         public uint dwUser;
         public uint dwFlags;
         [MarshalAs(System.Runtime.InteropServices.UnmanagedType.SafeArray)]
         byte[] dwReserved;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BITMAPINFOHEADER
      {
         public uint biSize;
         public int biWidth;
         public int biHeight;
         public ushort biPlanes;
         public ushort biBitCount;
         public uint biCompression;
         public uint biSizeImage;
         public int biXPelsPerMeter;
         public int biYPelsPerMeter;
         public uint biClrUsed;
         public uint biClrImportant;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BITMAPINFO
      {
         public BITMAPINFOHEADER bmiHeader;
         public int bmiColors;
      }
      #endregion

      /// <summary>
      /// Initializes a new instance of WebCameraDevice object
      /// </summary>
      /// <param name="width">Frame width in pixels</param>
      /// <param name="height">Frame height in pixels</param>
      /// <param name="preferredFPS">
      /// Preferred Frames Per Second. Available values are between 0 and 30
      /// Set value to 0, for manual frame grabbing
      /// </param>
      /// <param name="camID">Device ID</param>
      /// <param name="parentHwnd">Parent's handle</param>
      public WebCameraDevice(int frameWidth, int frameHeight, int preferredFPS, int camID, int parentHwnd)
      {
         this.frameWidth = frameWidth;
         this.frameHeight = frameHeight;
         this.parentHwnd = parentHwnd;
         this.camID = camID;
         PreferredFPS = preferredFPS;

         delegateFrameCallBack = FrameCallBack;
      }

      public void Start()
      {
         try
         {
            camHwnd = capCreateCaptureWindow("WebCam", 0, 0, 0, frameWidth, frameHeight, parentHwnd, camID);

            // connect to the device
            if (SendMessage(camHwnd, WM_CAP_DRIVER_CONNECT, 0, 0))
            {
               BITMAPINFO bInfo = new BITMAPINFO();
               bInfo.bmiHeader = new BITMAPINFOHEADER();
               bInfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bInfo.bmiHeader);
               bInfo.bmiHeader.biWidth = frameWidth;
               bInfo.bmiHeader.biHeight = frameHeight;
               bInfo.bmiHeader.biPlanes = 1;
               bInfo.bmiHeader.biBitCount = 24; // bits per frame, 24 - RGB

               //Enable preview mode. In preview mode, frames are transferred from the 
               //capture hardware to system memory and then displayed in the capture 
               //window using GDI functions.
               SendMessage(camHwnd, WM_CAP_SET_PREVIEW, 1, 0);
               SendMessage(camHwnd, WM_CAP_SET_PREVIEWRATE, 34, 0); // sets the frame display rate in preview mode
               SendBitmapMessage(camHwnd, WM_CAP_SET_VIDEOFORMAT, Marshal.SizeOf(bInfo), ref bInfo);
               
               frameThread = new Thread(new ThreadStart(this.FrameGrabber));
               bStart = true;       // First, set variable
               frameThread.Priority = ThreadPriority.Lowest;
               frameThread.Start(); // Only then put thread to the queue
            }
            else
               throw new Exception("Cannot connect to VFW device");
         }
         catch (Exception e)
         {
            Stop();
            MessageBox.Show("Error: " + e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      public void Stop()
      {
         try
         {
            bStart = false;
            Set();
            SendMessage(camHwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0);
         }
         catch { }
      }

      private void FrameGrabber()
      {
         while (bStart) // if worker active thread is still required
         {
            try
            {
               // get the next frame. This is the SLOWEST part of the program
               SendMessage(camHwnd, WM_CAP_GRAB_FRAME_NOSTOP, 0, 0);
               SendHeaderMessage(camHwnd, WM_CAP_SET_CALLBACK_FRAME, 0, delegateFrameCallBack);
            }
            catch (Exception excep)
            {
               this.Stop(); // stop the process
               MessageBox.Show("Capturing error:\r\n" + excep.Message);
            }
         }
      }

      /// <summary>
      /// Allow waiting worker (FrameGrabber) thread to proceed
      /// </summary>
      public void Set()
      {
         autoEvent.Set();
      }

      private void FrameCallBack(IntPtr hwnd, ref VIDEOHEADER hdr)
      {
         if (OnCameraFrame != null)
         {
            Bitmap bmp = new Bitmap(frameWidth, frameHeight, 3 * frameWidth, System.Drawing.Imaging.PixelFormat.Format24bppRgb, hdr.lpData);
            OnCameraFrame(this, new WebCameraEventArgs(bmp));
         }

         // block thread for preferred milleseconds
         if (preferredFPSms == 0)
            autoEvent.WaitOne();
         else
            autoEvent.WaitOne(preferredFPSms, false);
      }

      public void ShowVideoDialog()
      {
         SendMessage(camHwnd, WM_CAP_DLG_VIDEODISPLAY, 0, 0);
      }

      public int PreferredFPS
      {
         get { return 1000 / preferredFPSms; }
         set 
         {
            if (value == 0)
               preferredFPSms = 0;
            else if (value > 0 && value <= 30)
            {
               preferredFPSms = 1000 / value;
            }           
         }
      }

      public int ID
      {
         get { return camID; }
      }

      public int FrameHeight
      {
         get { return frameHeight; }
      }

      public int FrameWidth
      {
         get { return frameWidth; }
      }

      #region IDisposable Members

      public void Dispose()
      {
         this.Stop();
      }
      #endregion


      #region does not work
      /*
      [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
      public static extern int SendMessageAsBitMap(int hWnd, int wMsg, int wParam, ref BITMAPINFO lParam);

      /// <summary>
      /// HACK: see http://www.webtropy.com/articles/art7-2.asp
      /// returns void instead of bool (which does not fit to bool in c#)
      /// 
      /// The capSetVideoFormat API is used to indicate to the webcam the format
      /// of image to be returned. Many cameras do not support all ranges of bitmap formats,
      /// however, 24 bit colour 320 x 240 and 640 x 480 are quite common. 
      /// </summary>
      /// <param name="hCapWnd">The h cap WND.</param>
      /// <param name="BmpFormat">The BMP format.</param>
      /// <param name="CapFormatSize">Size of the cap format.</param>
      public static void capSetVideoFormat(int hCapWnd, ref BITMAPINFO BmpFormat, int CapFormatSize)
      {
          SendMessageAsBitMap(hCapWnd, WM_CAP_SET_VIDEOFORMAT, CapFormatSize, ref BmpFormat);
      }
      */
      #endregion
  }

   public class WebCameraEventArgs : EventArgs
   {
      Bitmap frame;

      public WebCameraEventArgs(Bitmap frame)
      {
         this.frame = frame;
      }

      public Bitmap Frame
      {
         get { return frame; }
      }
   }

}