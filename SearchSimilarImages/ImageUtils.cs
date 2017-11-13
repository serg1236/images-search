using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SearchSimilarImages
{
    class ImageUtils
    {
        public static Bitmap histogramEqualization(Bitmap sourceImage)
        {
            Bitmap renderedImage = sourceImage;

            uint pixels = (uint)renderedImage.Height * (uint)renderedImage.Width;
            decimal Const = 255 / (decimal)pixels;

            int x, y, R, G, B;

            ImageStatistics statistics = new ImageStatistics(renderedImage);

            //Create histogram arrays for R,G,B channels
            int[] cdfR = statistics.Red.Values.ToArray();
            int[] cdfG = statistics.Green.Values.ToArray();
            int[] cdfB = statistics.Blue.Values.ToArray();

            //Convert arrays to cumulative distribution frequency data
            for (int r = 1; r <= 255; r++)
            {
                cdfR[r] = cdfR[r] + cdfR[r - 1];
                cdfG[r] = cdfG[r] + cdfG[r - 1];
                cdfB[r] = cdfB[r] + cdfB[r - 1];
            }

            for (y = 0; y < renderedImage.Height; y++)
            {
                for (x = 0; x < renderedImage.Width; x++)
                {
                    Color pixelColor = renderedImage.GetPixel(x, y);

                    R = (int)((decimal)cdfR[pixelColor.R] * Const);
                    G = (int)((decimal)cdfG[pixelColor.G] * Const);
                    B = (int)((decimal)cdfB[pixelColor.B] * Const);

                    Color newColor = Color.FromArgb(R, G, B);
                    renderedImage.SetPixel(x, y, newColor);
                }
            }
            return renderedImage;
        }

        //by Red channel only. Suitable for greyscale
        public static int[] getCumulativeHistogram(Bitmap image)
        {
            ImageStatistics statistics = new ImageStatistics(image);

            //Create histogram arrays for R,G,B channels
            int[] cdfR = statistics.Red.Values.ToArray();

            //Convert arrays to cumulative distribution frequency data
            for (int r = 1; r <= 255; r++)
            {
                cdfR[r] = cdfR[r] + cdfR[r - 1];
            }
            return cdfR;
        }


        public static int[] getHistogram(Bitmap image)
        {
            ImageStatistics statistics = new ImageStatistics(image);
            return statistics.Red.Values.ToArray();
        }

        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }
    }
}
