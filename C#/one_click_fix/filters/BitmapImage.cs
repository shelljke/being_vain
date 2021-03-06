﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
/*using ChartDirector;*/
using System.IO;

namespace SimpleImageProcessing
{
        /// <summary>
        /// This class provides methods to Resize and Apply Filters to bitmap images.
        /// 
        /// ideas from 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp11152001.asp
        /// http://www.msnewsgroups.net/group/microsoft.public.dotnet.languages.csharp/topic9351.aspx
        /// </summary>
        public unsafe class ImagerBitmap
        {
            /// <summary>
            /// This struct is used to hold the RGB values when we find a pixel using the pointer
            /// </summary>
            public struct PixelData
            {
                public byte Blue;
                public byte Green;
                public byte Red;
            }
            /// <summary>
            /// This object contains pointer addressable information about the bitmap
            /// </summary>
            public BitmapData _bitmapData = null;
            /// <summary>
            /// The pointer to the upper left corner of the bitmap
            /// </summary>
            public byte* pBase = null;
            public Bitmap _bitmap = null;
            /// <summary>
            /// Get the Image we are working with
            /// </summary>
            public Bitmap Bitmap
            {
                get
                {
                    return _bitmap;
                }
            }
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="b">Bitmap to use as the basis of the Imager</param>
            public ImagerBitmap(Bitmap b)
            {
                if (b.PixelFormat != PixelFormat.Format24bppRgb)
                {
                    //Convert the image into Format24bppRgb since our unmanaged code 
                    //can walk that image type
                    Bitmap b2 = new Bitmap(b.Size.Width, b.Size.Height, PixelFormat.Format24bppRgb);
                    Graphics g = Graphics.FromImage(b2);
                    g.DrawImage(b, new Point(0, 0));
                    _bitmap = b2;
                    g.Dispose();
                }
                else
                {
                    _bitmap = b;
                }
                LockBitmap();
            }
            /// <summary>
            /// Load a pixel with color
            /// </summary>
            /// <param name="x">Column</param>
            /// <param name="y">Row</param>
            /// <param name="c">Color</param>
            public void SetPixel(int x, int y, Color c)
            {
                PixelData* p = PixelAt(x, y);
                p->Red = c.R;
                p->Green = c.G;
                p->Blue = c.B;
            }
            /// <summary>
            /// Get a pixel
            /// </summary>
            /// <param name="x">Column</param>
            /// <param name="y">Row</param>
            /// <returns>Color</returns>
            public Color GetPixel(int x, int y)
            {
                PixelData* p = PixelAt(x, y);
                return Color.FromArgb((int)p->Red, (int)p->Green, (int)p->Blue);
            }
            /// <summary>
            /// Get the Grey value for a give pixel
            /// </summary>
            /// <param name="column">Column</param>
            /// <param name="row">Row</param>
            /// <returns>Grey value for the pixel</returns>
            public int GetGreyPixel(int column, int row)
            {
                return (int)((GetPixel(column, row).R * 0.3) + (GetPixel(column, row).G * 0.59)
                    + (GetPixel(column, row).B * 0.11));
            }
            /// <summary>
            /// Use the 2 most signifigant bits from each of the values in the RGB to get an in value 
            /// for the histogram
            /// </summary>
            /// <param name="column">Column</param>
            /// <param name="row">Row</param>
            /// <returns>Histogram Value</returns>
            public int GetRGBHistogramValue(int column, int row)
            {
                Color c = GetPixel(column, row);
                int val = 0;
                int tmp = 0;
                tmp = c.R;
                if (tmp - 128 > 0)
                {
                    tmp -= 128;
                    val += 32;
                }
                if (tmp - 64 > 0)
                {
                    val += 16;
                }
                tmp = c.G;
                if (tmp - 128 > 0)
                {
                    tmp -= 128;
                    val += 8;
                }
                if (tmp - 64 > 0)
                {
                    val += 4;
                }
                tmp = c.B;
                if (tmp - 128 > 0)
                {
                    tmp -= 128;
                    val += 2;
                }
                if (tmp - 64 > 0)
                {
                    val += 1;
                }
                return val;
            }
            /// <summary>
            /// Lock the bitmap so we can use the pointers to access it
            /// </summary>
            public void LockBitmap()
            {
                _bitmapData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height),
                                       ImageLockMode.ReadWrite, _bitmap.PixelFormat);
                pBase = (Byte*)_bitmapData.Scan0.ToPointer();
            }
            /// <summary>
            /// Get a pointer to a pixel
            /// </summary>
            /// <param name="x">Column</param>
            /// <param name="y">Row</param>
            /// <returns></returns>
            public unsafe PixelData* PixelAt(int x, int y)
            {
                return (PixelData*)(pBase + y * _bitmapData.Stride + x * sizeof(PixelData));
            }
            /// <summary>
            /// Unlock the bitmap to end the pointer access session
            /// </summary>
            public void UnlockBitmap()
            {
                _bitmap.UnlockBits(_bitmapData);
                _bitmapData = null;
                pBase = null;
            }
            /// <summary>
            /// Get a 3x3 matrix of the pixles around the center
            /// </summary>
            /// <param name="row">Center Row</param>
            /// <param name="column">Center Column</param>
            /// <returns>3x3 matrix of the pixles around the center</returns>
            public Color[,] Get3x3(int row, int column)
            {
                Color[,] c = new Color[3, 3];
                c[0, 0] = this.GetPixel(column - 1, row - 1);
                c[0, 1] = this.GetPixel(column - 1, row);
                c[0, 2] = this.GetPixel(column - 1, row + 1);
                c[1, 0] = this.GetPixel(column, row - 1);
                c[1, 1] = this.GetPixel(column, row);
                c[1, 2] = this.GetPixel(column, row + 1);
                c[2, 0] = this.GetPixel(column + 1, row - 1);
                c[2, 1] = this.GetPixel(column + 1, row);
                c[2, 2] = this.GetPixel(column + 1, row + 1);
                return c;
            }
            public int[,] GetGrey3x3(int row, int column)
            {
                int[,] c = new int[3, 3];
                c[0, 0] = this.GetGreyPixel(column - 1, row - 1);
                c[0, 1] = this.GetGreyPixel(column - 1, row);
                c[0, 2] = this.GetGreyPixel(column - 1, row + 1);
                c[1, 0] = this.GetGreyPixel(column, row - 1);
                c[1, 1] = this.GetGreyPixel(column, row);
                c[1, 2] = this.GetGreyPixel(column, row + 1);
                c[2, 0] = this.GetGreyPixel(column + 1, row - 1);
                c[2, 1] = this.GetGreyPixel(column + 1, row);
                c[2, 2] = this.GetGreyPixel(column + 1, row + 1);
                return c;
            }
            /// <summary>
            /// Get at 5x5 matrix of the pixels around the center
            /// </summary>
            /// <param name="row">Center Row</param>
            /// <param name="column">Center Column</param>
            /// <returns>5x5 matrix of pixles around center</returns>
            public Color[,] Get5x5(int row, int column)
            {
                Color[,] c = new Color[5, 5];
                c[0, 0] = this.GetPixel(column - 2, row - 2);
                c[0, 1] = this.GetPixel(column - 2, row - 1);
                c[0, 2] = this.GetPixel(column - 2, row);
                c[0, 3] = this.GetPixel(column - 2, row + 1);
                c[0, 4] = this.GetPixel(column - 2, row + 2);
                c[1, 0] = this.GetPixel(column - 1, row - 2);
                c[1, 1] = this.GetPixel(column - 1, row - 1);
                c[1, 2] = this.GetPixel(column - 1, row);
                c[1, 3] = this.GetPixel(column - 1, row + 1);
                c[1, 4] = this.GetPixel(column - 1, row + 2);
                c[2, 0] = this.GetPixel(column, row - 2);
                c[2, 1] = this.GetPixel(column, row - 1);
                c[2, 2] = this.GetPixel(column, row);
                c[2, 3] = this.GetPixel(column, row + 1);
                c[2, 4] = this.GetPixel(column, row + 2);
                c[3, 0] = this.GetPixel(column + 1, row - 2);
                c[3, 1] = this.GetPixel(column + 1, row - 1);
                c[3, 2] = this.GetPixel(column + 1, row);
                c[3, 3] = this.GetPixel(column + 1, row + 1);
                c[3, 4] = this.GetPixel(column + 1, row + 2);
                c[4, 0] = this.GetPixel(column + 2, row - 2);
                c[4, 1] = this.GetPixel(column + 2, row - 1);
                c[4, 2] = this.GetPixel(column + 2, row);
                c[4, 3] = this.GetPixel(column + 2, row + 1);
                c[4, 4] = this.GetPixel(column + 2, row + 2);
                return c;
            }
            /// <summary>
            /// Perform laplace edge detection on the image
            /// </summary>
            /// <param name="b">Source Image</param>
            /// <returns>Edges</returns>
            public static Bitmap Laplace(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 1; column < i.Bitmap.Width - 1; column++)
                {
                    for (int row = 1; row < i.Bitmap.Height - 1; row++)
                    {
                        Color[,] c = i.Get3x3(row, column);
                        int red = (((c[0, 0].R + c[0, 1].R + c[0, 2].R + c[1, 0].R + c[1, 2].R + c[2, 0].R
                            + c[2, 1].R + c[2, 2].R) * -1) + (c[1, 1].R * 8)) + 128;
                        int green = (((c[0, 0].G + c[0, 1].G + c[0, 2].G + c[1, 0].G + c[1, 2].G
                            + c[2, 0].G + c[2, 1].G + c[2, 2].G) * -1) + (c[1, 1].G * 8)) + 128;
                        int blue = (((c[0, 0].B + c[0, 1].B + c[0, 2].B + c[1, 0].B + c[1, 2].B + c[2, 0].B
                            + c[2, 1].B + c[2, 2].B) * -1) + (c[1, 1].B * 8)) + 128;
                        if (red >= 128) red = 0; else red = 255;
                        if (green >= 128) green = 0; else green = 255;
                        if (blue >= 128) blue = 0; else blue = 255;
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            public static Bitmap LaplaceGreyscale(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 1; column < i.Bitmap.Width - 1; column++)
                {
                    for (int row = 1; row < i.Bitmap.Height - 1; row++)
                    {
                        int[,] c = i.GetGrey3x3(row, column);
                        int val = (((c[0, 0] + c[0, 1] + c[0, 2] + c[1, 0] + c[1, 2] + c[2, 0] + c[2, 1]
                            + c[2, 2]) * -1) + (c[1, 1] * 8)) + 128;
                        if (val >= 128) val = 0; else val = 255;
                        i2.SetPixel(column, row, Color.FromArgb(val, val, val));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }

            /// <summary>
            /// Subtract b2 from b1 and normalize the image
            /// </summary>
            /// <param name="b1">Image</param>
            /// <param name="b2">Image</param>
            /// <returns>Normalized Image</returns>
            public static Bitmap Subtract(Bitmap b1, Bitmap b2)
            {
                if (b1.Width != b2.Width || b1.Height != b2.Height)
                    throw new Exception("Images not the same size cannot subtract");
                ImagerBitmap i = new ImagerBitmap(b1.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b2.Clone() as Bitmap);
                int[,] red = new int[i.Bitmap.Width, i.Bitmap.Height];
                int[,] blue = new int[i.Bitmap.Width, i.Bitmap.Height];
                int[,] green = new int[i.Bitmap.Width, i.Bitmap.Height];
                int redMax = 0;
                int redMin = 0;
                int redRange = 0;
                int blueMax = 0;
                int blueMin = 0;
                int blueRange = 0;
                int greenMax = 0;
                int greenMin = 0;
                int greenRange = 0;
                //fill the arrays with the subtracted values
                //Keep track of the min and max values for later
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        Color c1 = i.GetPixel(column, row);
                        Color c2 = i2.GetPixel(column, row);
                        red[column, row] = c2.R - c1.R;
                        blue[column, row] = c2.B - c1.B;
                        green[column, row] = c2.G - c1.G;
                        if (red[column, row] > redMax) redMax = red[column, row];
                        if (red[column, row] < redMin) redMin = red[column, row];
                        if (blue[column, row] > blueMax) blueMax = blue[column, row];
                        if (blue[column, row] < blueMin) blueMin = blue[column, row];
                        if (green[column, row] > greenMax) greenMax = green[column, row];
                        if (green[column, row] < greenMin) greenMin = green[column, row];
                    }
                }
                //find the range of the min an max
                redRange = Math.Abs(redMax - redMin);
                blueRange = Math.Abs(blueMax - blueMin);
                greenRange = Math.Abs(greenRange - greenMin);
                //Normalize the values in the arrays and load the result image
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        if (redRange != 0)
                            red[column, row] = 255 - (((redMax - red[column, row]) * 255) / redRange);
                        if (blueRange != 0)
                            blue[column, row] = 255 - (((blueMax - blue[column, row]) * 255) / blueRange);
                        if (greenRange != 0)
                            green[column, row] = 255 - (((greenMax - green[column, row]) * 255) / greenRange);
                        if (red[column, row] < 0)
                            red[column, row] = 0;
                        if (blue[column, row] < 0)
                            blue[column, row] = 0;
                        if (green[column, row] < 0)
                            green[column, row] = 0;
                        i2.SetPixel(column, row, Color.FromArgb(red[column, row], green[column, row],
                            blue[column, row]));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Get the red pixels from the bitmap
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap GetRedBitmap(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        i.SetPixel(column, row, Color.FromArgb(i.GetPixel(column, row).R, 0, 0));
                    }
                }
                i.UnlockBitmap();
                return i.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Get the Blue Pixes from the bitmap
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap GetBlueBitmap(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        i.SetPixel(column, row, Color.FromArgb(0, 0, i.GetPixel(column, row).B));
                    }
                }
                i.UnlockBitmap();
                return i.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Get the green pixels from the image
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap GetGreenBitmap(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        i.SetPixel(column, row, Color.FromArgb(0, i.GetPixel(column, row).G, 0));
                    }
                }
                i.UnlockBitmap();
                return i.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Make the image Grey scale
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap GetGreyScaleBitmap(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        int val = i.GetGreyPixel(column, row);
                        i.SetPixel(column, row, Color.FromArgb(val, val, val));
                    }
                }
                i.UnlockBitmap();
                return i.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Make the image black and white
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap GetBlackAndWhiteBitmap(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                double[] histogram = new double[256];
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        histogram[i.GetGreyPixel(column, row)]++;
                    }
                }
                //find the position of the max value on the left
                int leftK = 0;
                for (int k = 0; k < 128; k++)
                {
                    if (histogram[k] > histogram[leftK]) leftK = k;
                }
                //find the position of the max value on the right
                int rightK = 0;
                for (int k = 128; k < 256; k++)
                {
                    if (histogram[k] > histogram[rightK]) rightK = k;
                }
                //find the min value between the 2 local maxes
                int localMin = rightK;
                for (int k = leftK; k < rightK; k++)
                {
                    if (histogram[k] < histogram[localMin]) localMin = k;
                }
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        int val = (i.GetPixel(column, row).R + i.GetPixel(column, row).G
                            + i.GetPixel(column, row).B) / 3;
                        if (val > localMin)
                            val = 255;
                        else
                            val = 0;
                        i.SetPixel(column, row, Color.FromArgb(val, val, val));
                    }
                }
                i.UnlockBitmap();
                return i.Bitmap.Clone() as Bitmap;
            }
            public static Bitmap GetBlackAndWhiteBitmap2(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                double[] histogram = new double[256];
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        histogram[i.GetGreyPixel(column, row)]++;
                    }
                }
                double k = b.Width * b.Height;
                double half = k / 2;
                int middle = 0;
                while (k > half)
                {
                    k = k - histogram[middle];
                    middle++;
                }
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        int val = (i.GetPixel(column, row).R + i.GetPixel(column, row).G
                            + i.GetPixel(column, row).B) / 3;
                        if (val > middle)
                            val = 255;
                        else
                            val = 0;
                        i.SetPixel(column, row, Color.FromArgb(val, val, val));
                    }
                }
                i.UnlockBitmap();
                return i.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Perform a Box filter using a 3x3 Mask
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap Box3x3(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 1; column < i.Bitmap.Width - 1; column++)
                {
                    for (int row = 1; row < i.Bitmap.Height - 1; row++)
                    {
                        Color[,] c = i.Get3x3(row, column);
                        int red = (c[0, 0].R + c[0, 1].R + c[0, 2].R + c[1, 0].R + c[1, 2].R + c[2, 0].R
                            + c[2, 1].R + c[2, 2].R + c[1, 1].R) / 9;
                        int green = (c[0, 0].G + c[0, 1].G + c[0, 2].G + c[1, 0].G + c[1, 2].G + c[2, 0].G
                            + c[2, 1].G + c[2, 2].G + c[1, 1].G) / 9;
                        int blue = (c[0, 0].B + c[0, 1].B + c[0, 2].B + c[1, 0].B + c[1, 2].B + c[2, 0].B
                            + c[2, 1].B + c[2, 2].B + c[1, 1].B) / 9;
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Perform a Bionomial filter using a 3x3 Mask
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap Binomial3x3(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 1; column < i.Bitmap.Width - 1; column++)
                {
                    for (int row = 1; row < i.Bitmap.Height - 1; row++)
                    {
                        Color[,] c = i.Get3x3(row, column);
                        int red = ((c[0, 0].R * 1) + (c[0, 1].R * 2) + (c[0, 2].R * 1) + (c[1, 0].R * 2)
                            + (c[1, 1].R * 4) + (c[1, 2].R * 2) + (c[2, 0].R * 1) + (c[2, 1].R * 2)
                            + (c[2, 2].R * 1)) / 16;
                        int green = ((c[0, 0].G * 1) + (c[0, 1].G * 2) + (c[0, 2].G * 1) + (c[1, 0].G * 2)
                            + (c[1, 1].G * 4) + (c[1, 2].G * 2) + (c[2, 0].G * 1) + (c[2, 1].G * 2)
                            + (c[2, 2].G * 1)) / 16;
                        int blue = ((c[0, 0].B * 1) + (c[0, 1].B * 2) + (c[0, 2].B * 1) + (c[1, 0].B * 2)
                            + (c[1, 1].B * 4) + (c[1, 2].B * 2) + (c[2, 0].B * 1) + (c[2, 1].B * 2)
                            + (c[2, 2].B * 1)) / 16;
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Perform a Median filter using a 3x3 mask
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap Median3x3(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 1; column < i.Bitmap.Width - 1; column++)
                {
                    for (int row = 1; row < i.Bitmap.Height - 1; row++)
                    {
                        Color[,] c = i.Get3x3(row, column);
                        int red = Median(c[0, 0].R, c[0, 1].R, c[0, 2].R, c[1, 0].R, c[1, 1].R, c[1, 2].R,
                            c[2, 0].R, c[2, 1].R, c[2, 2].R);
                        int green = Median(c[0, 0].G, c[0, 1].G, c[0, 2].G, c[1, 0].G, c[1, 1].G,
                            c[1, 2].G, c[2, 0].G, c[2, 1].G, c[2, 2].G);
                        int blue = Median(c[0, 0].B, c[0, 1].B, c[0, 2].B, c[1, 0].B, c[1, 1].B, c[1, 2].B,
                            c[2, 0].B, c[2, 1].B, c[2, 2].B);
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Perform a Box filter using a 5x5 Mask
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap Box5x5(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 2; column < i.Bitmap.Width - 2; column++)
                {
                    for (int row = 2; row < i.Bitmap.Height - 2; row++)
                    {
                        Color[,] c = i.Get5x5(row, column);
                        int red = (c[0, 0].R + c[0, 1].R + c[0, 2].R + c[0, 3].R + c[0, 4].R + c[1, 0].R
                            + c[1, 1].R + c[1, 2].R + c[1, 3].R + c[1, 4].R + c[2, 0].R + c[2, 1].R
                            + c[2, 2].R + c[2, 3].R + c[2, 4].R + c[3, 0].R + c[3, 1].R + c[3, 2].R
                            + c[3, 3].R + c[3, 4].R + c[4, 0].R + c[4, 1].R + c[4, 2].R + c[4, 3].R
                            + c[4, 4].R) / 25;
                        int green = (c[0, 0].G + c[0, 1].G + c[0, 2].G + c[0, 3].G + c[0, 4].G + c[1, 0].G
                            + c[1, 1].G + c[1, 2].G + c[1, 3].G + c[1, 4].G + c[2, 0].G + c[2, 1].G
                            + c[2, 2].G + c[2, 3].G + c[2, 4].G + c[3, 0].G + c[3, 1].G + c[3, 2].G
                            + c[3, 3].G + c[3, 4].G + c[4, 0].G + c[4, 1].G + c[4, 2].G + c[4, 3].G
                            + c[4, 4].G) / 25;
                        int blue = (c[0, 0].B + c[0, 1].B + c[0, 2].B + c[0, 3].B + c[0, 4].B + c[1, 0].B
                            + c[1, 1].B + c[1, 2].B + c[1, 3].B + c[1, 4].B + c[2, 0].B + c[2, 1].B
                            + c[2, 2].B + c[2, 3].B + c[2, 4].B + c[3, 0].B + c[3, 1].B + c[3, 2].B
                            + c[3, 3].B + c[3, 4].B + c[4, 0].B + c[4, 1].B + c[4, 2].B + c[4, 3].B
                            + c[4, 4].B) / 25;
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Perform a Binomial filter using a 5x5 Mask
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap Binomial5x5(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 2; column < i.Bitmap.Width - 2; column++)
                {
                    for (int row = 2; row < i.Bitmap.Height - 2; row++)
                    {
                        Color[,] c = i.Get5x5(row, column);
                        int red = ((c[0, 0].R * 1) + (c[0, 1].R * 4) + (c[0, 2].R * 6) + (c[0, 3].R * 4)
                            + (c[0, 4].R * 1) + (c[1, 0].R * 4) + (c[1, 1].R * 16) + (c[1, 2].R * 24)
                            + (c[1, 3].R * 16) + (c[1, 4].R * 4) + (c[2, 0].R * 6) + (c[2, 1].R * 24)
                            + (c[2, 2].R * 36) + (c[2, 3].R * 24) + (c[2, 4].R * 6) + (c[3, 0].R * 4)
                            + (c[3, 1].R * 16) + (c[3, 2].R * 24) + (c[3, 3].R * 16) + (c[3, 4].R * 4)
                            + (c[4, 0].R * 1) + (c[4, 1].R * 4) + (c[4, 2].R * 6) + (c[4, 3].R * 4)
                            + (c[4, 4].R * 1)) / 256;
                        int green = ((c[0, 0].G * 1) + (c[0, 1].G * 4) + (c[0, 2].G * 6) + (c[0, 3].G * 4)
                            + (c[0, 4].G * 1) + (c[1, 0].G * 4) + (c[1, 1].G * 16) + (c[1, 2].G * 24)
                            + (c[1, 3].G * 16) + (c[1, 4].G * 4) + (c[2, 0].G * 6) + (c[2, 1].G * 24)
                            + (c[2, 2].G * 36) + (c[2, 3].G * 24) + (c[2, 4].G * 6) + (c[3, 0].G * 4)
                            + (c[3, 1].G * 16) + (c[3, 2].G * 24) + (c[3, 3].G * 16) + (c[3, 4].G * 4)
                            + (c[4, 0].G * 1) + (c[4, 1].G * 4) + (c[4, 2].G * 6) + (c[4, 3].G * 4)
                            + (c[4, 4].G * 1)) / 256;
                        int blue = ((c[0, 0].B * 1) + (c[0, 1].B * 4) + (c[0, 2].B * 6) + (c[0, 3].B * 4)
                            + (c[0, 4].B * 1) + (c[1, 0].B * 4) + (c[1, 1].B * 16) + (c[1, 2].B * 24)
                            + (c[1, 3].B * 16) + (c[1, 4].B * 4) + (c[2, 0].B * 6) + (c[2, 1].B * 24)
                            + (c[2, 2].B * 36) + (c[2, 3].B * 24) + (c[2, 4].B * 6) + (c[3, 0].B * 4)
                            + (c[3, 1].B * 16) + (c[3, 2].B * 24) + (c[3, 3].B * 16) + (c[3, 4].B * 4)
                            + (c[4, 0].B * 1) + (c[4, 1].B * 4) + (c[4, 2].B * 6) + (c[4, 3].B * 4)
                            + (c[4, 4].B * 1)) / 256;
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Perform a Median fiter using a 5x5 Mask
            /// </summary>
            /// <param name="b">Image to Process</param>
            /// <returns>Filtered Image</returns>
            public static Bitmap Median5x5(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                ImagerBitmap i2 = new ImagerBitmap(b.Clone() as Bitmap);
                for (int column = 2; column < i.Bitmap.Width - 2; column++)
                {
                    for (int row = 2; row < i.Bitmap.Height - 2; row++)
                    {
                        Color[,] c = i.Get5x5(row, column);
                        int red = Median(c[0, 0].R, c[0, 1].R, c[0, 2].R, c[0, 3].R, c[0, 4].R, c[1, 0].R,
                            c[1, 1].R, c[1, 2].R, c[1, 3].R, c[1, 4].R, c[2, 0].R, c[2, 1].R, c[2, 2].R,
                            c[2, 3].R, c[2, 4].R, c[3, 0].R, c[3, 1].R, c[3, 2].R, c[3, 3].R, c[3, 4].R,
                            c[4, 0].R, c[4, 1].R, c[4, 2].R, c[4, 3].R, c[4, 4].R);
                        int green = Median(c[0, 0].G, c[0, 1].G, c[0, 2].G, c[0, 3].G, c[0, 4].G, c[1, 0].G,
                            c[1, 1].G, c[1, 2].G, c[1, 3].G, c[1, 4].G, c[2, 0].G, c[2, 1].G, c[2, 2].G,
                            c[2, 3].G, c[2, 4].G, c[3, 0].G, c[3, 1].G, c[3, 2].G, c[3, 3].G, c[3, 4].G,
                            c[4, 0].G, c[4, 1].G, c[4, 2].G, c[4, 3].G, c[4, 4].G);
                        int blue = Median(c[0, 0].B, c[0, 1].B, c[0, 2].B, c[0, 3].B, c[0, 4].B, c[1, 0].B,
                            c[1, 1].B, c[1, 2].B, c[1, 3].B, c[1, 4].B, c[2, 0].B, c[2, 1].B, c[2, 2].B,
                            c[2, 3].B, c[2, 4].B, c[3, 0].B, c[3, 1].B, c[3, 2].B, c[3, 3].B, c[3, 4].B,
                            c[4, 0].B, c[4, 1].B, c[4, 2].B, c[4, 3].B, c[4, 4].B);
                        i2.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    }
                }
                i.UnlockBitmap();
                i2.UnlockBitmap();
                return i2.Bitmap.Clone() as Bitmap;
            }
            /// <summary>
            /// Find the Median value in an array of int's
            /// </summary>
            /// <param name="values">Array of values</param>
            /// <returns>Median value</returns>
            public static int Median(params int[] values)
            {
                Array.Sort(values);
                return values[((values.Length - 1) / 2) + 1];
            }
            /// <summary>
            /// Resize an image
            /// </summary>
            /// <param name="b">Image to resize</param>
            /// <param name="width">Width in pixels</param>
            /// <param name="height">Height in pixels</param>
            /// <returns>New Image</returns>
            public static Bitmap Resize(Bitmap b, int width, int height)
            {
                Bitmap b2 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(b2);
                g.DrawImage(b, new Rectangle(0, 0, width, height), 0, 0, b.Width, b.Height,
                    GraphicsUnit.Pixel);
                g.Dispose();
                return b2;
            }
            /// <summary>
            /// Generate a greyscale histogram chart from the bitmap
            /// </summary>
            /// <param name="b">Image to use</param>
            /// <returns>Histogram chart</returns>
            /*public static Bitmap GenerateGreyscaleHistogram(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                double[] histogram = new double[256];
                string[] lbls = new string[256];
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        histogram[i.GetGreyPixel(column, row)]++;
                    }
                }
                i.UnlockBitmap();
                for (int j = 0; j < 256; j++)
                {
                    if ((j % 30) == 0)
                    {
                        lbls[j] = j.ToString();
                    }
                    else
                    {
                        lbls[j] = string.Empty;
                    }
                }
                XYChart c = new XYChart(b.Width + 60, b.Height + 60);
                c.setPlotArea(40, 40, b.Width - 20, b.Height - 20);
                c.addTitle("Greyscale Historgram", "Arial Bold", 10).setBackground(
                    Chart.metalColor(0x9999ff), -1, 1);
                c.addBarLayer(histogram);
                c.xAxis().setLabels(lbls);
                return c.makeImage() as Bitmap;
            }*/
            /// <summary>
            /// Generate a histogram chart from the bitmap
            /// </summary>
            /// <param name="b">Image to use</param>
            /// <returns>Histogram chart</returns>
           /* public static Bitmap GenerateHistogram(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                double[] histogram = new double[64];
                string[] lbls = new string[64];
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    for (int row = 0; row < i.Bitmap.Height; row++)
                    {
                        histogram[i.GetRGBHistogramValue(column, row)]++;
                    }
                }
                i.UnlockBitmap();
                for (int j = 0; j < 64; j++)
                {
                    if ((j % 10) == 0)
                    {
                        lbls[j] = j.ToString();
                    }
                    else
                    {
                        lbls[j] = string.Empty;
                    }
                }
                XYChart c = new XYChart(b.Width + 60, b.Height + 60);
                c.setPlotArea(40, 40, b.Width - 20, b.Height - 20);
                c.addTitle("Color Historgram", "Arial Bold", 10).setBackground(
                    Chart.metalColor(0x9999ff), -1, 1);
                c.addBarLayer(histogram);
                c.xAxis().setLabels(lbls);
                return c.makeImage() as Bitmap;
            }*/
            /// <summary>
            /// Generate a Chart of a Scan line
            /// </summary>
            /// <param name="b">Image to use</param>
            /// <param name="row">Row to use</param>
            /// <returns>Scan Line Chart</returns>
            /*public static Bitmap GenerateScanLineChart(Bitmap b, int row)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                double[] luminance = new double[b.Width];
                string[] lbls = new string[b.Width];
                double max = double.MinValue;
                double min = double.MaxValue;
                for (int column = 0; column < i.Bitmap.Width; column++)
                {
                    luminance[column] = i.GetGreyPixel(column, row);
                    if (luminance[column] > max) max = luminance[column];
                    if (luminance[column] < min) min = luminance[column];
                    if ((column % 40) == 0)
                    {
                        lbls[column] = column.ToString();
                    }
                    else
                    {
                        lbls[column] = string.Empty;
                    }
                }
                i.UnlockBitmap();
                XYChart c = new XYChart(b.Width + 60, b.Height + 60);
                c.setPlotArea(40, 40, b.Width - 20, b.Height - 20);
                c.addTitle(string.Format("Pixel Luminance for Scan Line {0}, STF {1:0.00}",
                    row.ToString(),
                    (max - min) / (max + min)), "Arial Bold", 10).setBackground(
                    Chart.metalColor(0x9999ff), -1, 1);
                c.addLineLayer(luminance);
                c.xAxis().setLabels(lbls);
                return c.makeImage() as Bitmap;
            }*/
            /// <summary>
            /// Generate a Chart of a Vertical Scan line
            /// </summary>
            /// <param name="b">Image to use</param>
            /// <param name="column">Column to use</param>
            /// <returns>Scan Line Chart</returns>
            /*public static Bitmap GenerateVerticalScanLineChart(Bitmap b, int col)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                double[] luminance = new double[b.Height];
                string[] lbls = new string[b.Height];
                for (int row = 0; row < i.Bitmap.Height; row++)
                {
                    luminance[row] = i.GetGreyPixel(col, row);
                    if ((row % 40) == 0)
                    {
                        lbls[row] = row.ToString();
                    }
                    else
                    {
                        lbls[row] = string.Empty;
                    }
                }
                i.UnlockBitmap();
                XYChart c = new XYChart(b.Width + 60, b.Height + 60);
                c.setPlotArea(40, 40, b.Width - 20, b.Height - 20);
                c.addTitle("Pixel Luminance for Vertical Scan Line " + col.ToString(),
                    "Arial Bold", 10).setBackground(
                    Chart.metalColor(0x9999ff), -1, 1);
                c.addLineLayer(luminance);
                c.xAxis().setLabels(lbls);
                return c.makeImage() as Bitmap;
            }*/
            public static void GenerateExcelFile(Bitmap b)
            {
                ImagerBitmap i = new ImagerBitmap(b.Clone() as Bitmap);
                string fileName = "output.txt";
                int f = 0;
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", "Index", "Row", "Column", "Red",
                        "Green", "Blue", "Gray");
                    for (int column = 0; column < i.Bitmap.Width; column++)
                    {
                        for (int row = 0; row < i.Bitmap.Height; row++)
                        {
                            f++;
                            Color c = i.GetPixel(column, row);
                            int g = i.GetGreyPixel(column, row);
                            sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", f,
                                row, column, c.R, c.G, c.B, g);
                        }
                    }
                }
                i.UnlockBitmap();
                System.Diagnostics.Process.Start(fileName);
            }
        }
    
}
