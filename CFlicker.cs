using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace VisualStimuli
{
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
			Console.WriteLine("			\t# |Width|  \t|Height|");
			Console.WriteLine("Flicker {0} created - Position \t{1} pixels\t{2} pixels", Screen.Name,Screen.W, Screen.H);
		}

		public void changeColors(UInt32 col1, UInt32 col2)
		{
			Color1 = col1;
			Color2 = col2;
		}


		public void changeAlphas(double alph1, double alph2)
		{
			Alpha1 = alph1;
			Alpha2 = alph2;
		}


		public void flip(UInt32 col, double alph)
		{
			Screen.changeColorAndAlpha(col, alph);
		}

		public Byte getRed(UInt32 color)
		{
			Byte res = (Byte)(color >> 16);
			return res;
		}

		public Byte getGreen(UInt32 color)
		{
			Byte res = (Byte)((color - (int)Math.Pow(2, 16)) >> 8);
			return res;
		}
		public Byte getBlue(UInt32 color)
		{
			Byte res = (Byte)((color - (int)Math.Pow(2, 16) - (int)Math.Pow(2, 8)));
			return res;
		}

		public void origin()
		{
			SDL.SDL_SetWindowSize(Screen.PWindow, Screen.W, Screen.H);
			SDL.SDL_SetWindowPosition(Screen.PWindow, Screen.X, Screen.Y);
		}

		public void display()
		{
			m_screen.show();
		}

		public double getData(int i, double[] a) {

			return a[i];
		
		}
		/// <summary>
		/// Flicker.matrixFrequence
		/// @agurment : ith flicker, framerate, a Flicker, matrix;
		/// Function to initilize type frequence of flicker
		/// TODO: 
		/// </summary>


		public void setData(CFlicker flicker) { 
		
			Random rand = new Random();
			int tmp;
			double frameRate = 60.0;
			const double timeFlicker = 50;
			m_data = new double[(int)(frameRate * timeFlicker)];

			if (flicker.TypeFrequence == 1) { 
			
				for(int j = 0; j < (int)frameRate * timeFlicker; j++)
				{

					tmp = rand.Next();
					if (tmp % 7 == 0)
					{
						Data[j] = 1;//  max amplitude = 1.0 
					}
					else
					{
						Data[j] = 0.1; //  min amplitude = 0.1 
					}

				}
			}
			if (flicker.TypeFrequence == 2) {

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{
					Data[j] = 0.5 * (1.0 + Math.Sin(2 * Math.PI * flicker.Frequence * j / frameRate + flicker.Phase * Math.PI));
				}

			}

			if (flicker.TypeFrequence == 3) {

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{
					double demo = 0.5 * (1.0 + Math.Sin(2 * Math.PI * flicker.Frequence * j / frameRate + flicker.Phase * Math.PI));
					if (demo <= 0.1)
					{
						Data[j] = 1;
					}
					else
					{
						Data[j] = 0.1;
					}
				}

			}

			if (flicker.TypeFrequence == 4) {

				for (int j = 0; j < (int)frameRate * timeFlicker; j++)
				{
					Data[j] = 0.5 * (1.0 + Math.Sqrt(2 * Math.PI * flicker.Frequence * j / frameRate + flicker.Phase * Math.PI));
				}

			}
		
		
		}

		// ------------------------------------------------ Oder verison -----------------------------------------
		public void matrixFrequence(int flickerth, double m_framerate, CFlicker Flicker, double[,] m_matrix)
		{
			 Random rand = new Random(); // Create a list of random number
			 int tmp; // temporal random number
					  
			// random frequence
			const double timeFlicker = 50;// in seconds
			if (Flicker.TypeFrequence == 1)
			{
				for (int j = 0; j < (int)m_framerate*timeFlicker; j++)
				{
					tmp = rand.Next();

					if (tmp % 7 == 0)
					{
						m_matrix[flickerth, j] = 1;//  max amplitude = 1.0 
					}
					else
					{
						m_matrix[flickerth, j] = 0.1; //  min amplitude = 0.1 
					}

				}
			}
			// sininous frequence
			if (Flicker.TypeFrequence == 2)
			{
				for (int j = 0; j < (int)m_framerate * timeFlicker; j++)
				{
					m_matrix[flickerth, j] = 0.5 * (1.0 + Math.Sin(2 * Math.PI * Flicker.Frequence * j / m_framerate + Flicker.Phase * Math.PI));
				}
			}
			// square frequence
			if (Flicker.TypeFrequence == 3)
			{

				for (int j = 0; j < (int)m_framerate * timeFlicker; j++)
				{
					double demo = 0.5 * (1.0 + Math.Sin(2 * Math.PI * Flicker.Frequence * j / m_framerate + Flicker.Phase * Math.PI));
					if (demo <= 0.1)
					{
						m_matrix[flickerth, j] = 1;
					}
					else
					{
						m_matrix[flickerth, j] = 0.1;
					}
				}

			}
			// square root frequence 

			if (Flicker.TypeFrequence == 4)
			{
				for (int j = 0; j < (int)m_framerate * timeFlicker; j++)
				{
					m_matrix[flickerth, j] = 0.5 * (1.0 + Math.Sqrt(2 * Math.PI * Flicker.Frequence * j / m_framerate + Flicker.Phase * Math.PI));
				}
			}


		}
	}
}






