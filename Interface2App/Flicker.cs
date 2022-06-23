using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Interface2App
{
	public class Flicker : EntityValidator
	{
		static int resX = Screen.PrimaryScreen.Bounds.Width;
		public int resY = Screen.PrimaryScreen.Bounds.Height;
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 1280)]
		public int X { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 720)]
		public int Y { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 1280)]
		public int Width { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 720)]
		public int Height { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 30)]
		public int Frequence { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 180)]
		public int Phase { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 100)]
		public int Opacity { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 5)]
		public int Type { get; set; }

		public int  Suplement {get ; set;}


	}
}
