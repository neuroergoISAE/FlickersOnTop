using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualStimuli
{
	public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}

		private void slider_Scroll(object sender, EventArgs e)
		{
			int redValue = slider1.Value;
			int greenValue = slider2.Value;
			int blueValue = slider3.Value;

			try
			{
					pnl.BackColor = Color.FromArgb(redValue, greenValue, blueValue);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
