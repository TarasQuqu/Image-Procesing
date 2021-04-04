using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{

    public partial class Map : Form
    {
        Picture pic;
        public Map(Bitmap bmp, string text, int flag, Picture pict)
        {
            try
            {
                pic = pict;
                bitFast bf = new bitFast(bmp);
                bf.BufferMemory(bmp);
                byte[] val = bf.TakeTAB();
                InitializeComponent();
                this.Text = text;

                string[] row1 = new string[bmp.Width];
                string[] row2 = new string[bmp.Width];
                string[] row3 = new string[bmp.Width];


                dataGridView1.ColumnCount = bmp.Width;
                dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);

                dataGridView2.ColumnCount = bmp.Width;
                dataGridView3.ColumnCount = bmp.Width;
                for (int i = 0; i < bmp.Width; i++)
                {
                    dataGridView1.Columns[i].Width = 40;
                    dataGridView2.Columns[i].Width = 40;
                    dataGridView3.Columns[i].Width = 40;
                }


                if (flag != 1)
                {
                    int counter = 0;
                    int poz = 0;
                    for (int i = 0; i < bmp.Height; i++)
                    {
                        for (int j = 0; j < bmp.Width; j++)
                        {
                            row1[j] = val[counter + poz].ToString();
                            row2[j] = val[counter + 1 + poz].ToString();
                            row3[j] = val[counter + 2 + poz].ToString();
                            counter += bmp.Height * 3;

                        }
                        dataGridView1.Rows.Add(row2);
                        dataGridView2.Rows.Add(row3);
                        dataGridView3.Rows.Add(row1);
                        counter = 0;
                        poz += 3;

                    }


                }
                else
                {
                    tabControl1.Controls.Clear();
                    tabControl1.Controls.Add(tabPage1);
                    tabPage1.Text = "Grey";
                    int counter = 0;
                    int poz = 0;
                    for (int i = 0; i < bmp.Height; i++)
                    {
                        for (int j = 0; j < bmp.Width; j++)
                        {
                            row1[j] = val[counter + poz].ToString();
                            row2[j] = val[counter + 1 + poz].ToString();
                            row3[j] = val[counter + 2 + poz].ToString();
                            counter += bmp.Height * 3;

                        }
                        dataGridView1.Rows.Add(row1);
                        dataGridView2.Rows.Add(row1);
                        dataGridView3.Rows.Add(row1);
                        counter = 0;
                        poz += 3;

                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Image too big for mapping", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Bitmap b = pic.getPicture();
            int c = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            b.SetPixel(e.ColumnIndex, e.RowIndex, Color.FromArgb(c, c, c));
            pic.RefreshBMP();
        }

        public Map(Bitmap bmp, string text, int flag)
        {

            try
            {

                byte[] val;

                InitializeComponent();
                this.Text = text;
                bitFast bf = new bitFast(bmp);
                string[] row1 = new string[bmp.Width];
                string[] row2 = new string[bmp.Width];
                string[] row3 = new string[bmp.Width];
                bf.BufferMemory(bmp);
                val = bf.TakeTAB();

                dataGridView1.ColumnCount = bmp.Width;
                dataGridView2.ColumnCount = bmp.Width;
                dataGridView3.ColumnCount = bmp.Width;
                dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                for (int i = 0; i < bmp.Width; i++)
                {
                    dataGridView1.Columns[i].Width = 40;
                    dataGridView2.Columns[i].Width = 40;
                    dataGridView3.Columns[i].Width = 40;
                }


                if (flag != 1)
                {
                    int counter = 0;
                    int poz = 0;
                    for (int i = 0; i < bmp.Height; i++)
                    {
                        for (int j = 0; j < bmp.Width; j++)
                        {
                            row1[j] = val[counter + poz].ToString();
                            row2[j] = val[counter + 1 + poz].ToString();
                            row3[j] = val[counter + 2 + poz].ToString();
                            counter += bmp.Height * 3;

                        }
                        dataGridView1.Rows.Add(row2);  //g
                        dataGridView2.Rows.Add(row3);  //r
                        dataGridView3.Rows.Add(row1);  //b
                        counter = 0;
                        poz += 3;

                    }

                }
                else
                {
                    tabControl1.Controls.Clear();
                    tabControl1.Controls.Add(tabPage1);
                    tabPage1.Text = "Grey";
                    for (int i = 0; i < bmp.Height; i++)
                    {
                        for (int j = 0; j < bmp.Width; j++)
                            row1[j] = Convert.ToString(val[i * bmp.Width + j]);

                        dataGridView1.Rows.Add(row1);
                        dataGridView2.Rows.Add(row1);
                        dataGridView3.Rows.Add(row1);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Image too big for mapping", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public Map(byte[] val, int w, int h, int flag, string text)
        {
            try
            {
                InitializeComponent();
                this.Text = text;
                string[] row1 = new string[w];
                string[] row2 = new string[w];
                string[] row3 = new string[w];
                dataGridView1.ColumnCount = w;
                dataGridView2.ColumnCount = w;
                dataGridView3.ColumnCount = w;

                dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);

                if (flag != 1)
                {
                    int counter = 0;
                    int poz = 0;
                    for (int i = 0; i < h; i++)
                    {
                        for (int j = 0; j < w; j++)
                        {
                            row1[j] = val[counter + poz].ToString();
                            row2[j] = val[counter + 1 + poz].ToString();
                            row3[j] = val[counter + 2 + poz].ToString();
                            counter += h * 3;

                        }
                        dataGridView1.Rows.Add(row2);
                        dataGridView2.Rows.Add(row3);
                        dataGridView3.Rows.Add(row1);
                        counter = 0;
                        poz += 3;

                    }

                }
                else
                {
                    tabControl1.Controls.Clear();
                    tabControl1.Controls.Add(tabPage1);
                    tabPage1.Text = "Grey";
                    for (int i = 0; i < h; i++)
                    {
                        for (int j = 0; j < w; j++)
                            row1[j] = Convert.ToString(val[i * w + j]);

                        dataGridView1.Rows.Add(row1);
                        dataGridView2.Rows.Add(row1);
                        dataGridView3.Rows.Add(row1);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Image too big for mapping", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public Map(float[] val, int w, int h, int flag, string text)
        {
            try
            {
                this.Text = text;
                InitializeComponent();

                string[] row1 = new string[w];
                string[] row2 = new string[w];
                string[] row3 = new string[w];

                dataGridView1.ColumnCount = w;
                dataGridView2.ColumnCount = w;
                dataGridView3.ColumnCount = w;

                dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);

                if (flag != 1)
                {
                    for (int i = 0; i < h; i++)
                    {
                        int k = 0;
                        for (int j = 0; j < (3 * w - 2); j = j + 3)
                        {
                            row1[k] = Convert.ToString(val[i * w + j]);
                            row2[k] = Convert.ToString(val[i * w + j + 1]);
                            row3[k] = Convert.ToString(val[i * w + j + 2]);
                            k++;
                        }
                        dataGridView1.Rows.Add(row2);
                        dataGridView2.Rows.Add(row3);
                        dataGridView3.Rows.Add(row1);
                    }

                }
                else
                {
                    tabControl1.Controls.Clear();
                    tabControl1.Controls.Add(tabPage1);
                    tabPage1.Text = "Grey";
                    for (int i = 0; i < h; i++)
                    {
                        for (int j = 0; j < w; j++)
                            row1[j] = Convert.ToString(val[i * w + j]);

                        dataGridView1.Rows.Add(row1);
                        dataGridView2.Rows.Add(row1);
                        dataGridView3.Rows.Add(row1);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Image too big for mapping", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void SelectCell(int x, int y)
        {
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;
            dataGridView3.MultiSelect = false;
            dataGridView1[x, y].Selected = true;
            dataGridView2[x, y].Selected = true;
            dataGridView3[x, y].Selected = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (pic != null) pic.setMap(null);
            base.OnClosed(e);
        }

    }
}