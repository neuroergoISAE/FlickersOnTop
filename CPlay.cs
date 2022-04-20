using System;
using SDL2;
using System.Runtime.InteropServices;
using System.Collections;



namespace VisualStimuli
{
	class CPlay
	{
		ArrayList m_listFlickers = new ArrayList();
		private double[,] m_matrix;

		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int height, int width, int cx, int cy, uint uFlags);

		private static readonly IntPtr HwndTopmost = new IntPtr(-1);
		private const UInt32 SDL_SWP_NOSIZE = 0x0001;
		private const UInt32 SDL_SWP_NOMOVE = 0x0002;
		private const UInt32 SDL_SWP_SHOWWINDOW = 0x0040;

		[DllImport("user32.dll")]
		public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref Devmode devMode);


		/// https://csharp.hotexamples.com/site/file?hash=0x238a44f2ed8da632e4e090af60159d66126fa38d9fd574bee99939a492be5ee7&fullName=KernelAPI.cs&project=ozeppi/mAgicAnime
		[StructLayout(LayoutKind.Sequential)]
		public struct Devmode
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string dmDeviceName;
			public System.Int16 dmSpecVersion;
			public System.Int16 dmDriverVersion;
			public System.Int16 dmSize;
			public System.Int16 dmDriverExtra;
			public System.Int32 dmFields;
			public System.Int16 dmOrientation;
			public System.Int16 dmPaperSize;
			public System.Int16 dmPaperLength;
			public System.Int16 dmPaperWidth;
			public System.Int16 dmScale;
			public System.Int16 dmCopies;
			public System.Int16 dmDefaultSource;
			public System.Int16 dmPrintQuality;
			public System.Int16 dmColor;
			public System.Int16 dmDuplex;
			public System.Int16 dmYResolution;
			public System.Int16 dmTTOption;
			public System.Int16 dmCollate;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string dmFormName;
			public System.Int16 dmUnusedPadding;
			public System.Int16 dmBitsPerPel;
			public System.Int32 dmPelsWidth;
			public System.Int32 dmPelsHeight;
			public System.Int32 dmDisplayFlags;
			public System.Int32 dmDisplayFrequency;
		}

		/// <summary>
		/// Temp function to initialize flickers in code (the same datas from file "test2_bis.txt")
		/// TODO : CSharp function to do it automaticaly
		/// </summary>
		public void init_test()
		{
			int height = 1920;
			int width = 1080;

			//*** flicker1
			CScreen screen1 = new CScreen((int)(height * 0), (int)(width * 0), (int)(height * 0.1), (int)(width * 0.1), "F1", false);
			var screenSurface1 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen1.PSurface);
			CFlicker flicker1 = new CFlicker(screen1,
				SDL.SDL_MapRGB(screenSurface1.format, 0, 0, 0), // color1 RGB
				SDL.SDL_MapRGB(screenSurface1.format, 255, 255, 255), // color2 RGB
				60.0, // freq
				1.0, // alpha1
				1.0, // alpha2
				0.5 // phase
				);
			m_listFlickers.Add(flicker1);

			//*** flicker2
			CScreen screen2 = new CScreen((int)(height * 0.7), (int)(width * 0.7), (int)(height * 0.1), (int)(width * 0.1), "F2", false);
			var screenSurface2 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen2.PSurface);
			CFlicker flicker2 = new CFlicker(screen2,
				SDL.SDL_MapRGB(screenSurface2.format, 0, 0, 0),
				SDL.SDL_MapRGB(screenSurface2.format, 255, 255, 255),
				40.0,
				0.5,
				1.0,
				0.0
				);
			m_listFlickers.Add(flicker2);

			//*** flicker3
			CScreen screen3 = new CScreen((int)(height * 0.2), (int)(width * 0.2), (int)(height * 0.2), (int)(width * 0.2), "F3", false);
			var screenSurface3 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen3.PSurface);
			CFlicker flicker3 = new CFlicker(screen3,
				SDL.SDL_MapRGB(screenSurface3.format, 0, 0, 0),
				SDL.SDL_MapRGB(screenSurface3.format, 255, 255, 255),
				10.0,
				1.0,
				0.2,
				0.0
				);
			m_listFlickers.Add(flicker3);

			//*** flicker4
			CScreen screen4 = new CScreen((int)(height * 0.6), (int)(width * 0.2), (int)(height * 0.2), (int)(width * 0.2), "F4", false);
			var screenSurface4 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen4.PSurface);
			CFlicker flicker4 = new CFlicker(screen4,
				SDL.SDL_MapRGB(screenSurface4.format, 0, 0, 0),
				SDL.SDL_MapRGB(screenSurface4.format, 255, 255, 255),
				10.0,
				1.0,
				0.2,
				0.7
				);
			m_listFlickers.Add(flicker4);

			//*** flicker5
			CScreen screen5 = new CScreen((int)(height * 0.8), (int)(width * 0.7), (int)(height * 0.05), (int)(width * 0.05), "F5", false);
			var screenSurface5 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen5.PSurface);
			CFlicker flicker5 = new CFlicker(screen5,
				SDL.SDL_MapRGB(screenSurface5.format, 0, 0, 0),
				SDL.SDL_MapRGB(screenSurface5.format, 255, 255, 255),
				10.0,
				1.0,
				1.0,
				0.0
				);
			m_listFlickers.Add(flicker5);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public double getFrameRate()
		{
			Devmode devMode = new Devmode();
			devMode.dmSize = (short)Marshal.SizeOf(devMode);
			devMode.dmDriverExtra = 0;
			EnumDisplaySettings(null, -1, ref devMode);
			return (double)devMode.dmDisplayFrequency;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="frameRate"></param>
		public void FrequenciesMatrix(double frameRate)
		{
			int n = m_listFlickers.Count;
			const double timeFlicker = 240;              //in seconds

			m_matrix = new double[n, (int)(frameRate * timeFlicker)];
			for (int i = 0; i < n; i++) {
				CFlicker aFlicker = (CFlicker)m_listFlickers[i];
				for (int j = 0; j < frameRate * timeFlicker; j++) {
					m_matrix[i, j] = 0.5 * (1.0 + Math.Sin(2 * Math.PI * aFlicker.Frequence * j / frameRate + aFlicker.Phase * Math.PI));
				}
			}
		}



		/// <summary>
		/// 
		/// </summary>
		public void FlexibleSin()
		{
			UInt32 time1 = 0;
			//UInt32 time2 = 0;
			bool quit = false;
			
			// Read and get the flickers positions and parameters
			init_test();

			// Init all the flickers on the foreground 
			for (int j = 0; j < m_listFlickers.Count; j++) {
				CFlicker aFlicker = (CFlicker)m_listFlickers[j];
				SetWindowPos(aFlicker.Handle, HwndTopmost, 0, 0, 0, 0, SDL_SWP_NOMOVE | SDL_SWP_NOSIZE);
			}

			// Init other variable
			int i = 0;
			double lumin = 0.0;
			//double[] alpha = new double[2];
			//UInt32[] color = new UInt32[2];
			UInt32 colorSin = 0;
			Byte rSin = 0; Byte gSin = 0; Byte bSin = 0;
			Byte r1 = 0; Byte g1 = 0; Byte b1 = 0;
			Byte r2 = 0; Byte g2 = 0; Byte b2 = 0;
			
			// Detect framerate of the screen
			double frameRate = getFrameRate();
			
			// Construct a matrix that contains values for all frames (timestep),
			// for all flickers
			FrequenciesMatrix(frameRate);
			
			// Loop for the flickering
			while (!quit && SDL.SDL_GetTicks() < 50000)
			{
				// Loop over every flicker to update them sequentially
				for (int j = 0; j < m_listFlickers.Count; j++)
				{
					CFlicker currentFlicker = (CFlicker)m_listFlickers[j];
					if (i >= frameRate * 240) {
						i = 0;
					}
					lumin = m_matrix[j, i];

					// Lower bound for color
					r1 = currentFlicker.GetRed(currentFlicker.Color1); 
					g1 = currentFlicker.GetGreen(currentFlicker.Color1); 
					b1 = currentFlicker.GetBlue(currentFlicker.Color1);

					// Upper bound for color
					r2 = currentFlicker.GetRed(currentFlicker.Color2); 
					g2 = currentFlicker.GetGreen(currentFlicker.Color2); 
					b2 = currentFlicker.GetBlue(currentFlicker.Color2);
					
					// Update color value following interpolated sin wave
					rSin = (Byte)(r1 * lumin + r2 * (1 - lumin));
					gSin = (Byte)(g1 * lumin + g2 * (1 - lumin));
					bSin = (Byte)(b1 * lumin + b2 * (1 - lumin));
					var screenSurface = Marshal.PtrToStructure<SDL.SDL_Surface>(currentFlicker.Screen.PSurface);
					colorSin = SDL.SDL_MapRGB(screenSurface.format, rSin, gSin, bSin);
					
					// Update transparency value (not necessary
					// double alphaSin = (currentFlicker.Alpha1 * lumin) + (currentFlicker.Alpha2 * (1 - lumin));

					// Put the updated value for color in the flicker
					currentFlicker.FlipColor(colorSin);
					//currentFlicker.flipAlpha(alphaSin);
					//currentFlicker.flip(colorSin, alphaSin);

					// Display the updated flicker
					currentFlicker.Display();
				} 


				time1 = SDL.SDL_GetTicks();
				SDL.SDL_Event evt = new SDL.SDL_Event();
				if (SDL.SDL_PollEvent(out evt) != 0) {
					if (evt.type == SDL.SDL_EventType.SDL_KEYUP && evt.key.keysym.sym == SDL.SDL_Keycode.SDLK_ESCAPE) {
						quit = true;
					}
				}
				i += 1;
			} 
		} 
	}


}
