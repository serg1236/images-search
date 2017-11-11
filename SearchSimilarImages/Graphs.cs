using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SearchSimilarImages
{
    public partial class Graphs : Form
    {
        private Dictionary<string, List<Point>[,]> chartsData;

        public Graphs(Dictionary<string, List<Point>[,]> chartsData)
        {
            this.chartsData = chartsData;
            InitializeComponent();
            listView1.LargeImageList = imageList;
            listView1.SmallImageList = imageList;
            listView1.MultiSelect = false;
            chartsData.Keys.ToList().ForEach(x => { 
                imageList.AddImage(Image.FromFile(x), x);
                listView1.AddRow(x, x.Split(Path.DirectorySeparatorChar).Last(), x);
            });
            InitSubImagesOptions(chartsData.Keys.ToList()[0]);
            subImagesBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private class Item
        {
            public string Name;
            public List<Point> Value;
            public Item(string name, List<Point> value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        private void InitSubImagesOptions(string selectedImage)
        {
            int selectedIndex = subImagesBox.SelectedIndex;
            List<Point>[,] imageData;
            this.chartsData.TryGetValue(selectedImage, out imageData);
            subImagesBox.Items.Clear();
            for(int i = 0; i < imageData.GetLength(0); i++) {
                for (int j = 0; j < imageData.GetLength(1); j++)
                {
                    subImagesBox.Items.Add(new Item("[" + i + "," + j + "]", imageData[i, j]));
                }
            }
            subImagesBox.SelectedItem = selectedIndex >= 0 ? subImagesBox.Items[selectedIndex] : subImagesBox.Items[0];
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string key = listView1.SelectedItems[0].ImageKey;
                InitSubImagesOptions(key);
                BuildChart(listView1.SelectedItems[0].Text, ((Item)subImagesBox.SelectedItem).Value);
            }
        }

        private void BuildChart(string key, List<Point> points)
        {
            clearChart();
            chart1.ChartAreas.Add(key);
            chart1.Series.Add(key);
            chart1.Legends.Add(new Legend(key));
            chart1.Legends[key].DockedToChartArea = key;
            chart1.Legends[key].IsDockedInsideChartArea = false;
            chart1.Legends[key].Docking = Docking.Bottom;
            chart1.Series[key].Legend = key;
            chart1.Series[key].ChartType = SeriesChartType.Line;
            points.ForEach(p => chart1.Series[key].Points.AddXY(p.X, p.Y));
            chart1.Series[key].ChartArea = key;
            chart1.Series[key].XValueType = ChartValueType.UInt64;
        }

        private void clearChart()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
        }

        private void subImagesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string key = listView1.SelectedItems[0].ImageKey;
                BuildChart(listView1.SelectedItems[0].Text, ((Item)subImagesBox.SelectedItem).Value);
            }
        }


    }
}
