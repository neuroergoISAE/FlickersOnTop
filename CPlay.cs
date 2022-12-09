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
using System.Xml;
using System.Globalization;
using System.Drawing;
using System.IO.Ports;

namespace VisualStimuli
{
	public class CPlay
	{
		ArrayList m_listFlickers = new ArrayList();
		string filepath;
		public CPlay(string filepath)
		{
			this.filepath = filepath;
		}
		StreamOutlet outl;

        public CPlay()
		{
            filepath = Application.StartupPath;
            filepath = filepath.Substring(0, filepath.LastIndexOf('\\'));
            filepath = filepath.Substring(0, filepath.LastIndexOf('\\'));
            // create stream info and outlet
            StreamInfo inf = new StreamInfo("flickers_info", "Markers", 1, 0, channel_format_t.cf_string, "giu4h5600");
            outl = new StreamOutlet(inf);
        }

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
        public enum Signal_Type
        {
            Sinuous = 1,
            Root_Square = 3,
            Square = 2,
            Random = 0,
            Maximum_Lenght_Sequence = 4
        };

        /// <summary>
        /// Read a xml file and add the flickers to the list of active flickers.
        /// </summary>
        /// <param name="filePath">Path to the txt file.</param>
        public void Read_File(string filePath)
		{
			try {
				// Load the XML file into memory
				XmlDocument doc = new XmlDocument();
				doc.Load(filePath);

				// Get the root element of the document
				XmlElement root = doc.DocumentElement;


				// Iterate over the child elements of the root
				foreach (XmlNode node in root.ChildNodes)
				{
					int pos_x, pos_y, width, height;
					int.TryParse(node.SelectSingleNode("X").InnerText, out pos_x);
					int.TryParse(node.SelectSingleNode("Y").InnerText, out pos_y);
					int.TryParse(node.SelectSingleNode("Width").InnerText, out width);
					int.TryParse(node.SelectSingleNode("Height").InnerText, out height);
					Signal_Type type;
					Enum.TryParse<Signal_Type>(node.SelectSingleNode("Type").InnerText, out type);
					string name = node.SelectSingleNode("Name").InnerText;
					double freq, phase;
					double.TryParse(node.SelectSingleNode("Frequency").InnerText, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out freq);
					double.TryParse(node.SelectSingleNode("Phase").InnerText, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out phase);
					var C1Node = node.SelectSingleNode("color1");
					var C2Node = node.SelectSingleNode("color2");
					Byte r1, g1, b1;
					int a1, a2;
					Byte.TryParse(C1Node.SelectSingleNode("R").InnerText, out r1);
					Byte.TryParse(C1Node.SelectSingleNode("G").InnerText, out g1);
					Byte.TryParse(C1Node.SelectSingleNode("B").InnerText, out b1);
                    int.TryParse(node.SelectSingleNode("Opacity_Min").InnerText, out a1);
                    int.TryParse(node.SelectSingleNode("Opacity_Max").InnerText, out a2);

                    //create a window and a the flickers to the list of flickers
                    CScreen screen = new CScreen(pos_x, pos_y, width, height, name, false,r1,g1,b1);
					var screenSurface1 = Marshal.PtrToStructure<SDL.SDL_Surface>(screen.PSurface);
					m_listFlickers.Add(new CFlicker(
						pos_x,
						pos_y,
						width,
						height,
						screen,
					   Color.FromArgb(255, r1, g1, b1), // color1 RGB
					   freq,
					   a1 *2.55, // alpha1
					   a2*2.55, // alpha2
					   phase,
					   (int)type)); // type frequence);
				}
				Console.WriteLine("Created {0} Flickers", m_listFlickers.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
        }

		/// <summary>
		/// Temporary function to initialize flickers
		/// </summary>
		/// <returns>None</returns>
		public void init_test()
		{
			Read_File(filepath+"\\Flickers.xml");
		}
		/// <summary>
		/// Get refresh rate of the screen
		/// </summary>
		/// <returns>Refresh rate of the screen</returns>
		public static double getFrameRate()
		{
			DEVMODE devMode = new DEVMODE();
			devMode.dmSize = (short)Marshal.SizeOf(devMode);
			devMode.dmDriverExtra = 0;
			EnumDisplaySettings(null, -1, ref devMode);
			return (double)devMode.dmDisplayFrequency;
		}
        private static double frameRate = getFrameRate();
        /// <summary>
        /// Generating the flickers on the screen, according to the parameters of the .txt file
        /// </summary>
        /// <returns>None</returns>
        public void flexibleSin()
		{
			bool quit = false;

			init_test();
			string[] marker_info = new string[4];

			// All the flickers foreground 
			for (int j = 0; j < m_listFlickers.Count; j++) {
				CFlicker aFlicker = (CFlicker)m_listFlickers[j];
				SetWindowPos(aFlicker.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
			}

			// init vars
			Console.WriteLine(frameRate.ToString());


			for (int j = 0; j < m_listFlickers.Count; j++)
			{
				// Send into LSL the ID,frequency,phase and amplitude of the flickers
				CFlicker currentFlicker = (CFlicker)m_listFlickers[j];
				marker_info[0] = j.ToString();
				marker_info[1] = currentFlicker.Frequency.ToString(); 
				marker_info[2] = currentFlicker.Phase.ToString();
				marker_info[3] = ((Math.Abs(currentFlicker.Alpha2-currentFlicker.Alpha1)).ToString());

                // Push the marker in LSL that the flicker will flicker now
                outl.push_sample(marker_info);
            }
            
            var frame = 0;
            //var watchTotal = System.Diagnostics.Stopwatch.StartNew();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (!quit && SDL.SDL_GetTicks() < 1000000)
			{
				frame += 1;
                
				//parallel treatment for each flickers
				//flickers are still synchronized, only parallelized during 1 frame.
				Parallel.ForEach<CFlicker>(m_listFlickers.Cast<CFlicker>(), c =>
				{
					if (c.index >= c.size) { c.index = 0; }
					c.display();
					c.index += 1;
				}
				);
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
				Console.WriteLine("frame {0}", frame);
				var left = (1 / frameRate)*frame - watch.ElapsedTicks/10000000d;
                if (left>0) { Thread.Sleep((int)(left*1000)); } else { Console.WriteLine("Warning Rendering can't keep up!! max FPS: {0}",frame*10000000d/watch.ElapsedTicks); }
            }
            //watchTotal.Stop();
            //Console.WriteLine("total time: {0}\n mean fps: {1}",watchTotal.ElapsedTicks/10000d,frame/(watchTotal.ElapsedTicks / 10000000d));
            
			//Kill all Flickers Windows
			Parallel.ForEach<CFlicker>(m_listFlickers.Cast<CFlicker>(), c =>
            {
                c.Destroy();
            });
			SDL.SDL_Quit();
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

			int N = (int)(time * frameRate); // number of flickerings 
			Console.WriteLine("time x frameRate = " + N);

			init_test();

			// initialize 
			Console.WriteLine("Number of flicker: " + m_listFlickers.Count);
			CFlicker currentFlicker = (CFlicker)m_listFlickers[0];///
			

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
				
				m_window = SDL.SDL_CreateWindow("Image", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 600,400,
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


