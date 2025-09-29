using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace RevaldeImageProcessing
{
    public partial class ImageManipulation : Form
    {
        private String imagePath;
        private Mat originalImg;
        private Mat? modifiedImg;
        private Mat finalImg;
        private Mat frame = new Mat();
        private Bitmap imageA;
        private Bitmap imageB;
        private bool subtracted = false;
        private decimal threshold = 10;
        private int modification = 1;
        private int mode = 1;
        private VideoCapture cap;
        private System.Windows.Forms.Timer webcamTimer;
        private bool videoFeed = false;
        private String window_name = "Output Image";

        private Scalar lowerBound = new Scalar(45, 100, 100);
        private Scalar upperBound = new Scalar(70, 255, 255);
        private Mat hsv = new Mat();
        private Mat mask = new Mat();
        private Mat inv = new Mat();
        private Mat subject = new Mat();
        private Mat bgPart = new Mat();
        private Mat final = new Mat();
        private Mat bg;



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
            comboBox3.SelectedIndex = 1;
            warningLabel.Visible = false;
            warningLabel.Text = "";
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

                    if (modifiedImg.Channels() == 4)
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
                        case 4: // Histogram
                            if (subtracted) finalImg = CalculateHistogram(modifiedImg);
                            else finalImg = CalculateHistogram(originalImg);
                            break;
                        case 5: // To Sepia
                            if (subtracted) finalImg = CalculateSepia(modifiedImg);
                            else finalImg = CalculateSepia(originalImg);
                            break;
                        case 6: // Sobel
                            finalImg = EdgeDetection(modifiedImg, 'd');
                            break;
                        case 7: // Emboss
                            finalImg = ConvolutionFilter(modifiedImg, 'e');
                            break;
                        case 8: // Sharpen
                            finalImg = ConvolutionFilter(modifiedImg, 's');
                            break;
                        case 9: // Horizontal Sobel
                            finalImg = EdgeDetection(modifiedImg, 'x');
                            break;
                        case 10:// Vertical Sobel
                            finalImg = EdgeDetection(modifiedImg, 'y');
                            break;
                        case 11:// Scharr
                            finalImg = EdgeDetection(modifiedImg, 's');
                            break;
                        case 12:// Blur
                            finalImg = Blur(modifiedImg, 'b');
                            break;
                        case 13:// Gaussian Blur
                            finalImg = Blur(modifiedImg, 'g');
                            break;
                        case 14:// Median Blur
                            finalImg = Blur(modifiedImg, 'm');
                            break;
                        case 15:// Bilateral Filter
                            finalImg = Blur(modifiedImg, 'f');
                            break;
                        case 16:// Outline
                            finalImg = ConvolutionFilter(modifiedImg, 'o');
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

        //Convolution blur functionality reference: https://docs.opencv.org/4.x/dc/dd3/tutorial_gausian_median_blur_bilateral_filter.html
        //The image is masked with an 11x11 convolution matrix to emphasize the blurring effect
        private Mat Blur(Mat image, char type)
        {
            Mat result = new Mat();

            switch (type)
            {
                case 'b':
                    Cv2.Blur(image, result, new OpenCvSharp.Size(11, 11), new OpenCvSharp.Point(-1, -1));
                    break;
                case 'g':
                    Cv2.GaussianBlur(image, result, new OpenCvSharp.Size(11, 11), 0, 0);
                    break;
                case 'm':
                    Cv2.MedianBlur(image, result, 11);
                    break;
                case 'f':
                    Cv2.BilateralFilter(image, result, 11, 11 * 2, 11 / 2);
                    break;
                default:
                    Cv2.Blur(image, result, new OpenCvSharp.Size(11, 11), new OpenCvSharp.Point(-1, -1));
                    break;
            }
            return result;
        }

        //Convolution masking functionality reference: https://docs.opencv.org/4.x/d7/d37/tutorial_mat_mask_operations.html
        private Mat ConvolutionFilter(Mat image, char type)
        {
            Mat result = new Mat();
            int[,] kernel;
            switch (type)
            {
                case 'e':
                    kernel = new int[,]{{ -2, -1, 0 },
                                        { -1, 1, 1 },
                                        { 0, 1, 2 }};
                    break;
                case 's':
                    kernel = new int[,]{{ 0, -1, 0 },
                                        { -1, 5, -1 },
                                        { 0, -1, 0 }};
                    break;
                case 'o':
                    kernel = new int[,]{{ -1, -1, -1 },
                                        { -1, 8, -1 },
                                        { -1, -1, -1 }};
                    break;
                default:
                    kernel = new int[,]{{ 0, 0, 0 },
                                        { 0, 1, 0 },
                                        { 0, 0, 0 }};
                    break;
            }
            Cv2.Filter2D(image, result, image.Depth(), InputArray.Create(kernel));
            return result;
        }

        //Sobel functionality reference: https://docs.opencv.org/4.x/d2/d2c/tutorial_sobel_derivatives.html
        private Mat EdgeDetection(Mat image, char type)
        {
            Mat result = new Mat();
            Mat src = new Mat();
            Mat srcGray = new Mat();
            Cv2.GaussianBlur(image, src, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Default);
            Cv2.CvtColor(src, srcGray, ColorConversionCodes.BGR2GRAY);

            Mat grad_x = new Mat();
            Mat grad_y = new Mat();
            Mat abs_grad_x = new Mat();
            Mat abs_grad_y = new Mat();

            if (type == 's')
            {
                Cv2.Scharr(srcGray, grad_x, MatType.CV_16S, 1, 0);
                Cv2.Scharr(srcGray, grad_y, MatType.CV_16S, 0, 1);
                Cv2.ConvertScaleAbs(grad_x, abs_grad_x);
                Cv2.ConvertScaleAbs(grad_y, abs_grad_y);

                Cv2.AddWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0, result);
            }
            else
            {
                Cv2.Sobel(srcGray, grad_x, MatType.CV_16S, 1, 0, 3); //<---- used Kernel {{-1, 0, 1},{-2, 0, 2},{-1, 0, 1}} detects vertical edges
                Cv2.Sobel(srcGray, grad_y, MatType.CV_16S, 0, 1, 3); //<---- used Kernel {{-1, -2, -1},{ 0, 0, 0},{1, 2, 1}} detects horizontal edges
                Cv2.ConvertScaleAbs(grad_x, abs_grad_x);
                Cv2.ConvertScaleAbs(grad_y, abs_grad_y);

                switch (type)
                {
                    case 'd':
                        Cv2.AddWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0, result);
                        break;
                    case 'y':
                        result = abs_grad_x;
                        break;
                    case 'x':
                        result = abs_grad_y;
                        break;
                    default:
                        Cv2.AddWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0, result);
                        break;
                }
            }

            return result;
        }


        private Mat CalculateSepia(Mat src)
        {
            double[,] kernel = new double[,] { { 0.272, 0.534, 0.131 },
                                               { 0.349, 0.686, 0.168 },
                                               { 0.393, 0.769, 0.189 }};
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
                    case "Sobel": //Convolution filters
                        modification = 6;
                        break;
                    case "Emboss":
                        modification = 7;
                        break;
                    case "Sharpen":
                        modification = 8;
                        break;
                    case "Horizontal Sobel":
                        modification = 9;
                        break;
                    case "Vertical Sobel":
                        modification = 10;
                        break;
                    case "Scharr":
                        modification = 11;
                        break;
                    case "Blur":
                        modification = 12;
                        break;
                    case "Gaussian Blur":
                        modification = 13;
                        break;
                    case "Median Blur":
                        modification = 14;
                        break;
                    case "Bilateral Filter":
                        modification = 15;
                        break;
                    case "Outline":
                        modification = 16;
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
            if (mode == 2 && !videoFeed)
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
            LoadBg();
            closeError();
        }

        private void SubtractBtn_Click(object sender, EventArgs e)
        {
            if(imageB == null)
            {
                ShowError("No loaded subject");
                return;
            }
            else if(imageA == null)
            {
                ShowError("No loaded background");
                return;
            } else
            {
                closeError();
                PhotoSubtraction();
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            threshold = numericUpDown1.Value;
        }

        private void ShowError(String message)
        {
            warningLabel.Text = message;
            warningLabel.Visible = true;
        }

        private void closeError()
        {
            warningLabel.Text = "";
            warningLabel.Visible = false;
        }
        private void PhotoSubtraction()
        {
            Bitmap resultImage = new Bitmap(imageB.Width, imageB.Height);
            Color myGreen = Color.FromArgb(0, 255, 0);
            int greygreen = (myGreen.R + myGreen.G + myGreen.B) / 3;

            if (imageA.Height < imageB.Height || imageA.Height < imageB.Height)
            {
                ShowError("Background image size is smaller than foreground Image");
                return;
            }
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
            Mat tempMat = BitmapConverter.ToMat(resultImage);
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
            closeError();
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
                ShowError("Error opening camera");
                Debug.WriteLine("Error opening webcam");
                return;
            }

            pictureBox2.Image = null;
            videoFeed = true;

            if (webcamTimer == null)
            {
                webcamTimer = new System.Windows.Forms.Timer();
                webcamTimer.Interval = (int)Math.Round(1000.0 / cap.Fps);
                webcamTimer.Tick += WebcamTimer_Tick;
            }
            webcamTimer.Start();
            StartBtn.Text = "Stop";
        }

        private void LoadBg()
        {
            if (!videoFeed) return;
            if (imageA != null && frame != null)
            {
                bg = BitmapConverter.ToMat(imageA);
                Cv2.Resize(bg, bg, new OpenCvSharp.Size(frame.Width, frame.Height));
            }
        }

        private void WebcamTimer_Tick(object sender, EventArgs e)
        {
            if (cap != null && cap.IsOpened())
            {
                cap.Read(frame);
                if (!frame.Empty())
                {
                    pictureBox1.Image = MatToImage(frame);

                    VideoSubtraction();
                }
            }
        }

        private void VideoSubtraction()
        {
            if (videoFeed && bg != null)
            {
                LoadBg();
                Cv2.CvtColor(frame, hsv, ColorConversionCodes.BGR2HSV);
                mask.SetTo(0);
                Cv2.InRange(hsv, lowerBound, upperBound, mask);
                inv.SetTo(0);
                Cv2.BitwiseNot(mask, inv);
                subject.SetTo(0);
                Cv2.BitwiseAnd(frame, frame, subject, inv);
                bgPart.SetTo(0);
                Cv2.BitwiseAnd(bg, bg, bgPart, mask);
                if (subject.Size() != bgPart.Size() || subject.Type() != bgPart.Type())
                {
                    Cv2.Resize(bgPart, bgPart, subject.Size());
                    if (bgPart.Type() != subject.Type())
                    {
                        bgPart = bgPart.CvtColor(ColorConversionCodes.BGRA2BGR);
                    }
                }
                Cv2.Add(subject, bgPart, final);
                pictureBox2.Image = BitmapConverter.ToBitmap(final);
            }
        }

        private void popoutImageBtn_Click(object sender, EventArgs e)
        {
            // Prefer final image if valid; otherwise fall back to original
            Mat? mat = null;
            if (finalImg != null && !finalImg.Empty())
                mat = finalImg;
            else if (modifiedImg != null && !modifiedImg.Empty())
                mat = modifiedImg;

            if (mat == null)
            {
                ShowError("No image to display.");
                return;
            }

            const string winName = "Output image";
            try
            {
                Cv2.NamedWindow(winName, WindowFlags.AutoSize);
                Cv2.ImShow(winName, mat);
                Cv2.WaitKey();
            }
            catch (OpenCVException ex)
            {
                Debug.WriteLine("OpenCV HighGUI error: " + ex.Message);
                ShowError("Failed to show image: " + ex.Message);
            }
            finally
            {
                try { Cv2.DestroyWindow(winName); } catch {}
            }
        }
    }
}
