using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO_TarasKuts16555
{
    class bitFast
    {
        private byte[] Values;
        private int multiplier;

        public bitFast(Bitmap bmp)
        {
            Values = new byte[bmp.Width * bmp.Height * 3];
            multiplier = 3;
        }

        public bitFast(int witdh, int height, int multiplier)
        {
            Values = new byte[witdh * height * multiplier];
            multiplier = 1;
        }

        public void BufferMemory(Bitmap bmp)
        {
            int counter = 0;
            unsafe
            {
                BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                byte* ptr = (byte*)bd.Scan0;

                if (multiplier > 1)
                {
                    for (int i = 0; i < bd.Width; i++)
                    {
                        for (int j = 0; j < bd.Height; j++)
                        {

                            Values[counter] = ptr[(j * bd.Stride) + (i * 3)];
                            Values[counter + 1] = ptr[(j * bd.Stride) + (i * 3) + 1];
                            Values[counter + 2] = ptr[(j * bd.Stride) + (i * 3) + 2];
                            counter += 3;
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < bd.Width; i++)
                        for (int j = 0; j < bd.Height; j++)
                        {
                            Values[counter] = ptr[(j * bd.Stride) + (i)];
                            counter++;
                        }

                }
                bmp.UnlockBits(bd);

            }

        }

        public void LoadToBitmap(byte[] tablica, Bitmap bmp)
        {
            int counter = 0;
            unsafe
            {
                BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

                byte* ptr = (byte*)bd.Scan0;

                if (multiplier > 1)
                {
                    for (int i = 0; i < bd.Width; i++)
                    {
                        for (int j = 0; j < bd.Height; j++)
                        {
                            ptr[(j * bd.Stride) + (i * 3)] = tablica[counter];
                            ptr[(j * bd.Stride) + (i * 3) + 1] = tablica[counter + 1];
                            ptr[(j * bd.Stride) + (i * 3) + 2] = tablica[counter + 2];
                            counter += 3;
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < bd.Width; i++)
                    {
                        for (int j = 0; j < bd.Height; j++)
                        {
                            ptr[(j * bd.Stride) + (i)] = Values[counter];
                            counter++;
                        }
                    }
                }
                bmp.UnlockBits(bd);
            }



        }

        public byte[] TakeTAB()
        {
            return this.Values;
        }
    }
}

