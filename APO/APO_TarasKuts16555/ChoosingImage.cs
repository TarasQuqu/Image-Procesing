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
    public partial class submiss : Form
    {
        private int f;
        private MainForm wsk;

        public submiss(MainForm w, int fl)
        {
            InitializeComponent();
            wsk = w;
            f = fl;
            comboBox1.KeyPress += new KeyPressEventHandler(comboBox1_KeyPress);
            comboBox2.KeyPress += new KeyPressEventHandler(comboBox2_KeyPress);
            comboBox3.KeyPress += new KeyPressEventHandler(comboBox3_KeyPress);
        }

        public void add_to_list(string n, Bitmap b, int f)
        {
            Container item = new Container(n, b, f);
            comboBox1.Items.Add(item);
            comboBox2.Items.Add(item);
            comboBox3.Items.Add(item);
        }

       

        public void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (((comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null)) && (comboBox3.SelectedItem != null))
            {
                if (this.f == 0)
                {
                    RadiometricCorrection kora = new RadiometricCorrection(((Container)comboBox1.SelectedItem).flag,wsk);
                    kora.ustaw_pierwotny(((Container)comboBox1.SelectedItem).bm);
                    kora.ustaw_odniesienie(((Container)comboBox2.SelectedItem).bm);
                    kora.ustaw_kora(((Container)this.comboBox3.SelectedItem).bm);

                    kora.counting(wsk);
                    base.Close();

                }
                else
                {
                    Submission zlozenie = new Submission(((Container)comboBox1.SelectedItem).flag, wsk);
                    zlozenie.set_original(((Container)comboBox1.SelectedItem).bm);
                    zlozenie.set_reference(((Container)comboBox2.SelectedItem).bm);
                    zlozenie.set_kora(((Container)comboBox3.SelectedItem).bm);

                    zlozenie.Counting(this.wsk);
                    base.Close();

                }
            }
            else
            {
                MessageBox.Show("Please choose images", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}