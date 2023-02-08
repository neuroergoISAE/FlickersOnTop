using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using SDL2;
using static SDL2.SDL;

namespace VisualStimuli
{   /// <summary>
    /// <strong>Defined informations:</strong> x, y, width, height, name;
    /// <strong>Functions: </strong>CSreen, show
    /// </summary>
    delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    class CScreen
    {

        /// New imports to be used by User32 to be able to define windows
        /// Use https://www.pinvoke.net/
        const UInt32 CS_VREDRAW = 1;
        const UInt32 CS_HREDRAW = 2;
        const UInt32 COLOR_BACKGROUND = 1;
        const UInt32 IDC_CROSS = 32515;
        const UInt32 WM_DESTROY = 2;
        const UInt32 WM_PAINT = 0x0f;
        const UInt32 WM_LBUTTONDBLCLK = 0x0203;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct WNDCLASSEX
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }
        private static IntPtr myWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                // All GUI painting must be done here
                case WM_PAINT:
                    break;

                case WM_LBUTTONDBLCLK:
                    MessageBox.Show("Doubleclick");
                    break;

                case WM_DESTROY:
                    DestroyWindow(hWnd);

                    //If you want to shutdown the application, call the next function instead of DestroyWindow
                    //PostQuitMessage(0);
                    break;

