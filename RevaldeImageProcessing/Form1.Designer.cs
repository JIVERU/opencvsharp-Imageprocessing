namespace RevaldeImageProcessing
{
    partial class Form1
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
            imageToolStripMenuItem = new ToolStripMenuItem();
            copyImageToolStripMenuItem = new ToolStripMenuItem();
            greyScaleToolStripMenuItem = new ToolStripMenuItem();
            colorInversionToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            rGBHistogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            UploadBtn = new Button();
            RunBtn = new Button();
            comboBox1 = new ComboBox();
            downloadBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
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
            pictureBox2.Click += pictureBox2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, imageToolStripMenuItem, runToolStripMenuItem });
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
            uploadImageToolStripMenuItem.Click += uploadImageToolStripMenuItem_Click;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(164, 22);
            saveImageToolStripMenuItem.Text = "Download Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyImageToolStripMenuItem, greyScaleToolStripMenuItem, colorInversionToolStripMenuItem, histogramToolStripMenuItem, rGBHistogramToolStripMenuItem, sepiaToolStripMenuItem });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
            // 
            // copyImageToolStripMenuItem
            // 
            copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            copyImageToolStripMenuItem.Size = new Size(183, 22);
            copyImageToolStripMenuItem.Text = "Copy Image";
            copyImageToolStripMenuItem.Click += copyImageToolStripMenuItem_Click;
            // 
            // greyScaleToolStripMenuItem
            // 
            greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            greyScaleToolStripMenuItem.Size = new Size(183, 22);
            greyScaleToolStripMenuItem.Text = "Greyscale";
            greyScaleToolStripMenuItem.Click += greyScaleToolStripMenuItem_Click;
            // 
            // colorInversionToolStripMenuItem
            // 
            colorInversionToolStripMenuItem.Name = "colorInversionToolStripMenuItem";
            colorInversionToolStripMenuItem.Size = new Size(183, 22);
            colorInversionToolStripMenuItem.Text = "Color Inversion";
            colorInversionToolStripMenuItem.Click += colorInversionToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(183, 22);
            histogramToolStripMenuItem.Text = "Greyscale Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // rGBHistogramToolStripMenuItem
            // 
            rGBHistogramToolStripMenuItem.Name = "rGBHistogramToolStripMenuItem";
            rGBHistogramToolStripMenuItem.Size = new Size(183, 22);
            rGBHistogramToolStripMenuItem.Text = "RGB Histogram";
            rGBHistogramToolStripMenuItem.Click += rGBHistogramToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(183, 22);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
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
            UploadBtn.Location = new Point(3, 3);
            UploadBtn.Name = "UploadBtn";
            UploadBtn.Size = new Size(248, 31);
            UploadBtn.TabIndex = 3;
            UploadBtn.Text = "Upload";
            UploadBtn.UseVisualStyleBackColor = true;
            UploadBtn.Click += uploadBtn_Click;
            // 
            // RunBtn
            // 
            RunBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RunBtn.Location = new Point(257, 3);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(248, 31);
            RunBtn.TabIndex = 4;
            RunBtn.Text = "Run";
            RunBtn.UseVisualStyleBackColor = true;
            RunBtn.Click += runBtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Copy", "Greyscale", "Color Inversion", "Greyscale Histogram", "RGB Histogram", "Sepia" });
            comboBox1.Location = new Point(257, 40);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(248, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // downloadBtn
            // 
            downloadBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            downloadBtn.Location = new Point(511, 3);
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Size = new Size(248, 31);
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
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(UploadBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(comboBox1, 1, 1);
            tableLayoutPanel2.Controls.Add(downloadBtn, 2, 0);
            tableLayoutPanel2.Controls.Add(RunBtn, 1, 0);
            tableLayoutPanel2.Location = new Point(182, 395);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 44.04762F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 55.95238F));
            tableLayoutPanel2.Size = new Size(762, 84);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 661);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(menuStrip1);
            Controls.Add(tableLayoutPanel1);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(1150, 700);
            MinimumSize = new Size(1150, 700);
            Name = "Form1";
            Text = "RevaldeImageProcessing";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
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
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem copyImageToolStripMenuItem;
        private ToolStripMenuItem greyScaleToolStripMenuItem;
        private ToolStripMenuItem colorInversionToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private Button UploadBtn;
        private Button RunBtn;
        private ComboBox comboBox1;
        private Button downloadBtn;
        private ToolStripMenuItem rGBHistogramToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
