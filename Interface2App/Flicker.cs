using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Windows.Media;

namespace Interface2App
{
	
	public class Flicker : EntityValidator
	{
        [Required, RegularExpression(@"^.*", ErrorMessage = "Please enter a number")]
        public string Name { get; set; }
        [Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		//[Range(0, sizeX())]
		public int X { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		//[Range(0, 720)]
		public int Y { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		//[Range(0, 1280)]
		public int Width { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		//[Range(0, 720)]
		public int Height { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		public int Frequency { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 180)]
		public int Phase { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 100)]
		public int Opacity_Min { get; set; }
		public int Opacity_Max { get; set; }
		public Signal_Type Type { get; set; }
        public Color color1 { get; set; }
        public string imagepath { get; set; }



        public enum Signal_Type
		{
			Sinuous=1,
			Root_Square=3,
			Square=2,
			Random=0,
			Maximum_Lenght_Sequence=4
		}

		public Flicker()
		{
			Name = "Flicker";
			Opacity_Min = 0;
			Opacity_Max = 100;
			Type= Signal_Type.Sinuous;
			color1= Color.FromArgb(255,255,255,255);
			imagepath = string.Empty;
			Frequency= 1;
		}
		public override string ToString()
		{
			return string.Format("Flicker at: {0},{1} Size: {2},{3}", X, Y, Width, Height);
		}
	}
}
