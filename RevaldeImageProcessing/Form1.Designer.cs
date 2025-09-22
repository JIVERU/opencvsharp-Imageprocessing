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
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            runImageProcessingToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            UploadBtn = new Button();
            RunBtn = new Button();
            StopBtn = new Button();
            comboBox1 = new ComboBox();
            downloadBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(23, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(446, 326);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(497, 34);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(446, 326);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, imageToolStripMenuItem, runToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(978, 24);
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
            uploadImageToolStripMenuItem.Size = new Size(180, 22);
            uploadImageToolStripMenuItem.Text = "Upload Image";
            uploadImageToolStripMenuItem.Click += uploadImageToolStripMenuItem_Click;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(180, 22);
            saveImageToolStripMenuItem.Text = "Download Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyImageToolStripMenuItem, greyScaleToolStripMenuItem, colorInversionToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
            // 
            // copyImageToolStripMenuItem
            // 
            copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            copyImageToolStripMenuItem.Size = new Size(180, 22);
            copyImageToolStripMenuItem.Text = "Copy Image";
            // 
            // greyScaleToolStripMenuItem
            // 
            greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            greyScaleToolStripMenuItem.Size = new Size(180, 22);
            greyScaleToolStripMenuItem.Text = "Greyscale";
            // 
            // colorInversionToolStripMenuItem
            // 
            colorInversionToolStripMenuItem.Name = "colorInversionToolStripMenuItem";
            colorInversionToolStripMenuItem.Size = new Size(180, 22);
            colorInversionToolStripMenuItem.Text = "Color Inversion";
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(180, 22);
            histogramToolStripMenuItem.Text = "Histogram";
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(180, 22);
            sepiaToolStripMenuItem.Text = "Sepia";
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { runImageProcessingToolStripMenuItem, stopToolStripMenuItem });
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(59, 20);
            runToolStripMenuItem.Text = "Process";
            runToolStripMenuItem.Click += runToolStripMenuItem_Click;
            // 
            // runImageProcessingToolStripMenuItem
            // 
            runImageProcessingToolStripMenuItem.Name = "runImageProcessingToolStripMenuItem";
            runImageProcessingToolStripMenuItem.Size = new Size(98, 22);
            runImageProcessingToolStripMenuItem.Text = "Run";
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(98, 22);
            stopToolStripMenuItem.Text = "Stop";
            // 
            // UploadBtn
            // 
            UploadBtn.Location = new Point(135, 377);
            UploadBtn.Name = "UploadBtn";
            UploadBtn.Size = new Size(210, 23);
            UploadBtn.TabIndex = 3;
            UploadBtn.Text = "Upload";
            UploadBtn.UseVisualStyleBackColor = true;
            UploadBtn.Click += uploadBtn_Click;
            // 
            // RunBtn
            // 
            RunBtn.Location = new Point(497, 377);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(137, 23);
            RunBtn.TabIndex = 4;
            RunBtn.Text = "Run";
            RunBtn.UseVisualStyleBackColor = true;
            RunBtn.Click += runBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.Location = new Point(654, 377);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(143, 23);
            StopBtn.TabIndex = 5;
            StopBtn.Text = "Stop";
            StopBtn.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(497, 406);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(210, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // downloadBtn
            // 
            downloadBtn.Location = new Point(821, 377);
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Size = new Size(122, 23);
            downloadBtn.TabIndex = 7;
            downloadBtn.Text = "Download";
            downloadBtn.UseVisualStyleBackColor = true;
            downloadBtn.Click += downloadBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 451);
            Controls.Add(downloadBtn);
            Controls.Add(comboBox1);
            Controls.Add(StopBtn);
            Controls.Add(RunBtn);
            Controls.Add(UploadBtn);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private ToolStripMenuItem runImageProcessingToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private Button UploadBtn;
        private Button RunBtn;
        private Button StopBtn;
        private ComboBox comboBox1;
        private Button downloadBtn;
    }
}
