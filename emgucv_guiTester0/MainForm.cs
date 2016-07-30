/*
 * Created by SharpDevelop.
 * User: Sa3dyLAP
 * Date: 2/21/2016
 * Time: 10:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Features2D;
using Emgu.CV.CvEnum;
using Emgu.Util.TypeEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace emgucv_guiTester0
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Browse_btnClick(object sender, EventArgs e)
		{
			inputImage_openFileDialog.Title = "Open Image";
	        inputImage_openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
	
	        if (inputImage_openFileDialog.ShowDialog() == DialogResult.OK)
	        {
	            input_pictureBox.Image = Image.FromFile(inputImage_openFileDialog.FileName);
	        }
		}
		
		void Convertcanny_btnClick(object sender, EventArgs e)
		{
			Bitmap input_pictureBoxBitmap = new Bitmap(input_pictureBox.Image);
			Image<Bgr, Byte> input_pictureBoxBgrImage = new Image<Bgr, byte>(input_pictureBoxBitmap);
	        
			Image<Gray, Byte> gray = input_pictureBoxBgrImage.Convert<Gray, Byte>().PyrDown().PyrUp();
			
			//Gray cannyThreshold = new Gray(80);
            //Gray cannyThresholdLinking = new Gray(100);

            //Image<Gray, float> cannyEdges = gray.Sobel(0, 1, 5).Add(gray.Sobel(1, 0, 5)).AbsDiff(new Gray(0.0));;
			
			//output_pictureBox.Image = cannyEdges.ToBitmap();
			
            Gray cannyThreshold = new Gray(80);
            Gray cannyThresholdLinking = new Gray(120);
            Gray circleAccumulatorThreshold = new Gray(120);

            Image<Gray, Byte> cannyEdges = gray.Canny(120, 120).Not();

            output_pictureBox.Image = gray.ToBitmap();

            Bitmap color;
            Bitmap bgray;
            IdentifyContours(cannyEdges.Bitmap, 10, true, out bgray, out color);

            output_pictureBox.Image = bgray;
			
	        //output_pictureBox.Image = input_pictureBoxBgrImage.ToBitmap();
		}
		
		public void IdentifyContours(Bitmap colorImage, int thresholdValue, bool invert, out Bitmap processedGray, out Bitmap processedColor)
        {
            Image<Gray, byte> grayImage = new Image<Gray, byte>(colorImage);
            Image<Bgr, byte> color = new Image<Bgr, byte>(colorImage);

            grayImage = grayImage.ThresholdBinary(new Gray(thresholdValue), new Gray(255));

            if (invert)
            {
                grayImage._Not();
            }

            using (MemStorage storage = new MemStorage())
            {

                for (Contour<Point> contours = grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
                {

                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                    if (currentContour.BoundingRectangle.Width > 20)
                    {
                        CvInvoke.cvDrawContours(grayImage, contours, new MCvScalar(255,255,255), new MCvScalar(255,255,255), -1, 3, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
                        color.Draw(currentContour.BoundingRectangle, new Bgr(0, 255, 0), 1);
                    }

                    Point[] pts = currentContour.ToArray();
                    foreach (Point p in pts)
                    {
                        //add points to listbox
                        contourpoints_listBox.Items.Add(p);
                    }
                }
            }

            processedColor = color.ToBitmap();
            processedGray = grayImage.ToBitmap();

        }
		
		void SaveoutputImage_btnClick(object sender, EventArgs e)
		{
			outputImage_saveFileDialog.Filter = "Images|*.bmp;*.png;*.jpg";
			
			ImageFormat format = ImageFormat.Bmp;
			if (outputImage_saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
			    string ext = System.IO.Path.GetExtension(outputImage_saveFileDialog.FileName);
			    switch (ext)
			    {
			        case ".png":
			            format = ImageFormat.Png;
			            break;
			        case ".jpg":
			            format = ImageFormat.Jpeg;
			            break;
			    }
			    output_pictureBox.Image.Save(outputImage_saveFileDialog.FileName, format);
			}
		}

        public void Train(string folder)
        {
            int class_num = 1;  //number of clusters/classes
            int input_num = 868;  //number of train images
            int j = 0;

            using (SURFDetector detector = new SURFDetector(500, false))
            using (BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2))
            {
                BOWKMeansTrainer bowTrainer = new BOWKMeansTrainer(33, new MCvTermCriteria(10, 0.01), 3, Emgu.CV.CvEnum.KMeansInitType.PPCenters);
                BOWImgDescriptorExtractor<float> bowDE = new BOWImgDescriptorExtractor<float>(detector, matcher);

                FileInfo[] files = new DirectoryInfo(folder).GetFiles();
                foreach (FileInfo file in files)
                {
                    using (Image<Bgr, Byte> model = new Image<Bgr, byte>(file.FullName))
                    using (Image<Gray, Byte> modelGray = model.Convert<Gray, Byte>())
                    //Detect SURF key points from images
                    using (VectorOfKeyPoint modelKeyPoints = detector.DetectKeyPointsRaw(modelGray, null))
                    //Compute detected SURF key points & extract modelDescriptors
                    using (Matrix<float> modelDescriptors = detector.ComputeDescriptorsRaw(modelGray, null, modelKeyPoints))
                    {
                        //Add the extracted BoW modelDescriptors into BOW trainer
                        bowTrainer.Add(modelDescriptors);
                    }
                    input_num++;
                }

                //Cluster the feature vectors
                Matrix<float> dictionary = bowTrainer.Cluster();
                //Store the vocabulary
                bowDE.SetVocabulary(dictionary);
                //To store all modelBOWDescriptor in a single trainingDescriptors
                Matrix<float> trainingDescriptors = new Matrix<float>(input_num, class_num);
                //To label each modelBOWDescriptor, in this case all train images are labelled with different integer 
                //hence all images are considered as a unique class, i.e class_num = input_num
                Matrix<float> labels = new Matrix<float>(input_num, 1);
                //Use labels of type <int> instead of <float> for NormalBayesClassifier
                //Matrix<int> labels = new Matrix<int>(input_num, 1);

                foreach (FileInfo file in files)
                {
                    using (Image<Bgr, Byte> model = new Image<Bgr, byte>(file.FullName))
                    using (Image<Gray, Byte> modelGray = model.Convert<Gray, Byte>())
                    using (VectorOfKeyPoint modelKeyPoints = detector.DetectKeyPointsRaw(modelGray, null))
                    using (Matrix<float> modelBOWDescriptor = bowDE.Compute(modelGray, modelKeyPoints))
                    {
                        //To merge all modelBOWDescriptor into single trainingDescriptors
                        for (int i = 0; i < trainingDescriptors.Cols; i++)
                        {
                            trainingDescriptors.Data[j, i] = modelBOWDescriptor.Data[0, i];
                        }
                        labels.Data[j, 0] = (j + 1);
                        j++;
                    }
                }

                //Declaration for Support Vector Machine & parameters
                SVM my_SVM = new SVM();
                SVMParams p = new SVMParams();
                p.KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR;
                p.SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC;
                p.C = 1;
                p.TermCrit = new MCvTermCriteria(100, 0.00001);
                bool trained = my_SVM.Train(trainingDescriptors, labels, null, null, p);

                //NormalBayesClassifier classifier = new NormalBayesClassifier();
                //classifier.Train(trainingDescriptors, labels, null, null, false);

                my_SVM.Save("Signs_SVM.xml");

                
            }
        }

        private void classify_btn_Click(object sender, EventArgs e)
        {
            Bitmap input_pictureBoxBitmap = new Bitmap(input_pictureBox.Image);
            Image<Bgr, Byte> input_pictureBoxBgrImage = new Image<Bgr, byte>(input_pictureBoxBitmap);

            using (SURFDetector detector = new SURFDetector(500, false))
            using (BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2))
            {
               
                BOWImgDescriptorExtractor<float> bowDE = new BOWImgDescriptorExtractor<float>(detector, matcher);

                SVM my_SVM = new SVM();
                
                my_SVM.Load("Signs_SVM.xml");

                using (Image<Gray, Byte> testImgGray = input_pictureBoxBgrImage.Convert<Gray, Byte>())
                using (VectorOfKeyPoint testKeyPoints = detector.DetectKeyPointsRaw(testImgGray, null))
                using (Matrix<float> testBOWDescriptor = bowDE.Compute(testImgGray, testKeyPoints))
                {
                    //float result = my_SVM.Predict(testBOWDescriptor);
                    //float result = classifier.Predict(testBOWDescriptor, null);
                    //result will indicate whether test image belongs to trainDescriptor label 1, 2 or 3  
                    //MessageBox.Show(result.ToString());
                }
            }
        }

        private void train_btn_Click(object sender, EventArgs e)
        {
            Train("C:\\Users\\Sa3dyLAP\\Desktop\\Our DataSet\\C");
            
        }
	}
}
