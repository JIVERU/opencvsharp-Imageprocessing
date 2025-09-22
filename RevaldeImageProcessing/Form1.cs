using OpenCvSharp;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;

namespace RevaldeImageProcessing
{
    public partial class Form1 : Form
    {
        String imagePath;
        Mat originalImg;
        Mat? modifiedImg;
        int modification = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        }

        private Image MatToImage(Mat image)
        {
            return Image.FromStream(image.ToMemoryStream(".png"));
        }

        //private Mat calculateHistogram(Mat src)
        //{
        //Mat grey = new Mat();
        //Cv2.CvtColor(src, grey, ColorConversionCodes.BGR2GRAY);

        //int histSize = 256;
        //Rangef histRange = new Rangef(0, 256);
        //Mat hist = new Mat();
        //Cv2.CalcHist(&grey[], new int[] { 0 }, null, hist, 1, new int[] { histSize }, new Rangef[] { histRange }, true, false);

        //Cv2.ImShow("asdf",hist);
        //return hist;
        //}

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloadBtn_Click(sender, e);
        }

        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*;*.bmp";
            ofd.Multiselect = false;
            ofd.Title = "Select an Image File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                Debug.WriteLine("PATH: " + imagePath);

                pictureBox1.Image = Image.FromFile(imagePath);
            }

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

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Run was pressed with mod number: " + modification);
            if (modification != 0 && originalImg != null)
            {
                if (modifiedImg == null) modifiedImg = new Mat();
                try
                {
                    switch (modification)
                    {
                        case 1: // Copy
                            modifiedImg = originalImg;
                            pictureBox2.Image = MatToImage(modifiedImg);
                            break;
                        case 2: // To Greyscale
                            if (originalImg.Channels() == 3) // Greyscale needs 3 channels or it will throw an error.
                            {
                                Cv2.CvtColor(originalImg, modifiedImg, ColorConversionCodes.BGR2GRAY);
                                pictureBox2.Image = MatToImage(modifiedImg);
                            }
                            break;
                        case 3: // Color Inversion
                            Cv2.BitwiseNot(originalImg, modifiedImg);
                            pictureBox2.Image = MatToImage(modifiedImg);
                            break;
                        case 4:
                            //pictureBox2.Image = MatToImage(calculateHistogram(originalImg));
                            break;
                        case 5:
                            //pictureBox2.Image = MatToImage(calculateHistogram(originalImg));
                            break;
                        case 6:// To Sepia
                            calculateSepia(originalImg);
                            pictureBox2.Image = MatToImage(modifiedImg);
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
            }
        }

        private void calculateSepia(Mat src)
        {
            double[,] kernel = new double[,] { { 0.272, 0.534, 0.131 }, { 0.349, 0.686, 0.168 }, { 0.393, 0.769, 0.189 } };
            Mat colorSrc = src;

            // Making sure src has 3 channels(BGR). More or less channels and Cv2.Transform() will throw an error.
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
            catch (OpenCVException e) { }
            modifiedImg = sepiaImg;
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            uploadImageToolStripMenuItem_Click(sender, e);
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
                    case "RGB Histogram":
                        modification = 5;
                        break;
                    case "Sepia":
                        modification = 6;
                        break;
                    default:
                        modification = 1;
                        break;
                }
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            runToolStripMenuItem_Click(sender, e);
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (modifiedImg != null)
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
                        Cv2.ImWrite(path, modifiedImg);
                    }
                    catch (Exception er)
                    {
                        Debug.WriteLine("Image download procedure failed");
                    }
                }
            }
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                modification = 2;
            }
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                modification = 1;
            }
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                modification = 3;
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                modification = 4;
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                modification = 6;
            }
        }

        private void rGBHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                modification = 5;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }

}
