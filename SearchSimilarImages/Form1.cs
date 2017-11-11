using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SearchSimilarImages
{
    public partial class Form1 : Form
    {
        private List<String> imageListPaths = new List<string>();
        private string[] _filesName;
        private string sourceImagePath;
        public ResultsComparator Comparator { set; get; }
        public List<string> CurrentResults { set; get; }
        public Dictionary<string, List<Point>[,]> chartData;

        public Form1()
        {
            InitializeComponent();
            cboStyle.SelectedIndex = 0;
        }

        private void onChooseImageListButtonClick(object sender, EventArgs e)
        {
            chartsButton.Enabled = false;
            matrixButton.Enabled = false;
            imageListControl.Clear();
            imlLargeIcons.Images.Clear();
            imlSmallIcons.Images.Clear();
            imageListControl.ListViewItemSorter = null;

            imageListControl.SmallImageList = imlSmallIcons;
            imageListControl.LargeImageList = imlLargeIcons;
            _filesName = new string[0];
            imageListPaths = new List<string>();

            var ofd = new OpenFileDialog
            {
                Title = @"Виберіть множину зображень",
                Multiselect = true,
                Filter = @"All|*.*|JPG|*.jpg|JPEG|*.jpeg|PNG|*.png"
            };
            var dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                imageListPaths.AddRange(ofd.FileNames);
                _filesName = ofd.SafeFileNames;
            }

            imageListControl.Items.Clear();
            imlLargeIcons.Images.Clear();
            imlSmallIcons.Images.Clear();
            foreach (var path in imageListPaths)
            {
                var bm = new Bitmap(Image.FromFile(path));
                imlLargeIcons.AddImage(bm, path);
                imlSmallIcons.AddImage(bm, path);

                imageListControl.AddRow(path, path, path);
            }
        }

        

        private void cboStyle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cboStyle.Text)
            {
                case "Large Icons":
                    imageListControl.View = View.LargeIcon;
                    break;
                case "Small Icons":
                    imageListControl.View = View.SmallIcon;
                    break;
                case "List":
                    imageListControl.View = View.List;
                    break;
                case "Tile":
                    imageListControl.View = View.Tile;
                    break;
            }
        }

        private void onChooseSourceImageButtonClick(object sender, EventArgs e)
        {
            chartsButton.Enabled = false;
            matrixButton.Enabled = false;
            var ofd = new OpenFileDialog
            {
                Title = @"Виберіть зображення для порівняння",
                Filter = @"All|*.*|JPG|*.jpg|JPEG|*.jpeg|PNG|*.png"
            };
            var dr = ofd.ShowDialog();
            if (dr != DialogResult.OK) return;
            sourceImageBox.Load(ofd.FileName);
            sourceImagePath = ofd.FileName;
            //sourceImageBox.Width = sourceImageBox.Image.Width;
            //sourceImageBox.Height = sourceImageBox.Image.Height;
        }

        private void onCalculateButtonClick(object sender, EventArgs e)
        {
            clearHistograms();
            this.chartData = new Dictionary<string, List<Point>[,]>();
            sourceImageBox.Image = Image.FromFile(sourceImagePath);
            int gridColCount = int.Parse(gridColCountTextBox.Text);
            int gridRowCount = int.Parse(gridRowCountTextBox.Text);
            int cellsColCount = int.Parse(imagesColCountTextBox.Text);
            int cellsRowCount = int.Parse(imagesRowCountTextBox.Text);
            Bitmap preparedSourceImage = MakeGrayAndCut(sourceImageBox.Image);
            if (hisEqCheckbox.Checked)
            {
                preparedSourceImage = ImageUtils.histogramEqualization(preparedSourceImage);
            }
            addHistogram(preparedSourceImage, "Source image");
            List<ImageCell> sourceImageCells = getImageCells(preparedSourceImage, cellsColCount, cellsRowCount, gridColCount, gridRowCount);
            sourceImageBox.Image = (Image)preparedSourceImage;
            addToChartData(sourceImagePath, sourceImageCells, cellsColCount, cellsRowCount);
            
            imageListControl.Items.Clear();
            imlLargeIcons.Images.Clear();
            imlSmallIcons.Images.Clear();
            for (var i = 0; i < imageListPaths.Count; i++)
            {
                var bitmap = MakeGrayAndCut(Image.FromFile(imageListPaths[i]));
                if (hisEqCheckbox.Checked)
                {
                    bitmap = ImageUtils.histogramEqualization(bitmap);
                }
                addHistogram(bitmap, "Image" + i);
                List<ImageCell> cells = getImageCells(bitmap, cellsColCount, cellsRowCount, gridColCount, gridRowCount);
                int difference = ImageCell.calculateDifference(sourceImageCells, cells);
                imlLargeIcons.AddImage(bitmap, imageListPaths[i]);
                imlSmallIcons.AddImage(bitmap, imageListPaths[i]);
                imageListControl.AddRow(imageListPaths[i], difference.ToString(), _filesName[i]);
                if (!this.chartData.ContainsKey(imageListPaths[i]))
                {
                    addToChartData(imageListPaths[i], cells, cellsColCount, cellsRowCount);
                }
            }
            imageListControl.ListViewItemSorter = new ListViewItemComparer();
            CurrentResults = new List<string>();
            foreach (ListViewItem item in imageListControl.Items) {
                CurrentResults.Add(item.ImageKey);
            }
            if (sampleSaveChackbox.Checked)
            {
                Comparator = new ResultsComparator();
                Comparator.SampleResults = CurrentResults;
                sampleSaveChackbox.Checked = false;
            }
            drawCells(sourceImageBox.Image, cellsRowCount, cellsColCount);
            foreach (ImageCell cell in sourceImageCells)
            {
                drawGridForCell(sourceImageBox.Image, cell, gridRowCount, gridColCount);
            }
            Update();
            Refresh();
            chartsButton.Enabled = true;
            matrixButton.Enabled = true;
            
        }

        private Bitmap MakeGrayAndCut(Image img)
        {
            var bmp = new Bitmap(img);

            // Задаєм формат Пікселя.
            const PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Отримуємо дані картинки.
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            // Блокуємо набір даних зображення в пам'яті
            var bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

            // Отримуємо адрес першої лінії.
            var ptr = bmpData.Scan0;

            // Задаємо масив із Byte і поміщаємо в нього набір даних.
            int numBytes = bmp.Width * bmp.Height * 3; 
            // Множимо на 3 - оскільки RGB колір кодується 3-ма байтами
            // Або використовуємо замість Width - Stride
            //var numBytes = bmpData.Stride * bmp.Height;
            //var widthBytes = bmpData.Stride;
            var rgbValues = new byte[numBytes];

            // Копіюжмо значения в масив.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Перебираємо пикселі по 3 байта на кожний і змінюємо значення
            for (var counter = 0; counter < rgbValues.Length; counter += 3)
            {

               // double brightness = 0.2125d * (double)rgbValues[counter] + 
               //     0.7154d * (double)rgbValues[counter + 1] + 0.0721d * (double)rgbValues[counter + 2];

                double brightness = (rgbValues[counter] + rgbValues[counter + 1] + rgbValues[counter + 2])/3;

                //var colorB = Convert.ToByte(value / 3);

                rgbValues[counter] = (byte)brightness;
                rgbValues[counter + 1] = (byte)brightness;
                rgbValues[counter + 2] = (byte)brightness;

            }
            
            // Копіюємо набір даних назад в зображення
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Розблоковуємо набір даних зображення в пам'яті.
            bmp.UnlockBits(bmpData);
            Point upperLeftCorner = new Point(0,0);
            Size size = bmp.Size;
            if (faceDetectionCheckBox.Checked)
            {
                Rectangle face = FaceDetector.detectFace(bmp);
                if(face.Width != 0) {
                    upperLeftCorner = new Point(face.X, face.Y);
                    size = face.Size;
                }
            }
            else
            {
                upperLeftCorner = new Point((int)lBorderInput.Value, (int)uBorderInput.Value);
                size = new Size(img.Width - (int)rBorderInput.Value - (int)lBorderInput.Value,
                    img.Height - (int)bBorderInput.Value - (int)uBorderInput.Value);
            }

            return CropImage(bmp, new Rectangle(upperLeftCorner, size));
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        private void drawCells(Image img, int rowCount, int colCount)
        {
            int colWidth = img.Width / colCount;
            int rowHeight = img.Height / rowCount;
            using (Graphics g = Graphics.FromImage(img))
            {
                for (var i = 1; i < colCount; i++)
                {
                    g.DrawLine(
                        new Pen(Color.Black, 3f),
                        new Point(i * colWidth, 0),
                        new Point(i * colWidth, img.Height));
                }

                for (var j = 1; j < rowCount; j++)
                {
                    g.DrawLine(
                        new Pen(Color.Black, 4f),
                        new Point(0, j * rowHeight),
                        new Point(img.Width, j * rowHeight));
                }
            }
        }

        private void drawGridForCell(Image img, ImageCell cell, int rowCount, int colCount)
        {
            int cellWidth = cell.RightLowerCorner.X - cell.LeftUpperCorner.X;
            int cellHeight = cell.RightLowerCorner.Y - cell.LeftUpperCorner.Y;
            int colWidth = cellWidth / colCount;
            int rowHeight = cellHeight / rowCount;
            using (Graphics g = Graphics.FromImage(img))
            {
                for (var i = 1; i < colCount; i++)
                {
                    g.DrawLine(
                        new Pen(Color.Black, 1f),
                        new Point(cell.LeftUpperCorner.X + i * colWidth, cell.LeftUpperCorner.Y),
                        new Point(cell.LeftUpperCorner.X + i * colWidth, cell.RightLowerCorner.Y));
                }

                for (var j = 1; j < rowCount; j++)
                {
                    g.DrawLine(
                        new Pen(Color.Black, 1f),
                        new Point(cell.LeftUpperCorner.X, j * rowHeight + cell.LeftUpperCorner.Y),
                        new Point(cell.RightLowerCorner.X, j * rowHeight + cell.LeftUpperCorner.Y));
                }
                var columCenter = cellWidth / 2;
                var rowCenter = cellHeight / 2;
                var values = cell.GridValues;
                for (var i = 0; i < colCount; i++)
                {
                    for (var j = 0; j < rowCount; j++)
                    {
                        g.DrawString(values[i, j].ToString(),
                            new Font("Arial", int.Parse(comboBox1.SelectedItem.ToString())), new SolidBrush(colorDialog.Color),
                            new Point(i * colWidth + cell.LeftUpperCorner.X, 
                                j * rowHeight + cell.LeftUpperCorner.Y));
                    }
                }
            }
        }




        

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                button4.BackColor = colorDialog.Color;
        }

        private List<ImageCell> getImageCells(Image image, int cellsColCount, int cellsRowCount, int gridColCount, int gridRowCount)
        {
            Bitmap imageBitmap = (Bitmap)image;
            int cellWidth = imageBitmap.Width / cellsColCount;
            int cellHeight = imageBitmap.Height / cellsRowCount;
            List<ImageCell> imageCells = new List<ImageCell>();
            for (int j = 0; j < cellsRowCount; j++)
            {
                for (int i = 0; i < cellsColCount; i++)
                {
                    Point upperLeftCorner = new Point(cellWidth * i, cellHeight * j);
                    var lowerCornerX = i == cellsColCount - 1 ? image.Width - 1 : cellWidth * (i + 1) - 1;
                    var lowerCornerY = j == cellsRowCount - 1 ? image.Height - 1 : cellHeight * (j + 1) - 1;
                    Point lowerRightCorner = new Point(lowerCornerX, lowerCornerY);
                    imageCells.Add(new ImageCell(imageBitmap, upperLeftCorner, lowerRightCorner, gridColCount, gridRowCount, segmentRadioButton.Checked));
                }
            }
            return imageCells;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderInput_ValueChanged(object sender, EventArgs e)
        {
            if (sourceImagePath != null)
            {
                sourceImageBox.Image = new Bitmap(Image.FromFile(sourceImagePath));
                var upperLeftCorner = new Point((int)lBorderInput.Value, (int)uBorderInput.Value);
                var size = new Size(sourceImageBox.Image.Width - (int)rBorderInput.Value - (int)lBorderInput.Value,
                    sourceImageBox.Image.Height - (int)bBorderInput.Value - (int)uBorderInput.Value);
                using (Graphics g = Graphics.FromImage(sourceImageBox.Image))
                {
                    g.DrawRectangle(new Pen(Color.Black, 3f), new Rectangle(upperLeftCorner, size));
                }
            }
            Update();
            Refresh();
        }

        private void addHistogram(Bitmap image, string seriesName)
        {
            var values = ImageUtils.getCumulativeHistogram(image);
            //todo: remove
            values[255] = 0;
            values[254] = 0;
            iHistogramChart.ChartAreas.Add(seriesName);
            iHistogramChart.ChartAreas[seriesName].Position.Height = 80;
            iHistogramChart.Width = 600 * (imageListPaths.Count + 1);
            iHistogramChart.ChartAreas[seriesName].Position.X = 100.0F / (imageListPaths.Count + 1) * (iHistogramChart.ChartAreas.Count - 1);
            iHistogramChart.ChartAreas[seriesName].Position.Width = (100.0F / (imageListPaths.Count + 1));
            iHistogramChart.Series.Add(seriesName);
            iHistogramChart.Legends.Add(new Legend(seriesName));
            iHistogramChart.Legends[seriesName].DockedToChartArea = seriesName;
            iHistogramChart.Legends[seriesName].IsDockedInsideChartArea = false;
            iHistogramChart.Legends[seriesName].Docking = Docking.Bottom;
            iHistogramChart.Series[seriesName].Legend = seriesName;
            iHistogramChart.Series[seriesName].ChartType = SeriesChartType.Column;
            iHistogramChart.Series[seriesName].Points.DataBindY(values);
            iHistogramChart.Series[seriesName].ChartArea = seriesName;
            var plotPosition = new ElementPosition();
            plotPosition.X = 0;
            plotPosition.Y = 0;
            plotPosition.Width = 70;
            plotPosition.Height = 80;
            iHistogramChart.ChartAreas[seriesName].InnerPlotPosition = plotPosition;
            iHistogramChart.Series[seriesName].XValueType = ChartValueType.UInt64;
        }

        private void clearHistograms()
        {
            iHistogramChart.ChartAreas.Clear();
            iHistogramChart.Series.Clear();
            iHistogramChart.Legends.Clear();
        }

        private void sampleCompareButton_Click(object sender, EventArgs e)
        {
            if (Comparator != null)
            {
                int difference = Comparator.CompareWithSample(CurrentResults);
                MessageBox.Show(owner: this, caption: "Результат порівняння з еталоном", text: "Модульна різниця: " + difference);
            }
            else
            {
                MessageBox.Show(owner: this, caption: "Помилка виконання", text: "Еталон не знайдено");
            }
        }

        private void hisEqCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void faceDetectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(faceDetectionCheckBox.Checked) {
                lBorderInput.Enabled = false;
                uBorderInput.Enabled = false;
                bBorderInput.Enabled = false;
                rBorderInput.Enabled = false;
            }
            else
            {
                lBorderInput.Enabled = true;
                uBorderInput.Enabled = true;
                bBorderInput.Enabled = true;
                rBorderInput.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addToChartData(string key, List<ImageCell> imageCells, int columns, int rows)
        {
            var chartDataEntry = new List<Point>[columns,rows];
            var cells = new List<ImageCell>(imageCells);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    chartDataEntry[j, i] = cells[0].cellChartPoints;
                    cells.RemoveAt(0);
                }
            }
            this.chartData.Add(key, chartDataEntry);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Graphs(this.chartData).Show();
        }

        private void matrixButton_Click(object sender, EventArgs e)
        {
            var gridData = MatrixCalculator.calculate(chartData);
            new Matrix(gridData).Show();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return int.Parse(((ListViewItem)x).Text) - int.Parse(((ListViewItem)y).Text);
        }
    }
}
