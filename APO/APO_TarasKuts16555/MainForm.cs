using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_TarasKuts16555
{
    public partial class MainForm : Form
    {
        private Picture picture;
        private bitFast fast;
        private int index;
        private uint counter;
        private int witdh;
        private int height;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            convertToGrayscaleToolStripMenuItem.Enabled = false;
            counter = 0;
            DisHelper();
        }
        public void DisHelper()
        {
            operationsToolStripMenuItem.Enabled = false;
            zoomINToolStripMenuItem.Enabled = false;
            zoomOUTToolStripMenuItem.Enabled = false;
            cUTToolStripMenuItem.Enabled = false;
            mapToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
        }
        public void Helper()
        {
            operationsToolStripMenuItem.Enabled = true;
            zoomINToolStripMenuItem.Enabled = true;
            zoomOUTToolStripMenuItem.Enabled = true;
            cUTToolStripMenuItem.Enabled = true;
            mapToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to close this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "",
                Filter = ".bmp|*.bmp"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.ReadWrite);
                Bitmap bmp = new Bitmap(stream);
                if (bmp.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    fast = new bitFast(bmp.Width, bmp.Height, 1);
                    fast.BufferMemory(bmp);
                    byte[] buffer = fast.TakeTAB();
                    byte[] v = new byte[buffer.Length * 3];
                    index = 0;
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        v[index] = buffer[i];
                        v[index + 1] = buffer[i];
                        v[index + 2] = buffer[i];
                        index += 3;
                    }
                    picture = new Picture(v, bmp.Width, bmp.Height, dialog.FileName, 1, this)
                    {
                        Text = "Image_" + this.counter
                    };
                    picture.SetName("Image_" + this.counter);
                    this.counter++;
                    picture.MdiParent = this;
                    picture.Show();
                    convertToGrayscaleToolStripMenuItem.Enabled = true;
                    stream.Close();
                }
                else
                {
                    fast = new bitFast(bmp);
                    fast.BufferMemory(bmp);
                    picture = new Picture(fast.TakeTAB(), bmp.Width, bmp.Height, dialog.FileName, this)
                    {
                        Text = "Image_" + this.counter
                    };
                    picture.SetName("Image_" + this.counter);
                    this.counter++;
                    picture.MdiParent = this;
                    picture.Show();
                    stream.Close();
                }
                convertToGrayscaleToolStripMenuItem.Enabled = true;
            }
        }
        private void radiometricCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submiss submiss = new submiss(this, 0);
            for (int i = 0; i < base.MdiChildren.Length; i++)
            {
                if (base.MdiChildren[i] is Picture)
                {
                    submiss.add_to_list(((Picture)base.MdiChildren[i]).Text, ((Picture)base.MdiChildren[i]).getPicture(), ((Picture)base.MdiChildren[i]).GetFlag());
                }
            }
            submiss.MdiParent = this;
            submiss.Show();
        }

        private void discortionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submiss submiss = new submiss(this, 1);
            for (int i = 0; i < base.MdiChildren.Length; i++)
            {
                if (base.MdiChildren[i] is Picture)
                {
                    Console.WriteLine(((Picture)base.MdiChildren[i]).Text);
                    submiss.add_to_list(((Picture)base.MdiChildren[i]).Text, ((Picture)base.MdiChildren[i]).getPicture(), ((Picture)base.MdiChildren[i]).GetFlag());
                }
            }
            submiss.MdiParent = this;
            submiss.Show();
        }

        private void createBrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (base.ActiveMdiChild is Picture)
            {
                Bitmap bmp = new Bitmap(((Picture)base.ActiveMdiChild).getPicture().Width, ((Picture)base.ActiveMdiChild).getPicture().Height);
                bitFast fast = new bitFast(bmp);
                fast.BufferMemory(bmp);
                byte[] tablica = fast.TakeTAB();
                for (int i = 0; i < tablica.Length; i++)
                {
                    tablica[i] = 0xff;
                }
                fast.LoadToBitmap(tablica, bmp);
                Picture p = new Picture(tablica, bmp.Width, bmp.Height, "", 3, this)
                {
                    Text = "Light image " + base.ActiveMdiChild.Text,
                    MdiParent = this
                };
                p.Show();
                CreateDarkImage distortion = new CreateDarkImage(p.getPicture(), p)
                {
                    MdiParent = this
                };
                distortion.Show();
                p.SetD2(distortion);
            }
            else
            {
                MessageBox.Show("Choose image", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public uint get_counter()
        {
            return this.counter;
        }
        private void createDarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (base.ActiveMdiChild is Picture)
            {
                Bitmap bmp = new Bitmap(((Picture)base.ActiveMdiChild).getPicture().Width, ((Picture)base.ActiveMdiChild).getPicture().Height);
                bitFast fast = new bitFast(bmp);
                fast.BufferMemory(bmp);
                byte[] tablica = fast.TakeTAB();
                for (int i = 0; i < tablica.Length; i++)
                {
                    tablica[i] = 0;
                }
                fast.LoadToBitmap(tablica, bmp);
                Picture p = new Picture(tablica, bmp.Width, bmp.Height, "", 2, this)
                {
                    Text = "Dark image " + base.ActiveMdiChild.Text,
                    MdiParent = this
                };
                p.Show();
                CreateLightImage distortion = new CreateLightImage(p.getPicture(), p)
                {
                    MdiParent = this
                };
                distortion.Show();
                p.SETd(distortion);
            }
            else
            {
                MessageBox.Show("Choose image", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void zoomINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is Picture)
            {
                Picture o = (Picture)this.ActiveMdiChild;
                o.ZoomIN();
                if (o.GetZoom() != 10)
                {
                    if (o.GetZoom() > 10)
                    {
                        o.Text = o.GetName() + " " + (o.GetZoom() - 10) + "0%";
                    }
                    else
                    {
                        o.Text = o.GetName() + " -" + (10 - o.GetZoom()) + "0%";
                    }
                }
                else
                {
                    o.Text = o.GetName();
                }

            }
        }

        private void zoomOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is Picture)
            {
                Picture o = (Picture)this.ActiveMdiChild;
                o.ZoomOUT();
                if (o.GetZoom() != 10)
                {
                    if (o.GetZoom() > 10)
                    {
                        o.Text = o.GetName() + " " + (o.GetZoom() - 10) + "0%";
                    }
                    else
                    {
                        o.Text = o.GetName() + " -" + (10 - o.GetZoom()) + "0%";
                    }
                }
                else
                {
                    o.Text = o.GetName();
                }

            }
        }

     
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is Picture)
            {
                Picture o = (Picture)this.ActiveMdiChild;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Bitmap Image|*.bmp";
                saveFileDialog1.Title = "Save as";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    o.path = saveFileDialog1.FileName;
                    o.getPicture().Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                    fs.Close();
                }
            }
            else
            {
                MessageBox.Show("Choose image", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void loadBrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"";
            openFile.Filter = ".bmp|*.bmp";
            Picture p;
            bitFast bf;
            byte[] val;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.Open(openFile.FileName, FileMode.Open, FileAccess.ReadWrite);
                bmp = new Bitmap(fs);
                bf = new bitFast(bmp);
                bf.BufferMemory(bmp);
                val = bf.TakeTAB();
                p = new Picture(val, bmp.Width, bmp.Height, openFile.FileName, this);
                p.Text = "Light image" + counter;
                counter++;
                p.MdiParent = this;
                p.Show();
                fs.Close();
            }
        }

        private void loadDarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"";
            ofd.Filter = ".bmp|*.bmp";
            Picture p;
            bitFast bf;
            byte[] val;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.ReadWrite);
                bmp = new Bitmap(fs);
                bf = new bitFast(bmp);
                bf.BufferMemory(bmp);
                val = bf.TakeTAB();
                p = new Picture(val, bmp.Width, bmp.Height, ofd.FileName, this);
                p.Text = "Dark image" + counter;
                counter++;
                p.MdiParent = this;
                p.Show();
                fs.Close();
            }
        }

        private void cUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is Picture)
            {
                CUT Cut = new CUT((Picture)this.ActiveMdiChild, this);
                Cut.MdiParent = this;
                ((Picture)this.ActiveMdiChild).set_wptr(Cut);
                Cut.Show();
            }
        }

        private void mapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (base.ActiveMdiChild is Picture)
                {
                    Map mapa = new Map(((Picture)base.ActiveMdiChild).getPicture(), ((Picture)base.ActiveMdiChild).Text, ((Picture)base.ActiveMdiChild).GetFlag(), (Picture)base.ActiveMdiChild)
                    {
                        MdiParent = this
                    };
                    ((Picture)base.ActiveMdiChild).setMap(mapa);
                    mapa.Show();
                }
                else
                {
                    MessageBox.Show("Choose image","Info",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void iNFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author Taras Kuts 16555");
        }
        private void convertToGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is Picture)
            {
                Bitmap bmp = (Bitmap)((Picture)this.ActiveMdiChild).getPicture().Clone();
                byte[] val;
                byte sr;
                bitFast bf = new bitFast(bmp);
                bf.BufferMemory(bmp);
                val = bf.TakeTAB();
                for (int i = 0; i < val.Length; i += 3)
                {
                    sr = (byte)((val[i] + val[i + 1] + val[i + 2]) / 3);
                    val[i] = sr;
                    val[i + 1] = sr;
                    val[i + 2] = sr;
                }
                bf.LoadToBitmap(val, bmp);
                Picture p = new Picture(val, bmp.Width, bmp.Height, "", 1, this);
                p.Text = "Grayscale " + ((Picture)this.ActiveMdiChild).Text;
                p.MdiParent = this;
                p.Show();
                Helper();
            }
        }
    }

     
}

