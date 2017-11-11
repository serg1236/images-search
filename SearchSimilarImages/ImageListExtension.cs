using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchSimilarImages
{
    static class ImageListExtensions
    {
        public static void AddImage(this ImageList iml, Image bm, string key)
        {
            var imlBm = new Bitmap(iml.ImageSize.Width, iml.ImageSize.Height);
            using (var gr = Graphics.FromImage(imlBm))
            {
                gr.Clear(Color.Transparent);
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var sourceRect = new RectangleF(0, 0, bm.Width, bm.Height);
                var destRect = new RectangleF(0, 0, imlBm.Width, imlBm.Height);
                destRect = ScaleRect(sourceRect, destRect);

                gr.DrawImage(bm, destRect, sourceRect, GraphicsUnit.Pixel);
            }

            iml.Images.Add(key, imlBm);
        }

        private static RectangleF ScaleRect(RectangleF sourceRect, RectangleF destRect)
        {
            var sourceAspect = sourceRect.Width / sourceRect.Height;
            var wid = destRect.Width;
            var hgt = destRect.Height;
            var destAspect = wid / hgt;

            if (sourceAspect > destAspect)
            {
                // The source is relatively short and wide.
                // Use all of the available width.
                hgt = wid / sourceAspect;
            }
            else
            {
                // The source is relatively tall and thin.
                // Use all of the available height.
                wid = hgt * sourceAspect;
            }

            // Center it.
            var x = destRect.Left + (destRect.Width - wid) / 2;
            var y = destRect.Top + (destRect.Height - hgt) / 2;
            return new RectangleF(x, y, wid, hgt);
        }
    }
}
