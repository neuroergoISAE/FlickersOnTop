namespace VisualStimuli
{
	partial class UserControl2
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
			this.userControl11 = new VisualStimuli.UserControl1();
			this.SuspendLayout();
			// 
			// userControl11
			// 
			this.userControl11.Location = new System.Drawing.Point(35, 22);
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(824, 562);
			this.userControl11.TabIndex = 0;
			this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
			// 
			// UserControl2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.userControl11);
			this.Name = "UserControl2";
			this.Size = new System.Drawing.Size(924, 615);
			this.ResumeLayout(false);

		}

		#endregion

		private UserControl1 userControl11;
	}
}
