using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{
    public partial class CreateDarkImage : Form
    {
        private Bitmap bmp;
        private Picture pic;

        public CreateDarkImage(Bitmap b, Picture p)
        {
            this.InitializeComponent();
            this.textBox1.Text = "255";
            this.textBox2.Text = "0";
            this.bmp = b;
            this.pic = p;
        }

     

       

        private void btnOK_Click(object sender, EventArgs e)
        {
            int fc = Convert.ToInt32(this.textBox1.Text);
            int sc = Convert.ToInt32(this.textBox2.Text);
            this.pic.SetRysShape(0);
            this.pic.RefreshBMP();
            if ((((fc < 0x100) && (fc > -1)) && (sc < 0x100)) && (sc > -1))
            {
                Color[] colorArray;
                Rectangle r = new Rectangle(0, 0, this.pic.getPicture().Width, this.pic.getPicture().Height);
                Graphics g = Graphics.FromImage(this.bmp);
                Point[] points = new Point[] { new Point(0, 0), new Point(0, this.pic.getPicture().Height), new Point(this.pic.getPicture().Width, this.pic.getPicture().Height), new Point(this.pic.getPicture().Width, 0) };
                PathGradientBrush brush = new PathGradientBrush(points);
                if (this.rdVertical.Checked)
                {
                    colorArray = new Color[] { Color.FromArgb(fc, fc, fc), Color.FromArgb(fc, fc, fc), Color.FromArgb(sc, sc, sc), Color.FromArgb(sc, sc, sc) };
                    brush.SurroundColors = colorArray;
                    brush.CenterColor = Color.FromArgb(fc, fc, fc);
                    brush.CenterPoint = new PointF(0f, (float)this.pic.getPicture().Height);
                    g.FillRectangle(brush, r);
                }
                if (this.rdHorizontal.Checked)
                {
                    colorArray = new Color[] { Color.FromArgb(fc, fc, fc), Color.FromArgb(fc, fc, fc), Color.FromArgb(fc, fc, fc), Color.FromArgb(fc, fc, fc) };
                    brush.SurroundColors = colorArray;
                    brush.CenterColor = Color.FromArgb(sc, sc, sc);
                    brush.CenterPoint = new PointF((float)(this.pic.getPicture().Width / 2), (float)(this.pic.getPicture().Height / 2));
                    g.FillRectangle(brush, r);
                }

                if (this.rdCenter.Checked)
                {
                    colorArray = new Color[] { Color.FromArgb(fc, fc, fc), Color.FromArgb(sc, sc, sc), Color.FromArgb(sc, sc, sc), Color.FromArgb(fc, fc, fc) };
                    brush.SurroundColors = colorArray;
                    brush.CenterColor = Color.FromArgb(fc, fc, fc);
                    brush.CenterPoint = new PointF((float)(this.pic.getPicture().Width / 2), 0f);
                    g.FillRectangle(brush, r);
                }
                if (rdHalf.Checked == true)
                {
                    brush.SurroundColors = new Color[] { Color.FromArgb(sc, sc, sc), Color.FromArgb(sc, sc, sc), Color.FromArgb(fc, fc, fc), Color.FromArgb(fc, fc, fc) };
                    brush.CenterColor = Color.FromArgb(fc, fc, fc);
                    brush.CenterPoint = new PointF(0, pic.getPicture().Height);
                    g.FillRectangle(brush, r);
                }
                if (rdUpDown.Checked == true)
                {
                    brush.SurroundColors = new Color[] { Color.FromArgb(fc, fc, fc), Color.FromArgb(sc, sc, sc), Color.FromArgb(fc, fc, fc), Color.FromArgb(sc, sc, sc) };
                    brush.CenterColor = Color.FromArgb(fc, fc, fc);
                    brush.CenterPoint = new PointF(pic.getPicture().Width / 2, pic.getPicture().Height / 2);
                    g.FillRectangle(brush, r);
                }
                if (rdDownUp.Checked == true)
                {
                    brush.SurroundColors = new Color[] { Color.FromArgb(sc, sc, sc), Color.FromArgb(fc, fc, fc), Color.FromArgb(sc, sc, sc), Color.FromArgb(fc, fc, fc) };
                    brush.CenterColor = Color.FromArgb(fc, fc, fc);
                    brush.CenterPoint = new PointF(0, pic.getPicture().Height);
                    g.FillRectangle(brush, r);
                }

                this.pic.RefreshBMP();
            }
            else
            {
                MessageBox.Show("First color and Second Color should have values from range <0,255>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
