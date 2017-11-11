using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;
using System.Drawing;

namespace SearchSimilarImages
{
    class FaceDetector
    {
        public static Rectangle detectFace(Bitmap bitmap)
        {
            var rectangle = new Rectangle();
            var cascade = new FaceHaarCascade();
            var detector = new HaarObjectDetector(cascade, 600);

            detector.SearchMode = ObjectDetectorSearchMode.Default;
            detector.ScalingFactor = 1.5F;
            detector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
            detector.UseParallelProcessing = true;
            detector.Suppression = 3;

            var faceObjects = detector.ProcessFrame(bitmap);
            var possbleFaces = new List<Rectangle>();
            foreach (var face in faceObjects) {
                if (face.Width > 100 && face.Height > 100)
                {
                    possbleFaces.Add(face);
                }
            }
            if(possbleFaces.Count > 0) {
                int x = possbleFaces.Sum((r) => r.X) / possbleFaces.Count;
                int y = possbleFaces.Sum((r) => r.Y) / possbleFaces.Count;
                int width = possbleFaces.Sum((r) => r.Width) / possbleFaces.Count;
                int height = possbleFaces.Sum((r) => r.Width) / possbleFaces.Count;
                rectangle = new Rectangle(x, y, width, height);
            }
            return rectangle;
        }
    }
}
