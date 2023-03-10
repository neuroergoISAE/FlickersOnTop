
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

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
		[Range(0, 360)]
		public double Phase { get; set; }
		[Required, RegularExpression(@"^.*[0-9]", ErrorMessage = "Please enter a number")]
		[Range(0, 100)]
		public int Opacity_Min { get; set; }
		public int Opacity_Max { get; set; }
		public Signal_Type Type { get; set; }
        public System.Windows.Media.Color color1 { get; set; }
        public string image { get; set; }
		public bool IsImageFlicker { get; set; } 
		public sequenceValue sequence { get; set; }



        public enum Signal_Type
		{
			Sine=1,
			Root_Square=3,
			Square=2,
			Random=0,
			Maximum_Lenght_Sequence=4,
			None=5
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
			Phase = 0;
			sequence = new sequenceValue(sequenceValue.type.Block, sequenceValue.CondType.Never);
            sequence.addSeq(new sequenceValue(sequenceValue.type.Active, sequenceValue.CondType.Never));
        }
		/// <summary>
		/// custom flicker with parameters
		/// </summary>
		/// <param name="X"></param>
		/// <param name="Y"></param>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		/// <param name="c"></param>
        public Flicker(String name,int X,int Y,int Width,int Height,System.Windows.Media.Color c,int op_min,int op_max,double freq,double phase,int type,sequenceValue seq)
        {
            Name = name;
            Opacity_Min = op_min;
            Opacity_Max = op_max;
            Type = (Signal_Type)type;
			color1 = c;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            IsImageFlicker = false;
            image = String.Empty;
            Frequency = freq;
			Phase=phase;
			sequence = seq;
        }
        //Other construction method
		public Flicker(int X, int Y, int Width, int Height, System.Windows.Media.Color c, int op_min, int op_max, double freq, double phase, int type) : this("Flicker", X, Y, Width, Height, c, op_min, op_max, freq, phase, type, new sequenceValue(sequenceValue.type.Block, sequenceValue.CondType.Never).addSeq(new sequenceValue(sequenceValue.type.Active, sequenceValue.CondType.Never)))
        {
        }
        public Flicker(string name,int X, int Y, int Width, int Height, System.Windows.Media.Color c, int op_min, int op_max, double freq, double phase, int type) :this(name, X, Y, Width, Height, c, op_min, op_max, freq, phase, type, new sequenceValue(sequenceValue.type.Block, sequenceValue.CondType.Never).addSeq(new sequenceValue(sequenceValue.type.Active, sequenceValue.CondType.Never)))
        {
        }
        public Flicker(int X, int Y, int Width, int Height, System.Windows.Media.Color c, int op_min, int op_max, double freq, double phase, int type,sequenceValue seq): this("Flicker", X, Y, Width, Height, c, op_min, op_max, freq, phase, type, seq)
        {
            
        }
        /// <summary>
        /// copy a flicker
        /// </summary>
        /// <param name="f"></param>
        public Flicker(Flicker f) : this(f.Name, f.X, f.Y, f.Width, f.Height, f.color1, f.Opacity_Min, f.Opacity_Max, f.Frequency, f.Phase, (int)f.Type,f.sequence)
		{
			
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
            KeyPress = 2,
            Time = 3,
            Always = 1,
            Never = 0,
            None
        }
        private sequenceValue()
        {
            Type = type.Block;
            cond = CondType.Always;
            value = 0.0;
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
            return this;
        }
        public sequenceValue addSeq(sequenceValue seq)
        {
            contained_sequence.Add(seq);
            return this;

        }
        public sequenceValue addSeq(type t, CondType c)
        {
            var seq = new sequenceValue(t, c);
            addSeq(seq);
            return this;
        }
        public sequenceValue addSeq(int pos, type t, CondType c)
        {
            var seq = new sequenceValue(t, c);
            addSeq(pos, seq);
            return this;
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
        public void removeSeq(sequenceValue seq)
        {
            contained_sequence.Remove(seq);
        }
        public override String ToString()
        {
            return Type.ToString() + ":[" + contained_sequence.ToString() + "]\n" + cond.ToString() + ":" + value + "\n";
        }
        public sequenceValue GetSequence(int pos) { return contained_sequence[pos]; }
    }
}