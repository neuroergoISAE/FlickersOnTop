using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualStimuli;
using System.Threading;


namespace Interface2App
{
	 public class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//using StreamInfo inf = new StreamInfo("TEst")
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			// create stream info and outlet
			//StreamInfo inf = new StreamInfo("Test1", "Markers", 1, 0, channel_format_t.cf_string, "giu4569");
			//StreamOutlet outl = new StreamOutlet(inf);

			
		}
	}
}
