using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchSimilarImages
{
    public partial class Matrix : Form
    {
        public Dictionary<string, Dictionary<string, double>> GridData { set; get; }

        private ClassificationType Type = ClassificationType.NORMAL;
        private ClassificationMode Mode = ClassificationMode.INNER;
        private int Cols;
        private int Rows;
        private string ImagePath;
        private List<List<string>> Groups;

        public Matrix(Dictionary<string, Dictionary<string, double>> gridData)
        {
            this.GridData = gridData;
            InitializeComponent();
            groupCountControl.Minimum = 1;
            groupCountControl.Maximum = gridData.Keys.Count;
            groupCountControl.Value = gridData.Keys.Count > 1 ? 2 : 1;
            Classify();
            BuildGrid();
            
        }

        public Matrix(string imagePath, int cols, int rows, Dictionary<string, Dictionary<string, double>> gridData)
        {
            this.GridData = gridData;
            this.ImagePath = imagePath;
            this.Cols = cols;
            this.Rows = rows;
            this.Type = ClassificationType.SELF;
            InitializeComponent();
            groupCountControl.Minimum = 1;
            groupCountControl.Maximum = gridData.Keys.Count;
            groupCountControl.Value = gridData.Keys.Count > 1 ? 2 : 1;
            Classify();
            BuildGrid();

        }

        private void BuildGrid()
        {
            matrixGridView.ColumnCount = GridData.Keys.Count;
            matrixGridView.RowHeadersWidth = 100;
            int i = 0;
            foreach (string key in GridData.Keys)
            {
                matrixGridView.Columns[i].Name = key.Split(Path.DirectorySeparatorChar).Last();
                var row = GridData.Get(key);
                matrixGridView.Rows.Add(row.Values.ToList().ConvertAll(value => value.ToString()).ToArray());
                matrixGridView.Rows[i].HeaderCell.Value = key.Split(Path.DirectorySeparatorChar).Last();
                i++;
            }
        }

        private void Classify()
        {
            Groups = ClassificationUtil.Classify(GridData, Mode, (int)groupCountControl.Value);
            groupsList.Items.Clear();
            foreach (var group in Groups)
            {
                groupsList.Items.Add("Група " + groupsList.Items.Count);
            }
            groupsList.SelectedIndex = 0;
        }

        private void innerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (innerRadioButton.Checked)
            {
                Mode = ClassificationMode.INNER;
                Classify();
            }
        }

        private void outerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (outerRadioButton.Checked)
            {
                Mode = ClassificationMode.OUTER;
                Classify();
            }
        }

        private void innerOuterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (innerOuterRadioButton.Checked)
            {
                Mode = ClassificationMode.INNER_OUTER;
                Classify();
            }
        }

        private void groupCountControl_ValueChanged(object sender, EventArgs e)
        {
            Classify();
        }

        private void groupsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageList.Images.Clear();
            imagesListView.Items.Clear();
            var groupIndex = groupsList.SelectedIndex;
            foreach (var path in Groups[groupIndex])
            {
                var bm = getImage(path, Type);
                imageList.AddImage(bm, path);

                imagesListView.AddRow(path, path.Split(Path.DirectorySeparatorChar).Last(), path);
            }
        }

        private Bitmap getImage(string key, ClassificationType type)
        {
            if (type == ClassificationType.SELF)
            {
                var dimensions = key.Split(',').Select(x => int.Parse(x));
                var bitmap = new Bitmap(Image.FromFile(ImagePath));
                var rectangle = new Rectangle(bitmap.Width / Cols * dimensions.ElementAt(0),
                    bitmap.Height / Rows * dimensions.ElementAt(1),
                    bitmap.Width / Cols,
                    bitmap.Height / Rows);
                return ImageUtils.CropImage(bitmap, rectangle);
            }
            else
            {
                return new Bitmap(Image.FromFile(key));
            }
        }


    }
}
