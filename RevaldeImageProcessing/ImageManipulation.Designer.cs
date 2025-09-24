namespace RevaldeImageProcessing
{
    partial class ImageManipulation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            uploadImageToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            UploadBtn = new Button();
            ApplyBtn = new Button();
            comboBox1 = new ComboBox();
            downloadBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            comboBox3 = new ComboBox();
            StartBtn = new Button();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label3 = new Label();
            subtractBtn = new Button();
            loadbackgroundBtn = new Button();
            label2 = new Label();
            warningLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(531, 345);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(540, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(532, 345);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, runToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1134, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uploadImageToolStripMenuItem, saveImageToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // uploadImageToolStripMenuItem
            // 
            uploadImageToolStripMenuItem.Name = "uploadImageToolStripMenuItem";
            uploadImageToolStripMenuItem.Size = new Size(164, 22);
            uploadImageToolStripMenuItem.Text = "Upload Image";
            uploadImageToolStripMenuItem.Click += LoadImageToolStripMenuItem_Click;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(164, 22);
            saveImageToolStripMenuItem.Text = "Download Image";
            saveImageToolStripMenuItem.Click += SaveImageToolStripMenuItem_Click;
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(40, 20);
            runToolStripMenuItem.Text = "Run";
            runToolStripMenuItem.Click += runToolStripMenuItem_Click;
            // 
            // UploadBtn
            // 
            UploadBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UploadBtn.Location = new Point(131, 34);
            UploadBtn.Name = "UploadBtn";
            UploadBtn.Size = new Size(158, 26);
            UploadBtn.TabIndex = 3;
            UploadBtn.Text = "Load Image";
            UploadBtn.UseVisualStyleBackColor = true;
            UploadBtn.Click += uploadBtn_Click;
            // 
            // ApplyBtn
            // 
            ApplyBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApplyBtn.Location = new Point(644, 34);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new Size(201, 26);
            ApplyBtn.TabIndex = 4;
            ApplyBtn.Text = "Apply ";
            ApplyBtn.UseVisualStyleBackColor = true;
            ApplyBtn.Click += ApplyBtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Copy", "Greyscale", "Color Inversion", "Histogram", "Sepia" });
            comboBox1.Location = new Point(644, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(201, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // downloadBtn
            // 
            downloadBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            downloadBtn.Location = new Point(644, 66);
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Size = new Size(201, 22);
            downloadBtn.TabIndex = 7;
            downloadBtn.Text = "Download";
            downloadBtn.UseVisualStyleBackColor = true;
            downloadBtn.Click += downloadBtn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBox2, 1, 0);
            tableLayoutPanel1.Location = new Point(28, 38);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.70886F));
            tableLayoutPanel1.Size = new Size(1075, 351);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.1386147F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4653473F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.2277222F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.16831684F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 205F));
            tableLayoutPanel2.Controls.Add(label6, 4, 2);
            tableLayoutPanel2.Controls.Add(label5, 4, 1);
            tableLayoutPanel2.Controls.Add(label4, 0, 0);
            tableLayoutPanel2.Controls.Add(comboBox3, 1, 0);
            tableLayoutPanel2.Controls.Add(downloadBtn, 5, 2);
            tableLayoutPanel2.Controls.Add(comboBox1, 5, 0);
            tableLayoutPanel2.Controls.Add(UploadBtn, 1, 1);
            tableLayoutPanel2.Controls.Add(StartBtn, 2, 0);
            tableLayoutPanel2.Controls.Add(numericUpDown1, 1, 2);
            tableLayoutPanel2.Controls.Add(ApplyBtn, 5, 1);
            tableLayoutPanel2.Controls.Add(label1, 0, 2);
            tableLayoutPanel2.Controls.Add(label3, 0, 1);
            tableLayoutPanel2.Controls.Add(subtractBtn, 2, 2);
            tableLayoutPanel2.Controls.Add(loadbackgroundBtn, 2, 1);
            tableLayoutPanel2.Controls.Add(label2, 4, 0);
            tableLayoutPanel2.Location = new Point(129, 408);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 49.20635F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50.79365F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.Size = new Size(848, 91);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(541, 66);
            label6.Name = "label6";
            label6.Size = new Size(97, 21);
            label6.TabIndex = 18;
            label6.Text = "Download Image";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(503, 36);
            label5.Name = "label5";
            label5.Size = new Size(135, 21);
            label5.TabIndex = 17;
            label5.Text = "Apply Image Processing";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 5);
            label4.Name = "label4";
            label4.Size = new Size(122, 21);
            label4.TabIndex = 10;
            label4.Text = "Photo or Video mode";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.UseCompatibleTextRendering = true;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Video Mode", "Photo Mode" });
            comboBox3.Location = new Point(131, 3);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(158, 23);
            comboBox3.TabIndex = 15;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // StartBtn
            // 
            StartBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StartBtn.Location = new Point(295, 3);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(177, 25);
            StartBtn.TabIndex = 12;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown1.Location = new Point(135, 66);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(154, 23);
            numericUpDown1.TabIndex = 10;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(65, 69);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 10;
            label1.Text = "Threshold";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(39, 39);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 14;
            label3.Text = "Upload Images";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtractBtn
            // 
            subtractBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            subtractBtn.Location = new Point(295, 66);
            subtractBtn.Name = "subtractBtn";
            subtractBtn.Size = new Size(177, 22);
            subtractBtn.TabIndex = 9;
            subtractBtn.Text = "Subtract";
            subtractBtn.UseVisualStyleBackColor = true;
            subtractBtn.Click += SubtractBtn_Click;
            // 
            // loadbackgroundBtn
            // 
            loadbackgroundBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            loadbackgroundBtn.Location = new Point(295, 34);
            loadbackgroundBtn.Name = "loadbackgroundBtn";
            loadbackgroundBtn.Size = new Size(177, 23);
            loadbackgroundBtn.TabIndex = 8;
            loadbackgroundBtn.Text = "Load Background";
            loadbackgroundBtn.UseVisualStyleBackColor = true;
            loadbackgroundBtn.Click += LoadbackgroundBtn_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(524, 5);
            label2.Name = "label2";
            label2.Size = new Size(114, 21);
            label2.TabIndex = 16;
            label2.Text = "Image Manipulation";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.UseCompatibleTextRendering = true;
            // 
            // warningLabel
            // 
            warningLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            warningLabel.AutoSize = true;
            warningLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            warningLabel.ForeColor = Color.Brown;
            warningLabel.Location = new Point(365, 518);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(53, 27);
            warningLabel.TabIndex = 10;
            warningLabel.Text = "label7";
            warningLabel.TextAlign = ContentAlignment.MiddleCenter;
            warningLabel.UseCompatibleTextRendering = true;
            // 
            // ImageManipulation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 661);
            Controls.Add(warningLabel);
            Controls.Add(menuStrip1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(1150, 700);
            MinimumSize = new Size(1150, 700);
            Name = "ImageManipulation";
            Text = "RevaldeImageProcessing";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem uploadImageToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private Button UploadBtn;
        private Button ApplyBtn;
        private ComboBox comboBox1;
        private Button downloadBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button subtractBtn;
        private Button loadbackgroundBtn;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button StartBtn;
        private Label label3;
        private ComboBox comboBox3;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label warningLabel;
    }
}
