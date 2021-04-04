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
    public partial class CUT : Form
    {
        private Picture pic;
        private int flag;
        private MainForm ptr;
        private int val1;
        private int val2;

        public CUT(Picture p, MainForm f)
        {
            InitializeComponent();
            pic = p;
            flag = 0;
            ptr = f;
        }
        public void set_Text(int x, int y)
        {
            txtX.Text = x.ToString();
            txtY.Text = y.ToString();
        }

        public int get_flag()
        {
            return flag;
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
                flag = 1;
                btnCut.Enabled = Int32.TryParse(txtX.Text, out val1) && Int32.TryParse(txtY.Text, out val2);
                if (val1 > 0 && val1 < pic.getPicture().Width && val2 > 0 && val2 < pic.getPicture().Height)
                {
                    pic.SETcutW(val1);
                    pic.SETcutH(val2);
                    pic.setCut_select(1);
                }
                else
                {
                    MessageBox.Show("Enter length and width", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            pic.setCut_select(0);
        }
    }
}
