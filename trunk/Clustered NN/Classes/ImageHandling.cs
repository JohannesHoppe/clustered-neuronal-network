using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Clustered_NN.Classes
{
    static class ImageHandling
    {

        /// <summary>
        /// +++ Makes an image easier identifiable +++
        /// 
        /// 1. Grayscale filter - reduces colors (of course)
        /// 2. Gaussian Blur filter - reduces noise
        /// 3. Histogram Equalization - dynamic range of the histogram is increased (more intensity)
        /// </summary>
        /// <param name="img">The source image</param>
        /// <returns>The new image</returns>
        public static Image GeneralizeImage(Image img)
        {
            // 1.
            Image newImage = ToGrayScale(img);

            // 2.
            Bitmap bmp = new Bitmap(newImage);
            GaussianBlur(bmp, 4);
            

            // 3.
            EquilizeHistogram(bmp);

            newImage = (Image)bmp;

            return newImage;
        }

        #region Fundamental image prodessing

        /// <summary>
        /// Saving Bitmap as JPEG
        /// a quality of 80 means a compression of 20%
        /// overrides existing files
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="bmp">The bitmap.</param>
        /// <param name="quality">The quality (worst: 0 - best: 100L)</param>
        public static void SaveJpeg(string path, Bitmap bmp, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam =
               new EncoderParameter(Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = ImageHandling.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
            {
                throw new Exception("The jpeg codec is not available!");
            }

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            bmp.Save(path, jpegCodec, encoderParams);
        }

        /// <summary>
        /// Returns the encoder info for the given mimeType
        /// </summary>
        /// <param name="mimeType">mimeType</param>
        /// <returns>encoder or null</returns>
        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }


        /// <summary>
        /// Crops the given image
        /// by cloning the original image and taking a rectangle of the original
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="cropArea">The crop area.</param>
        /// <returns></returns>
        public static Image cropImage(Image img, Rectangle cropArea)
        {
            try
            {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea,
                bmpImage.PixelFormat);
                return (Image)(bmpCrop);
            }
            catch (OutOfMemoryException)
            {
                throw new RectangleDoesNotFitToImageException();
            }

        }


        /// <summary>
        /// Resizes an image proportionally
        /// </summary>
        /// <param name="imgToResize">The img to resize.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        #endregion


        #region GreyScale Filter

        //Gilles Khouzams colour corrected grayscale shear
        private static ColorMatrix cm = new ColorMatrix(new float[][]{   
                                               new float[]{0.3f,  0.3f, 0.3f,  0,  0},
                                               new float[]{0.59f,0.59f,0.59f,  0,  0},
                                               new float[]{0.11f,0.11f,0.11f,  0,  0},
                                               new float[]{0,  0,    0,    1,  0,  0},
                                               new float[]{0,  0,    0,    0,  1,  0},
                                               new float[]{0,  0,    0,    0,  0,  1}});

        /// <summary>
        /// Convert a colour image to grayscale
        /// (same function as in WebCamera.Filters)
        /// </summary>
        /// <param name="img">The img.</param>
        /// <returns>new image</returns>
        public static Image ToGrayScale(Image img)
        {
            Graphics g = Graphics.FromImage(img);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            return img;
        }

        #endregion


        #region Gaussian Blur Filter
        /// see: http://www.codeproject.com/KB/GDI-plus/csharpfilters.aspx
        /// for more filters...
        
        /// <summary>
        /// A smoothing effect
        /// 
        /// We ascribe values to all our pixels, so that the weight of each pixel is spread
        /// over the surrounding area.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="nWeight">The n weight.</param>
        /// <returns></returns>
        public static bool Smooth(Bitmap b, int nWeight /* default to 1 */)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;

            return Conv3x3(b, m);
        }

        /// <summary>
        /// Gaussian blur
        /// 
        /// [ 1 2 1 ]
        /// [ 2 4 2 ]
        /// [ 1 2 1 ] /16+0
        /// 
        /// Gaussian Blur filters locate significant color transitions in an image,
        /// then create intermediary colors to soften the edges. 
        /// 
        /// </summary>
        /// <param name="b">The source bitmap</param>
        /// <param name="nWeight">filter weight
        /// The middle value is the one you can alter with the filter provided,
        /// you can see that the default value especially makes for a circular effect,
        /// with pixels given less weight the further they go from the edge.
        /// <returns>The blured bitmap</returns>
        public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = nWeight + 12;

            return Conv3x3(b, m);
        }


        /// <summary>
        /// convolution filters need a pixel matrix like this:
        /// [0 0 0]
        /// [0 1 0]
        /// [0 0 0] / 1+ 0
        /// 
        /// The idea is that the pixel we are processing,
        /// and the eight that surround it, are each given a weight.
        /// The total value of the matrix is divided by a factor,
        /// and optionally an offset is added to the end value.
        /// </summary>
        private class ConvMatrix
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 1, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;
            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
            }
        }


        /// <summary>
        /// The pixel processing code,
        /// calculates each pixel value by the help of a convolution matrix
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        private static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                            (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                            (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }


        #endregion


        #region Histogram equalization

        /// <summary>
        /// Histogram equalization is the technique by which the dynamic range
        /// of the histogram of an image is increased. Histogram equalization
        /// assigns the intensity values of pixels in the input image such that
        /// the output image contains a uniform distribution of intensities.
        /// 
        /// It improves contrast and the goal of histogram equalization is to
        /// obtain a uniform histogram.
        /// 
        /// see: http://www.codersource.net/csharp_histogram_equalization.aspx
        /// </summary>
        /// <param name="bmp">The equilized bitmap image</param>
        public static void EquilizeHistogram(Bitmap bmp)
        {

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                                              ImageLockMode.ReadWrite,
                                              PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                int remain = data.Stride - data.Width * 3;

                int[] histogram = new int[256];
                for (int i = 0; i < histogram.Length; i++)
                    histogram[i] = 0;

                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        int mean = ptr[0] + ptr[1] + ptr[2];
                        mean /= 3;

                        histogram[mean]++;
                        ptr += 3;
                    }

                    ptr += remain;
                }

                float[] LUT = equilize(histogram, data.Width * data.Height);
                ptr = (byte*)data.Scan0;

                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        int index = ptr[0];
                        byte nValue = (byte)LUT[index];
                        if (LUT[index] > 255)
                            nValue = 255;
                        ptr[0] = ptr[1] = ptr[2] = nValue;
                        ptr += 3;
                    }

                    ptr += remain;
                }

                ptr = (byte*)data.Scan0;

                histogram = new int[256];
                for (int i = 0; i < histogram.Length; i++)
                    histogram[i] = 0;

                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        int mean = ptr[0];

                        histogram[mean]++;
                        ptr += 3;
                    }

                    ptr += remain;
                }

            } // unsafe

            bmp.UnlockBits(data);
        }


        /// <summary>
        /// used by equilizeHist
        /// </summary>
        /// <param name="histogram">The histogram.</param>
        /// <param name="numPixel">The num pixel.</param>
        /// <returns></returns>
        private static float[] equilize(int[] histogram, long numPixel)
        {
            float[] hist = new float[256];

            hist[0] = histogram[0] * histogram.Length / numPixel;
            long prev = histogram[0];
            string str = "";
            str += (int)hist[0] + "\n";

            for (int i = 1; i < hist.Length; i++)
            {
                prev += histogram[i];
                hist[i] = prev * histogram.Length / numPixel;
                str += (int)hist[i] + "   _" + i + "\t";
            }

            //	MessageBox.Show( str );
            return hist;

        }


        #endregion
    }

    class RectangleDoesNotFitToImageException : Exception
    {

        /// <summary>
        /// Gets a message that describes the current exception.
        /// Thrown by ImageHandling.CropImage
        /// </summary>
        /// <value></value>
        /// <returns>The error message that explains the reason for the exception</returns>
        public override string Message
        {
            get
            {
                return "It is not possible to crop the image." + System.Environment.NewLine
                     + "Take care that the rectanlge stays within coordinatesof the image!";
            }
        }
    }
}
