using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HizliOkuma
{
    public partial class KayanResimlerForm : Form
    {
        int seviye, sure;
        List<String> TumResimDosyaIsimleri;
        string RootDirectory;
        public KayanResimlerForm()
        {
            InitializeComponent();
            RootDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            TumResimDosyaIsimleri = Directory.GetFiles(RootDirectory + @"\images\KayanResimler\", "*.*", SearchOption.AllDirectories).ToList();

            // Seviye diğer formdan gelecek
            seviye = 1;

            ResimHizi = new System.Windows.Forms.Timer();
            ResimHizi.Tick += new EventHandler(timer1_Tick);
            if (seviye == 1)
                ResimHizi.Interval = 100;
            else
                ResimHizi.Interval = (1000 / 10) * seviye;
            ResimHizi.Enabled = true;

            Zamanlayici = new System.Windows.Forms.Timer();
            Zamanlayici.Tick += new EventHandler(Zamanlayici_Tick);
            Zamanlayici.Interval = 1000;
            Zamanlayici.Enabled = true;
        }

        private void KayanResimlerForm_SizeChanged(object sender, EventArgs e)
        {
            this.Text = "Width : " + this.Width.ToString() + " " + "Height : " + this.Height.ToString();
        }

        int siradakiResim = 0;
        int katsayi = 0;
        int turSayisi = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "Width : " + this.Width.ToString() + " " + "Height : " + this.Height.ToString();
            PictureBox picture = new PictureBox();
            picture.Name = "pictureBox";
            picture.Size = new Size(100, 100);
            picture.Location = new Point(0 + (katsayi * 100), panel1.Height / 2 - 50);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            if(siradakiResim + katsayi < TumResimDosyaIsimleri.Count())
                picture.Image = Image.FromFile(TumResimDosyaIsimleri[katsayi + siradakiResim]);
            else
            {
                siradakiResim = 0;
                picture.Image = Image.FromFile(TumResimDosyaIsimleri[katsayi + siradakiResim]);
            }
            panel1.Controls.Add(picture);
            this.Text += " " + picture.Location.X.ToString() + "," + picture.Location.Y.ToString() + "Sure = " + sure.ToString();
            katsayi++;
            if(katsayi * 100 > panel1.Width)
            {
                panel1.Controls.Clear();
                siradakiResim = katsayi + siradakiResim;
                katsayi = 0;
                turSayisi++;
                if (turSayisi % 5 == 0)
                {
                    if(turSayisi == 15)
                    {
                        turSayisi = 0;
                        ResimHizi.Interval = 100;
                    }
                    else if (turSayisi % 10 == 0)
                        ResimHizi.Interval += 150;
                    else
                        ResimHizi.Interval -= 50;
                }
            }
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            if (sure == 90)
                this.Close();
            else
                sure++;
        }
    }

}
