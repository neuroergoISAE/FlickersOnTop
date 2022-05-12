namespace VisualStimuli
{
	partial class UserControl1
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.slider1 = new System.Windows.Forms.TrackBar();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.slider2 = new System.Windows.Forms.TrackBar();
			this.slider3 = new System.Windows.Forms.TrackBar();
			this.pnl = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.slider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slider2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.slider3)).BeginInit();
			this.SuspendLayout();
			// 
			// slider1
			// 
			this.slider1.Location = new System.Drawing.Point(345, 430);
			this.slider1.Maximum = 255;
			this.slider1.Name = "slider1";
			this.slider1.Size = new System.Drawing.Size(209, 69);
			this.slider1.TabIndex = 0;
			this.slider1.TickFrequency = 5;
			this.slider1.Scroll += new System.EventHandler(this.slider_Scroll);
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(466, 491);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(60, 8);
			this.hScrollBar1.TabIndex = 1;
			// 
			// slider2
			// 
			this.slider2.Location = new System.Drawing.Point(345, 495);
			this.slider2.Maximum = 255;
			this.slider2.Name = "slider2";
			this.slider2.Size = new System.Drawing.Size(209, 69);
			this.slider2.TabIndex = 2;
			this.slider2.TickFrequency = 5;
			this.slider2.Scroll += new System.EventHandler(this.slider_Scroll);
			// 
			// slider3
			// 
			this.slider3.Location = new System.Drawing.Point(345, 566);
			this.slider3.Maximum = 255;
			this.slider3.Name = "slider3";
			this.slider3.Size = new System.Drawing.Size(209, 69);
			this.slider3.TabIndex = 3;
			this.slider3.TickFrequency = 5;
			this.slider3.Scroll += new System.EventHandler(this.slider_Scroll);
			// 
			// pnl
			// 
			this.pnl.Location = new System.Drawing.Point(619, 450);
			this.pnl.Name = "pnl";
			this.pnl.Size = new System.Drawing.Size(259, 151);
			this.pnl.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(351, 390);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Red";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(351, 472);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Green";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(351, 543);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Blue";
			// 
			// UserControl1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pnl);
			this.Controls.Add(this.slider3);
			this.Controls.Add(this.slider2);
			this.Controls.Add(this.hScrollBar1);
			this.Controls.Add(this.slider1);
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(988, 656);
			((System.ComponentModel.ISupportInitialize)(this.slider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slider2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.slider3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar slider1;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.TrackBar slider2;
		private System.Windows.Forms.TrackBar slider3;
		private System.Windows.Forms.Panel pnl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}
