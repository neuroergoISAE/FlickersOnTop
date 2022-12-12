using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Windows.Media;
using System.Drawing;

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
        public System.Windows.Media.Color color1 { get; set; }
        public string image { get; set; }
		public bool IsImageFlicker { get; set; } 



        public enum Signal_Type
		{
			Sine=1,
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
			Type= Signal_Type.Sine;
			color1= System.Windows.Media.Color.FromArgb(255,255,255,255);
			IsImageFlicker = false;
			image = String.Empty;
			Frequency= 1;
		}
		public Flicker(Flicker f)
		{
			Name = f.Name;
			Opacity_Min = f.Opacity_Min;
			Opacity_Max = f.Opacity_Max;
			Type= f.Type;
			color1 = f.color1;
			image = f.image;
			Frequency= f.Frequency;
			Phase= f.Phase;
			X= f.X;
			Y= f.Y;
			Width= f.Width;
			Height= f.Height;
		}
		public override string ToString()
		{
			return string.Format("Flicker at: {0},{1} Size: {2},{3}", X, Y, Width, Height);
		}
	}
}
