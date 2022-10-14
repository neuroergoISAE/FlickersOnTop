using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using LSL;
 

namespace VisualStimuli
{
	public class CPlay
	{
		ArrayList m_listFlickers = new ArrayList();
		//double[,] m_matrix;

		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
		public const UInt32 SWP_NOSIZE = 0x0001;
		public const UInt32 SWP_NOMOVE = 0x0002;
		public const UInt32 SWP_SHOWWINDOW = 0x0040;

		[DllImport("user32.dll")]
		public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);


		/// https://csharp.hotexamples.com/site/file?hash=0x238a44f2ed8da632e4e090af60159d66126fa38d9fd574bee99939a492be5ee7&fullName=KernelAPI.cs&project=ozeppi/mAgicAnime
		[StructLayout(LayoutKind.Sequential)]
		public struct DEVMODE
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
		/// Read a txt file to file with flickers information.
		/// </summary>
		/// <param name="filePath">Path to the txt file.</param>
		/// <param name="matrix">Empty matrix to be filled.</param>
		/// <returns> A matrix that contains the flickers information</returns>
		public static void Read_File(string filePath, int[,] matrix)
		{
			
			int i = 0;
			
			try
			{
				StreamReader reader = new StreamReader(filePath);
				
					string line;
				line = reader.ReadLine();
				
				
				while (line != null) { 
					
					string [] parts = line.Split(' ');
					for (int j = 0; j < parts.Length; j++) {
					
							matrix[i, j] = int.Parse(parts[j]);
						
					}
					i++;
					line = reader.ReadLine();
				}
				
				reader.Close();
				
			}
			catch (Exception ex)
			{
				Console.WriteLine("The file could not be readed");
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Temporary function to initialize flickers
		/// </summary>
		/// <returns>None</returns>
		public void init_test()
		{
			
			Console.WriteLine("The one that got away - Katy Perry \n");

			int numFlicker = 0;

			// string filePath = "D:\\MANIPS\\FlickersOnTop\\test1_file.txt";// change here ***
			
			string filePath = Application.StartupPath;
			filePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
			filePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
			filePath += "\\test1_file.txt";

			//string filePath = "test_file.txt";

			StreamReader reader = new StreamReader (filePath);
			string line = reader.ReadLine();
			while(line!= null)
			{
				numFlicker++;
				line = reader.ReadLine();
			}
			reader.Close ();
			Console.WriteLine("Number of Flicker:" + numFlicker);
			int[,] pMatrix = new int[numFlicker,11];// matrix  flickers and 11 defined infomations

			Read_File(filePath, pMatrix);


			//byte red1 = Convert.ToByte(pMatrix[0, 8]);
			//byte green1 = Convert.ToByte(pMatrix[0, 9]);
			//byte bleu1 = Convert.ToByte(pMatrix[0, 10]);
			CScreen[] screen = new CScreen[numFlicker]; 
			CFlicker[] flicker = new CFlicker[numFlicker];
			for (int i = 0; i < numFlicker; i++)
			{

				screen[i] = new CScreen(pMatrix[i, 0], pMatrix[i, 1], pMatrix[i, 2], pMatrix[i, 3], i.ToString(), false) ;
					var screenSurface1 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen[i].PSurface);
					 flicker[i] = new CFlicker(screen[i],
						SDL.SDL_MapRGB(screenSurface1.format, 0, 0, 0), // color1 RGB
						SDL.SDL_MapRGB(screenSurface1.format, 255, 255, 255), // color2 RGB
						pMatrix[i, 4], // freq`
						(double)pMatrix[i, 6]/100, // alpha1
						(double)pMatrix[i, 6] /100, // alpha2
						pMatrix[i, 5],  // phase
						pMatrix[i, 7]); // type frequence

					m_listFlickers.Add(flicker[i]);
				
			}
		}
		/// <summary>
		/// Get refresh rate of the screen
		/// </summary>
		/// <returns>Refresh rate of the screen</returns>
		public double getFrameRate()
		{
			DEVMODE devMode = new DEVMODE();
			devMode.dmSize = (short)Marshal.SizeOf(devMode);
			devMode.dmDriverExtra = 0;
			EnumDisplaySettings(null, -1, ref devMode);
			return (double)devMode.dmDisplayFrequency;
		}
		
		/// <summary>
		/// Generating the flickers on the screen, according to the parameters of the .txt file
		/// </summary>
		/// <returns>None</returns>
		public void flexibleSin()
		{
			bool quit = false;

			init_test();

			// create stream info and outlet
            StreamInfo inf = new StreamInfo("flickers_info", "Markers", 1, 0.1, channel_format_t.cf_string , "giu4h5600");
            StreamOutlet outl = new StreamOutlet(inf);
			string[] marker_info = new string[2];

			// All the flickers foreground 
			for (int j = 0; j < m_listFlickers.Count; j++) {
				CFlicker aFlicker = (CFlicker)m_listFlickers[j];
				SetWindowPos(aFlicker.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
			}

			// init vars
			int i = 0;
			double lumin = 0.0;
			double[] alpha = new double[2];
			UInt32[] color = new UInt32[2];
			UInt32 colorSin = 0;
			Byte rSin = 0; Byte gSin = 0; Byte bSin = 0;
			Byte r1 = 0; Byte g1 = 0; Byte b1 = 0;
			Byte r2 = 0; Byte g2 = 0; Byte b2 = 0;

			double frameRate = getFrameRate();


			for (int j = 0; j < m_listFlickers.Count; j++)
			{
				// Current flicker frequency
				CFlicker currentFlicker = (CFlicker)m_listFlickers[j];
				marker_info[0] = currentFlicker.Frequence.ToString(); 
				marker_info[1] = currentFlicker.Phase.ToString();

				// Push the marker in LSL that the flicker will flicker now
				//outl.push_sample(string.Join("_", marker_info));
				outl.push_sample(marker_info);
			}

			while (!quit && SDL.SDL_GetTicks() < 1000000)
			{
				for (int j = 0; j < m_listFlickers.Count; j++)
				{
					CFlicker currentFlicker = (CFlicker)m_listFlickers[j];

					currentFlicker.setData(currentFlicker);

					if (i >= frameRate)
					{
						i = 0;
					}

					lumin = currentFlicker.getData(i, currentFlicker.Data);
					//Console.Write(lumin+ " ");
					// col1
					r1 = currentFlicker.getRed(currentFlicker.Color1);
					g1 = currentFlicker.getGreen(currentFlicker.Color1);
					b1 = currentFlicker.getBlue(currentFlicker.Color1);

					// col2
					r2 = currentFlicker.getRed(currentFlicker.Color2);
					g2 = currentFlicker.getGreen(currentFlicker.Color2);
					b2 = currentFlicker.getBlue(currentFlicker.Color2);

					// interpollation sin waves

					// col sin
					rSin = (Byte)(r1 * lumin + r2 * (1 - lumin));
					gSin = (Byte)(g1 * lumin + g2 * (1 - lumin));
					bSin = (Byte)(b1 * lumin + b2 * (1 - lumin));

					var screenSurface = Marshal.PtrToStructure<SDL.SDL_Surface>(currentFlicker.Screen.PSurface);

					colorSin = SDL.SDL_MapRGB(screenSurface.format, rSin, gSin, bSin);

					// alpha sin
					double alphaSin = (currentFlicker.Alpha1 * lumin) + (currentFlicker.Alpha2 * (1 - lumin));

					// flip
					currentFlicker.flip(colorSin, alphaSin);

					// dislay
					currentFlicker.display();
				}

				
				SDL.SDL_Event evt = new SDL.SDL_Event();
				if (SDL.SDL_PollEvent(out evt) != 0)
				{
					if (evt.type == SDL.SDL_EventType.SDL_KEYUP && evt.key.keysym.sym == SDL.SDL_Keycode.SDLK_ESCAPE)
					{
						quit = true;
					}
					else
					{
						quit = false;
					}
				}

				i += 1;

			}
		
		}
		public void Close()
		{
			Environment.Exit(0);
		}

		public int resX = Screen.PrimaryScreen.Bounds.Width;
		public int resY = Screen.PrimaryScreen.Bounds.Height;
		/// <summary>
		/// Make a chossen image flicks in the center of the screen with size 400x400
		/// </summary>
		/// <returns>None</returns>
		public void ImageFlicker() 
		{
			
		string filepath = "F:\\MANIPS\\FlickersOnTop\\image_file.txt";

			StreamReader reader = new StreamReader(filepath);
			string imagefile = reader.ReadToEnd();
			Console.WriteLine(imagefile);

			int i = 0;
			double time = 50; // in seconds

			double frameRate = getFrameRate();

			

			int N = (int)(time * frameRate); // number of flickerings 
			Console.WriteLine("time x frameRate = " + N);

			init_test();

			// initialize 
			Console.WriteLine("Number of flicker: " + m_listFlickers.Count);
			CFlicker currentFlicker = (CFlicker)m_listFlickers[0];///

			currentFlicker.setData(currentFlicker);
			

			IntPtr m_window = IntPtr.Zero;
			IntPtr m_render = IntPtr.Zero;
			IntPtr m_texture = IntPtr.Zero;
			IntPtr m_surface = IntPtr.Zero;

			if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
			{

				Console.WriteLine("Unable to initialize SDL.Error: {0}", SDL.SDL_GetError());

			}
			else
			{
				
				m_window = SDL.SDL_CreateWindow("Image", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, resX,resY,
												SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS);
				if(m_window == IntPtr.Zero)
				{
					Console.WriteLine("Enable to create a window: Error {0}", SDL.SDL_GetError());
				}

				m_render = SDL.SDL_CreateRenderer(m_window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

				m_surface = SDL.SDL_LoadBMP(imagefile); // ***** file

				if (m_surface == IntPtr.Zero)
				{
					Console.WriteLine("Enable to create a surface of image: Error {0}", SDL.SDL_GetError());
				}
				m_texture = SDL.SDL_CreateTextureFromSurface(m_render, m_surface);

				//Initialize the opacity from table 
				float[] opacity = new float[(int)frameRate];
				for(int j = 0; j < frameRate; j++)
				{
					opacity[j] = (float)currentFlicker.getData(j, currentFlicker.Data);
					Console.Write(opacity[j] + " ");
				}
				
				while (SDL.SDL_GetTicks() < 10000)
				{
					if(i > (int)frameRate - 1 )
						{
							i = 0;
						}

					SDL.SDL_SetWindowOpacity(m_window, opacity[i]);
					SDL.SDL_RenderClear(m_render);
					SDL.SDL_RenderCopy(m_render, m_texture, IntPtr.Zero, IntPtr.Zero);
					SDL.SDL_RenderPresent(m_render);
					i++;
				}

			}

			SDL.SDL_DestroyTexture(m_texture);
			SDL.SDL_FreeSurface(m_surface);
			SDL.SDL_DestroyRenderer(m_render);
			SDL.SDL_DestroyWindow(m_window);
			SDL.SDL_Quit();
		}
	}

}


