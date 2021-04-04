using System;
using System.Drawing;
namespace APO_TarasKuts16555
{
 public class Container
    {
        public Bitmap bm;
        public int flag;
        public string name;

        public Container(string n, Bitmap b, int f)
        {
            this.name = n;
            this.bm = (Bitmap)b.Clone();
            this.flag = f;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}

