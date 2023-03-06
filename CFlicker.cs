using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

		//sequence stuff
		public sequenceValue seq { get; set; }
		public OrderedDictionary sequenceDict { get; set; }
        public int nextTime { get; set; }
		public bool isActive { get; set; }
        

        public double[] Data { get => m_data; set => m_data = value; }
        public static double[] mseq;
        public static int mseqshift = 0;
		//list of primitive polynoms for mseq calculation of different size (taken from scipy module in python)
		private static Dictionary<int,List<int>> tapslist = new Dictionary<int, List<int>>()
			{
				{ 2, new List<int>(){1} }, {3, new List<int>(){2} }, {4, new List<int>(){3} }, {5, new List<int>(){3} }, {6, new List<int>(){5} }, {7, new List<int>(){6} }, {8, new List<int>(){7, 6, 1 }},
				{ 9, new List<int>(){5} }, {10, new List<int>(){7} }, {11, new List<int>(){9} }, {12, new List<int>(){11, 10, 4 } },{ 13, new List<int>(){12, 11, 8 } },
				{ 14, new List<int>(){13, 12, 2 } },{ 15, new List<int>(){14} },{ 16, new List<int>(){15, 13, 4 } },{ 17, new List<int>(){14} },
				{ 18, new List<int>(){11} },{ 19, new List<int>(){18, 17, 14 } },{ 20, new List<int>(){17} },{ 21, new List<int>(){19} },{ 22, new List<int>(){21} },
				{ 23, new List<int>(){18} },{ 24, new List<int>(){23, 22, 17 } },{ 25, new List<int>(){22} },{ 26, new List<int>(){25, 24, 20 } },
				{ 27, new List<int>(){26, 25, 22 } },{ 28, new List<int>(){25} },{ 29, new List<int>(){27} },{ 30, new List<int>(){29, 28, 7 } },
				{ 31, new List<int>(){28} },{ 32, new List<int>(){31, 30, 10 } }
			};
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

		public CFlicker(string n,int x,int y,int width,int height,CScreen screen, Color col1, double freq, int alph1, int alph2, double phase, int typeFreq)
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
			isActive= true;
			//if (seq.Length > 0) { nextTime = 0; if (nextTime != 0) { isActive = false; } Console.WriteLine("seq lenght: {0}\n nextTime: {1}",seq.Length,nextTime); }
			double frameRate = GetFrameRate();
			while (Frequency > frameRate)
			{
				Frequency = frameRate; //a frequency higher than the frameRate is useless and takes more ressource
			}
            setData();
            SDL.SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();			
			SDL.SDL_VERSION(out info.version);
			SDL.SDL_bool bRes = SDL.SDL_GetWindowWMInfo(Screen.PWindow, ref info);
			Handle = info.info.win.window;
			index = 0;

			Console.WriteLine("	\n");
			Console.WriteLine("Flicker {0} created - Position \tX = {1}\tY = {2}\tWidth = {3}\tHeight = {4} pixels", Screen.Name,Screen.X, Screen.Y,Screen.W, Screen.H);
			
            //CreateAtlas();
        }
        public CFlicker(string n, int x, int y, int width, int height, CScreen screen, Color col1, double freq, int alph1, int alph2, double phase, int typeFreq, sequenceValue seq)
		{
			new CFlicker(n,x,y,width,height,screen,col1,freq,alph1,alph2,phase,typeFreq);
            this.seq = seq;
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
			Console.WriteLine(Data.Length);
			if (index >= Data.Length)
			{
				index = 0;
			}
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
		private static double[] create_mseq(int bits_length, int length)
		{
			var Taps = tapslist[bits_length];
			//number of possible code with bits_length
			var nseed = 2 ^ bits_length;
			var state = new List<int>();
			var out_mseq = new double[length];
			var r = new Random();
			//Linear feedback shift registers function
			double[] lfsr(List<int> seed)
			{
				var seed_copy = new List<int>();
				for (int i = 0; i < length; i++)
				{
					out_mseq[i] = seed[0];
					var feedback = out_mseq[i];
					foreach (int tap in Taps)
					{
						feedback = (int)feedback ^ seed[tap];
					}
					//roll seed value backward by 1
					seed_copy.Clear();
					for (int j = 0; j < seed.Count; j++)
					{
						seed_copy.Add(seed[(j + 1) % seed.Count]);
					}
					seed = new List<int>(seed_copy);
					//add feedback in the seed
					seed[seed.Count - 1] = (int)feedback;
				}
				return out_mseq;
			}
			//create a random seed
			for(int f = 0; f < bits_length; f++)
			{
				state.Add(r.Next(0, 1));
			}
			//force at least one value to be a "1". a full zero seed is useless
			state[r.Next(0, state.Count - 1)] = 1;

			//choose a seed and throw it in the feedback loop
			out_mseq = lfsr(state);
			mseq = out_mseq;
			return out_mseq;

			

			
		}
		private static double[] create_mseq(int size)
		{
			if (mseq == null)
			{
				int bitl=(int)Math.Ceiling(Math.Log(size+1,2));

				return create_mseq(bitl, size);
			}
			else
			{
				var mseq_copy = new double[size];
				for (int j = 0; j< mseq.Length; j++)
				{
					mseq_copy[j]=(mseq[(j + mseqshift) % mseq.Count()]);
				}
				mseqshift = (mseqshift + 3) % mseq.Count();
				return mseq_copy;
			}
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
				// So data we will set here have form: s[k + 8] = s[k + 7] + s[k + 2] + s[k + 1] + s[k]
				// LFSR is Linear feedback shift registers 
				// We initialyze 8 first random numbers (because of MLS is pseudorandom frequence)
				/*Data[0] = rand.Next(0, 1);
				Data[1] = rand.Next(0, 1);
				Data[2] = rand.Next(0, 1);
				Data[3] = rand.Next(0, 1);
				Data[4] = rand.Next(0, 1);
				Data[5] = rand.Next(0, 1);
				Data[6] = rand.Next(0, 1);
				Data[7] = rand.Next(0, 1);
				for (int j = 0;j < size - 8 ; j++)
				{
					Data[j + 8] = (Data[j + 7] + Data[j + 2] + Data[j + 1] + Data[j]) % 2;

				}*/

				Data = create_mseq(size);
				Console.WriteLine(Data);
				 
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
		public sequenceValue currentSeq()
		{
            return (sequenceValue)getSeq(sequenceDict.Count - 1).Key;
        }
		public sequenceValue nextSeq(double time)
		{
			sequenceValue newSeq;
			var current = currentSeq();
			if (sequenceDict.Count== 0) { newSeq = seq; }
			else
			{
				if (current.contained_sequence.Count > 0)
				{
					newSeq = current.contained_sequence[0];
				}
				else
				{
					
					var parent = (sequenceValue)getSeq(sequenceDict.Count - 2).Key;
					var indexSeq = parent.contained_sequence.FindIndex(a => a.contained_sequence.Contains(current));
                    sequenceDict.Remove(current);
                    // start by checking if we are at the end of the list
                    if (indexSeq == parent.contained_sequence.Count - 1)
					{
						//check recursively if we are at the end of the parent list, parent parent list....
                        while (indexSeq == parent.contained_sequence.Count - 1 && indexSeq != -1 && sequenceDict.Count > 1)
                        {
                            current = parent;
                            if (current == seq)
                            {
                                newSeq = seq;
                                break;
                            }
                            parent = (sequenceValue)getSeq(sequenceDict.Count - 2).Key;
                            indexSeq = parent.contained_sequence.FindIndex(a => a.contained_sequence.Contains(current));
                        }
						newSeq = parent.contained_sequence[indexSeq + 1];
                    }
					else
					{
						newSeq = parent.contained_sequence[indexSeq + 1];
					}
                   
                }
			}
			//add to dictionnary
			if (newSeq.cond == sequenceValue.CondType.Time)
			{
				sequenceDict.Add(newSeq, time);
			}
			else
			{
				if (newSeq.cond == sequenceValue.CondType.KeyPress)
				{
                    sequenceDict.Add(newSeq, newSeq.value);
				}
				else
				{
                    sequenceDict.Add(newSeq, 0.0);
                }
			}
			//if type is a container then jump to next sequence
			/*if (newSeq.Type==sequenceValue.type.Block || newSeq.Type == sequenceValue.type.Loop)
			{
				return nextSeq(time);
			}
			else
			{
                return newSeq;
            }*/
			return newSeq;
			
		}
		public void skipTo(sequenceValue seq,double time)
		{
			var current = currentSeq();
			while(current != seq)
			{
				current = nextSeq(time);
			}
		}
		public DictionaryEntry getSeq(int indexDict)
		{
			return sequenceDict.Cast<DictionaryEntry>().ElementAt(indexDict);

        }
		public void Destroy()
		{
			Screen.Quit();
		}
	}
    public class sequenceValue
    {
        public type Type;
        public List<sequenceValue> contained_sequence = new List<sequenceValue>();
        public CondType cond;
        public double value;
        public enum type
        {
            Block,
            Loop,
            Active,
            Inactive
        }
        public enum CondType
        {
            KeyPress = 0,
            Time = 0,
            Always = 1,
            Never = 0,
            None
        }
        public sequenceValue(type t, CondType c)
        {
            Type = t;
            cond = c;
            value = 0;
        }
        public sequenceValue(type t, CondType c, double v)
        {
            Type = t;
            cond = c;
            value = v;
        }
        public sequenceValue addSeq(int pos, sequenceValue seq)
        {
            contained_sequence.Insert(pos, seq);
            return seq;
        }
        public sequenceValue addSeq(sequenceValue seq)
        {
            contained_sequence.Add(seq);
			return seq;

        }
        public sequenceValue addSeq(type t, CondType c)
        {
            var seq = new sequenceValue(t, c);
            addSeq(seq);
            return seq;
        }
        public sequenceValue addSeq(int pos, type t, CondType c)
        {
            var seq = new sequenceValue(t, c);
            addSeq(pos, seq);
            return seq;
        }
        public sequenceValue addSeq(int pos, type t, CondType c, double v)
        {
            return addSeq(pos, new sequenceValue(t, c, v));
        }
        public sequenceValue addSeq(type t, CondType c, double v)
        {
            return addSeq(new sequenceValue(t, c, v));
        }
        public void removeSeq(int pos)
        {
			contained_sequence.RemoveAt(pos);

        }
        public override String ToString()
        {
            return Type.ToString() + ":[" + contained_sequence.ToString() + "]\n" + cond.ToString() + ":" + value + "\n";
        }
        public sequenceValue GetSequence(int pos) { return contained_sequence[pos]; }
    }
}






