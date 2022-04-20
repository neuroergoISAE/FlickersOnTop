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

        public double Phase { get => m_phase; set => m_phase = value; }
        public double Frequence { get => m_frequence; set => m_frequence = value; }
        public double Alpha2 { get => m_alpha2; set => m_alpha2 = value; }
        public uint Color2 { get => m_color2; set => m_color2 = value; }
        public double Alpha1 { get => m_alpha1; set => m_alpha1 = value; }
        public uint Color1 { get => m_color1; set => m_color1 = value; }
        internal CScreen Screen { get => m_screen; set => m_screen = value; }
        public IntPtr Handle { get => m_handle; set => m_handle = value; }


        public CFlicker(CScreen aScreen, UInt32 col1, UInt32 col2, double freq, double alph1, double alph2, double phase)
		{
			Color1 = col1;
			Color2 = col2;
			Frequence = freq;
			Screen = aScreen;
			Alpha1 = alph1;
			Alpha2 = alph2;
			Phase = phase;

			SDL.SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();			
			SDL.SDL_VERSION(out info.version);
			SDL.SDL_bool bRes = SDL.SDL_GetWindowWMInfo(Screen.PWindow, ref info);
			Handle = info.info.win.window;

			Screen.ChangeColorAndAlpha(col1, alph1);
			Console.WriteLine("Flicker {0} created", Screen.Name);
		}

		public void ChangeColors(UInt32 col1, UInt32 col2)
		{
			Color1 = col1;
			Color2 = col2;
		}


		public void ChangeAlphas(double alph1, double alph2)
		{
			Alpha1 = alph1;
			Alpha2 = alph2;
		}


		public void Flip(UInt32 col, double alph)
		{
			Screen.ChangeColorAndAlpha(col, alph);
		}
		
		public void FlipColor(UInt32 col)
		{
			Screen.ChangeColor(col);
		}
		
		public void FlipAlpha(double alph)
		{
			Screen.ChangeAlpha(alph);
		}
		
		public Byte GetRed(UInt32 color)
		{
			Byte res = (Byte)(color >> 16);
			return res;
		}

		public Byte GetGreen(UInt32 color)
		{
			Byte res = (Byte)((color - (int)Math.Pow(2, 16)) >> 8);
			return res;
		}
		public Byte GetBlue(UInt32 color)
		{
			Byte res = (Byte)((color - (int)Math.Pow(2, 16) - (int)Math.Pow(2, 8)));
			return res;
		}

		public void Origin()
		{
			SDL.SDL_SetWindowSize(Screen.PWindow, Screen.W, Screen.H);
			SDL.SDL_SetWindowPosition(Screen.PWindow, Screen.X, Screen.Y);
		}

		public void Display()
		{
			m_screen.Show();
		}


	}
}






