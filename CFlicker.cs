using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace VisualStimuli
{	/// <summary>
	/// <strong>Inputs:</strong> Color, Frequence, Alpha, Phase, Type, Screen;
	/// 
	/// <strong>Functions: </strong>CFlicker, changeColors, changeAlphas, flip, getRed, getBlue, get Green, origin, display, getData, setData;
	/// </summary>
    class CFlicker
    {
		private IntPtr m_handle;
		private CScreen m_screen;
		private UInt32 m_color1;
		private double m_alpha1;
		private UInt32 m_color2;
		private double m_alpha2;
		private double m_frequence;
		private double m_phase;
		private int m_typeFreq;
		private double[] m_data;
		public double Phase { get => m_phase; set => m_phase = value; }
        public double Frequence { get => m_frequence; set => m_frequence = value; }
        public double Alpha2 { get => m_alpha2; set => m_alpha2 = value; }
        public uint Color2 { get => m_color2; set => m_color2 = value; }
        public double Alpha1 { get => m_alpha1; set => m_alpha1 = value; }
        public uint Color1 { get => m_color1; set => m_color1 = value; }
        internal CScreen Screen { get => m_screen; set => m_screen = value; }
        public IntPtr Handle { get => m_handle; set => m_handle = value; }
		public int TypeFrequence { get => m_typeFreq; set => m_typeFreq = value; }

		public double[] Data { get => m_data; set => m_data = value; }
		/// <summary>
		/// Create a flicker.
		/// </summary>
		/// <param name="aScreen">The screen which will flick.</param>
		/// <param name="col1">The UInt32 value illustates color1.</param>
		/// <param name="col2">The UInt32 value illustates color2.</param>
		/// <param name="freq">The double value illustates frequence.</param>
		/// <param name="alph1">The double value illustates the opacity1.</param>
		/// <param name="alph2">The double value illustates the opacity2.</param>
		/// <param name="phase">The double value illustates the phase.</param>
		/// <param name="typeFreq">The double value illustates type of the flicker (sinious, max-length-sequence,...).</param>
		///<return>None</return>>
		
		public CFlicker(CScreen aScreen, UInt32 col1, UInt32 col2, double freq, double alph1, double alph2, double phase, int typeFreq)
		{
			Color1 = col1;
			Color2 = col2;
			Frequence = freq;
			Screen = aScreen;
			Alpha1 = alph1;
			Alpha2 = alph2;
			Phase = phase;
			TypeFrequence = typeFreq;

			SDL.SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();			
			SDL.SDL_VERSION(out info.version);
			SDL.SDL_bool bRes = SDL.SDL_GetWindowWMInfo(Screen.PWindow, ref info);
			Handle = info.info.win.window;

			Screen.changeColorAndAlpha(col1, alph1);
			Console.WriteLine("	\n");
			Console.WriteLine("Flicker {0} created - Position \tX = {1}\tY = {2}\tWidth = {3}\tHeight = {4} pixels", Screen.Name,Screen.X, Screen.Y,Screen.W, Screen.H);
		}

		/// <summary>
		/// Update color coefficient.
		/// </summary>
		/// <param name="col1">Color 1</param>
		/// <param name="col2">Color 2</param>
		public void changeColors(UInt32 col1, UInt32 col2)
		{
			Color1 = col1;
			Color2 = col2;
		}

		/// <summary>
		/// Update the coefficient of opacity.
		/// </summary>
		/// <param name="alph1">Double Alpha 1.</param>
		/// <param name="alph2">Double Alpha 2.</param>
		public void changeAlphas(double alph1, double alph2)
		{
			Alpha1 = alph1;
			Alpha2 = alph2;
		}

		/// <summary>
		/// Update Color and Alpha coefficients.
		/// </summary>
		/// <param name="col">UInt32 Color value.</param>
		/// <param name="alph">Double Alpha value.</param>
		public void flip(UInt32 col, double alph)
		{
			Screen.changeColorAndAlpha(col, alph);
		}

		/// <summary>
		/// Get the number which represents to red color.
		/// </summary>
		/// <param name="color"> Red value. </param>
		/// <returns>Red color.</returns>
		public Byte getRed(UInt32 color)
		{
			Byte res = (Byte)(color >> 16);
			return res;
		}

		/// <summary>
		/// Get the number which represents to green color.
		/// </summary>
		/// <param name="color"> Green value. </param>
		/// <returns> Green color.</returns>
		public Byte getGreen(UInt32 color)
		{
			Byte res = (Byte)((color - (int)Math.Pow(2, 16)) >> 8);
			return res;
		}

		/// <summary>
		/// Get the number which represents to blue color.
		/// </summary>
		/// <param name="color"> Blue value. </param>
		/// <returns> Blue color.</returns>
		public Byte getBlue(UInt32 color)
		{
			Byte res = (Byte)((color - (int)Math.Pow(2, 16) - (int)Math.Pow(2, 8)));
			return res;
		}

		/// <summary>
		/// Setting flicker's size and flicker's position.
		/// </summary>
		public void origin()
		{
			SDL.SDL_SetWindowSize(Screen.PWindow, Screen.W, Screen.H);
			SDL.SDL_SetWindowPosition(Screen.PWindow, Screen.X, Screen.Y);
		}

		/// <summary>
		/// Display the flicker.
		/// </summary>
		public void display()
		{
			m_screen.show();
		}

		/// <summary>
		/// Return a number in the list Data
		/// </summary>
		/// <param name="i"> ith value in the list</param>
		/// <param name="a">list number of opacity</param>
		/// <returns>The number ith in the list Data</returns>
		public double getData(int i, double[] a) {

			return a[i];
		
		}

		/// <summary>
		/// Generate a list of opacity number depends on type which was defined.
		/// </summary>
		/// <param name="flicker">FLicker.</param>
		public void setData(CFlicker flicker)
		{

			Random rand = new Random();
			int tmp;
			double frameRate = 60;  // 60Hz 
			const double timeFlicker = 50;
			m_data = new double[(int)(frameRate * timeFlicker)]; // initializing data

			// random frequence
			if (flicker.TypeFrequence == 1)
			{

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{

					tmp = rand.Next();
					if (tmp % 7 == 0)
					{
						Data[j] = 1;//  max opacity = 1.0 
					}
					else
					{
						Data[j] = 0; //  min opacity = 0
					}

				}
			}
			// sininous frequence
			if (flicker.TypeFrequence == 2)
			{

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{
					Data[j] = 0.5 * (1.0 + Math.Sin(2 * Math.PI * flicker.Frequence * j / frameRate + flicker.Phase * Math.PI));
					
				}

			}
			// square frequence
			if (flicker.TypeFrequence == 3)
			{

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{
					double demo = 0.5 * (1.0 + Math.Sin(2 * Math.PI * flicker.Frequence * j / frameRate + flicker.Phase * Math.PI));
					if (demo <= 0.5)   // demo has a continous range from 0 to 1 so when demo value < 0.5 we consider approximatively demo = 0 and in inverse we consider demo = 1 when its value > 0.5; 
					{
						Data[j] = 0;
					}
					else
					{
						Data[j] = 1;
					}
				}

			}
			// square root frequence 
			if (flicker.TypeFrequence == 4)
			{

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{
					Data[j] = 0.5 * (1.0 + Math.Sqrt(2 * Math.PI * flicker.Frequence * j / frameRate + flicker.Phase * Math.PI));
				}

			}
			// Maximum length sequences
			if(flicker.TypeFrequence == 5)
			{
				// To understand maximum length sequence, go https://www.gaussianwaves.com/2018/09/maximum-length-sequences-m-sequences/
				// Here, we take a primitive polynomial degree 8 
				// The generator polynomial of the given LFSR is g(x) = g0 + g1x + g2x^2 + ... + gnx^n
				// So data we wiil set here have form: s[k + 8] = s[k + 7] + s[k + 2] + s[k + 1] + s[k]
				// LFSR is Linear feedback shift registers 
				// We initialyze 8 first random numbers (because of MLS is pseudorandom frequence)
				Data[0] = 1;
				Data[1] = 0;
				Data[2] = 0;
				Data[3] = 1;
				Data[4] = 0;
				Data[5] = 1;
				Data[6] = 0;
				Data[7] = 1;
				 for(int j = 0;j < (int)frameRate * timeFlicker - 8 ; j++)
				{
					Data[j + 8] = (Data[j + 7] + Data[j + 2] + Data[j + 1] + Data[j]) % 2;
					
				}

				 
			}
		}
	}
}






