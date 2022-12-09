using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Security.Cryptography;

namespace Interface2App
{
    [System.ComponentModel.DefaultBindingProperty("FlickerList")]
	public class ScreenViewer : UserControl
	{
        protected static int edgeSizeForResize = 2;
        private class flickerRect
        {
            public Rectangle zone;
            public Rectangle innerZone;
            public bool hovered;
            public Color color1;
            public int a1;
            public int a2;
            public Flicker flicker;
            public flickerRect()
            {
                zone = new Rectangle();
                innerZone = new Rectangle();
                hovered=false;
            }
            public void resize(Rectangle r)
            {
                zone = new Rectangle(r.Location,r.Size);
                r.Inflate(-edgeSizeForResize, -edgeSizeForResize);
                innerZone=r;
            }
        }
        private List<Flicker> dataSource= new List<Flicker>();
        private List<flickerRect> FlickerZones= new List<flickerRect>();
        [Browsable(true)]
        [Bindable(true)]
		public List<Flicker> DataSource { get { return dataSource; } set { dataSource = value; } }

        private int resX = Screen.PrimaryScreen.Bounds.Width;
        private int resY = Screen.PrimaryScreen.Bounds.Height;

        public ScreenViewer() 
        {
            this.MouseHover += OnMouseHover;
            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;
        }
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
            if (dataSource != null)
            {
                if (dataSource.Count() > 0)
                {
                    try
                    {
                        for(int i=0; i<dataSource.Count(); i++)
                        {
                            if(FlickerZones.Count==i) { UpdateFlickerZones(); }
                            var rect = FlickerZones[i];
                            if (rect.zone.IntersectsWith(e.ClipRectangle))
                            {
                                var c = rect.color1;
                                c = Color.FromArgb((int)(rect.a2*2.55 * 0.7), c.R, c.G, c.B);
                                Pen blackPen = new Pen(c);
                                blackPen.Width = 3;
                                var alpha = rect.a1*2.55*0.3;
                                if (rect.hovered) { alpha*=1.3; }
                                e.Graphics.DrawRectangle(blackPen, rect.zone);
                                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)alpha, rect.color1.R, rect.color1.G, rect.color1.B)), rect.zone);

                            }
                        }
                    }
                    catch (Exception ex) 
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message+ex.StackTrace);
                    }
                }
            }
           
		}
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            UpdateFlickerZones();
            base.OnInvalidated(e);
        }
        private void UpdateFlickerZones()
        {
            Parallel.For(0,dataSource.Count, i =>
            {
                var flicker = dataSource[i];
                float Xfactor = (float)this.Size.Width / (float)resX;
                float Yfactor = (float)this.Size.Height / (float)resY;
                var tmp = flicker.color1;
                Color c = Color.FromArgb(tmp.A, tmp.R, tmp.G, tmp.B);
                while (FlickerZones.Count <= i) { FlickerZones.Add(new flickerRect()); }
                var fz = FlickerZones[i];
                fz.color1 = c;
                fz.a1 = flicker.Opacity_Min;
                fz.a2 = flicker.Opacity_Max;
                fz.flicker = flicker;
                fz.resize(new Rectangle(1 + (int)(flicker.X * Xfactor), 1 + (int)(flicker.Y * Yfactor), (int)(flicker.Width * Xfactor), (int)(flicker.Height * Yfactor)));
            });
        }
        private void OnMouseHover(object sender, EventArgs e)
        {
        }
        private Point _startPosition;
        private Size _startSize;
        private flickerRect _selectedRect;
        private bool LockMouse;
        private void OnMouseDown(object sender, EventArgs e)
        {
            _startPosition= PointToClient(System.Windows.Forms.Cursor.Position);
            foreach(flickerRect fr in FlickerZones)
            {
                if(fr.zone.Contains(_startPosition)) 
                { 
                    
                    _selectedRect = fr;
                    if (!fr.innerZone.Contains(_startPosition)) { _startSize = fr.zone.Size; }
                    LockMouse = true;
                    break;
                }

            }
        }
        private void OnMouseMove(object sender, EventArgs e)
        {
            var mousePosition = PointToClient(System.Windows.Forms.Cursor.Position);
            if (LockMouse)
            {
                if (!_startPosition.IsEmpty && !_startSize.IsEmpty)
                {
                    var difX = mousePosition.X - _startPosition.X;
                    var difY = mousePosition.Y - _startPosition.Y;
                    //_selectedRect.resize(new Rectangle(_startPosition.X, _startPosition.Y, _startSize.Width + difX, _startSize.Height + difY));
                    _selectedRect.flicker.Width = _startSize.Width + difX;
                    _selectedRect.flicker.Height = _startSize.Height + difY;
                    Invalidate(new Rectangle(_startPosition, new Size(_startSize.Width + difX, _startSize.Height + difY)));
                }
                else
                {
                    if (!_startPosition.IsEmpty)
                    {
                        var difX = mousePosition.X - _startPosition.X;
                        var difY = mousePosition.Y - _startPosition.Y;
                        _selectedRect.resize(new Rectangle(_startPosition.X + difX, _startPosition.Y + difY, _selectedRect.zone.Width, _selectedRect.zone.Height));
                    }
                }
            }
            if (mousePosition != null && !LockMouse)
            {
                bool b = true;
                foreach (flickerRect fr in FlickerZones)
                {
                    if (fr.zone.Contains(mousePosition))
                    {
                        if (!fr.hovered)
                        {
                            fr.hovered = true;
                            Invalidate(fr.zone);
                        }
                        changeCursor(mousePosition, fr);
                        b = false;

                    }
                    else
                    {
                        fr.hovered = false;
                    }
                }
                if (b)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
        }
        private void OnMouseUp(object sender, EventArgs e)
        {
            _startSize = Size.Empty;
            _startPosition = Point.Empty;
            LockMouse = false;
        }

        private void changeCursor(Point mousePosition,flickerRect fr)
        {
            if (fr.innerZone.Contains(mousePosition))
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeAll;
            }
            else
            {
                if (mousePosition.X > fr.innerZone.X)
                {
                    if (mousePosition.Y > fr.innerZone.Y)
                    {
                        if (mousePosition.Y > fr.innerZone.Height)
                        {
                            if (mousePosition.X > fr.innerZone.Width)
                            {
                                this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                            }
                            else
                            {
                                this.Cursor = System.Windows.Forms.Cursors.SizeNS;
                            }
                        }
                        else
                        {
                            this.Cursor = System.Windows.Forms.Cursors.SizeWE;
                        }
                    }
                    else
                    {
                        if (mousePosition.X > fr.innerZone.Width)
                        {
                            this.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                        }
                        else
                        {
                            this.Cursor = System.Windows.Forms.Cursors.SizeNS;
                        }
                    }
                }
                else
                {
                    if (mousePosition.Y > fr.innerZone.Y)
                    {
                        if (mousePosition.Y > fr.innerZone.Height)
                        {
                            this.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                        }
                        else
                        {
                            this.Cursor = System.Windows.Forms.Cursors.SizeWE;
                        }
                    }
                    else
                    {
                        this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    }
                }
            }
        }

	}
}
