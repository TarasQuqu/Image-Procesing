using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{
    public partial class CreateLightImage : Form
    {
        Bitmap bmp;
        Picture pic;
        private int color;
        private int stripe;
        private byte[] val;
        private int step, counter, it;
        private float percent;
        public CreateLightImage(Bitmap b, Picture p)
        {
            InitializeComponent();
            rdVertical.Checked = true;
            bmp = b;
            pic = p;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_LINE_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pic.getPicture());
            float percent = (float)(this.numericUpDown2.Value / 100);
            Random r = new Random();
            Random c = new Random();
            bitFast bf = new bitFast(bmp);
            byte[] val;
            bf.BufferMemory(bmp);
            val = bf.TakeTAB();
            for (int i = 0; i < val.Length; i++)
            {
                val[i] = 0;
            }
            bf.LoadToBitmap(val, bmp);
            while (counter < bmp.Width)
            {
                if (rdVertical.Checked == true)
                {
                    int step = (int)(bmp.Width / (bmp.Width * percent));
                    stripe = r.Next(counter, counter + step);
                    color = c.Next(0, 80);
                    g.DrawLine(new Pen(Color.FromArgb(color, color, color)), new Point(stripe, 0), new Point(stripe, bmp.Height));
                    counter += step;
                }
                if (rdHorizontal.Checked == true)
                {
                    int step = (int)(bmp.Height / (bmp.Height * percent));
                    stripe = r.Next(counter, counter + step);
                    color = c.Next(0, 80);
                    g.DrawLine(new Pen(Color.FromArgb(color, color, color)), new Point(0, stripe), new Point(bmp.Width, stripe));
                    counter += step;
                }
            }
            pic.RefreshBMP();
        }

        private void btnOK_CROPS_Click(object sender, EventArgs e)
        {
            
            Random r = new Random();
            Random p = new Random();
            bitFast bf = new bitFast(bmp);
            percent = (float)this.numericUpDown1.Value / 100;
            bf.BufferMemory(bmp);
            val = bf.TakeTAB();

            step = (int)(val.Length / (val.Length * percent));
            counter = 0;

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = 0;
            }

            for (int i = 0; i < val.Length; i += 3)
            {
                if (counter == step)
                {
                    it = p.Next(i - step * 3, i);
                    while (it % 3 != 0)
                    {
                        it--;
                    }
                    val[it] = (byte)r.Next(0, 80);
                    val[it + 1] = val[it];
                    val[it + 2] = val[it];
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }

            bf.LoadToBitmap(val, bmp);
            pic.RefreshBMP();
        }
    }
}
