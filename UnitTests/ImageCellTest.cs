using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using SearchSimilarImages;

namespace UnitTests
{
    [TestClass]
    public class ImageCellTest
    {
        [TestMethod]
        public void ShouldExtractProperFeaturesForSolidFillImage()
        {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Black, 0, 0, 300, 300);
            ImageCell cell = new ImageCell(bitmap, new Point(0, 0), new Point(300, 300), 3, 3, false);
            Assert.AreEqual(3, cell.GridValues.GetLength(0));
            Assert.AreEqual(3, cell.GridValues.GetLength(1));
            CollectionAssert.AreEqual(new int[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }, cell.GridValues);
        }

        [TestMethod]
        public void ShouldExtractProperFeaturesForGradientFillImage()
        {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Black, 0, 0, 300, 100);
            g.FillRectangle(Brushes.Gray, 0, 100, 300, 100);
            g.FillRectangle(Brushes.White, 0, 200, 300, 100);
            ImageCell cell = new ImageCell(bitmap, new Point(0, 0), new Point(300, 300), 3, 3, false);
            CollectionAssert.AreEqual(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } }, cell.GridValues);
            ImageCell cell2 = new ImageCell(bitmap, new Point(0, 0), new Point(300, 300), 3, 3, true);
            CollectionAssert.AreEqual(new int[,] { { 0, 0, 0 }, { 255, 1, 0 }, { 0, 0, 0 } }, cell2.GridValues);
        }

        [TestMethod]
        public void ShouldExtractProperChartValuesForGradientFillImage()
        {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Black, 0, 0, 300, 100);
            g.FillRectangle(Brushes.Gray, 0, 100, 300, 100);
            g.FillRectangle(Brushes.White, 0, 200, 300, 100);
            ImageCell cell = new ImageCell(bitmap, new Point(0, 0), new Point(300, 300), 3, 3, false);
            foreach (var chartPoint in cell.cellChartPoints)
            {
                if (chartPoint.X == 0)
                {
                    Assert.AreEqual(2, chartPoint.Y);
                } 
                else if(chartPoint.X == 128) {
                    Assert.AreEqual(5, chartPoint.Y);
                }
                else if (chartPoint.X == 255)
                {
                    Assert.AreEqual(8, chartPoint.Y);
                }
                else
                {
                    Assert.AreEqual(0, chartPoint.Y);
                }
            }
            ImageCell cell2 = new ImageCell(bitmap, new Point(0, 0), new Point(300, 300), 3, 3, true);
            foreach (var chartPoint in cell2.cellChartPoints)
            {
                if (chartPoint.X == 255)
                {
                    Assert.AreEqual(5, chartPoint.Y);
                }
                else
                {
                    Assert.AreEqual(2, chartPoint.Y);
                }
            }
        }

        [TestMethod]
        public void ShouldExtractProperChartValuesForSolidFillImage()
        {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Black, 0, 0, 300, 300);
            ImageCell cell = new ImageCell(bitmap, new Point(0, 0), new Point(300, 300), 3, 3, false);
            foreach (var chartPoint in cell.cellChartPoints)
            {
                if (chartPoint.X == 0)
                {
                    Assert.AreEqual(5, chartPoint.Y);
                }
                else
                {
                    Assert.AreEqual(0, chartPoint.Y);
                }
            }
        }
    }
}
