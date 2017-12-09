namespace SearchSimilarImages
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.imageListControl = new System.Windows.Forms.ListView();
            this.imlLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.imlSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.faceDetectionCheckBox = new System.Windows.Forms.CheckBox();
            this.hisEqCheckbox = new System.Windows.Forms.CheckBox();
            this.segmentRadioButton = new System.Windows.Forms.RadioButton();
            this.fragmentRadioButton = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.sampleCompareButton = new System.Windows.Forms.Button();
            this.sampleSaveChackbox = new System.Windows.Forms.CheckBox();
            this.imagesRowCountTextBox = new System.Windows.Forms.TextBox();
            this.imagesColCountTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.gridRowCountTextBox = new System.Windows.Forms.TextBox();
            this.gridColCountTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sourceImageBox = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.iHistogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lBorderInput = new System.Windows.Forms.NumericUpDown();
            this.rBorderInput = new System.Windows.Forms.NumericUpDown();
            this.uBorderInput = new System.Windows.Forms.NumericUpDown();
            this.bBorderInput = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartsButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.matrixButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.sourceClassification = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHistogramChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBorderInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBorderInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uBorderInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bBorderInput)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListControl
            // 
            this.imageListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageListControl.BackColor = System.Drawing.SystemColors.Info;
            this.imageListControl.LargeImageList = this.imlLargeIcons;
            this.imageListControl.Location = new System.Drawing.Point(571, 36);
            this.imageListControl.Name = "imageListControl";
            this.imageListControl.Size = new System.Drawing.Size(572, 339);
            this.imageListControl.SmallImageList = this.imlSmallIcons;
            this.imageListControl.TabIndex = 15;
            this.imageListControl.UseCompatibleStateImageBehavior = false;
            // 
            // imlLargeIcons
            // 
            this.imlLargeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlLargeIcons.ImageSize = new System.Drawing.Size(128, 128);
            this.imlLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imlSmallIcons
            // 
            this.imlSmallIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlSmallIcons.ImageSize = new System.Drawing.Size(64, 64);
            this.imlSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // faceDetectionCheckBox
            // 
            this.faceDetectionCheckBox.AutoSize = true;
            this.faceDetectionCheckBox.Location = new System.Drawing.Point(16, 312);
            this.faceDetectionCheckBox.Name = "faceDetectionCheckBox";
            this.faceDetectionCheckBox.Size = new System.Drawing.Size(157, 17);
            this.faceDetectionCheckBox.TabIndex = 23;
            this.faceDetectionCheckBox.Text = "Використати пошук облич";
            this.faceDetectionCheckBox.UseVisualStyleBackColor = true;
            this.faceDetectionCheckBox.Visible = false;
            this.faceDetectionCheckBox.CheckedChanged += new System.EventHandler(this.faceDetectionCheckBox_CheckedChanged);
            // 
            // hisEqCheckbox
            // 
            this.hisEqCheckbox.AutoSize = true;
            this.hisEqCheckbox.Location = new System.Drawing.Point(16, 289);
            this.hisEqCheckbox.Name = "hisEqCheckbox";
            this.hisEqCheckbox.Size = new System.Drawing.Size(134, 17);
            this.hisEqCheckbox.TabIndex = 22;
            this.hisEqCheckbox.Text = "Вирівняти гістограми";
            this.hisEqCheckbox.UseVisualStyleBackColor = true;
            this.hisEqCheckbox.CheckedChanged += new System.EventHandler(this.hisEqCheckbox_CheckedChanged);
            // 
            // segmentRadioButton
            // 
            this.segmentRadioButton.AutoSize = true;
            this.segmentRadioButton.Location = new System.Drawing.Point(117, 172);
            this.segmentRadioButton.Name = "segmentRadioButton";
            this.segmentRadioButton.Size = new System.Drawing.Size(74, 17);
            this.segmentRadioButton.TabIndex = 21;
            this.segmentRadioButton.Text = "Сегменти";
            this.segmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // fragmentRadioButton
            // 
            this.fragmentRadioButton.AutoSize = true;
            this.fragmentRadioButton.Checked = true;
            this.fragmentRadioButton.Location = new System.Drawing.Point(16, 172);
            this.fragmentRadioButton.Name = "fragmentRadioButton";
            this.fragmentRadioButton.Size = new System.Drawing.Size(84, 17);
            this.fragmentRadioButton.TabIndex = 20;
            this.fragmentRadioButton.TabStop = true;
            this.fragmentRadioButton.Text = "Фрагменти";
            this.fragmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(605, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(212, 46);
            this.button3.TabIndex = 19;
            this.button3.Text = "Розпочати аналіз";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.onCalculateButtonClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(16, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 26);
            this.button2.TabIndex = 18;
            this.button2.Text = "Множина";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.onChooseImageListButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(932, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Вигляд списку:";
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons",
            "List",
            "Tile"});
            this.cboStyle.Location = new System.Drawing.Point(1022, 8);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(121, 21);
            this.cboStyle.TabIndex = 14;
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged_1);
            // 
            // sampleCompareButton
            // 
            this.sampleCompareButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.sampleCompareButton.Location = new System.Drawing.Point(16, 407);
            this.sampleCompareButton.Name = "sampleCompareButton";
            this.sampleCompareButton.Size = new System.Drawing.Size(157, 26);
            this.sampleCompareButton.TabIndex = 30;
            this.sampleCompareButton.Text = "Порівняти зі збереженим";
            this.sampleCompareButton.UseVisualStyleBackColor = false;
            this.sampleCompareButton.Click += new System.EventHandler(this.sampleCompareButton_Click);
            // 
            // sampleSaveChackbox
            // 
            this.sampleSaveChackbox.AutoSize = true;
            this.sampleSaveChackbox.Location = new System.Drawing.Point(16, 384);
            this.sampleSaveChackbox.Name = "sampleSaveChackbox";
            this.sampleSaveChackbox.Size = new System.Drawing.Size(127, 17);
            this.sampleSaveChackbox.TabIndex = 29;
            this.sampleSaveChackbox.Text = "Зберегти результат";
            this.sampleSaveChackbox.UseVisualStyleBackColor = true;
            // 
            // imagesRowCountTextBox
            // 
            this.imagesRowCountTextBox.Location = new System.Drawing.Point(82, 214);
            this.imagesRowCountTextBox.Name = "imagesRowCountTextBox";
            this.imagesRowCountTextBox.Size = new System.Drawing.Size(37, 20);
            this.imagesRowCountTextBox.TabIndex = 28;
            this.imagesRowCountTextBox.Text = "2";
            // 
            // imagesColCountTextBox
            // 
            this.imagesColCountTextBox.Location = new System.Drawing.Point(16, 214);
            this.imagesColCountTextBox.Name = "imagesColCountTextBox";
            this.imagesColCountTextBox.Size = new System.Drawing.Size(37, 20);
            this.imagesColCountTextBox.TabIndex = 27;
            this.imagesColCountTextBox.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Сітка характеристик";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Сітка підзображень";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "11",
            "14",
            "16",
            "18",
            "20",
            "24",
            "28",
            "36"});
            this.comboBox1.Location = new System.Drawing.Point(313, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(41, 21);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.Text = "11";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(266, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 25);
            this.button4.TabIndex = 22;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Шрифт:";
            // 
            // gridRowCountTextBox
            // 
            this.gridRowCountTextBox.Location = new System.Drawing.Point(82, 263);
            this.gridRowCountTextBox.Name = "gridRowCountTextBox";
            this.gridRowCountTextBox.Size = new System.Drawing.Size(37, 20);
            this.gridRowCountTextBox.TabIndex = 21;
            this.gridRowCountTextBox.Text = "2";
            // 
            // gridColCountTextBox
            // 
            this.gridColCountTextBox.Location = new System.Drawing.Point(16, 263);
            this.gridColCountTextBox.Name = "gridColCountTextBox";
            this.gridColCountTextBox.Size = new System.Drawing.Size(37, 20);
            this.gridColCountTextBox.TabIndex = 20;
            this.gridColCountTextBox.Text = "2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(16, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 26);
            this.button1.TabIndex = 17;
            this.button1.Text = "Еталон";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.onChooseSourceImageButtonClick);
            // 
            // sourceImageBox
            // 
            this.sourceImageBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sourceImageBox.Location = new System.Drawing.Point(219, 36);
            this.sourceImageBox.Name = "sourceImageBox";
            this.sourceImageBox.Size = new System.Drawing.Size(346, 339);
            this.sourceImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceImageBox.TabIndex = 18;
            this.sourceImageBox.TabStop = false;
            // 
            // iHistogramChart
            // 
            chartArea1.Name = "ChartArea1";
            this.iHistogramChart.ChartAreas.Add(chartArea1);
            this.iHistogramChart.Location = new System.Drawing.Point(0, 0);
            this.iHistogramChart.Name = "iHistogramChart";
            this.iHistogramChart.Size = new System.Drawing.Size(1127, 230);
            this.iHistogramChart.TabIndex = 31;
            this.iHistogramChart.Text = "chart1";
            // 
            // lBorderInput
            // 
            this.lBorderInput.Location = new System.Drawing.Point(313, 413);
            this.lBorderInput.Name = "lBorderInput";
            this.lBorderInput.Size = new System.Drawing.Size(56, 20);
            this.lBorderInput.TabIndex = 32;
            this.lBorderInput.ValueChanged += new System.EventHandler(this.borderInput_ValueChanged);
            // 
            // rBorderInput
            // 
            this.rBorderInput.Location = new System.Drawing.Point(393, 413);
            this.rBorderInput.Name = "rBorderInput";
            this.rBorderInput.Size = new System.Drawing.Size(54, 20);
            this.rBorderInput.TabIndex = 33;
            this.rBorderInput.ValueChanged += new System.EventHandler(this.borderInput_ValueChanged);
            // 
            // uBorderInput
            // 
            this.uBorderInput.Location = new System.Drawing.Point(469, 413);
            this.uBorderInput.Name = "uBorderInput";
            this.uBorderInput.Size = new System.Drawing.Size(54, 20);
            this.uBorderInput.TabIndex = 34;
            this.uBorderInput.ValueChanged += new System.EventHandler(this.borderInput_ValueChanged);
            // 
            // bBorderInput
            // 
            this.bBorderInput.Location = new System.Drawing.Point(545, 413);
            this.bBorderInput.Name = "bBorderInput";
            this.bBorderInput.Size = new System.Drawing.Size(54, 20);
            this.bBorderInput.TabIndex = 35;
            this.bBorderInput.ValueChanged += new System.EventHandler(this.borderInput_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Параметри алгоритму";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Дослідження";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Вибір зображень";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(56, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 15);
            this.label12.TabIndex = 40;
            this.label12.Text = "Елементи аналізу";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(56, 263);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 41;
            this.label13.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Обмежити";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Ліво";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Право";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(466, 397);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Верх";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(542, 397);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 46;
            this.label15.Text = "Низ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Window;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 20);
            this.label16.TabIndex = 47;
            this.label16.Text = "Гістограми";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.iHistogramChart);
            this.panel1.Location = new System.Drawing.Point(16, 439);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 230);
            this.panel1.TabIndex = 48;
            // 
            // chartsButton
            // 
            this.chartsButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chartsButton.Enabled = false;
            this.chartsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartsButton.ForeColor = System.Drawing.Color.White;
            this.chartsButton.Location = new System.Drawing.Point(823, 387);
            this.chartsButton.Name = "chartsButton";
            this.chartsButton.Size = new System.Drawing.Size(117, 46);
            this.chartsButton.TabIndex = 49;
            this.chartsButton.Text = "Графіки";
            this.chartsButton.UseVisualStyleBackColor = false;
            this.chartsButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // matrixButton
            // 
            this.matrixButton.BackColor = System.Drawing.Color.SkyBlue;
            this.matrixButton.Enabled = false;
            this.matrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matrixButton.ForeColor = System.Drawing.Color.White;
            this.matrixButton.Location = new System.Drawing.Point(1047, 401);
            this.matrixButton.Name = "matrixButton";
            this.matrixButton.Size = new System.Drawing.Size(96, 33);
            this.matrixButton.TabIndex = 50;
            this.matrixButton.Text = "Множина";
            this.matrixButton.UseVisualStyleBackColor = false;
            this.matrixButton.Click += new System.EventHandler(this.matrixButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(987, 378);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 20);
            this.label17.TabIndex = 51;
            this.label17.Text = "Класифікація";
            // 
            // sourceClassification
            // 
            this.sourceClassification.BackColor = System.Drawing.Color.SteelBlue;
            this.sourceClassification.Enabled = false;
            this.sourceClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceClassification.ForeColor = System.Drawing.Color.White;
            this.sourceClassification.Location = new System.Drawing.Point(945, 400);
            this.sourceClassification.Name = "sourceClassification";
            this.sourceClassification.Size = new System.Drawing.Size(96, 33);
            this.sourceClassification.TabIndex = 52;
            this.sourceClassification.Text = "Еталон";
            this.sourceClassification.UseVisualStyleBackColor = false;
            this.sourceClassification.Click += new System.EventHandler(this.sourceClassification_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 676);
            this.Controls.Add(this.sourceClassification);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.matrixButton);
            this.Controls.Add(this.chartsButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bBorderInput);
            this.Controls.Add(this.uBorderInput);
            this.Controls.Add(this.rBorderInput);
            this.Controls.Add(this.lBorderInput);
            this.Controls.Add(this.imageListControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faceDetectionCheckBox);
            this.Controls.Add(this.cboStyle);
            this.Controls.Add(this.sampleCompareButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.segmentRadioButton);
            this.Controls.Add(this.hisEqCheckbox);
            this.Controls.Add(this.fragmentRadioButton);
            this.Controls.Add(this.sampleSaveChackbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.imagesRowCountTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.sourceImageBox);
            this.Controls.Add(this.imagesColCountTextBox);
            this.Controls.Add(this.gridRowCountTextBox);
            this.Controls.Add(this.gridColCountTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Пошук подібних зображень";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHistogramChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBorderInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBorderInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uBorderInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bBorderInput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView imageListControl;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.TextBox gridRowCountTextBox;
        private System.Windows.Forms.TextBox gridColCountTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imlSmallIcons;
        private System.Windows.Forms.ImageList imlLargeIcons;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton segmentRadioButton;
        private System.Windows.Forms.RadioButton fragmentRadioButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox imagesRowCountTextBox;
        private System.Windows.Forms.TextBox imagesColCountTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox hisEqCheckbox;
        private System.Windows.Forms.Button sampleCompareButton;
        private System.Windows.Forms.CheckBox sampleSaveChackbox;
        private System.Windows.Forms.CheckBox faceDetectionCheckBox;
        private System.Windows.Forms.PictureBox sourceImageBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart iHistogramChart;
        private System.Windows.Forms.NumericUpDown lBorderInput;
        private System.Windows.Forms.NumericUpDown rBorderInput;
        private System.Windows.Forms.NumericUpDown uBorderInput;
        private System.Windows.Forms.NumericUpDown bBorderInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button chartsButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button matrixButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button sourceClassification;
    }
}