                default:
                    break;
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }
        private WndProc delegWndProc = myWndProc;

        [DllImport("user32.dll")]
        static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyWindow(IntPtr hWnd);


        [DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowEx")]
        public static extern IntPtr CreateWindowEx(
           int dwExStyle,
           UInt16 regResult,
           //string lpClassName,
           string lpWindowName,
           UInt32 dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClassEx")]
        static extern System.UInt16 RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("user32.dll")]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        static extern bool UnregisterClass([In] string class_name);
        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_COMPOSITED = 0x02000000;
        public const int LWA_ALPHA = 0x00000002;
        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_CLIENTEDGE = 0x00000200;
        public const int GWL_EXSTYLE= -0x14;
        public const uint WS_POPUP = 0x80000000;
        private static WNDCLASSEX wind_class = new WNDCLASSEX();
        private static ushort regResult =0;
        private static IntPtr ParentWindow=IntPtr.Zero;
        private bool IsParent=false;
        // End of imports used by User32 to define windows

        // Attributes (from "struct screen" in Screen.h)
        private IntPtr m_pWindow = IntPtr.Zero; // ex "pWindow"
        private IntPtr m_pRenderer = IntPtr.Zero; // ex "renderer"
        private IntPtr m_pSurface = IntPtr.Zero; // ex "surface"
        private IntPtr m_pTexture = IntPtr.Zero; // ex "texture"
        private IntPtr m_pImage = IntPtr.Zero;// ex "image"
        private IntPtr hwnd = IntPtr.Zero;
        private int m_x = 0;
        private int m_y = 0;
        private int m_w = 0;
        private int m_h = 0;
        private String m_name = ""; // ex "name"

        public IntPtr PWindow { get => m_pWindow; set => m_pWindow = value; }
        public IntPtr PRenderer { get => m_pRenderer; set => m_pRenderer = value; }
        public IntPtr PSurface { get => m_pSurface; set => m_pSurface = value; }
        public IntPtr PTexture { get => m_pTexture; set => m_pTexture = value; }
        public IntPtr PImage { get => m_pImage; set => m_pImage = value; }
        public int X { get => m_x; set => m_x = value; }
        public int Y { get => m_y; set => m_y = value; }
        public int W { get => m_w; set => m_w = value; }
        public int H { get => m_h; set => m_h = value; }
        public string Name { get => m_name; set => m_name = value; }

        /// <summary>
        /// Create a borderless rectangle window on computer screen.
        /// </summary>
        /// <param name="x">The value represents the horizontal position center of the screen.</param>
        /// <param name="y">The value represents the vertical position center of the screen.</param>
        /// <param name="width">The value represents the width of the screen.</param>
        /// <param name="height">The value represents the height of the screen.</param>
        /// <param name="name">The value represents the name of the screen.</param>
        /// <param name="fixedScreen">The value represents the screen is fixed or not.</param>
        public CScreen(int x, int y, int width, int height, String name, bool fixedScreen,Byte r,Byte g, Byte b,string imagepath,IntPtr instance)
        {
            
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            create(x, y, width, height, name, fixedScreen, instance);
            if (imagepath == string.Empty)
            {
                SDL.SDL_SetRenderDrawColor(PRenderer, r, g, b, 255);
                SDL.SDL_RenderClear(PRenderer);
            }
            else
            {
                var m_surface = SDL.SDL_LoadBMP(imagepath);
                var m_texture = SDL.SDL_CreateTextureFromSurface(PRenderer, m_surface);
                SDL.SDL_RenderCopy(PRenderer, m_texture, IntPtr.Zero, IntPtr.Zero);
                SDL.SDL_RenderPresent(PRenderer);
                SDL.SDL_FreeSurface(m_surface);
            }
            SDL.SDL_RenderPresent(PRenderer);
            SDL.SDL_SetWindowBordered(m_pWindow, SDL_bool.SDL_FALSE);
        }

        /// <summary>
        /// Support to function CSreen.
        /// </summary>

        private void create(int x, int y, int width, int height, String name, bool fixedScreen, IntPtr instance)
        {
            /// Legacy code to define windows using SDL DLL
            /// 
            /*if (!fixedScreen)
            {

                m_pWindow = SDL.SDL_CreateWindow(name,
                    x,
                    y,
                    width,
                    height,
                    SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS | SDL.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR);

                if (m_pWindow == IntPtr.Zero)
                {
                    Console.WriteLine("Window could not be created - Level 1 ! SDL_Error: {0}", SDL.SDL_GetError());
                    return;
                }
            }
            else
            {

                m_pWindow = SDL.SDL_CreateWindow(name,
                    x,
                    y,
                    width,
                    height,
                    SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN | SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP | SDL.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR);

                if (m_pWindow == IntPtr.Zero)
                {
                    Console.WriteLine("Window could not be created - Level 2 ! SDL_Error: {0}", SDL.SDL_GetError());
                    return;
                }
            }*/
            /// Windows defined using the User32 DLL (lower level to allow clicks through windows)

            if (regResult == 0)
            {
                wind_class = new WNDCLASSEX
                {
                    cbSize = Marshal.SizeOf(typeof(WNDCLASSEX)),
                    style = (int)(CS_HREDRAW | CS_VREDRAW),
                    hbrBackground = (IntPtr)COLOR_BACKGROUND + 1, //Black background, +1 is necessary
                    cbClsExtra = 0,
                    cbWndExtra = 0,
                    //wind_class.hInstance = instance ;// alternative: Process.GetCurrentProcess().Handle;
                    //wind_class.hInstance = Marshal.GetHINSTANCE(this.GetType().Module);
                    hInstance = GetModuleHandle(null),
                    hIcon = IntPtr.Zero,
                    hCursor = LoadCursor(IntPtr.Zero, (int)IDC_CROSS),
                    lpszMenuName = null,
                    lpszClassName = name,
                    lpfnWndProc = Marshal.GetFunctionPointerForDelegate(delegWndProc),
                    hIconSm = IntPtr.Zero
                };
                regResult = RegisterClassEx(ref wind_class);
                Console.WriteLine(regResult);
                if (regResult == 0)
                {
                    uint error = GetLastError();
                    Console.WriteLine("Error while registering class code: {0}", error);
                }
            }
            if(ParentWindow== IntPtr.Zero) {
                hwnd = CreateWindowEx(WS_EX_COMPOSITED | WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOPMOST, regResult, name, WS_POPUP, x, y, width, height, IntPtr.Zero, IntPtr.Zero, wind_class.hInstance, IntPtr.Zero);
                ParentWindow = hwnd; IsParent = true;
            }
            else
            {
                hwnd = CreateWindowEx(WS_EX_COMPOSITED | WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOPMOST, regResult, name, WS_POPUP, x, y, width, height, ParentWindow, IntPtr.Zero, wind_class.hInstance, IntPtr.Zero);
            }
            // Create a window with capacity to be clicked through: WS_EX_LAYERED and WS_EX_TRANSPARENT together
            /// WS_POPUP make the window borderless
            ShowWindow(hwnd, 1);
            //SetWindowLong(hwnd,GWL_EXSTYLE,0);

            /// Put this new User32 window into SDL instead of the regular m_pWindow from SDL
            m_pWindow = SDL.SDL_CreateWindowFrom(hwnd);
            //SDL.SDL_ShowWindow(m_pWindow);
            
            SDL.SDL_SetWindowOpacity(m_pWindow, 0.0f); //make window invisible before animation
            SDL.SDL_SetRelativeMouseMode(SDL.SDL_bool.SDL_FALSE);

            //removing some event to assure it doesn't get laggy with lots of flickers on top of each other
            SDL_EventState(SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN, SDL_IGNORE);
            SDL_EventState(SDL.SDL_EventType.SDL_MOUSEBUTTONUP, SDL_IGNORE);
            SDL_EventState(SDL.SDL_EventType.SDL_MOUSEMOTION, SDL_IGNORE);
            SDL_EventState(SDL.SDL_EventType.SDL_MOUSEWHEEL, SDL_IGNORE);

            //SDL_SetHint(SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH, "0");
            // the Surface
            m_pSurface = SDL.SDL_GetWindowSurface(m_pWindow);
            if (m_pSurface == IntPtr.Zero)
            {
                Console.WriteLine("Surface could not be created ! SDL_Error: {0}", SDL.SDL_GetError());
                return;
            }

            // the renderer
            //m_pRenderer = SDL.SDL_CreateRenderer(m_pWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
            //                                                          SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            //note: Vsync can cause massive lag when using lots of flickers, moving to manual fps management
            m_pRenderer = SDL.SDL_CreateRenderer(m_pWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            if (m_pRenderer == IntPtr.Zero)
            {
                Console.WriteLine("Renderer could not be created ! SDL_Error: {0}", SDL.SDL_GetError());
                return;
            }
            

            // Attributes
            X = x;
            Y = y;
            W = width;
            H = height;
            Name = name;
        }
        /// <summary>
        /// Display the screen.
        /// </summary>
        public void show(Byte a)
        {
            try
            {
                // With User32, opacity is named a here. Little bit more efficient than SDL_SetWindowOpacity
                SetLayeredWindowAttributes(hwnd, 0, a, LWA_ALPHA);
                /*if (SDL.SDL_SetWindowOpacity(m_pWindow, a/255.0f) != 0) //might be the quickest SDL rendering in the world :)
                {
                    Console.WriteLine("Warning, error while rendering");
                    throw new Exception(SDL_GetError());
                }*/
            }catch(Exception e) { Console.WriteLine(e.ToString()); }
            
            
        }
        /// <summary>
        /// Kill the windows and free up memory properly when leaving
        /// </summary>
        public void Quit()
        {
            if(IsParent) {
                DestroyWindow(hwnd);
                ParentWindow = IntPtr.Zero;
            }
            //SetLayeredWindowAttributes(hwnd, 0, 0, LWA_ALPHA);

            //myWndProc(ParentWindow, WM_DESTROY, IntPtr.Zero, IntPtr.Zero);
            //var b=UnregisterClass(wind_class.lpszClassName);
            //Console.WriteLine("{0} code: {1}",b,GetLastError());
            SDL.SDL_FreeSurface(m_pSurface);
            SDL.SDL_DestroyRenderer(PRenderer);
            SDL.SDL_DestroyWindow(m_pWindow);
        }
    }
} 
