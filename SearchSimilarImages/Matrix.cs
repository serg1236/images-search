using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using TreeGenerator;

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
            PostInit();
            Classify();
            BuildGrid();
            BuildTree();
        }

        public Matrix(string imagePath, int cols, int rows, Dictionary<string, Dictionary<string, double>> gridData)
        {
            this.GridData = gridData;
            this.ImagePath = imagePath;
            this.Cols = cols;
            this.Rows = rows;
            this.Type = ClassificationType.SELF;
            InitializeComponent();
            PostInit();
            Classify();
            BuildGrid();
            BuildTree();
        }

        private void PostInit()
        {
            groupCountControl.Minimum = 1;
            groupCountControl.Maximum = GridData.Keys.Count;
            groupCountControl.Value = GridData.Keys.Count > 1 ? 2 : 1;
            imagesListView.ContextMenuStrip = copySelectedMenuStrip;
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
                groupsList.Items.Add("Група " + (groupsList.Items.Count + 1));
            }
            groupsList.SelectedIndex = 0;
        }

        private void innerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (innerRadioButton.Checked)
            {
                Mode = ClassificationMode.INNER;
                Classify();
                BuildTree();
            }
        }

        private void outerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (outerRadioButton.Checked)
            {
                Mode = ClassificationMode.OUTER;
                Classify();
                BuildTree();
            }
        }

        private void innerOuterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (innerOuterRadioButton.Checked)
            {
                Mode = ClassificationMode.INNER_OUTER;
                Classify();
                BuildTree();
            }
        }

        private void groupCountControl_ValueChanged(object sender, EventArgs e)
        {
            Classify();
            BuildTree();
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

        private void copySelectedItem_Click(object sender, EventArgs e)
        {
            if (imagesListView.SelectedItems.Count > 0)
            {
                var item = imagesListView.SelectedItems[0];
                Image image = item.ImageList.Images[item.ImageKey];
                Clipboard.SetImage(image);
            }
        }

        private void BuildTree()
        {
            TreeData.TreeDataTableDataTable dtTree =
            new TreeData.TreeDataTableDataTable();
            var tree = ClassificationUtil.ExtractTree(GridData, Mode, (int)groupCountControl.Value);
            foreach (var treeEntry in tree)
            {
                TreeNode node = treeEntry.Item2;
                var label = node is LeafNode ? ((LeafNode)node).ImageName.Split(Path.DirectorySeparatorChar).Last() : "";
                dtTree.AddTreeDataTableRow(node.Id, treeEntry.Item1, label, node.GroupRoot);
            }
            //instantiate the object 
            var myTree = new TreeBuilder(dtTree);
            var rootId = tree.Find(t => t.Item1 == "").Item2.Id;
            treeBox.Image = Image.FromStream(
            myTree.GenerateTree(rootId,
            System.Drawing.Imaging.ImageFormat.Bmp));

        }

        private void stretchRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (stretchRadioButton.Checked)
            {
                treePanel.AutoScrollPosition = new Point(0, 0);
                treeBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSizeRadioButton.Checked)
            {
                treeBox.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(treeBox.Image != null) {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "tree";
                dialog.AddExtension = true;
                dialog.Filter = "Image Files (*.jpg)|*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                   treeBox.Image.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }


    }
}
