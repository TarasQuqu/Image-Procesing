using System;
using System.Drawing;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{


    public class RadiometricCorrection
    {
        private Bitmap reference;
        private Bitmap KORA;
        private Bitmap original;
        private MainForm ptr;
        private int f;
        private byte[] kora_tab;
        private float[] korm;
        private byte[] original_tab;
        private byte[] Pkora;
        private byte[] ref_tab;
        private byte[] res_tab;

        public RadiometricCorrection(int fl, MainForm p)
        {
            this.f = fl;
            this.ptr = p;
        }
        private void Count_result()
        {
            this.res_tab = new byte[this.original_tab.Length];
            for (int i = 0; i < this.res_tab.Length; i++)
            {
                int num = Convert.ToInt32((float)((this.original_tab[i] - this.kora_tab[i]) * this.korm[i]));
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
        public void counting(MainForm wsk)
        {
            bitFast fast = new bitFast(this.original);
            bitFast fast2 = new bitFast(this.KORA);
            bitFast fast3 = new bitFast(this.reference);
            fast.BufferMemory(this.original);
            fast2.BufferMemory(this.KORA);
            fast3.BufferMemory(this.reference);
            if ((this.original.Width == this.KORA.Width) && (this.original.Width == this.reference.Width))
            {
                this.original_tab = fast.TakeTAB();
                this.kora_tab = fast2.TakeTAB();
                this.ref_tab = fast3.TakeTAB();
                this.count_Kora();
                this.policz_KORM();
                this.Count_result();
                Bitmap bmp = (Bitmap)this.original.Clone();
                bitFast fast4 = new bitFast(bmp);
                fast4.BufferMemory(bmp);
                fast4.LoadToBitmap(this.res_tab, bmp);
                new Picture(this.res_tab, bmp.Width, bmp.Height, "", wsk) { MdiParent = wsk, Text = "Output Image" }.Show();
            }
            else
            {
                MessageBox.Show("Cannot use images with different sizes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public int get_height()
        {
            return this.original.Height;
        }

        public int get_width()
        {
            return this.original.Width;
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

    

        public void counting(MainForm wsk, bool b)
        {
            bitFast fast = new bitFast(this.original);
            bitFast fast2 = new bitFast(this.KORA);
            bitFast fast3 = new bitFast(this.reference);
            Map mapbmp = new Map(this.original, "Input image", this.f);
            Map mapbmp2 = new Map(this.KORA, "Dark image", this.f);
            Map mapbmp3 = new Map(this.reference, "Light image", this.f);
            mapbmp.MdiParent = this.ptr;
            mapbmp2.MdiParent = this.ptr;
            mapbmp3.MdiParent = this.ptr;
            mapbmp.Text = "Input image";
            mapbmp.Show();
            mapbmp2.Text = "Dark image";
            mapbmp2.Show();
            mapbmp3.Text = "Light image";
            mapbmp3.Show();
            fast.BufferMemory(this.original);
            fast2.BufferMemory(this.KORA);
            fast3.BufferMemory(this.reference);
            if ((this.original.Width == this.KORA.Width) && (this.original.Width == this.reference.Width))
            {
                this.original_tab = fast.TakeTAB();
                this.kora_tab = fast2.TakeTAB();
                this.ref_tab = fast3.TakeTAB();
                this.count_Kora();
                this.policz_KORM();
                this.Count_result();
                Map mapbmp4 = new Map(this.Pkora, this.original.Width, this.original.Height, this.f, "PKora");
                Map mapbmp5 = new Map(this.korm, this.original.Width, this.original.Height, this.f, "Korm");
                Bitmap bmp = (Bitmap)this.original.Clone();
                bitFast fast4 = new bitFast(bmp);
                fast4.BufferMemory(bmp);
                fast4.LoadToBitmap(this.res_tab, bmp);
                Map mapbmp6 = new Map(bmp, "Output Image", this.f);
                mapbmp4.MdiParent = this.ptr;
                mapbmp5.MdiParent = this.ptr;
                mapbmp6.MdiParent = this.ptr;
                mapbmp4.Text = "Pkora";
                mapbmp4.Show();
                mapbmp5.Text = "Korm";
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

        private void policz_KORM()
        {
            this.korm = new float[this.kora_tab.Length];
            byte num = this.max(this.Pkora);
            for (int i = 0; i < this.korm.Length; i++)
            {
                if (this.Pkora[i] == 0)
                {
                    this.Pkora[i] = 1;
                }
                else
                {
                    this.korm[i] = ((float)num) / ((float)this.Pkora[i]);
                }
            }
        }

        private void count_Kora()
        {
            try
            {
                this.Pkora = new byte[this.kora_tab.Length];
                for (int i = 0; i < this.Pkora.Length; i++)
                {
                    if ((this.ref_tab[i] - this.kora_tab[i]) < 0)
                    {
                        this.Pkora[i] = 0;
                    }
                    else if ((this.ref_tab[i] - this.kora_tab[i]) > 0xff)
                    {
                        this.Pkora[i] = 0xff;
                    }
                    else
                    {
                        this.Pkora[i] = Convert.ToByte((int)(this.ref_tab[i] - this.kora_tab[i]));
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Cannot use images with different sizes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void ustaw_kora(Bitmap k)
        {
            this.KORA = k;
        }

        public void ustaw_odniesienie(Bitmap o)
        {
            this.reference = o;
        }

        public void ustaw_pierwotny(Bitmap p)
        {
            this.original = p;
        }
    }
}