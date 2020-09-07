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
    public partial class KayanYazilarForm : Form
    {
        // Paragraflar okunduktan sonra, random karıştırılabilir
        // Paragraflar İnternet bağlantısı varsa wikipedia'dan çekileiblir
        // Paragraflar kullanıcı girişli olarak düzenlenebilir.

        int sure = 0;
        List<String> TumYaziDosyaIsimleri, OkunanVeri;
        string RootDirectory;
        public KayanYazilarForm()
        {
            InitializeComponent();

            RootDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            TumYaziDosyaIsimleri = Directory.GetFiles(RootDirectory + @"\resources\", "*.*", SearchOption.AllDirectories).ToList();

            OkunanVeri = new List<string>();

            label1.Text = "";
            label2.Visible = false;

            string[] lines = File.ReadAllLines(TumYaziDosyaIsimleri[0]);
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    OkunanVeri.Add(words[i]);
                }
            }



            // Seviye diğer formdan gelecek
            int seviye = 1;

            yaziHizi = new System.Windows.Forms.Timer();
            yaziHizi.Tick += new EventHandler(yaziHizi_Tick);
            if (seviye == 1)
                yaziHizi.Interval = 100;
            else
                yaziHizi.Interval = (1000 / 10) * seviye;
            yaziHizi.Enabled = true;


            zamanlayici = new System.Windows.Forms.Timer();
            zamanlayici.Tick += new EventHandler(zamanlayici_Tick);
            zamanlayici.Interval = 1000;
            zamanlayici.Enabled = true;
        }

        private void KayanYazilarForm_SizeChanged(object sender, EventArgs e)
        {
            this.Text = "Width : " + this.Width.ToString() + " " + "Height : " + this.Height.ToString() + " Sure = " + sure.ToString(); ;
        }

        private void zamanlayici_Tick(object sender, EventArgs e)
        {
            if (sure == 90)
                this.Close();
            else
                sure++;
        }

        int sayac = 0;
        private void yaziHizi_Tick(object sender, EventArgs e)
        {
            this.Text = "Width : " + this.Width.ToString() + " " + "Height : " + this.Height.ToString() + " Sure = " + sure.ToString();
            label1.Location = new Point(label1.Location.X , panel1.Height / 2 - label1.Height/2);
            label2.Text = OkunanVeri[sayac];
            if (label1.Width + label2.Width < panel1.Width)
                label1.Text += " " + OkunanVeri[sayac];
            else
                label1.Text = OkunanVeri[sayac];

            if (sayac < OkunanVeri.Count-1)
                sayac++;
            else
                sayac = 0;


            if (sure >= 60 && yaziHizi.Interval != 800)
                yaziHizi.Interval = 800;
            else if (sure >= 30 && yaziHizi.Interval != 500)
                yaziHizi.Interval = 500;
            else
                yaziHizi.Interval = 200;
        }
    }
}
