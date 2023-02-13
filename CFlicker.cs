using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using SDL2;
using static VisualStimuli.CPlay;

namespace VisualStimuli
{	/// <summary>
	/// <strong>Inputs:</strong> Color, Frequency, Alpha, Phase, Type, Screen;
	/// 
	/// <strong>Functions: </strong>CFlicker,getRed, getBlue, get Green, origin, display, getData, setData;
	/// </summary>
    class CFlicker
    {
		private IntPtr m_handle;
		private CScreen m_screen;
		private Color m_color1;
		private int m_alpha1;
		private int m_alpha2;
		private double m_frequence;
		private double m_phase;
		private int m_typeFreq;
		private double[] m_data;
		private int m_x;
		private int m_y;
		private int m_width;
		private int m_height;
		public string name { get; set; }
		public int X { get=>m_x; set=>m_x=value; }
		public int Y { get=>m_y; set=> m_y = value; }
		public int Width { get=>m_width; set=> m_width = value; }
		public int Height { get=>m_height; set=> m_height = value; }
		public double Phase { get => m_phase; set => m_phase = value; }
        public double Frequency { get => m_frequence; set => m_frequence = value; }
        public int Alpha2 { get => m_alpha2; set => m_alpha2 = value; }
        public int Alpha1 { get => m_alpha1; set => m_alpha1 = value; }
        public Color Color1 { get => m_color1; set => m_color1 = value; }
        internal CScreen Screen { get => m_screen; set => m_screen = value; }
        public IntPtr Handle { get => m_handle; set => m_handle = value; }
		public int TypeFrequence { get => m_typeFreq; set => m_typeFreq = value; }
		public int size { get; set; }
		public int index { get; set; }
		public int[] seq { get; set; }
		public int nextTime { get; set; }
		public bool isActive { get; set; }

		public double[] Data { get => m_data; set => m_data = value; }
		/// <summary>
		/// Create a flicker.
		/// </summary>
		/// <param name="col1">The UInt32 value illustates color1.</param>
		/// <param name="col2">The UInt32 value illustates color2.</param>
		/// <param name="freq">The double value illustates frequence.</param>
		/// <param name="alph1">The double value illustates the opacity1.</param>
		/// <param name="alph2">The double value illustates the opacity2.</param>
		/// <param name="phase">The double value illustates the phase.</param>
		/// <param name="typeFreq">The double value illustates type of the flicker (sine, max-length-sequence,...).</param>
		/// <param name="seq">The int array illustrates the timing in which the flicker is active</param>
		///<return>None</return>>
		
		public CFlicker(string n,int x,int y,int width,int height,CScreen screen, Color col1, double freq, int alph1, int alph2, double phase, int typeFreq, int[] seq)
		{
			name = n;
			Color1 = col1;
			Frequency = freq;
			Screen= screen;
			X = x;
			Y = y;
			Width = width;
			Height = height;
			Alpha1 = alph1;
			Alpha2 = alph2;
			Phase = phase;
			TypeFrequence = typeFreq;
			this.seq= seq;
			isActive= true;
			if (seq.Length > 0) { nextTime = 0; if (nextTime != 0) { isActive = false; } Console.WriteLine("seq lenght: {0}\n nextTime: {1}",seq.Length,nextTime); }
			double frameRate = GetFrameRate();
			while (Frequency > frameRate)
			{
				Frequency = frameRate; //a frequency higher than the frameRate is useless and takes more ressource
			}

			SDL.SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();			
			SDL.SDL_VERSION(out info.version);
			SDL.SDL_bool bRes = SDL.SDL_GetWindowWMInfo(Screen.PWindow, ref info);
			Handle = info.info.win.window;
			index = 0;

            Console.WriteLine("	\n");
			Console.WriteLine("Flicker {0} created - Position \tX = {1}\tY = {2}\tWidth = {3}\tHeight = {4} pixels", Screen.Name,Screen.X, Screen.Y,Screen.W, Screen.H);
			setData();
			//CreateAtlas();
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
		/// Display the flicker if it is active.
		/// </summary>
		public void display()
		{
            var i = Data[index];
            var a = (Byte)(Alpha1 * i + Alpha2 * (1 - i));
			if (isActive)
			{
                m_screen.show(a);
            }
           
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
		/// Getting frame rate of the computer
		/// </summary>
		/// <returns></returns>
		private double GetFrameRate()
		{
			DEVMODE devMode = new DEVMODE();
			devMode.dmSize = (short)Marshal.SizeOf(devMode);
			devMode.dmDriverExtra = 0;
			EnumDisplaySettings(null, -1, ref devMode);
			return (double)devMode.dmDisplayFrequency;
		}

		/// <summary>
		/// Generate a list of opacity number depends on type which was defined.
		/// </summary>
		/// <param name="flicker">FLicker.</param>
		public void setData()
		{
            int LCM(int a, int b)
            {
                return (a * b) / GCD(a, b);
            }

            int GCD(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            Random rand = new Random();
			int tmp;
			double frameRate = GetFrameRate();
            size = LCM((int)frameRate,(int)Frequency);

            m_data = new double[size]; // initializing data

            // random frequence
            if (TypeFrequence == 0)
			{

				for (int j = 0; j < size; j++)
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
			if (TypeFrequence == 1)
			{
				for (int j = 0; j < size; j++)
				{
					Data[j] = 0.5 * (1.0d + Math.Sin(2d * Math.PI * Frequency * (float)j / frameRate + (Phase/180d) * Math.PI));
				}
			}
			// square frequence
			if (TypeFrequence == 2)
			{

				for (int j = 0; j < size; j++)
				{
					double demo = 0.5 * (1.0d + Math.Sin(2d * Math.PI * Frequency * (float)j / frameRate + (Phase / 180d) * Math.PI));
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
			if (TypeFrequence == 3)
			{

				for (int j = 0; j < size; j++)
				{
					Data[j] = 0.5 * (1.0 + Math.Sqrt(2 * Math.PI * Frequency * j / frameRate + Phase * Math.PI));
				}

			}
			// Maximum length sequences
			if(TypeFrequence == 4)
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
				 for(int j = 0;j < size - 8 ; j++)
				{
					Data[j + 8] = (Data[j + 7] + Data[j + 2] + Data[j + 1] + Data[j]) % 2;
					
				}

				 
			}
			// None, used only for test
            if (TypeFrequence == 5)
			{
				for(int j=0;j<size;j++)
				{
					Data[j] = 1.0;
				}
			}

        }
		public void Destroy()
		{
			Screen.Quit();
		}
	}
}






