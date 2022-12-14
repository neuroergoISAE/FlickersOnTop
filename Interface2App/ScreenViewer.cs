
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Interface2App
{
    /// <summary>
    /// Screenviewer is a custom control for windows form that allow us to draw the flickers on screen
    /// 
    /// </summary>
    public class ScreenViewer : UserControl
	{
        private Image bitmap;
        public float Xfactor;
        public float Yfactor;
        public Form1 form;
        private List<Flicker> dataSource= new List<Flicker>();
        private List<flickerRect> FlickerZones= new List<flickerRect>();
        //[Browsable(true)]
        //[Bindable(true)]
        public List<Flicker> DataSource { get { return dataSource; } set { dataSource = value; } }

        private int resX = Screen.PrimaryScreen.Bounds.Width;
        private int resY = Screen.PrimaryScreen.Bounds.Height;

        public ScreenViewer() 
        {
            var bounds = Screen.PrimaryScreen.Bounds;

            // create a new Bitmap object with the same dimensions as the screen
            bitmap = new Bitmap(bounds.Width, bounds.Height);

            // create a Graphics object from the Bitmap
            var graphics = Graphics.FromImage(bitmap);

            // copy the screen to the Bitmap
            graphics.CopyFromScreen(0, 0, 0, 0, bounds.Size);


            //event handling
            this.SizeChanged+= OnSizeChanged;
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
        }
        public void InvalidateRectangle()
        {
            UpdateFlickerZones();
        }
        public void InvalidateRectangle(int index)
        {
            UpdateFlickerZones(index);
        }
        private void UpdateFlickerZones()
        {
            foreach(flickerRect fr in FlickerZones)
            {
                fr.Dispose();
            }
            FlickerZones = new List<flickerRect>();
            for(int i=0; i<dataSource.Count; i++)
            {
                var fr = new flickerRect(dataSource[i],this);
                FlickerZones.Add(fr);
                UpdateFlickerZones(i);
            }
        }
        private void UpdateFlickerZones(int index)
        {
            var flicker = dataSource[index];
            if (index >= FlickerZones.Count)
            {
                FlickerZones.Add(new flickerRect(dataSource[index],this));
            }
            var fz = FlickerZones[index];
            fz.flicker = flicker;
            fz.Xfactor = Xfactor; fz.Yfactor=Yfactor;
            fz.Invalidate();
        }
        private void OnSizeChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = bitmap.GetThumbnailImage(this.Width, this.Height, null, IntPtr.Zero);
            Xfactor = (float)this.Size.Width / (float)resX;
            Yfactor = (float)this.Size.Height / (float)resY;
            //this.MaximumSize = new Size((int)(this.Height*(resX/resY)),9999); //to get an aspect ratio equal to the real screen
            this.MaximumSize = new Size((int)(this.Height*1.7),9999); //to get an aspect ratio equal to the real screen
    }

}
    /// <summary>
    /// Each flickerRect correspond to one flicker and is used to visualized the flickers in a ScreenViewer.
    /// </summary>
    public class flickerRect : UserControl
    {
        protected static int edgeSizeForResize = 1; //size of area where we can grab the object for resizing
        private bool hovered;
        private Color color1;
        private int a1;
        private int a2;
        public Flicker flicker;
        private Image image;
        private bool IsImage;
        private ScreenViewer sv;
        private List<Rectangle> covers; //used for rezizing, a list of rectangle on the edges
        /*
         covers:
        0:North
        1:South
        2:East
        3:West
        4:NW
        5:NE
        6:SW
        7:SE
        8:Center
         */
        public float Xfactor = 0;
        public float Yfactor = 0;
        public flickerRect(Flicker f,ScreenViewer sv)
        {
            flicker = f;
            this.Parent = sv;
            this.sv = sv;
            //resize(new Rectangle((int)(f.X/Xfactor), (int)(f.Y/Yfactor), (int)(f.Width/Xfactor), (int)(f.Height/Yfactor)));
            resize(new Rectangle(f.X,f.Y,f.Width,f.Height));
            hovered = false;

            BackColor= Color.Transparent;

            MouseHover += OnMouseHover;
            MouseLeave+= OnMouseLeave;
            MouseDown+= OnMouseDown;
            MouseMove+= OnMouseMove;
            MouseUp+= OnMouseUp;
        }
        /// <summary>
        /// called each time a flicker or this object change sized -> we need to reajust the covers for grabbing it.
        /// </summary>
        /// <param name="r"></param>
        public void resize(Rectangle r)
        {
            Location = r.Location;
            Size = r.Size;
            r = DisplayRectangle;
            r.Inflate(-edgeSizeForResize*2, -edgeSizeForResize*2);
            createCovers();
            covers.Add(r); //add inner zone of the rectangle

        }
        public void createCovers()
        {
            var e = edgeSizeForResize;
            var X = DisplayRectangle.Location.X; var Y = DisplayRectangle.Location.Y;
            covers = new List<Rectangle>
                {
                    new Rectangle(X, Y, Width + (2 * e), e),
                    new Rectangle(X, Height - e, Width + (2 * e), e),
                    new Rectangle(Width - e, Y, e, Height + 2 * e),
                    new Rectangle(X, Y, e, Height + (2 * e)),
                    new Rectangle(X - 2 * e, Y - 2 * e, 4 * e, 4 * e),
                    new Rectangle(Width - 2 * e, Y - 2 * e, 4 * e, 4 * e),
                    new Rectangle(X - 2 * e, Height - 2 * e, 4 * e, 4 * e),
                    new Rectangle(Width - 2 * e, Height - 2 * e, 4 * e, 4 * e)
                };
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var c = color1;
            if (!IsImage)
            {
                c = Color.FromArgb((int)(a2 * 2.55 * 0.7), c.R, c.G, c.B);
                var alpha = a1 * 2.55 * 0.5;
                if (hovered) { alpha *= 1.3; }
                //e.Graphics.DrawRectangle(blackPen, new Rectangle(Location.X/2,Location.Y/2,Width,Height));
                ControlPaint.DrawBorder(e.Graphics, DisplayRectangle, c, ButtonBorderStyle.Solid);
                BackColor = Color.FromArgb((int)alpha, c.R, c.G, c.B);
            }
            else
            {
                var alpha = a1 * 2.55 * 0.3;
                e.Graphics.DrawImage(image.GetThumbnailImage(Width, Height, null, IntPtr.Zero), DisplayRectangle.Location);
            }
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            var tmp = flicker.color1;
            Color c = Color.FromArgb(tmp.A, tmp.R, tmp.G, tmp.B);
            IsImage = flicker.IsImageFlicker;
            if (IsImage)
            {
                image = Image.FromFile(flicker.image);
            }
            else
            {
                color1 = c;
            }
            a1 = flicker.Opacity_Min;
            a2 = flicker.Opacity_Max;
            resize(new Rectangle(1 + (int)(flicker.X * Xfactor), 1 + (int)(flicker.Y * Yfactor), (int)(flicker.Width * Xfactor), (int)(flicker.Height * Yfactor)));

            base.OnInvalidated(e);
        }
        private void OnMouseHover(Object sender,EventArgs e)
        {
            hovered = true;
        }
        private void OnMouseLeave(Object sender, EventArgs e)
        {
            hovered= false;
        }



        //variable for resizing
        private Point _startPosition = Point.Empty;
        private Size _startSize = Size.Empty;
        private Point originalPoint = Point.Empty;
        private Point _previousPoint = Point.Empty;
        private bool LockMouse = false;
        private int index = -1;
        private void OnMouseDown(Object sender, MouseEventArgs e)
        {
            _startPosition = PointToClient(System.Windows.Forms.Cursor.Position);
            originalPoint = new Point(flicker.X, flicker.Y);
            LockMouse = true;
            if (DisplayRectangle.Contains(_startPosition))
            {
                if (!covers[8].Contains(_startPosition)) { _startSize = Size;_previousPoint = DisplayRectangle.Location; }
            }
        }

        private void OnMouseMove(Object sender, MouseEventArgs e)
        {
            var mousePosition = PointToClient(System.Windows.Forms.Cursor.Position);
            if (LockMouse && index>=0)
            {
                var difX = mousePosition.X - _startPosition.X;
                var difY = mousePosition.Y - _startPosition.Y;
                if(Math.Abs(difX)>10 || Math.Abs(difY) > 6) //check if a minimum distance has been covered
                {
                    if (!_startPosition.IsEmpty && !_startSize.IsEmpty)
                    {
                        var s = _startSize;
                        switch (index)
                        {
                            case 0:
                                flicker.Height = (int)((s.Height - difY) / Yfactor);
                                flicker.Y = originalPoint.Y + (int)(difY / Yfactor);
                                break;
                            case 1:
                                flicker.Height = (int)((s.Height + difY) / Yfactor);
                                break;
                            case 2:
                                flicker.Width = (int)((s.Width + difX) / Xfactor);
                                break;
                            case 3:
                                flicker.X = originalPoint.X + (int)(difX / Xfactor);
                                flicker.Width = (int)((s.Width - difX) / Xfactor);
                                break;
                            case 4:
                                flicker.X = originalPoint.X + (int)(difX / Xfactor);
                                flicker.Y = originalPoint.Y + (int)(difY / Yfactor);
                                flicker.Width = (int)((s.Width - difX) / Xfactor);
                                flicker.Height = (int)((s.Height - difY) / Yfactor);
                                break;
                            case 5:
                                flicker.Y = originalPoint.Y + (int)(difY / Yfactor);
                                flicker.Width = (int)((s.Width + difX) / Xfactor);
                                flicker.Height = (int)((s.Height - difY) / Yfactor);
                                break;
                            case 6:
                                flicker.Width = (int)((s.Width - difX) / Xfactor);
                                flicker.Height = (int)((s.Height + difY) / Yfactor);
                                flicker.X = originalPoint.X + (int)(difX / Xfactor);
                                break;
                            case 7:
                                flicker.Width = (int)((s.Width + difX) / Xfactor);
                                flicker.Height = (int)((s.Height + difY) / Yfactor);
                                break;
                            default: break;

                        }
                        // remove negativity of value if needed
                        if (flicker.Y < 0) { flicker.Y = 0; }
                        if (flicker.X < 0) { flicker.X = 0; }
                        if (flicker.Width < 0) { flicker.Width = 0; }
                        if (flicker.Height < 0) { flicker.Height = 0; }
                    }
                    else
                    {
                        //panning
                        if (!_startPosition.IsEmpty)
                        {
                            flicker.X = (int)((Location.X + difX) / Xfactor);
                            flicker.Y = (int)((Location.Y + difY) / Yfactor);
                        }
                    }
                    Invalidate();
                }
            }
            if (mousePosition != null && !LockMouse)
            {
                //detect which cover the mouse if hovering above, priority created between covers by looking through a list iteratively.
                index = -1;
                for (int i = 0; i < covers.Count; i++)
                {
                    if (covers[i].Contains(mousePosition)) { index = i; }
                }
                if (index >= 0) 
                { changeCursor(index); }
                else
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
            _previousPoint = mousePosition;
        }
        private void OnMouseUp(Object sender, MouseEventArgs e)
        {
            sv.form.dataview.ResetBindings(false);
            _startSize = Size.Empty;
            _startPosition = Point.Empty;
            _previousPoint = Point.Empty;
            LockMouse = false;
            index = -1;
        }
        private void changeCursor(int index)
        {
            if (index == 0 || index == 1) { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNS; }
            if (index == 2 || index == 3) { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeWE; }
            if (index == 4 || index == 7) { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNWSE; }
            if (index == 5 || index == 6) { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNESW; }
            if (index == 8) { System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeAll; }
        }

    }
}