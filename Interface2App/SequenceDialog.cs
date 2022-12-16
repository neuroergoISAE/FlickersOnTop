
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Interface2App
{
    public class SequenceForm : Form
    {
        private static int scrollBarGranularity = 10; //controls how precise the scroll bar is
        private TableLayoutPanel tableLayoutPanel1;
        private SequenceControl sequenceControl1;
        private HScrollBar hScrollBar1;
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip SequenceControlContextMenu;
        private ToolStripMenuItem AddTimeWindow;
        public Flicker flicker;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.sequenceControl1 = new Interface2App.SequenceControl(flicker);
            this.SequenceControlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTimeWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SequenceControlContextMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sequenceControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.hScrollBar1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customize Your Sequence";
            // 
            // sequenceControl1
            // 
            this.sequenceControl1.AutoSize = true;
            this.sequenceControl1.ContextMenuStrip = this.SequenceControlContextMenu;
            this.sequenceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sequenceControl1.Location = new System.Drawing.Point(3, 16);
            this.sequenceControl1.MinimumSize = new System.Drawing.Size(0, 200);
            this.sequenceControl1.Name = "sequenceControl1";
            this.sequenceControl1.Size = new System.Drawing.Size(278, 200);
            this.sequenceControl1.TabIndex = 2;
            // 
            // SequenceControlContextMenu
            // 
            this.SequenceControlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTimeWindow});
            this.SequenceControlContextMenu.Name = "contextMenuStrip1";
            this.SequenceControlContextMenu.Size = new System.Drawing.Size(284, 48);
            // 
            // AddTimeWindow
            // 
            this.AddTimeWindow.Name = "AddTimeWindow";
            this.AddTimeWindow.Size = new System.Drawing.Size(283, 22);
            this.AddTimeWindow.Text = "Add a new time window at this position";
            this.AddTimeWindow.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(119, 242);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 219);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(284, 20);
            this.hScrollBar1.TabIndex = 3;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // SequenceForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SequenceForm";
            this.Load += new System.EventHandler(this.SequenceForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.SequenceControlContextMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
        public SequenceForm(Flicker flicker)
        {
            this.flicker= flicker;
            if(flicker!= null)
            {
                InitializeComponent();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
        }

        private void SequenceForm_Load(object sender, EventArgs e)
        {
            sequenceControl1.flicker = flicker;
            sequenceControl1.owner = this;
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            var totalTimeShown = (sequenceControl1.getScale() * sequenceControl1.Width);
            //convert back into timePos
            sequenceControl1.setPos(hScrollBar1.Value*totalTimeShown/ scrollBarGranularity);
        }
        public void setSizeScrollBar(int max)
        {
            var totalTimeShown = (sequenceControl1.getScale() * sequenceControl1.Width);
            //if all is shown, no need for the scroll bar
            if (totalTimeShown >= max) { hScrollBar1.Maximum = 0; }
            //else add the number of different position we want to show  based on granularity
            else { hScrollBar1.Maximum = (int)(scrollBarGranularity * max / totalTimeShown); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //accept the modification and close
            int[] newSequence = new int[sequenceControl1.timeRectangles.Count*2];
            for(int i=0;sequenceControl1.timeRectangles.Count>i;i++)
            {
                var tr = sequenceControl1.timeRectangles[i];
                newSequence.SetValue(tr.startTime, index:i * 2);
                newSequence.SetValue(tr.endTime, index:i * 2 + 1);
            }
            flicker.sequence=newSequence;
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //we don't change anything and close
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var pointX = sequenceControl1.PointToClient(Cursor.Position).X;
            var startTime = (int)(pointX * sequenceControl1.getScale());
            sequenceControl1.timeRectangles.Add(new TimeRectangle(startTime, startTime + (int)(10 * sequenceControl1.getScale()), sequenceControl1));
            sequenceControl1.BackColor= Color.White;
        }
    }
    public class SequenceControl : UserControl
    {
        public Flicker flicker;
        public SequenceForm owner;
        private double timeScale; //number of seconds per pixel
        private double timePos; //represent the current time we are looking at (~middle of the screen)
        private double timeMax; //endTime of time for our scene 
        public List<TimeRectangle> timeRectangles= new List<TimeRectangle>();
        public SequenceControl(Flicker flicker)
        {
            timeScale= 1.0;
            timeMax = 60.0;
            this.flicker = flicker;
            this.MouseWheel += OnScroll;
            this.BackColor= Color.White;
            //check if sequence list correct
            if(flicker.sequence!=null)
            {
                if (flicker.sequence.Length % 2 == 0)
                {
                    //create the resizable rectangle that represent activity
                    for (int i = 0; i < flicker.sequence.Length; i += 2)
                    {
                        var s = flicker.sequence[i];
                        var e = flicker.sequence[i + 1];
                        timeRectangles.Add(new TimeRectangle(s, e, this));
                        if (e > timeMax) { timeMax = e; }
                    }
                }
                //if the sequence is empty, we change the background to signify it's always active
                if (flicker.sequence.Length == 0)
                {
                    this.BackColor = Color.AliceBlue;
                }
            }
            else { this.BackColor = Color.AliceBlue; }
            
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //call base painting method
            base.OnPaint(e);

            //add a line in the middle that represent the timeline
            e.Graphics.DrawLine(new Pen(Color.Black),new Point { X=Location.X,Y=Height/2 },new Point { X=Width,Y=Height/2});

            //add demarcation for clarity
            //TODO

        }
        private void OnScroll(object sender, MouseEventArgs e)
        {
            //if we scrolled, change the time scale , the scroll bar and potentially timeMax
            if (e.Delta != 0)
            {
                if (e.Delta > 0) { setScale(timeScale /= 1.3); }
                if (e.Delta < 0) { setScale(timeScale * 1.5); }
                if (timeScale * DisplayRectangle.Width > timeMax) { timeMax = timeScale*DisplayRectangle.Width;}
                owner.setSizeScrollBar((int)timeMax);
            }
            return;
        }
        public void setPos(double pos)
        {
            //we moved on the time axis
            timePos = pos;
            Invalidate();
        }
        public void setScale(double scale)
        {
            //we changed the zoom
            if (scale < timeScale)
            {
                var timeWindow= DisplayRectangle.Width * scale;
                //reposition the pos since we zoomed in (to focus on the correct part)
                var point = PointToClient(Cursor.Position);
                var start = timePos - timeWindow / 2;
                var end = timePos + timeWindow / 2;
                timePos = (start * (DisplayRectangle.Width - point.X) + end * point.X) / 2;
            }
            timeScale=scale;
            Invalidate();
        }
        public double getPos() { return timePos;}
        public double getScale() { return timeScale;}
    }
    public class TimeRectangle : UserControl
    {
        public int startTime;
        public int endTime;
        public SequenceControl owner;
        protected static int SizeRectY = 6; //size in pixel of the rectanle on screen
        protected static int edgeSizeForResize = 1; //size of area where we can grab the object for resizing
        public TimeRectangle(int start, int end,SequenceControl owner)
        {
            this.startTime = start;
            this.endTime = end;

            //link this rectangle to the sequence control parent + access to some value of the owner
            this.Parent= owner;
            this.owner= owner;
            this.Height = SizeRectY * 2;

            //Event handling for mouse interaction
            this.MouseDown += OnMouseDown;
            this.MouseUp+= OnMouseUp;
            this.MouseMove += OnMouseMove;
            this.MouseLeave+= OnMouseLeave;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var scale = owner.getScale();
            var pos = owner.getPos();
            Location = new Point((int)((pos - startTime) * scale), owner.Height / 2 - SizeRectY);
            Width = (int)((endTime - pos) * scale);
            BackColor = Color.FromArgb(200, 80, 80, 220);
        }
        private bool mouseLock = false;
        private int startPoint = 0;
        private int direction = 0;
        private int sOrigin = 0;
        private int eOrigin = 0;
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            mouseLock= true;
            var point = PointToClient(Cursor.Position);
            startPoint = point.X;
            sOrigin = startTime;
            eOrigin = endTime;
        }
        private void OnMouseMove(object sender, EventArgs e)
        {
            var point = PointToClient(Cursor.Position);
            if (!mouseLock)
            {
                if (point.X <= Location.X + edgeSizeForResize || point.X >= Width - edgeSizeForResize)
                {
                    if (point.X <= Location.X + edgeSizeForResize)
                    {
                        direction = -1;
                    }
                    else { direction= 1; }
                    Cursor.Current = Cursors.SizeWE;
                }
                else
                {
                    Cursor.Current = Cursors.SizeAll;
                    direction = 0;
                }
            }
            else
            {
                var scale = owner.getScale();
                if((point.X - startPoint) > 2) //minimum distance before modifying anything
                {
                    var difX = (int)(scale * (point.X - startPoint)); //time displacement (with scale!)
                    switch (direction)
                    {
                        case 1:
                            endTime = eOrigin + difX;
                            break;
                        case 0:
                            startTime = sOrigin + difX;
                            endTime = eOrigin + difX;
                            break;
                        case -1:
                            startTime = sOrigin + difX;
                            break;
                    }
                    //start time can't be inferior to 0
                    if (startTime < 0) { startTime = 0; }
                    //redraw the rectangle
                    Invalidate();
                }
            }
            
        }
        private void OnMouseUp(object sender, EventArgs e)
        {
            mouseLock= false;
            startPoint= 0;
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            mouseLock = false;
            Cursor.Current = Cursors.Default;
        }
    }
}