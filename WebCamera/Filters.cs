using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace WebCamera
{
   public class Filters
   {
      //Gilles Khouzams colour corrected grayscale shear
      static ColorMatrix cm = new ColorMatrix(new float[][]{   
                                   new float[]{0.3f,  0.3f, 0.3f,  0,  0},
                                   new float[]{0.59f,0.59f,0.59f,  0,  0},
                                   new float[]{0.11f,0.11f,0.11f,  0,  0},
                                   new float[]{0,  0,    0,    1,  0,  0},
                                   new float[]{0,  0,    0,    0,  1,  0},
                                   new float[]{0,  0,    0,    0,  0,  1}});

      public static Image ToGrayScale(Image img)
      {
         //BobPowell.Net
         //http://www.bobpowell.net/grayscale.htm
         Graphics g = Graphics.FromImage(img);
         ImageAttributes ia = new ImageAttributes();
         ia.SetColorMatrix(cm);
         g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
         g.Dispose();
         return img;
      }


      public static bool Flip(Bitmap b, bool bHorz, bool bVert)
      {
         //http://www.codeproject.com/script/profile/whos_who.asp?vt=arts&id=6556
         Point[,] ptFlip = new Point[b.Width, b.Height];

         int nWidth = b.Width;
         int nHeight = b.Height;

         for (int x = 0; x < nWidth; ++x)
            for (int y = 0; y < nHeight; ++y)
            {
               ptFlip[x, y].X = (bHorz) ? nWidth - (x + 1) : x;
               ptFlip[x, y].Y = (bVert) ? nHeight - (y + 1) : y;
            }

         OffsetFilterAbs(b, ptFlip);

         return true;
      }

      public static bool OffsetFilterAbs(Bitmap b, Point[,] offset)
      {
         Bitmap bSrc = (Bitmap)b.Clone();

         // GDI+ still lies to us - the return format is BGR, NOT RGB.
         BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
         BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

         int scanline = bmData.Stride;

         System.IntPtr Scan0 = bmData.Scan0;
         System.IntPtr SrcScan0 = bmSrc.Scan0;

         unsafe
         {
            byte* p = (byte*)(void*)Scan0;
            byte* pSrc = (byte*)(void*)SrcScan0;

            int nOffset = bmData.Stride - b.Width * 3;
            int nWidth = b.Width;
            int nHeight = b.Height;

            int xOffset, yOffset;

            for (int y = 0; y < nHeight; ++y)
            {
               for (int x = 0; x < nWidth; ++x)
               {
                  xOffset = offset[x, y].X;
                  yOffset = offset[x, y].Y;

                  if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
                  {
                     p[0] = pSrc[(yOffset * scanline) + (xOffset * 3)];
                     p[1] = pSrc[(yOffset * scanline) + (xOffset * 3) + 1];
                     p[2] = pSrc[(yOffset * scanline) + (xOffset * 3) + 2];
                  }

                  p += 3;
               }
               p += nOffset;
            }
         }

         b.UnlockBits(bmData);
         bSrc.UnlockBits(bmSrc);

         return true;
      }
   }

   
}
