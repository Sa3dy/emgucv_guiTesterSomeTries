/*
 * Created by SharpDevelop.
 * User: Sa3dyLAP
 * Date: 4/30/2016
 * Time: 11:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace emgucv_guiTester0
{
	partial class IP_Assignment2
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.input_pictureBox = new System.Windows.Forms.PictureBox();
			this.outputContours_pictureBox = new System.Windows.Forms.PictureBox();
			this.detectBtn = new System.Windows.Forms.Button();
			this.outputCircles_pictureBox = new System.Windows.Forms.PictureBox();
			this.contourpoints_lbl = new System.Windows.Forms.Label();
			this.contourpoints_listBox = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.input_pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.outputContours_pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.outputCircles_pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// input_pictureBox
			// 
			this.input_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.input_pictureBox.Location = new System.Drawing.Point(12, 12);
			this.input_pictureBox.Name = "input_pictureBox";
			this.input_pictureBox.Size = new System.Drawing.Size(355, 304);
			this.input_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.input_pictureBox.TabIndex = 1;
			this.input_pictureBox.TabStop = false;
			// 
			// outputContours_pictureBox
			// 
			this.outputContours_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.outputContours_pictureBox.Location = new System.Drawing.Point(400, 12);
			this.outputContours_pictureBox.Name = "outputContours_pictureBox";
			this.outputContours_pictureBox.Size = new System.Drawing.Size(355, 304);
			this.outputContours_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.outputContours_pictureBox.TabIndex = 2;
			this.outputContours_pictureBox.TabStop = false;
			// 
			// detectBtn
			// 
			this.detectBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.detectBtn.Location = new System.Drawing.Point(628, 322);
			this.detectBtn.Name = "detectBtn";
			this.detectBtn.Size = new System.Drawing.Size(127, 54);
			this.detectBtn.TabIndex = 3;
			this.detectBtn.Text = "Detect!";
			this.detectBtn.UseVisualStyleBackColor = true;
			this.detectBtn.Click += new System.EventHandler(this.DetectBtnClick);
			// 
			// outputCircles_pictureBox
			// 
			this.outputCircles_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.outputCircles_pictureBox.Location = new System.Drawing.Point(12, 322);
			this.outputCircles_pictureBox.Name = "outputCircles_pictureBox";
			this.outputCircles_pictureBox.Size = new System.Drawing.Size(355, 304);
			this.outputCircles_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.outputCircles_pictureBox.TabIndex = 4;
			this.outputCircles_pictureBox.TabStop = false;
			// 
			// contourpoints_lbl
			// 
			this.contourpoints_lbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.contourpoints_lbl.Location = new System.Drawing.Point(542, 392);
			this.contourpoints_lbl.Name = "contourpoints_lbl";
			this.contourpoints_lbl.Size = new System.Drawing.Size(211, 23);
			this.contourpoints_lbl.TabIndex = 7;
			this.contourpoints_lbl.Text = "0 Contours";
			// 
			// contourpoints_listBox
			// 
			this.contourpoints_listBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.contourpoints_listBox.FormattingEnabled = true;
			this.contourpoints_listBox.ItemHeight = 19;
			this.contourpoints_listBox.Location = new System.Drawing.Point(544, 418);
			this.contourpoints_listBox.Name = "contourpoints_listBox";
			this.contourpoints_listBox.Size = new System.Drawing.Size(211, 118);
			this.contourpoints_listBox.TabIndex = 6;
			// 
			// IP_Assignment2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(767, 740);
			this.Controls.Add(this.contourpoints_lbl);
			this.Controls.Add(this.contourpoints_listBox);
			this.Controls.Add(this.outputCircles_pictureBox);
			this.Controls.Add(this.detectBtn);
			this.Controls.Add(this.outputContours_pictureBox);
			this.Controls.Add(this.input_pictureBox);
			this.Name = "IP_Assignment2";
			this.Text = "IP_Assignment2";
			this.Load += new System.EventHandler(this.IP_Assignment2Load);
			((System.ComponentModel.ISupportInitialize)(this.input_pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.outputContours_pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.outputCircles_pictureBox)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox contourpoints_listBox;
		private System.Windows.Forms.Label contourpoints_lbl;
		private System.Windows.Forms.PictureBox outputCircles_pictureBox;
		private System.Windows.Forms.Button detectBtn;
		private System.Windows.Forms.PictureBox outputContours_pictureBox;
		private System.Windows.Forms.PictureBox input_pictureBox;
	}
}
