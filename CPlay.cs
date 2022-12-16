using System;
using System.Linq;
using System.Threading.Tasks;
using SDL2;
using System.Runtime.InteropServices;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using LSL;
using System.Xml;
using System.Globalization;
using System.Drawing;

namespace VisualStimuli
{
	public class CPlay
	{
		ArrayList m_listFlickers = new ArrayList();
		string filepath; //indicate the environment path
		public CPlay(string filepath)
		{
			this.filepath = filepath;
		}
		StreamOutlet outl;

        public CPlay()
		{
			//lookup the position of the Application
            filepath = Application.StartupPath;
            //filepath = filepath.Substring(0, filepath.LastIndexOf('\\'));
            //filepath = filepath.Substring(0, filepath.LastIndexOf('\\'));
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
        public enum Signal_Type //enum for reading the xml file
        {
            Sine = 1,
            Root_Square = 3,
            Square = 2,
            Random = 0,
            Maximum_Lenght_Sequence = 4
        };

        /// <summary>
        /// Read a Xml file and add the flickers to the list of active flickers.
        /// </summary>
        /// <param name="filePath">Path to the xml file.</param>
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
					string image = string.Empty;
					bool IsImage;
                    bool.TryParse(node.SelectSingleNode("IsImageFlicker").InnerText, out IsImage);
					if(IsImage)
					{
						image= node.SelectSingleNode("image").InnerText;
                    }
                    

                    //create a window and a the flickers to the list of flickers
                    CScreen screen = new CScreen(pos_x, pos_y, width, height, name, false,r1,g1,b1,image);
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
					   (int)type) // type frequence
					);
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
		/// Initiate Flickers
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
        /// Animate the flickers from the .xml file
        /// </summary>
        /// <returns>None</returns>
        public void Animate_Flicker()
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
            
            long frame = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew(); //watch for fps syncing
			int lost_frame = 0; //only used if computer is too slow to display all frames, we will jump over some frames
			long frame_ticks =(long) ((1d / frameRate) * 10000000d);
            SDL.SDL_Event evt = new SDL.SDL_Event();
            while (!quit && SDL.SDL_GetTicks() < 1000000)
			{
				frame += 1;
                var watchFPSMax=System.Diagnostics.Stopwatch.StartNew();
				//parallel treatment for each flickers
				//flickers are still synchronized, only parallelized during 1 frame.
				Parallel.ForEach<CFlicker>(m_listFlickers.Cast<CFlicker>(), c =>
				{
					if (c.index >= c.size) { c.index = 0; }
					c.display();
					c.index += 1+lost_frame;
				}
				);
				watchFPSMax.Stop();
                
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
				var left = frame_ticks*frame - watch.ElapsedTicks;
                //Console.WriteLine("frame {0}: watch {1} ms left: {2} ms\nEstimated FPS: {3}\nEstimated Max Fps: {4}", frame,watch.ElapsedTicks/10000d,left/10000d,frame*1000/watch.ElapsedMilliseconds,10000000d/watchFPSMax.ElapsedTicks);
                if (left>0L) { 
					Thread.Sleep((int)(left/10000d));
					lost_frame= 0;
				} 
				else 
				{ 
					//Console.WriteLine("Warning Rendering can't keep up!! max FPS: {0}",frame*10000000d/watch.ElapsedTicks);
                    //left= Math.Abs(left);
                    //lost_frame = Convert.ToInt32(left / frame_ticks)+1;
                    //left -= (lost_frame-1) * frame_ticks;
                }
            }
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
	}

}


