using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleImageProcessing;
//using AForge.Imaging;

namespace one_click
{
    public partial class mainwindow : Form
    {
        public byte div, offset;
        public int kernel_w, kernel_h;
        public int[,] kernel;
        public mainwindow()

        {
            InitializeComponent();
        }

        private void hi_Click(object sender, EventArgs e)
        {

        }

        private void beginpic_Click_1(object sender, EventArgs e)
        {
            hi.Hide();
            begin.Hide();
            beginpic.Hide();

            open.Show();
            save.Show();
            reset.Show();

            open_Click(sender, EventArgs.Empty);

        }

        private void begin_Click(object sender, EventArgs e)
        {
            beginpic_Click_1(sender, EventArgs.Empty);
        }

        public Bitmap origin_size_image, image_l, nashville1, win;
        public ImagerBitmap dst, dsp, image_l1;
        public float w, h;
        public int a;

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog() { Filter = "Файл изображения|*.jpg" };
            var result = op.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                fon.Show();
                inv.Show();
                shrp.Show();
                blr.Show();
                cld.Show();
                hp.Show();
                nshv.Show();
                wlw.Show();
                pb.Show();
                ht.Show();
                clg.Show();

                if (origin_size_image != null)
                {
                    origin_size_image.Dispose();
                }

                origin_size_image = (Bitmap)Image.FromFile(op.FileName);
                w = origin_size_image.Width;
                h = origin_size_image.Height;

                if (origin_size_image.Width >= 150 && origin_size_image.Width >= origin_size_image.Height)
                {
                    float k = (float)origin_size_image.Width / 150;
                    w = 150;
                    h = origin_size_image.Height / k;
                }
                else if (origin_size_image.Height >= 120 && origin_size_image.Width < origin_size_image.Height)
                {
                    float k = (float)origin_size_image.Height / 120;
                    h = 120;
                    w = origin_size_image.Width / k;
                }


                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                inversion();
                kern();
                inv.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                sharpen();
                kern();
                shrp.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                blur();
                kern();
                blr.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                cold();
                cld.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                hope();
                hp.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                nashville();
                nshv.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                willow();
                wlw.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                bp();
                pb.Image = image_l;

                image_l = new Bitmap(origin_size_image, (int)w, (int)h);
                heat();
                ht.Image = image_l;

                h *= 2;
                w *= 2;

                image_l = new Bitmap(origin_size_image, (int)(w), (int)(h));
                collage();
                clg.Image = image_l;

                w = origin_size_image.Width;
                h = origin_size_image.Height;

                if (origin_size_image.Width >= 1340 && origin_size_image.Width >= origin_size_image.Height)
                {
                    float k = (float)origin_size_image.Width / 1340;
                    w = 1340;
                    h = origin_size_image.Height / k;
                }
                if (origin_size_image.Height >= 860 && origin_size_image.Width < origin_size_image.Height)
                {
                    float k = (float)origin_size_image.Height / 860;
                    h = 860;
                    w = origin_size_image.Width / k;
                }
                image_l = new Bitmap(origin_size_image, (int)w, (int)h);

