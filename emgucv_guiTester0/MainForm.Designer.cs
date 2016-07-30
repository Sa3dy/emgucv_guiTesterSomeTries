/*
 * Created by SharpDevelop.
 * User: Sa3dyLAP
 * Date: 2/21/2016
 * Time: 10:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace emgucv_guiTester0
{
	partial class MainForm
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
            this.output_pictureBox = new System.Windows.Forms.PictureBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.convertcanny_btn = new System.Windows.Forms.Button();
            this.inputImage_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contourpoints_listBox = new System.Windows.Forms.ListBox();
            this.contourpoints_lbl = new System.Windows.Forms.Label();
            this.saveoutputImage_btn = new System.Windows.Forms.Button();
            this.outputImage_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.classify_btn = new System.Windows.Forms.Button();
            this.train_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // input_pictureBox
            // 
            this.input_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.input_pictureBox.Location = new System.Drawing.Point(12, 12);
            this.input_pictureBox.Name = "input_pictureBox";
            this.input_pictureBox.Size = new System.Drawing.Size(340, 261);
            this.input_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.input_pictureBox.TabIndex = 0;
            this.input_pictureBox.TabStop = false;
            // 
            // output_pictureBox
            // 
            this.output_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.output_pictureBox.Location = new System.Drawing.Point(404, 12);
            this.output_pictureBox.Name = "output_pictureBox";
            this.output_pictureBox.Size = new System.Drawing.Size(340, 261);
            this.output_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.output_pictureBox.TabIndex = 1;
            this.output_pictureBox.TabStop = false;
            // 
            // browse_btn
            // 
            this.browse_btn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse_btn.Location = new System.Drawing.Point(631, 309);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(113, 40);
            this.browse_btn.TabIndex = 2;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.Browse_btnClick);
            // 
            // convertcanny_btn
            // 
            this.convertcanny_btn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertcanny_btn.Location = new System.Drawing.Point(365, 309);
            this.convertcanny_btn.Name = "convertcanny_btn";
            this.convertcanny_btn.Size = new System.Drawing.Size(260, 40);
            this.convertcanny_btn.TabIndex = 3;
            this.convertcanny_btn.Text = "Convert Canny Edges";
            this.convertcanny_btn.UseVisualStyleBackColor = true;
            this.convertcanny_btn.Click += new System.EventHandler(this.Convertcanny_btnClick);
            // 
            // contourpoints_listBox
            // 
            this.contourpoints_listBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contourpoints_listBox.FormattingEnabled = true;
            this.contourpoints_listBox.ItemHeight = 19;
            this.contourpoints_listBox.Location = new System.Drawing.Point(12, 330);
            this.contourpoints_listBox.Name = "contourpoints_listBox";
            this.contourpoints_listBox.Size = new System.Drawing.Size(211, 118);
            this.contourpoints_listBox.TabIndex = 4;
            // 
            // contourpoints_lbl
            // 
            this.contourpoints_lbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contourpoints_lbl.Location = new System.Drawing.Point(12, 304);
            this.contourpoints_lbl.Name = "contourpoints_lbl";
            this.contourpoints_lbl.Size = new System.Drawing.Size(211, 23);
            this.contourpoints_lbl.TabIndex = 5;
            this.contourpoints_lbl.Text = "Contour Points:";
            // 
            // saveoutputImage_btn
            // 
            this.saveoutputImage_btn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveoutputImage_btn.Location = new System.Drawing.Point(365, 355);
            this.saveoutputImage_btn.Name = "saveoutputImage_btn";
            this.saveoutputImage_btn.Size = new System.Drawing.Size(260, 40);
            this.saveoutputImage_btn.TabIndex = 6;
            this.saveoutputImage_btn.Text = "Save Output Image";
            this.saveoutputImage_btn.UseVisualStyleBackColor = true;
            this.saveoutputImage_btn.Click += new System.EventHandler(this.SaveoutputImage_btnClick);
            // 
            // outputImage_saveFileDialog
            // 
            this.outputImage_saveFileDialog.FileName = "outputImage";
            // 
            // classify_btn
            // 
            this.classify_btn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classify_btn.Location = new System.Drawing.Point(631, 408);
            this.classify_btn.Name = "classify_btn";
            this.classify_btn.Size = new System.Drawing.Size(113, 40);
            this.classify_btn.TabIndex = 7;
            this.classify_btn.Text = "Classify";
            this.classify_btn.UseVisualStyleBackColor = true;
            this.classify_btn.Click += new System.EventHandler(this.classify_btn_Click);
            // 
            // train_btn
            // 
            this.train_btn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.train_btn.Location = new System.Drawing.Point(512, 411);
            this.train_btn.Name = "train_btn";
            this.train_btn.Size = new System.Drawing.Size(113, 40);
            this.train_btn.TabIndex = 8;
            this.train_btn.Text = "Train";
            this.train_btn.UseVisualStyleBackColor = true;
            this.train_btn.Click += new System.EventHandler(this.train_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 463);
            this.Controls.Add(this.train_btn);
            this.Controls.Add(this.classify_btn);
            this.Controls.Add(this.saveoutputImage_btn);
            this.Controls.Add(this.contourpoints_lbl);
            this.Controls.Add(this.contourpoints_listBox);
            this.Controls.Add(this.convertcanny_btn);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.output_pictureBox);
            this.Controls.Add(this.input_pictureBox);
            this.Name = "MainForm";
            this.Text = "emgucv_guiTester0";
            ((System.ComponentModel.ISupportInitialize)(this.input_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_pictureBox)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.SaveFileDialog outputImage_saveFileDialog;
		private System.Windows.Forms.Button saveoutputImage_btn;
		private System.Windows.Forms.Label contourpoints_lbl;
		private System.Windows.Forms.ListBox contourpoints_listBox;
		private System.Windows.Forms.OpenFileDialog inputImage_openFileDialog;
		private System.Windows.Forms.Button convertcanny_btn;
		private System.Windows.Forms.Button browse_btn;
		private System.Windows.Forms.PictureBox output_pictureBox;
		private System.Windows.Forms.PictureBox input_pictureBox;
        private System.Windows.Forms.Button classify_btn;
        private System.Windows.Forms.Button train_btn;
	}
}
