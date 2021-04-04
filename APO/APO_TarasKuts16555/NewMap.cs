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
    public partial class NewMap : Form
    {
        private int witdh;
        private int height;
        public NewMap()
        {
            InitializeComponent();
            Int32.TryParse(txtHeight.Text, out height);
            Int32.TryParse(txtWitdh.Text, out witdh);
        }

        public int GetWidth
        {
            get
            {
                return witdh;
            }
        }

        public int GetHeight
        {
            get
            {
                return height;
            }
        }
    }
}