                this.BackgroundImage = image_l;
                this.BackColor = Color.Black;
                fon.Show();
                fon.BackColor = Color.Transparent;
            }
        }

        private void inv_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            inversion();
            kern();
            this.BackgroundImage = image_l;
            a = 1;
        }

        private void shrp_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            sharpen();
            kern();
            this.BackgroundImage = image_l;
            a = 2;
        }

        private void blur_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
          //  blur();
            kerng();

            this.BackgroundImage = image_l;
            a = 3;
        }

        private void cld_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            cold();
            this.BackgroundImage = image_l;
            a = 4;
        }

        private void hp_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            hope();
            a = 5;
            this.BackgroundImage = image_l;
        }

        private void nshv_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            nashville();
            a = 6;
            this.BackgroundImage = image_l;
        }

        private void wlw_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            willow();
            a = 7;
            this.BackgroundImage = image_l;
        }

        private void pb_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            bp();
            a = 8;
            this.BackgroundImage = image_l;
        }

        private void ht_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)w, (int)h);
            heat();
            a = 9;
            this.BackgroundImage = image_l;
        }

        private void clg_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            reset.Enabled = true;
            image_l = new Bitmap(origin_size_image, (int)(w / 2), (int)(h / 2));
            collage();
            a = 10;
            this.BackgroundImage = image_l;
        }


        void inversion()
        {
            kernel = new int[1, 1];

            kernel[0, 0] = -1;

            div = 1;
            offset = 255;
            kernel_h = kernel_w = 1;
        }

        void sharpen()
        {
            kernel = new int[3, 3];

            kernel[0, 0] = -1;
            kernel[1, 0] = -1;
            kernel[2, 0] = -1;

            kernel[0, 1] = -1;
            kernel[1, 1] = 9;
            kernel[2, 1] = -1;

            kernel[0, 2] = -1;
            kernel[1, 2] = -1;
            kernel[2, 2] = -1;


            div = 1;
            offset = 0;
            kernel_h = kernel_w = 3;
        }

        void blur()
        {
            kernel = new int[7, 7];

            kernel[0, 0] = 1;
            kernel[1, 0] = 1;
            kernel[2, 0] = 1;
            kernel[3, 0] = 1;
            kernel[4, 0] = 1;
            kernel[5, 0] = 1;
            kernel[6, 0] = 1;

            kernel[0, 1] = 1;
            kernel[1, 1] = 1;
            kernel[2, 1] = 1;
            kernel[3, 1] = 1;
            kernel[4, 1] = 1;
            kernel[5, 1] = 1;
            kernel[6, 1] = 1;

            kernel[0, 2] = 1;
            kernel[1, 2] = 1;
            kernel[2, 2] = 1;
            kernel[3, 2] = 1;
            kernel[4, 2] = 1;
            kernel[5, 2] = 1;
            kernel[6, 2] = 1;

            kernel[0, 3] = 1;
            kernel[1, 3] = 1;
            kernel[2, 3] = 1;
            kernel[3, 3] = 1;
            kernel[4, 3] = 1;
            kernel[5, 3] = 1;
            kernel[6, 3] = 1;

            kernel[0, 4] = 1;
            kernel[1, 4] = 1;
            kernel[2, 4] = 1;
            kernel[3, 4] = 1;
            kernel[4, 4] = 1;
            kernel[5, 4] = 1;
            kernel[6, 4] = 1;

            kernel[0, 5] = 1;
            kernel[1, 5] = 1;
            kernel[2, 5] = 1;
            kernel[3, 5] = 1;
            kernel[4, 5] = 1;
            kernel[5, 5] = 1;
            kernel[6, 5] = 1;

            kernel[0, 6] = 1;
            kernel[1, 6] = 1;
            kernel[2, 6] = 1;
            kernel[3, 6] = 1;
            kernel[4, 6] = 1;
            kernel[5, 6] = 1;
            kernel[6, 6] = 1;


            div = 49;
            offset = 0;
            kernel_h = kernel_w = 7;
        }

        void cold()
        {

            GC.Collect();
            win = new Bitmap(one_click.Properties.Resources.ramka, (int)w, (int)h);
            dst = new ImagerBitmap(image_l);
            dsp = new ImagerBitmap(win);

            Enumerable.Range(0, (int)w).AsParallel().ForAll(x =>
            {
                var color = new Color();
                var color1 = new Color();
                for (int y = 0; y < (int)h; y++)
                {
                    color = dst.GetPixel(x, y);
                    color1 = dsp.GetPixel(x, y);

                    float brght = color.GetBrightness();

                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;

                    float brght1 = color1.GetBrightness();

                    byte r1 = color1.R;
                    byte g1 = color1.G;
                    byte b1 = color1.B;

                    r = (byte)((r * 0.35 + ((brght) * r + (1 - brght) * 100) * 0.65));
                    b = (byte)((b * 0.7 + ((1 - brght) * b + (brght) * 255) * 0.3));

                    dst.SetPixel(x, y, Color.FromArgb((byte)(r * (1 - brght1) + r1 * brght1), (byte)(g * (1 - brght1) + g1 * brght1), (byte)(b * (1 - brght1) + b1 * brght1)));
                }
            });

            dst.UnlockBitmap();
            dsp.UnlockBitmap();
            image_l = dst.Bitmap;
        }

        void kern()
        {


            var dst = new ImagerBitmap(image_l);
            var image_l1 = new ImagerBitmap(image_l);


            Enumerable.Range(kernel_h / 2, (int)w - kernel_h / 2 - 1).AsParallel().ForAll(x =>
            {
                var color = new Color();
                int rSum = 0, gSum = 0, bSum = 0;
                for (int y = kernel_w / 2; y < (int)h - kernel_w / 2 - 1; y++)
                {

                    for (int j = 0; j < kernel_h; j++)
                    {

                        for (int i = 0; i < kernel_w; i++)
                        {
                            color = image_l1.GetPixel(x - kernel_h / 2 + i, y - kernel_h / 2 + j);

                            byte r = color.R;
                            byte g = color.G;
                            byte b = color.B;
                            int a = kernel[i, j];

                            rSum += r * a;
                            gSum += g * a;
                            bSum += b * a;
                        }

                    }
                    rSum /= div;
                    gSum /= div;
                    bSum /= div;

                    rSum += offset;
                    gSum += offset;
                    bSum += offset;

                    if (rSum > 255) rSum = 255;
                    if (rSum < 0) rSum = 0;

                    if (gSum > 255) gSum = 255;
                    if (gSum < 0) gSum = 0;

                    if (bSum > 255) bSum = 255;
                    if (bSum < 0) bSum = 0;

                    dst.SetPixel(x, y, Color.FromArgb((byte)rSum, (byte)gSum, (byte)bSum));
                    rSum = gSum = bSum = 0;
                }

            });
            image_l1.UnlockBitmap();

            dst.UnlockBitmap();
            image_l1.Bitmap.Dispose();
            image_l = dst.Bitmap;
        }


        void kerng()
        {
            int[] kernel1;
            kernel1 = new int[11];

            kernel1[0] = 1;
            kernel1[1] = 2;
            kernel1[2] = 4;
            kernel1[3] = 8;
            kernel1[4] = 16;
            kernel1[5] = 32;
            kernel1[6] = 16;
            kernel1[7] = 8;
            kernel1[8] = 4;
            kernel1[9] = 2;
            kernel1[10] = 1;
            div = 94;
            var dst = new ImagerBitmap(image_l);
            var image_l1 = new ImagerBitmap(image_l);
            

            Enumerable.Range(7, (int)w - 7).AsParallel().ForAll(x =>
            {
                var color = new Color();
                int rSum = 0, gSum = 0, bSum = 0;
                for (int y = 7; y < (int)h-7 ; y++)
                {
                     for (int i = 0; i < 11; i++)
                        {
                            color = image_l1.GetPixel(x - 3 + i, y);

                            byte r = color.R;
                            byte g = color.G;
                            byte b = color.B;
                            int a = kernel1[i];

                            rSum += r * a;
                            gSum += g * a;
                            bSum += b * a;
                        }                  
                    rSum /= div;
                    gSum /= div;
                    bSum /= div;

                    rSum += offset;
                    gSum += offset;
                    bSum += offset;

                    if (rSum > 255) rSum = 255;
                    if (rSum < 0) rSum = 0;

                    if (gSum > 255) gSum = 255;
                    if (gSum < 0) gSum = 0;

                    if (bSum > 255) bSum = 255;
                    if (bSum < 0) bSum = 0;

                    dst.SetPixel(x, y, Color.FromArgb((byte)rSum, (byte)gSum, (byte)bSum));
                    rSum = gSum = bSum = 0;
                }          
});


            image_l1.UnlockBitmap();
         //   dst.UnlockBitmap();
            image_l1.Bitmap.Dispose();
            image_l = dst.Bitmap;

            var dsp = dst;
            var image_l2 = dst;


            Enumerable.Range(7, (int)h - 7).AsParallel().ForAll(y =>
            {
                var color = new Color();
                int rSum = 0, gSum = 0, bSum = 0;
                for (int x = 7; x < (int)w - 7; x++)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        color = dst.GetPixel(x, y - 3 + i);

                        byte r = color.R;
                        byte g = color.G;
                        byte b = color.B;
                        int a = kernel1[i];

                        rSum += r * a;
                        gSum += g * a;
                        bSum += b * a;
                    }
                    rSum /= div;
                    gSum /= div;
                    bSum /= div;

                    rSum += offset;
                    gSum += offset;
                    bSum += offset;

                    if (rSum > 255) rSum = 255;
                    if (rSum < 0) rSum = 0;

                    if (gSum > 255) gSum = 255;
                    if (gSum < 0) gSum = 0;

                    if (bSum > 255) bSum = 255;
                    if (bSum < 0) bSum = 0;

                    dsp.SetPixel(x, y, Color.FromArgb((byte)rSum, (byte)gSum, (byte)bSum));
                    rSum = gSum = bSum = 0;
                }
            });


            image_l2.UnlockBitmap();
            dsp.UnlockBitmap();
            dst.UnlockBitmap();
            image_l2.Bitmap.Dispose();
            image_l = dsp.Bitmap;
        }
        void hope()
        {
            GC.Collect();
            dst = new ImagerBitmap(image_l);

            Enumerable.Range(0, (int)w - 1).AsParallel().ForAll(x =>
                   {
                       var color = new Color();
                       for (int y = 0; y < (int)h - 1; y++)
                       {
                           color = dst.GetPixel(x, y);

                           float brght = color.GetBrightness();
                           byte r = color.R;
                           byte g = color.G;
                           byte b = color.B;

                           if (brght <= 0.35)
                           {
                               r = 0;
                               g = 50;
                               b = 77;
                           };
                           if (brght > 0.35 & brght <= 0.55)
                           {
                               r = 215;
                               g = 26;
                               b = 33;
                           };
                           if (brght > 0.55)
                           {
                               r = 252;
                               g = 228;
                               b = 168;
                           };

                           dst.SetPixel(x, y, Color.FromArgb(r, g, b));
                       }
                   });


            dst.UnlockBitmap();
            image_l = dst.Bitmap;
        }

        void nashville()
        {
            GC.Collect();
            win = new Bitmap(one_click.Properties.Resources.nashville, (int)w, (int)h);
            dst = new ImagerBitmap(image_l);
            dsp = new ImagerBitmap(win);

            Enumerable.Range(0, (int)w).AsParallel().ForAll(x =>
            {
                var color = new Color();
                var color1 = new Color();
                for (int y = 0; y < (int)h; y++)
                {
                    color = dst.GetPixel(x, y);
                    color1 = dsp.GetPixel(x, y);
                    float brght = color.GetBrightness();

                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;

                    byte r1 = color1.R;
                    byte g1 = color1.G;
                    byte b1 = color1.B;

                    b = (byte)(255 * brght);

                    dst.SetPixel(x, y, Color.FromArgb((byte)(r * 0.55 + r1 * 0.45), (byte)(g * 0.95 + g1 * 0.05), (byte)(b * 0.6 + b1 * 0.4)));

                }
            });

            dst.UnlockBitmap();
            dsp.UnlockBitmap();
            image_l = dst.Bitmap;
        }

        void willow()
        {
            GC.Collect();
            win = new Bitmap(one_click.Properties.Resources.willow1, (int)w, (int)h);
            dst = new ImagerBitmap(image_l);
            dsp = new ImagerBitmap(win);

            Enumerable.Range(0, (int)w).AsParallel().ForAll(x =>
            {
                var color = new Color();
                var color1 = new Color();
                for (int y = 0; y < (int)h; y++)
                {
                    color = dst.GetPixel(x, y);
                    color1 = dsp.GetPixel(x, y);
                    float brght = color.GetBrightness();

                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;

                    float brght1 = color1.GetBrightness();
                    byte r1 = color1.R;
                    byte g1 = color1.G;
                    byte b1 = color1.B;

                    g = b = r;

                    dst.SetPixel(x, y, Color.FromArgb((byte)(r * (1 - brght1) + r1 * brght1), (byte)(g * (1 - brght1) + g1 * brght1), (byte)(b * (1 - brght1) + b1 * brght1)));

                }
            });

            dst.UnlockBitmap();
            dsp.UnlockBitmap();
            image_l = dst.Bitmap;
            win.Dispose();
        }

        void heat()
        {
            GC.Collect();
            win = new Bitmap(one_click.Properties.Resources.vignette, (int)w, (int)h);
            dst = new ImagerBitmap(image_l);
            dsp = new ImagerBitmap(win);

            Enumerable.Range(0, (int)w).AsParallel().ForAll(x =>
            {
                var color = new Color();
                var color1 = new Color();
                for (int y = 0; y < (int)h; y++)
                {
                    color = dst.GetPixel(x, y);
                    color1 = dsp.GetPixel(x, y);

                    float brght = color.GetBrightness();
                    float brght1 = color1.GetBrightness();
                
                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;

                    byte r1 = color1.R;
                    byte g1 = color1.G;
                    byte b1 = color1.B;

                    g = (byte)((g * 0.65 + ((brght) * g + (1 - brght) * 120) * 0.35));


                    g = (byte)((g * 0.75 + ((1-brght) * g + (brght) *120) * 0.25));
                    r = (byte)((r * 0.75 + ((1 - brght) * r + (brght) * 255) * 0.25));
                    b = (byte)((b * 0.6 + ((1 - brght) * b + (brght) * 25) * 0.4));

                   // dst.SetPixel(x, y, Color.FromArgb((byte)( r1 ), (byte)( g1 ), (byte)( b1 )));
                    dst.SetPixel(x, y, Color.FromArgb((byte)(r * brght1 + r1 * (1 - brght1)), (byte)(g * brght1 + g1 * (1 - brght1)), (byte)(b * brght1 + b1 * (1-brght1))));
                }
            });

            dst.UnlockBitmap();

            image_l = dst.Bitmap;
        }

        void bp()
        {
            GC.Collect();
            win = new Bitmap(one_click.Properties.Resources.pb, (int)w, (int)h);
            dst = new ImagerBitmap(image_l);
            dsp = new ImagerBitmap(win);

            Enumerable.Range(0, (int)w).AsParallel().ForAll(x =>
            {
                var color = new Color();
                var color1 = new Color();
                for (int y = 0; y < (int)h; y++)
                {
                    color = dst.GetPixel(x, y);
                    color1 = dsp.GetPixel(x, y);
                    float brght = color.GetBrightness();

                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;

                    float brght1 = color1.GetBrightness();
                    byte r1 = color1.R;
                    byte g1 = color1.G;
                    byte b1 = color1.B;

                    if (brght < 0.15)
                    {
                        b = 50;
                    }

                    dst.SetPixel(x, y, Color.FromArgb((byte)(r * 0.3 + r1 * 0.7), (byte)(g * 0.9 + g1 * 0.1), (byte)(b * 0.9 + b1 * 0.1)));

                }
            });

            dst.UnlockBitmap();
            dsp.UnlockBitmap();
            image_l = dst.Bitmap;
            win.Dispose();
        }

        void collage()
        {
            GC.Collect();


            win = new Bitmap(one_click.Properties.Resources.collage, (int)(w + w / 10), (int)(h + h / 10));

            dsp = new ImagerBitmap(image_l);

            dst = new ImagerBitmap(win);


            Enumerable.Range(0, (int)(w / 2)).AsParallel().ForAll(x =>
            {
                var color = new Color();


                for (int y = 0; y < (int)(h / 2); y++)
                {
                    color = dsp.GetPixel(x, y);


                    float brght = color.GetBrightness();


                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;

                    if (brght < 0.15)
                    {
                        b = 100;
                    }

                    if (brght >= 0.15 & brght < 0.3)
                    {
                        r = 50;
                        b = 50;
                    }

                    if (brght >= 0.3 & brght < 0.85)
                    {
                        r = 255;
                        g = 0;
                        b = 50;
                    }

                    if (brght >= 0.85)
                    {
                        g = 200;
                        b = 100;
                    }
                    dst.SetPixel((int)(x + w / 30), (int)(y + h / 30), Color.FromArgb(r, g, b));

                    /////////////////////////////////////////////
                    r = color.R;
                    g = color.G;
                    b = color.B;

                    if (brght < 0.15)
                    {
                        r = 20;
                        g = 20;
                    }

                    if (brght >= 0.15 & brght < 0.3)
                    {
                        g = 150;
                        b = 150;
                    }

                    if (brght >= 0.3 & brght < 0.85)
                    {
                        r = 55;
                        b = 255;
                    }

                    if (brght >= 0.85)
                    {
                        r = 190;
                        g -= 50;
                        b = 255;
                    }
                    dst.SetPixel((int)(x + 17 * w / 30), (int)(y + h / 30), Color.FromArgb(r, g, b));

                    /////////////////////////////////////////////
                    r = color.R;
                    g = color.G;
                    b = color.B;

                    if (brght < 0.15)
                    {
                        b = 75;
                        r = 75;
                    }

                    if (brght >= 0.15 & brght < 0.3)
                    {
                        r = 50;
                        b = 150;
                    }

                    if (brght >= 0.3 & brght < 0.85)
                    {
                        r = 255;
                        g = 175;
                        // b = 250;
                    }

                    if (brght >= 0.85)
                    {
                        g = 200;
                        b = 100;
                    }
                    dst.SetPixel((int)(x + 17 * w / 30), (int)(y + 17 * h / 30), Color.FromArgb(r, g, b));

                    /////////////////////////////////////////////
                    r = color.R;
                    g = color.G;
                    b = color.B;

                    if (brght < 0.15)
                    {
                        b = 100;
                        g = 100;
                    }

                    if (brght >= 0.15 & brght < 0.3)
                    {
                        r = 50;
                        b = 50;
                    }

                    if (brght >= 0.3 & brght < 0.85)
                    {
                        r -= 10;
                        g = 250;
                        b += 25;
                    }

                    if (brght >= 0.85)
                    {
                        g = 210;
                        b = 150;
                        r = 15;
                    }
                    dst.SetPixel((int)(x + w / 30), (int)(y + 17 * h / 30), Color.FromArgb(r, g, b));

                }
            });



            dst.UnlockBitmap();
            dsp.UnlockBitmap();

            image_l = dst.Bitmap;

        }

        private void save_Click(object sender, EventArgs e)
        {

            var sfd = new SaveFileDialog();
            sfd.Filter = "Файл изображения|*.jpg";
            image_l = new Bitmap(origin_size_image);
            h = origin_size_image.Height;
            w = origin_size_image.Width;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var fileName = sfd.FileName;
                var fileStream = File.Create(sfd.FileName);

                switch (a)
                {
                    case 0:
                        image_l = origin_size_image;
                        break;

                    case 1:
                        inversion();
                        kern();
                        break;

                    case 2:
                        sharpen();
                        kern();
                        break;

                    case 3:
                        blur();
                        kern();
                        break;

                    case 4:
                        cold();
                        break;

                    case 5:
                        hope();
                        break;

                    case 6:
                        nashville();
                        break;

                    case 7:
                        willow();
                        break;

                    case 8:
                        bp();
                        break;

                    case 9:
                        heat();
                        break;

                    case 10:
                        image_l = new Bitmap(origin_size_image, (int)(w / 2), (int)(h / 2));
                        collage();
                        break;
                }
                image_l.Save(fileStream, origin_size_image.RawFormat);
                fileStream.Close();
                image_l.Dispose();
            }
        }
        private void reset_Click(object sender, EventArgs e)
        {
            save.Enabled = false;
            reset.Enabled = false;
            this.BackgroundImage = origin_size_image;
        }

        private void Thr()
        {
            
            clock.Show();
        }
     }

}

