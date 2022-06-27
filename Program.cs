using System;
using System.Runtime.InteropServices;
using SDL2;

using System.Windows.Forms;


namespace VisualStimuli
{
    class Program
    {
        static int Main(string[] args)
        {

           // Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());
            
            CPlay oPlay = new CPlay();
            oPlay.flexibleSin();
            //oPlay.ImageFlicker();
            return 0;
        }
    }
}
