using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{
    public partial class Picture : Form
    {
        private CUT wptr;
        private MainForm ptr;
        private CreateLightImage d;
        private CreateDarkImage d2;
        private Map map;
        private Bitmap bmp;
        private ContextMenu cm;
        private int prevHeight;
        private int prevWidth;
        private int zoom;
        private int rys_shape, shape_width, shape_height, xp, yp, x, y, fcol, scol;
        private int cut_h, cut_select, cut_w;
        private int f;
        private float focus1,focus2;
        private string name;
        public string path;
        public Picture(Bitmap b, string p, MainForm pt)
        {
            this.components = null;
            this.InitializeComponent();
            this.bmp = (Bitmap)b.Clone();
            this.path = p;
            this.pictureBox1.Width = this.bmp.Width;
            this.pictureBox1.Height = this.bmp.Height;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Image = this.bmp;
            this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
            this.f = 0;
            this.rys_shape = 0;
            this.xp = 0;
            this.yp = 0;
            this.x = -1;
            this.y = -1;
            this.ptr = pt;
            this.CMcreate();
            this.ContextMenu = this.cm;
            this.Text = p;
            this.name = this.Text;
            this.cut_select = 0;
        }

        public Picture(byte[] v, int w, int h, string p, MainForm pt)
        {
            this.path = p;
            this.f = 0;
            this.rys_shape = 0;
            this.xp = 0;
            this.yp = 0;
            this.x = -1;
            this.y = -1;
            this.ptr = pt;
            this.CMcreate();
            this.ContextMenu = this.cm;
            this.name = this.Text;
            this.cut_select = 0;
            this.components = null;
            this.InitializeComponent();
            this.bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            new bitFast(this.bmp).LoadToBitmap(v, this.bmp);
            this.pictureBox1.Width = this.bmp.Width;
            this.pictureBox1.Height = this.bmp.Height;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Image = this.bmp;
            this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
          
        }

        public Picture(byte[] v, int w, int h, string p, int flag, MainForm pt)
        {
            this.path = p;
            this.f = flag;
            this.rys_shape = 0;
            this.xp = 0;
            this.yp = 0;
            this.x = -1;
            this.y = -1;
            this.ptr = pt;
            this.CMcreate();
            this.ContextMenu = this.cm;
            this.name = this.Text;
            this.cut_select = 0;
            this.components = null;
            this.InitializeComponent();
            this.bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            new bitFast(this.bmp).LoadToBitmap(v, this.bmp);
            this.pictureBox1.Width = this.bmp.Width;
            this.pictureBox1.Height = this.bmp.Height;
            this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Image = this.bmp;
        }
        public void SETcutH(int h)
        {
            this.cut_h = h;
        }

        public void SETcutW(int w)
        {
            this.cut_w = w;
        }

        public void SETd(CreateLightImage d_)
        {
            this.d = d_;
            this.d.FormClosing += new FormClosingEventHandler(this.d_FormClosing);
        }

        public void SetD2(CreateDarkImage d2_)
        {
            this.d2 = d2_;
            this.d2.FormClosing += new FormClosingEventHandler(this.d2_FormClosing);
        }
        public void SetFirstCol(int c)
        {
            this.fcol = c;
        }

        public void SetFocus1(float f)
        {
            this.focus1 = f;
        }

        public void SetFocus(float f)
        {
            this.focus2 = f;
        }

        public void SetName(string n)
        {
            this.name = n;
        }

        public void SetRysShape(int shape)
        {
            this.rys_shape = shape;
        }

        public void SetSec(int c)
        {
            this.scol = c;
        }

        public void SetShapeHeight(int height)
        {
            this.shape_height = height;
        }

        public void SetShapeWitdh(int width)
        {
            this.shape_width = width;
        }

        public void setCut_select(int cs)
        {
            this.cut_select = cs;
        }

        public void setMap(Map mapa)
        {
            this.map = mapa;
        }
        public void RefreshBMP()
        {
            pictureBox1.Refresh();
        }
        private void close_click(object sender, EventArgs e)
        {
            base.Close();
        }
        public void ZoomIN()
        {
            if (zoom < 20)
            {
                this.pictureBox1.Width += (int)(prevWidth * 0.1);
                this.pictureBox1.Height += (int)(prevHeight * 0.1);
                zoom++;
                this.AutoSize = true;
            }
        }

        public void ZoomOUT()
        {
            if (zoom > 0)
            {
                this.pictureBox1.Width -= (int)(this.pictureBox1.Width * 0.1);
                this.pictureBox1.Height -= (int)(this.pictureBox1.Height * 0.1);
                zoom--;
                this.Size = new Size(pictureBox1.Width, pictureBox1.Height);
            }
        }
        private void CMcreate()
        {
            this.cm = new ContextMenu();
            MenuItem item = new MenuItem("Save", new EventHandler(this.save_click));
            MenuItem item2 = new MenuItem("Save as", new EventHandler(this.saveas_click));
            MenuItem item3 = new MenuItem("Show dark image tools", new EventHandler(this.dis_tool));
            MenuItem item4 = new MenuItem("Show light image tools", new EventHandler(this.dis_tool2));
            // MenuItem item5 = new MenuItem("Show draw mode", new EventHandler(this.drmod_click));
            MenuItem item6 = new MenuItem("Close", new EventHandler(this.close_click));
            this.cm.MenuItems.Add(item);
            this.cm.MenuItems.Add(item2);
            this.cm.MenuItems.Add(item3);
            this.cm.MenuItems.Add(item4);
            //         this.cm.MenuItems.Add(item5);
            this.cm.MenuItems.Add(item6);
            this.cm.MenuItems[2].Visible = false;
            this.cm.MenuItems[3].Visible = false;
            this.cm.MenuItems[4].Visible = false;
        }

        private void d_FormClosing(object s, EventArgs e)
        {
            this.cm.MenuItems[2].Visible = true;
        }

        private void d2_FormClosing(object s, EventArgs e)
        {
            this.cm.MenuItems[3].Visible = true;
        }

        private void dis_tool(object sender, EventArgs e)
        {
            this.d = new CreateLightImage(this.bmp, this);
            this.d.MdiParent = this.ptr;
            this.d.Show();
            this.d.FormClosing += new FormClosingEventHandler(this.d_FormClosing);
            this.cm.MenuItems[2].Visible = false;
        }

        private void dis_tool2(object sender, EventArgs e)
        {
            this.d2 = new CreateDarkImage(this.bmp, this);
            this.d2.MdiParent = this.ptr;
            this.d2.FormClosing += new FormClosingEventHandler(this.d2_FormClosing);
            this.d2.Show();
            this.cm.MenuItems[3].Visible = false;
        }
        private void dm_FormClosing(object s, EventArgs e)
        {
            this.cm.MenuItems[4].Visible = true;
        }
        public int GetFlag()
        {
            return this.f;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetPath()
        {
            return this.path;
        }

        public int GetZoom()
        {
            return this.zoom;
        }

        public int GetCutSelet()
        {
            return this.cut_select;
        }

        public Bitmap getPicture()
        {
            return this.bmp;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if ((e.CloseReason != CloseReason.ApplicationExitCall) && (e.CloseReason != CloseReason.MdiFormClosing))
            {
                if (MessageBox.Show("Do you really want to close this window?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (this.d != null)
                    {
                        this.d.Close();
                    }
                    if (this.d2 != null)
                    {
                        this.d2.Close();
                    }
                }
            }
        }

        protected unsafe void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.map != null)
            {
                this.map.SelectCell(e.X, e.Y);
            }
            if ((this.rys_shape != 0) && (e.Button == MouseButtons.Left))
            {
                PathGradientBrush brush;
                this.pictureBox1.Refresh();
                Graphics graphics = Graphics.FromImage(this.pictureBox1.Image);
                Point[] points = new Point[] { new Point(this.x - (this.shape_width / 2), this.y - (this.shape_height / 2)), new Point(this.x - (this.shape_width / 2), (this.y - (this.shape_height / 2)) + this.shape_height), new Point((this.x - (this.shape_width / 2)) + this.shape_width, (this.y - (this.shape_height / 2)) + this.shape_height), new Point((this.x - (this.shape_width / 2)) + this.shape_width, this.y - (this.shape_height / 2)) };
                Color[] colorArray2 = new Color[] { Color.FromArgb(this.scol, this.scol, this.scol), Color.FromArgb(this.scol, this.scol, this.scol), Color.FromArgb(this.scol, this.scol, this.scol), Color.FromArgb(this.scol, this.scol, this.scol) };
                Color[] colorArray = colorArray2;
                Rectangle rect = new Rectangle(new Point(this.x - (this.shape_width / 2), this.y - (this.shape_height / 2)), new Size(this.shape_width, this.shape_height));
                if (this.rys_shape == 1)
                {
                    brush = new PathGradientBrush(points)
                    {
                        CenterColor = Color.FromArgb(this.fcol, this.fcol, this.fcol),
                        CenterPoint = new PointF((float)this.x, (float)this.y),
                        SurroundColors = colorArray
                    };
                    graphics.FillRectangle(brush, rect);
                }
                else
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(rect);
                    brush = new PathGradientBrush(path)
                    {
                        CenterColor = Color.FromArgb(this.fcol, this.fcol, this.fcol)
                    };
                    colorArray2 = new Color[] { Color.FromArgb(this.scol, this.scol, this.scol) };
                    brush.SurroundColors = colorArray2;
                    brush.FocusScales = new PointF(this.focus1, this.focus2);
                    graphics.FillEllipse(brush, rect);
                }
                this.pictureBox1.Refresh();
                this.xp = -1;
                this.yp = -1;
                this.rys_shape = 0;
            }
            if ((((this.cut_select > 0) && ((e.X + this.cut_w) > 0)) && (((e.X + this.cut_w) < this.pictureBox1.Width) && ((e.Y + this.cut_h) > 0))) && ((e.Y + this.cut_h) < this.pictureBox1.Height))
            {
                Bitmap b = new Bitmap(this.cut_w, this.cut_h, PixelFormat.Format24bppRgb);
                BitmapData bitmapdata = b.LockBits(new Rectangle(0, 0, this.cut_w, this.cut_h), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData data2 = this.bmp.LockBits(new Rectangle(e.X, e.Y, this.cut_w, this.cut_h), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* numPtr = (byte*)data2.Scan0;
                byte* numPtr2 = (byte*)bitmapdata.Scan0;
                int num = data2.Stride - (data2.Width * 3);
                int num2 = bitmapdata.Stride - (data2.Width * 3);
                for (int i = 0; i < data2.Height; i++)
                {
                    for (int j = 0; j < data2.Width; j++)
                    {
                        numPtr2[0] = numPtr[0];
                        numPtr2[1] = numPtr[1];
                        numPtr2[2] = numPtr[2];
                        numPtr += 3;
                        numPtr2 += 3;
                    }
                    numPtr += num;
                    numPtr2 += num2;
                }
                this.bmp.UnlockBits(data2);
                b.UnlockBits(bitmapdata);
                new Picture(b, "Image_" + this.ptr.get_counter(), this.ptr) { MdiParent = this.ptr }.Show();
                this.cut_select = 0;
                this.pictureBox1.Refresh();
            }
        }

        protected void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (rys_shape != 0)
            {
                Graphics g = this.pictureBox1.CreateGraphics();
                if (rys_shape == 1)
                {
                    if (x != -1 && y != -1)
                    {
                        xp = x;
                        yp = y;
                        g.DrawRectangle(new Pen(Color.White), new Rectangle(new Point(xp - shape_width / 2, yp - shape_height / 2), new Size(shape_width, shape_height)));
                    }
                    x = e.X;
                    y = e.Y;

                    g.DrawRectangle(new Pen(Color.Red), new Rectangle(new Point(x - shape_width / 2, y - shape_height / 2), new Size(shape_width, shape_height)));
                }
                else
                {
                    if (x != -1 && y != -1)
                    {
                        xp = x;
                        yp = y;
                        g.DrawEllipse(new Pen(Color.White), new Rectangle(new Point(xp - shape_width / 2, yp - shape_height / 2), new Size(shape_width, shape_height)));
                    }
                    x = e.X;
                    y = e.Y;

                    g.DrawEllipse(new Pen(Color.Blue), new Rectangle(new Point(x - shape_width / 2, y - shape_height / 2), new Size(shape_width, shape_height)));
                }
            }



            if (cut_select > 0 && e.X > 0 && e.X < pictureBox1.Width && e.Y > 0 && e.Y < pictureBox1.Height)
            {
                this.pictureBox1.Refresh();


                Graphics g2 = pictureBox1.CreateGraphics();
                g2.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(e.X, e.Y, cut_w, cut_h));
                 
            }
        }
        public void reset_Image()
        {
            bitFast fast = new bitFast(this.bmp);
            fast.BufferMemory(this.bmp);
            byte[] tablica = fast.TakeTAB();
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = 0xff;
            }
            fast.LoadToBitmap(tablica, this.bmp);
            this.Refresh();
        }

        private void save_click(object sender, EventArgs e)
        {
            this.save_f(this.path);
        }
        public void set_wptr(CUT w)
        {
            wptr = w;
        }
        public void save_f(string path)
        {
            if (path != "")
            {
                this.pictureBox1.Image.Save(path, ImageFormat.Bmp);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Bitmap Image|*.bmp",
                    Title = "Save as"
                };
                dialog.ShowDialog();
                if (dialog.FileName != "")
                {
                    FileStream stream = (FileStream)dialog.OpenFile();
                    this.path = dialog.FileName;
                    this.bmp.Save(stream, ImageFormat.Bmp);
                    stream.Close();
                }
            }
        }

        private void saveas_click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Bitmap Image|*.bmp",
                Title = "Save as"
            };
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                FileStream stream = (FileStream)dialog.OpenFile();
                this.path = dialog.FileName;
                this.bmp.Save(stream, ImageFormat.Bmp);
                stream.Close();
            }
        }
    }
}

