/*
 * Created by SharpDevelop.
 * User: Sa3dyLAP
 * Date: 4/30/2016
 * Time: 11:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;
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
	/// Description of IP_Assignment2.
	/// </summary>
	public partial class IP_Assignment2 : Form
	{
		private Image<Bgr, Byte> input_pictureBoxBgrImage;
		
		public IP_Assignment2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void IP_Assignment2Load(object sender, EventArgs e)
		{
			Image<Bgr, byte> inputImg = new Image<Bgr, byte>("inputImg.jpg");
			input_pictureBox.Image = inputImg.ToBitmap();
		}
		
		public void performCirclesDetection()
      {
            //Load the image from file and resize it for display
            Image<Bgr, Byte> img = 
               new Image<Bgr, byte>("inputImg.jpg")
               .Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, true);

            //Convert the image to grayscale and filter out the noise
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();

            Gray cannyThreshold = new Gray(100);
            Gray cannyThresholdLinking = new Gray(180);
            Gray circleAccumulatorThreshold = new Gray(500);

            CircleF[] circles = gray.HoughCircles(
                cannyThreshold,
                circleAccumulatorThreshold,
                4.0, //Resolution of the accumulator used to detect centers of the circles
                1.0, //min distance 
                5, //min radius
                0 //max radius
                )[0]; //Get the circles from the first channel

            input_pictureBox.Image = img.ToBitmap();

            #region draw circles
            Image<Bgr, Byte> circleImage = img;
            foreach (CircleF circle in circles)
               circleImage.Draw(circle, new Bgr(Color.Brown), 2);
            outputCircles_pictureBox.Image = circleImage.ToBitmap();
            #endregion
      }
		
		void DetectBtnClick(object sender, EventArgs e)
		{
		    Bitmap input_pictureBoxBitmap = new Bitmap(input_pictureBox.Image);
			input_pictureBoxBgrImage = new Image<Bgr, byte>(input_pictureBoxBitmap);
			Image<Bgr, Byte> outputCircles_pictureBoxBgrImage = new Image<Bgr, byte>(input_pictureBoxBitmap);
	        
			Image<Gray, Byte> gray = input_pictureBoxBgrImage.Convert<Gray, Byte>().PyrDown().PyrUp();
			
			//Gray cannyThreshold = new Gray(80);
            //Gray cannyThresholdLinking = new Gray(100);

            //Image<Gray, float> cannyEdges = gray.Sobel(0, 1, 5).Add(gray.Sobel(1, 0, 5)).AbsDiff(new Gray(0.0));;
			
			//output_pictureBox.Image = cannyEdges.ToBitmap();
			
            Gray cannyThreshold = new Gray(250);
            Gray cannyThresholdLinking = new Gray(120);
            Gray circleAccumulatorThreshold = new Gray(200);

            Image<Gray, Byte> cannyEdges = gray.Canny(120, 20).Not();

            Bitmap color;
            Bitmap bgray;
            
            IdentifyContours(cannyEdges.Bitmap, 100, true, out bgray, out color);
            
            Image<Gray, Byte> bgrayImage = new Image<Gray, byte>(bgray);

            outputContours_pictureBox.Image = input_pictureBoxBgrImage.ToBitmap();
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
                    	double area = currentContour.Area;
                        CvInvoke.cvDrawContours(input_pictureBoxBgrImage, contours, new MCvScalar(0,0,255), new MCvScalar(255,255,255), -1, 3, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
                        color.Draw(currentContour.BoundingRectangle, new Bgr(0, 0, 255), 1);
                        contourpoints_lbl.Text = contours.Total.ToString() + " Contours";
                        contourpoints_listBox.Items.Add(area);
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
	}
}
