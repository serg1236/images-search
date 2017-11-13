using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SearchSimilarImages
{
    class MatrixCalculator
    {
        public static Dictionary<string, Dictionary<string, double>> calculate(Dictionary<string, List<Point>[,]> data)
        {
            var result = new Dictionary<string, Dictionary<string, double>>();
            data.Keys.ToList().ForEach(key =>
            {
                var currentResult = new Dictionary<string, double>();
                List<Point>[,] currentImage;
                data.TryGetValue(key, out currentImage);
                var cols = currentImage.GetLength(0);
                var rows = currentImage.GetLength(1);
                data.Keys.ToList().ForEach(key2 =>
                {
                    List<Point>[,] currentImage2;
                    data.TryGetValue(key2, out currentImage2);
                    var differences = new List<double>();
                    for (int i = 0; i < cols; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            differences.Add(getDifference(currentImage[i, j], currentImage2[i, j]));
                        }
                    }
                    var difference = differences.Sum() / (double)differences.Count;
                    currentResult.Add(key2, difference);
                });
                result.Add(key, currentResult);
            });
            return result;
        }

        public static Dictionary<string, Dictionary<string, double>> calculate(List<Point>[,] data) 
        {
            var result = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    result.Add(i + "," + j, getRow(data[i, j], data));
                }
            }
            return result;
        }

        private static Dictionary<string, double> getRow(List<Point> keydata, List<Point>[,] data)
        {
            var result = new Dictionary<string, double>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    result.Add(i + "," + j, getDifference(keydata, data[i, j]));

                }
            }
            return result;
        }

        private static double getDifference(List<Point> data1, List<Point> data2)
        {
            double sum = 0.0;
            foreach (Point point1 in data1)
            {
                List<Point> point2 = data2.FindAll(p => p.X == point1.X);
                if (point2.Count > 1) throw new Exception("data duplication!");
                if (point2.Count == 1)
                {
                    sum += Math.Pow(point1.Y - point2[0].Y, 2.0);
                }
                else
                {
                    sum += Math.Pow(point1.Y, 2.0);
                }
            }
            foreach (Point point2 in data2)
            {
                List<Point> point1 = data1.FindAll(p => p.X == point2.X);
                if (point1.Count > 1) throw new Exception("data duplication!");
                if (point1.Count == 0)
                {
                    sum += Math.Pow(point2.Y, 2.0);
                }
            }
            return Math.Sqrt(sum);
        }
    }
}
