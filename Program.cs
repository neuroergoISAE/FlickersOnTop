using System;
using System.Runtime.InteropServices;
using SDL2;


namespace VisualStimuli
{
    class Program
    {
        static int Main(string[] args)
        {
           
           CPlay oPlay = new CPlay();
            oPlay.flexibleSin();              
            return 0;
        }
    }
}
