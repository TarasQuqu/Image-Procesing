using System;
using System.Drawing;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{
    

    public class Submission
    {
        private Bitmap Reference;
        private Bitmap KORA;
        private Bitmap Original;
        private MainForm temp;

        private byte[] kora_tab;
        private float[] korm;
        private byte[] pier_tab;
        private byte[] Pkora;
        private byte[] ref_tab;
        private byte[] res_tab;
        private int f;


        public Submission(int fl, MainForm p)
        {
            this.f = fl;
            this.temp = p;
        }

        public int get_height()
        {
            return this.Original.Height;
        }

        public int get_width()
        {
            return this.Original.Width;
        }

        private byte max(byte[] tab)
        {
            byte num = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                if (num < tab[i])
                {
                    num = tab[i];
                }
            }
            return num;
        }

        public void Counting(MainForm wsk)
        {
            bitFast fast = new bitFast(this.Original);
            bitFast fast2 = new bitFast(this.KORA);
            bitFast fast3 = new bitFast(this.Reference);
            fast.BufferMemory(this.Original);
            fast2.BufferMemory(this.KORA);
            fast3.BufferMemory(this.Reference);
            this.pier_tab = fast.TakeTAB();
            this.kora_tab = fast2.TakeTAB();
            this.ref_tab = fast3.TakeTAB();
            this.Count_PKORA();
            this.Count_KORM();
            this.count_res();
            Bitmap bmp = (Bitmap)this.Original.Clone();
            bitFast fast4 = new bitFast(bmp);
            fast4.BufferMemory(bmp);
            fast4.LoadToBitmap(this.res_tab, bmp);
            new Picture(this.res_tab, bmp.Width, bmp.Height, "", wsk) { MdiParent = wsk, Text = "Submissio " }.Show();
        }

        public void Counting(MainForm wsk, bool b)
        {
            bitFast fast = new bitFast(this.Original);
            bitFast fast2 = new bitFast(this.KORA);
            bitFast fast3 = new bitFast(this.Reference);
            Map mapbmp = new Map(this.Original, "Input image", this.f);
            Map mapbmp2 = new Map(this.KORA, "Dark image", this.f);
            Map mapbmp3 = new Map(this.Reference, "Bright image", this.f);
            mapbmp.MdiParent = this.temp;
            mapbmp2.MdiParent = this.temp;
            mapbmp3.MdiParent = this.temp;
            mapbmp.Text = "Input image";
            mapbmp2.Text = "Dark image";
            mapbmp3.Text = "Bright image";
            mapbmp.Show();
            mapbmp2.Show();
            mapbmp3.Show();
            fast.BufferMemory(this.Original);
            fast2.BufferMemory(this.KORA);
            fast3.BufferMemory(this.Reference);
            if ((this.Original.Width == this.KORA.Width) && (this.Original.Width == this.Reference.Width))
            {
                this.pier_tab = fast.TakeTAB();
                this.kora_tab = fast2.TakeTAB();
                this.ref_tab = fast3.TakeTAB();
                this.Count_PKORA();
                this.Count_KORM();
                this.count_res();
                Map mapbmp4 = new Map(this.Pkora, this.Original.Width, this.Original.Height, this.f, "PKora");
                Map mapbmp5 = new Map(this.korm, this.Original.Width, this.Original.Height, this.f, "Korm");
                Bitmap bmp = (Bitmap)this.Original.Clone();
                bitFast fast4 = new bitFast(bmp);
                fast4.BufferMemory(bmp);
                fast4.LoadToBitmap(this.res_tab, bmp);
                Map mapbmp6 = new Map(bmp, "Output Image", this.f);
                mapbmp4.MdiParent = this.temp;
                mapbmp4.Text = "Pkora";
                mapbmp5.MdiParent = this.temp;
                mapbmp5.Text = "Korm";
                mapbmp6.MdiParent = this.temp;
                mapbmp4.Show();
                mapbmp5.Show();
                new Picture(this.res_tab, bmp.Width, bmp.Height, "", wsk) { MdiParent = wsk, Text = "After Correction" }.Show();
                mapbmp6.Text = "Output image";
                mapbmp6.Show();
            }
            else
            {
                MessageBox.Show("Cannot use images with different sizes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Count_KORM()
        {
            this.korm = new float[this.kora_tab.Length];
            byte num = this.max(this.Pkora);
            for (int i = 0; i < this.korm.Length; i++)
            {
                this.korm[i] = ((float)num) / ((float)this.Pkora[i]);
            }
        }

        private void Count_PKORA()
        {
            this.Pkora = new byte[this.kora_tab.Length];
            for (int i = 0; i < this.Pkora.Length; i++)
            {
                int num = this.ref_tab[i] - this.kora_tab[i];
                if (num < 0)
                {
                    this.Pkora[i] = 0;
                }
                else if (num > 0xff)
                {
                    this.Pkora[i] = 0xff;
                }
                else
                {
                    this.Pkora[i] = Convert.ToByte((int)(this.ref_tab[i] - this.kora_tab[i]));
                }
            }
        }

        public void set_kora(Bitmap k)
        {
            this.KORA = k;
        }

        public void set_reference(Bitmap o)
        {
            this.Reference = o;
        }

        public void set_original(Bitmap p)
        {
            this.Original = p;
        }

        private void count_res()
        {
            try
            {
                this.res_tab = new byte[this.pier_tab.Length];
                for (int i = 0; i < this.res_tab.Length; i++)
                {
                    int num = Convert.ToInt32((float)((this.pier_tab[i] * (1f / this.korm[i])) + this.kora_tab[i]));
                    if ((num > -1) && (num < 0x100))
                    {
                        this.res_tab[i] = Convert.ToByte(num);
                    }
                    else if (num < 0)
                    {
                        this.res_tab[i] = 0;
                    }
                    else
                    {
                        this.res_tab[i] = 0xff;
                    }
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Cannot perform operation for this pictures", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}