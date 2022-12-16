
using System;
using System.ComponentModel.DataAnnotations;

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
		public double Frequency { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 180)]
		public double Phase { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 100)]
		public int Opacity_Min { get; set; }
		public int Opacity_Max { get; set; }
		public Signal_Type Type { get; set; }
        public System.Windows.Media.Color color1 { get; set; }
        public string image { get; set; }
		public bool IsImageFlicker { get; set; } 
		public int[] sequence { get; set; }



        public enum Signal_Type
		{
			Sine=1,
			Root_Square=3,
			Square=2,
			Random=0,
			Maximum_Lenght_Sequence=4
		}
		/// <summary>
		/// create a new flicker in top-left point of the screen with white color.
		/// </summary>
		public Flicker()
		{
			Name = "Flicker";
			Opacity_Min = 0;
			Opacity_Max = 100;
			Type= Signal_Type.Sine;
			color1= System.Windows.Media.Color.FromArgb(255,255,255,255);
			X = 0;
			Y = 0;
			Width = 100;
			Height = 100;
			IsImageFlicker = false;
			image = String.Empty;
			Frequency= 1;
		}
		/// <summary>
		/// custom flicker with parameters
		/// </summary>
		/// <param name="X"></param>
		/// <param name="Y"></param>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		/// <param name="c"></param>
        public Flicker(int X,int Y,int Width,int Height,System.Windows.Media.Color c,int op_min,int op_max,double freq)
        {
            Name = "Flicker";
            Opacity_Min = op_min;
            Opacity_Max = op_max;
            Type = Signal_Type.Sine;
			color1 = c;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            IsImageFlicker = false;
            image = String.Empty;
            Frequency = freq;
        }
        /// <summary>
        /// copy a flicker
        /// </summary>
        /// <param name="f"></param>
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
		/// <summary>
		/// copy a flicker
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static Flicker copy(Flicker f)
		{
			return new Flicker(f);
		}
		public override string ToString()
		{
			return string.Format("Flicker at: {0},{1} Size: {2},{3}", X, Y, Width, Height);
		}
	}
}
