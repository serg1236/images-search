using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SearchSimilarImages
{
    public class ImageCell
    {
        public Point LeftUpperCorner { set; get; }
        public Point RightLowerCorner { set; get; }
        public int [,] GridValues { set; get; }

        public List<Point> cellChartPoints { set; get; }

        public ImageCell(Bitmap imageBitmap, Point leftUpperCorner, Point rightLowerCorner, int gridColCount, int gridRowCount, bool useSegments)
        {
            cellChartPoints = new List<Point>();
            LeftUpperCorner = leftUpperCorner;
            RightLowerCorner = rightLowerCorner;
            var values = new int[256];
            var pointsSums = new Tuple<long, long>[256];
            for (int i = 0; i < pointsSums.Length; i++) {
                pointsSums[i] = new Tuple<long, long>(0L, 0L);
            }
            //fragments
            for (var i = leftUpperCorner.X; i < rightLowerCorner.X; i++)
            {
                for (var j = leftUpperCorner.Y; j < rightLowerCorner.Y; j++)
                {
                    int colorValue = imageBitmap.GetPixel(i, j).R;
                    values[colorValue] += 1;
                    pointsSums[colorValue] = new Tuple<long, long>(pointsSums[colorValue].Item1 + i, pointsSums[colorValue].Item2 + j);
                }
            }
            if (useSegments)
            {
                //segments
                var tempSums = new Tuple<long, long>[256];
                var tempValues = new int[256];
                for (int i = 0; i < pointsSums.Length; i++)
                {
                    tempSums[i] = new Tuple<long, long>(0L, 0L);
                }
                for (var i = 0; i < 256; i++)
                {
                    for (var j = 0; j <= i; j++)
                    {
                        tempValues[i] += values[j];
                        tempSums[i] = new Tuple<long, long>(tempSums[i].Item1 + pointsSums[j].Item1, tempSums[i].Item2 + pointsSums[j].Item2);
                    }
                }
                pointsSums = tempSums;
                values = tempValues;
            }
            
            GridValues = initGridValues(values, pointsSums, gridRowCount, gridColCount);
            
        }

        private int[,] initGridValues(int[] characteristicValues, Tuple<long, long>[] pointsSums, int rowCount, int colCount)
        {

            double columnWidth = (double)(RightLowerCorner.X - LeftUpperCorner.X) / (double)colCount;
            double rowHeight = (double)(RightLowerCorner.Y - LeftUpperCorner.Y) / (double)rowCount;
            var values = new int[colCount, rowCount];
            for (var i = 0; i < 256; i++)
            {
                if (characteristicValues[i] != 0)
                {
                    var avgX = pointsSums[i].Item1 / characteristicValues[i];
                    var avgY = pointsSums[i].Item2 / characteristicValues[i];
                    Point location = findGridCellIndex(values.GetLength(0), values.GetLength(1), avgX, avgY, columnWidth, rowHeight);
                    values[location.X, location.Y] += 1;
                    cellChartPoints.Add(new Point(i, location.Y * rowCount + location.X + 1));
                }
                else
                {
                    cellChartPoints.Add(new Point(i, 0));
                }
            }
            return values;
        }

        private Point findGridCellIndex(int columns, int rows, long avgX, long avgY, double columnWidth, double rowHeight)
        {
            var cellWidth = RightLowerCorner.X - LeftUpperCorner.X;
            var cellHeight = RightLowerCorner.Y - LeftUpperCorner.Y;
            avgX -= LeftUpperCorner.X;
            avgY -= LeftUpperCorner.Y;
            int i = (int)(avgX  / columnWidth);
            if (i == columns)
            {
                i = columns - 1;
            }

            int j = (int)(avgY / rowHeight);
            if (j == rows)
            {
                j = rows - 1;
            }
            return new Point(i, j);
            
        }

        public static int calculateDifference(List<ImageCell> sourceImageCells, List<ImageCell> currentImageCells)
        {
            var different = 0;
            int gridColCount = 1;
            int gridRowCount = 1;
            for (int k = 0; k < sourceImageCells.Count; k++)
            {

                var sourceValues = sourceImageCells.ElementAt(k).GridValues;
                var currentValues = currentImageCells.ElementAt(k).GridValues;
                gridColCount = sourceValues.GetLength(0);
                gridRowCount = sourceValues.GetLength(1);


                for (var i = 0; i < gridColCount; i++)
                {
                    for (var j = 0; j < gridRowCount; j++)
                    {
                        if (sourceValues[i, j] > currentValues[i, j])
                            different += sourceValues[i, j] - currentValues[i, j];
                        else
                            different += currentValues[i, j] - sourceValues[i, j];
                    }
                }
            }

            return different;
        }
    }
}
