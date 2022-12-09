using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SDL2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VisualStimuli
{   /// <summary>
    /// <strong>Defined informations:</strong> x, y, width, height, name;
    /// <strong>Functions: </strong>CSreen, show
    /// </summary>
    class CScreen
    {
        // Attributes (from "struct screen" in Screen.h)
        private IntPtr m_pWindow = IntPtr.Zero; // ex "pWindow"
        private IntPtr m_pRenderer = IntPtr.Zero; // ex "renderer"
        private IntPtr m_pSurface = IntPtr.Zero; // ex "surface"
        private IntPtr m_pTexture = IntPtr.Zero; // ex "texture"
        private IntPtr m_pImage = IntPtr.Zero;// ex "image"
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
        public CScreen(int x, int y, int width, int height, String name, bool fixedScreen,Byte r,Byte g, Byte b)
        {
            create(x, y, width, height, name, fixedScreen);
            SDL.SDL_RenderClear(PRenderer);
            SDL.SDL_SetRenderDrawColor(PRenderer, r, g, b, 255);
            SDL.SDL_RenderFillRect(PRenderer, IntPtr.Zero);
        }

        /// <summary>
        /// Support to function CSreen.
        /// </summary>

        private void create(int x, int y, int width, int height, String name, bool fixedScreen)
        {
            if (!fixedScreen)
            {

                m_pWindow = SDL.SDL_CreateWindow(name,
                    x,
                    y,
                    width,
                    height,
                    SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS);

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
                    SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN | SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP);

                if (m_pWindow == IntPtr.Zero)
                {
                    Console.WriteLine("Window could not be created - Level 2 ! SDL_Error: {0}", SDL.SDL_GetError());
                    return;
                }
            }
            SDL.SDL_SetWindowOpacity(m_pWindow, 0.5f);
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
            SDL.SDL_SetRenderDrawBlendMode(m_pRenderer, SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND);
            



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
            SDL.SDL_RenderPresent(PRenderer);
            SDL.SDL_SetWindowOpacity(m_pWindow, a / 255f);
        }
        public void Quit()
        {
            SDL.SDL_FreeSurface(m_pSurface);
            SDL.SDL_DestroyRenderer(PRenderer);
        }
    }
} 
