namespace SearchSimilarImages
{
    partial class Matrix
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
            this.matrixGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupsList = new System.Windows.Forms.ListBox();
            this.imagesListView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupCountControl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.innerOuterRadioButton = new System.Windows.Forms.RadioButton();
            this.outerRadioButton = new System.Windows.Forms.RadioButton();
            this.innerRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCountControl)).BeginInit();
            this.SuspendLayout();
            // 
            // matrixGridView
            // 
            this.matrixGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGridView.Location = new System.Drawing.Point(0, 3);
            this.matrixGridView.Name = "matrixGridView";
            this.matrixGridView.ReadOnly = true;
            this.matrixGridView.Size = new System.Drawing.Size(735, 401);
            this.matrixGridView.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 444);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.matrixGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(738, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Матриця подібності";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupsList);
            this.tabPage2.Controls.Add(this.imagesListView);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupCountControl);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.innerOuterRadioButton);
            this.tabPage2.Controls.Add(this.outerRadioButton);
            this.tabPage2.Controls.Add(this.innerRadioButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Групи зображень";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupsList
            // 
            this.groupsList.FormattingEnabled = true;
            this.groupsList.Location = new System.Drawing.Point(624, 53);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(108, 355);
            this.groupsList.TabIndex = 7;
            this.groupsList.SelectedIndexChanged += new System.EventHandler(this.groupsList_SelectedIndexChanged);
            // 
            // imagesListView
            // 
            this.imagesListView.LargeImageList = this.imageList;
            this.imagesListView.Location = new System.Drawing.Point(6, 52);
            this.imagesListView.Name = "imagesListView";
            this.imagesListView.Size = new System.Drawing.Size(611, 356);
            this.imagesListView.SmallImageList = this.imageList;
            this.imagesListView.TabIndex = 6;
            this.imagesListView.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(128, 128);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(559, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Кількість груп";
            // 
            // groupCountControl
            // 
            this.groupCountControl.Location = new System.Drawing.Point(657, 16);
            this.groupCountControl.Name = "groupCountControl";
            this.groupCountControl.Size = new System.Drawing.Size(75, 20);
            this.groupCountControl.TabIndex = 4;
            this.groupCountControl.ValueChanged += new System.EventHandler(this.groupCountControl_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Зв\'язки";
            // 
            // innerOuterRadioButton
            // 
            this.innerOuterRadioButton.AutoSize = true;
            this.innerOuterRadioButton.Location = new System.Drawing.Point(219, 16);
            this.innerOuterRadioButton.Name = "innerOuterRadioButton";
            this.innerOuterRadioButton.Size = new System.Drawing.Size(123, 17);
            this.innerOuterRadioButton.TabIndex = 2;
            this.innerOuterRadioButton.Text = "Зовнішні - внутрішні";
            this.innerOuterRadioButton.UseVisualStyleBackColor = true;
            this.innerOuterRadioButton.CheckedChanged += new System.EventHandler(this.innerOuterRadioButton_CheckedChanged);
            // 
            // outerRadioButton
            // 
            this.outerRadioButton.AutoSize = true;
            this.outerRadioButton.Location = new System.Drawing.Point(145, 16);
            this.outerRadioButton.Name = "outerRadioButton";
            this.outerRadioButton.Size = new System.Drawing.Size(68, 17);
            this.outerRadioButton.TabIndex = 1;
            this.outerRadioButton.Text = "Зовнішні";
            this.outerRadioButton.UseVisualStyleBackColor = true;
            this.outerRadioButton.CheckedChanged += new System.EventHandler(this.outerRadioButton_CheckedChanged);
            // 
            // innerRadioButton
            // 
            this.innerRadioButton.AutoSize = true;
            this.innerRadioButton.Checked = true;
            this.innerRadioButton.Location = new System.Drawing.Point(67, 16);
            this.innerRadioButton.Name = "innerRadioButton";
            this.innerRadioButton.Size = new System.Drawing.Size(72, 17);
            this.innerRadioButton.TabIndex = 0;
            this.innerRadioButton.TabStop = true;
            this.innerRadioButton.Text = "Внутрішні";
            this.innerRadioButton.UseVisualStyleBackColor = true;
            this.innerRadioButton.CheckedChanged += new System.EventHandler(this.innerRadioButton_CheckedChanged);
            // 
            // Matrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 468);
            this.Controls.Add(this.tabControl1);
            this.Name = "Matrix";
            this.Text = "Classification";
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCountControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView matrixGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton innerOuterRadioButton;
        private System.Windows.Forms.RadioButton outerRadioButton;
        private System.Windows.Forms.RadioButton innerRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown groupCountControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox groupsList;
        private System.Windows.Forms.ListView imagesListView;
        private System.Windows.Forms.ImageList imageList;
    }
}