using OpenCvSharp;
using System.Collections.Generic;
using System.Diagnostics;


namespace RevaldeImageProcessing
{
    public partial class ImageManipulation : Form
    {
        String imagePath;
        Mat originalImg;
        Mat? modifiedImg;
        Mat finalImg;
        Mat frame;
        Bitmap imageA;
        Bitmap imageB;
        bool subtracted = false;
        decimal threshold = 10;
        int modification = 1;
        int mode = 1;
        VideoCapture cap;
        System.Windows.Forms.Timer webcamTimer;
        bool videoFeed = false;
        

        public ImageManipulation()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = 10;
            comboBox3.SelectedIndex = 0;
        }

        private Image MatToImage(Mat image)
        {
            return Image.FromStream(image.ToMemoryStream(".png"));
        }

        //Histogram functionality reference on opencvsharp wiki https://github.com/shimat/opencvsharp/wiki/Histogram
        public Mat CalculateHistogram(Mat src)
        {
            if (src == null || src.Empty())
            {
                throw new ArgumentException("Input image cannot be null or empty.");
            }


            using Mat grayImage = src.Channels() == 3 ? src.CvtColor(ColorConversionCodes.BGR2GRAY) : src;

            const int histSize = 256;
            var hdims = new int[] { histSize };
            var ranges = new Rangef[] { new Rangef(0, 256) };
            var channels = new int[] { 0 };

            using Mat hist = new Mat();
            Cv2.CalcHist(
                new Mat[] { grayImage },
                channels,
                null,
                hist,
                1,
                hdims,
                ranges
            );


            int histImageWidth = src.Width;
            int histImageHeight = src.Height;
            Mat histImage = new Mat(new OpenCvSharp.Size(histImageWidth, histImageHeight), MatType.CV_8UC3, Scalar.All(255));

            Cv2.MinMaxLoc(hist, out _, out double maxVal);
            Mat scaledHist = hist * (maxVal != 0 ? (double)histImageHeight / maxVal : 0.0);
            Scalar color = Scalar.All(100);
            int binWidth = (int)Math.Round((double)histImageWidth / histSize);

            for (int i = 0; i < histSize; ++i)
            {
                int binHeight = (int)scaledHist.Get<float>(i);
                histImage.Rectangle(
                    new OpenCvSharp.Point(i * binWidth, histImageHeight - binHeight),
                    new OpenCvSharp.Point((i + 1) * binWidth, histImageHeight),
                    color,
                    -1
                );
            }

            return histImage;
        }



        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Run was pressed with mod number: " + modification);
            if (modification != 0 && originalImg != null)
            {
                try
                {
                    if (modifiedImg == null) modifiedImg = originalImg.Clone();
                    if (finalImg == null) finalImg = originalImg.Clone();

                    if(modifiedImg.Channels() == 4)
                    {
                        Cv2.CvtColor(modifiedImg, modifiedImg, ColorConversionCodes.BGRA2BGR);
                    }
                    switch (modification)
                    {
                        case 1: // Copy
                            if (imageB != null)
                            {
                                modifiedImg = originalImg;
                                pictureBox2.Image = new Bitmap(imageB);
                                subtracted = false;
                            }
                            return;
                        case 2: // To Greyscale
                            if (originalImg.Channels() == 3)
                            {
                                if (subtracted) Cv2.CvtColor(modifiedImg, finalImg, ColorConversionCodes.BGR2GRAY);
                                else Cv2.CvtColor(originalImg, finalImg, ColorConversionCodes.BGR2GRAY);
                            }
                            break;
                        case 3: // Color Inversion
                            if (subtracted) finalImg = ~modifiedImg;
                            else Cv2.BitwiseNot(originalImg, finalImg);
                            break;
                        case 4: //Histogram
                            finalImg = CalculateHistogram(originalImg);
                            break;
                        case 5: // To Sepia
                            if (subtracted) finalImg = calculateSepia(modifiedImg);
                            else finalImg = calculateSepia(originalImg);
                            break;
                        default:
                            break;
                    }
                }
                catch (OpenCVException er)
                {
                    Debug.WriteLine("OpenCV error: " + er);
                }
                catch (Exception er)
                {
                    Debug.WriteLine("Error during image processing: " + er);
                }
                pictureBox2.Image = MatToImage(finalImg);
            }
        }

        private Mat calculateSepia(Mat src)
        {
            double[,] kernel = new double[,] { { 0.272, 0.534, 0.131 }, { 0.349, 0.686, 0.168 }, { 0.393, 0.769, 0.189 } };
            Mat colorSrc = src;

            if (src.Channels() == 1)
            {
                Cv2.CvtColor(src, colorSrc, ColorConversionCodes.GRAY2BGR);
            }
            else if (src.Channels() == 2)
            {
                Mat[] channels = Cv2.Split(src);
                Mat merged = new Mat();
                Cv2.Merge(new[] { channels[0], channels[0], channels[0] }, merged);
                colorSrc = merged;
            }
            else
            {
                Cv2.CvtColor(src, colorSrc, ColorConversionCodes.BGRA2BGR);
            }

            Mat sepiaImg = new Mat();
            try
            {
                Cv2.Transform(colorSrc, sepiaImg, InputArray.Create(kernel));
            }
            catch (OpenCVException ex)
            {
                Debug.WriteLine("Error converting Image to Sepia: " + ex.Message);
            }
            return sepiaImg;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedItem = comboBox1.SelectedItem;
            if (selectedItem != null)
            {
                switch (selectedItem.ToString())
                {
                    case "Copy":
                        modification = 1;
                        break;
                    case "Greyscale":
                        modification = 2;
                        break;
                    case "Color Inversion":
                        modification = 3;
                        break;
                    case "Histogram":
                        modification = 4;
                        break;
                    case "Sepia":
                        modification = 5;
                        break;
                    default:
                        modification = 1;
                        break;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBox3.SelectedItem;
            if (selectedItem != null)
            {
                switch (selectedItem.ToString())
                {
                    case "Video Mode":
                        mode = 1;
                        ApplyBtn.Visible = false;
                        StartBtn.Visible = true;
                        downloadBtn.Visible = false;
                        comboBox1.Visible = false;
                        UploadBtn.Visible = false;
                        label2.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        subtractBtn.Visible = false;
                        numericUpDown1.Visible = false;
                        label1.Visible = false;
                        break;
                    case "Photo Mode":
                        mode = 2;
                        ApplyBtn.Visible = true;
                        StartBtn.Visible = false;
                        downloadBtn.Visible = true;
                        comboBox1.Visible = true;
                        UploadBtn.Visible = true;
                        label2.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        subtractBtn.Visible = true;
                        numericUpDown1.Visible = true;
                        label1.Visible = true;
                        break;
                    default:
                        mode = 1;
                        break;
                }
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            runToolStripMenuItem_Click(sender, e);
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (finalImg != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.FileName = "Modified";
                dialog.DefaultExt = ".png";
                dialog.Title = "Save your exported file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string path = dialog.FileName;
                        Cv2.ImWrite(path, finalImg);
                    }
                    catch (Exception er)
                    {
                        Debug.WriteLine("Image download procedure failed");
                    }
                }
            }
        }

        private void SaveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloadBtn_Click(sender, e);
        }

        private void LoadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode == 2)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;
                ofd.Title = "Select an Image File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePath = ofd.FileName;
                    Debug.WriteLine("PATH: " + imagePath);

                    pictureBox1.Image = Image.FromFile(imagePath);
                    imageB = (Bitmap)Bitmap.FromFile(imagePath);
                    try
                    {
                        originalImg = Cv2.ImRead(imagePath);
                        modifiedImg = null;
                    }
                    catch (Exception er)
                    {
                        Debug.WriteLine("Invalid image path" + imagePath + er);
                    }
                }
                subtracted = false;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            LoadImageToolStripMenuItem_Click(sender, e);
        }

        private void LoadbackgroundBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Multiselect = false;
            ofd.Title = "Select an Image File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                Debug.WriteLine("PATH: " + imagePath);
                try
                {
                    imageA = (Bitmap)Bitmap.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    Debug.Write("Error loading ImageA: " + ex.Message);
                }
            }
            modifiedImg = originalImg;
            pictureBox2.Image = imageA;
            subtracted = false;
        }

        private void SubtractBtn_Click(object sender, EventArgs e)
        {
            if(imageB != null && imageA != null)
            {
                PhotoSubtraction();
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            threshold = numericUpDown1.Value;
        }

        private void PhotoSubtraction()
        {
            Bitmap resultImage = new Bitmap(imageB.Width, imageB.Height);
            Color myGreen = Color.FromArgb(0, 255, 0);
            int greygreen = (myGreen.R + myGreen.G + myGreen.B) / 3;

            for (int x = 0; x < imageB.Width; x++)
            {
                for (int y = 0; y < imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);
                    decimal grey = (pixel.R + pixel.G + pixel.B) / 3;
                    decimal subtractvalue = Math.Abs(grey - greygreen);
                    if (subtractvalue > threshold)
                        resultImage.SetPixel(x, y, pixel);
                    else
                        resultImage.SetPixel(x, y, backpixel);
                }
            }
            Mat tempMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(resultImage);
            if (tempMat.Channels() == 1)
            {
                Mat colorMat = new Mat();
                Cv2.CvtColor(tempMat, colorMat, ColorConversionCodes.GRAY2BGR);
                modifiedImg = colorMat;
            }
            else
            {
                modifiedImg = tempMat;
            }
            subtracted = true;
            pictureBox2.Image = MatToImage(modifiedImg);
        }
        /*I don't have a webcam so I used an app called DroidCam client to connect my phone camera to my pc 
         with a CamIndex = 1400. Thus, I don't have experience using a real webcam on my program. So kindly
         adjust the CamIndex to find the appropriate camera in your system */
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (videoFeed)
            {
                StartBtn.Text = "Start";
                cap.Release();
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                videoFeed = false;
                return;
            }

            int CamIndex = 0; 
            cap = new VideoCapture(CamIndex, VideoCaptureAPIs.ANY);
            
            if (!cap.IsOpened())
            {
                Debug.WriteLine("Error opening webcam");
                return;
            }

            if (webcamTimer == null)
            {
                webcamTimer = new System.Windows.Forms.Timer();
                webcamTimer.Interval = (int) Math.Round(1000.0 / cap.Fps);
                webcamTimer.Tick += WebcamTimer_Tick;
            }
            webcamTimer.Start();
            StartBtn.Text = "Stop";
            videoFeed = true;
        }

        private void WebcamTimer_Tick(object sender, EventArgs e)
        {
            if (cap != null && cap.IsOpened())
            {
                frame ??= new Mat();
                cap.Read(frame);
                if (!frame.Empty())
                {
                    pictureBox1.Image = MatToImage(frame);

                    //Video Subtraction
                    if (videoFeed && imageA != null)
                    {
                        Mat bg = OpenCvSharp.Extensions.BitmapConverter.ToMat(imageA).Clone();
                        Cv2.Resize(bg, bg, new OpenCvSharp.Size(frame.Width, frame.Height));

                        Mat hsv = new Mat();
                        Cv2.CvtColor(frame, hsv, ColorConversionCodes.BGR2HSV);

                        Scalar lowerBound = new Scalar(40, 50, 50);
                        Scalar upperBound = new Scalar(85, 255, 255);
                        
                        Mat mask = new Mat();
                        Cv2.InRange(hsv,lowerBound,upperBound, mask);
                        Mat inv = new Mat();
                        Cv2.BitwiseNot(mask, inv);

                        Mat subject = new Mat();
                        Cv2.BitwiseAnd(frame, frame, subject, inv);

                        Mat bgPart = new Mat();
                        Cv2.BitwiseAnd(bg, bg, bgPart, mask);

                        Mat final = new Mat();
                        Cv2.Add(subject, bgPart, final);
                        pictureBox2.Image = MatToImage(final);
                    }
                }
            }
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                modification = 2;
            }
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                modification = 1;
            }
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                modification = 3;
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                modification = 4;
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                modification = 6;
            }
        }

        private void rGBHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item != null)
            {
                modification = 5;
            }
        }
    }

}
