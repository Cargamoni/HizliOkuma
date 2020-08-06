using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HizliOkuma
{

    // To DO
    // Zaman 90 saniye olacak ve Seviyeye Göre değişecek Hız
    // TimeInterval 300 altına düşmeyecek
    // En sonunda kod düzenlenecek

    public enum kontrolcu
    {
        AsagiYukariSagaGidis,
        AsagiYukariSolaGidis,
        SagaSolaAsagiGidis,
        SagaSolaYukariGidis,
        CaprazSagaGidis,
        CaprazSagaGidisAsagi,
        CaprazSolaGidis,
        CaprazSolaGidisAsagi
    }

    public partial class ObjectMoveForm : Form
    {
        int width, height, surecik, xKatsayi, yKatsayi;
        bool first, second, third, fourth, fifth, sixth;
        Point TenisTopuReset;
        kontrolcu hareketKontrol;
        public ObjectMoveForm()
        {
            InitializeComponent();
            width = this.panel1.Width;
            height = this.panel1.Height;
            StartButton.Text = "Sureci";
            surecik = 0;
            WidthDebug.Text = "Width = " + width.ToString();
            HeightDebug.Text = "Height = " + height.ToString();
            LokasyonDebug.Text = TenisTopu.Location.X.ToString() + ", " + TenisTopu.Location.Y.ToString();
            TimerDebug.Text = surecik.ToString();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            first = true;
            second = false;
            third = false;
            fourth = false;
            fifth = false;
            sixth = false;
            hareketKontrol = kontrolcu.AsagiYukariSagaGidis;

            xKatsayi = panel1.Width / 10;
            yKatsayi = panel1.Height / 10;


            TenisTopuReset = TenisTopu.Location;
        }

        private void ObjectMoveForm_Resize(object sender, EventArgs e)
        {
            WidthDebug.Text = "Width = " + this.panel1.Width.ToString();
            HeightDebug.Text = "Height = " + this.panel1.Height.ToString();
            xKatsayi = panel1.Width / 10;
            yKatsayi = panel1.Height / 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
            {
                timer1.Enabled = true;
            }
        }

        // Resimdeki Topun Sağa Gidiş Fonksiyonu
        void AsagiYukariSagaGidis()
        {
            if (TenisTopu.Location.Y + TenisTopu.Height >= panel1.Height)
            {
                Point yNoktasi = new Point();
                if (TenisTopu.Location.X + TenisTopu.Width * 2 >= panel1.Width)
                {
                    hareketKontrol = kontrolcu.AsagiYukariSolaGidis;
                    AsagiYukariSolaGidis();
                }
                else
                {
                    yNoktasi = new Point(TenisTopu.Location.X + TenisTopu.Width * 2, 0);
                    TenisTopu.Location = yNoktasi;
                }
            }
            else
            {
                Point yNoktasi = new Point(TenisTopu.Location.X, panel1.Height - (TenisTopu.Height));
                TenisTopu.Location = yNoktasi;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Interval += 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Interval > 100)
                timer1.Interval -= 100;
        }



        // Resimdeki Topun Sola Gidiş Fonksiyonu
        void AsagiYukariSolaGidis()
        {
            //System.Windows.Forms.MessageBox.Show("Vololooooooooo");
            if (TenisTopu.Location.Y + TenisTopu.Height >= panel1.Height)
            {
                Point yNoktasi = new Point();
                if (TenisTopu.Location.X - TenisTopu.Width * 2 <= 0)
                {
                    hareketKontrol = kontrolcu.SagaSolaAsagiGidis;
                    TenisTopu.Location = new Point(TenisTopuReset.X, TenisTopuReset.Y);
                    SagaSolaAsagiGidis();
                }
                else
                {
                    yNoktasi = new Point(TenisTopu.Location.X - TenisTopu.Width * 2, 0);
                    TenisTopu.Location = yNoktasi;
                }
            }
            else
            {
                Point yNoktasi = new Point(TenisTopu.Location.X, panel1.Height - (TenisTopu.Height));
                TenisTopu.Location = yNoktasi;
            }
        }

        // Bu fonksiyon sağa sola aşağı doğru gidişi sağlar.
        void SagaSolaAsagiGidis()
        {
            Point yNoktasi;
            if (TenisTopu.Location.Y + TenisTopu.Height * 2 <= panel1.Height)
            {
                if (TenisTopu.Location.X + TenisTopu.Width * 2 <= panel1.Width)
                {
                    yNoktasi = new Point(panel1.Width - TenisTopu.Width, TenisTopu.Location.Y);
                    TenisTopu.Location = yNoktasi;
                }
                else
                    TenisTopu.Location = new Point(3, TenisTopu.Location.Y + TenisTopu.Height);
            }
            else
            {
                hareketKontrol = kontrolcu.SagaSolaYukariGidis;
                TenisTopu.Location = new Point(3, TenisTopu.Location.Y);
                SagaSolaYukariGidis();
            }
        }

        // Bu fonksiyon sağa sola yukarı doğru gidişi sağlar.
        void SagaSolaYukariGidis()
        {
            Point yNoktasi;
            if (TenisTopu.Location.X + TenisTopu.Width * 2 <= panel1.Width)
            {
                yNoktasi = new Point(panel1.Width - TenisTopu.Width, TenisTopu.Location.Y - TenisTopu.Height);
                TenisTopu.Location = yNoktasi;
            }
            else
            {
                TenisTopu.Location = new Point(3, TenisTopu.Location.Y);
            }

            if (TenisTopu.Location.Y < 0)
            {
                hareketKontrol = kontrolcu.CaprazSagaGidis;
                yNoktasi = new Point((panel1.Width - TenisTopu.Width) / 2, (panel1.Height - TenisTopu.Height) / 2);
                TenisTopu.Location = yNoktasi;
                CaprazSagaGidis();
            }
        }

        int katsayiArttirici = 1;
        void CaprazSagaGidis()
        {
            if (TenisTopu.Location.X < panel1.Width - TenisTopu.Width && TenisTopu.Location.Y < panel1.Height - TenisTopu.Width)
            {
                int yeniX = TenisTopu.Location.X + (xKatsayi * katsayiArttirici);
                int yeniY = TenisTopu.Location.Y - (yKatsayi * katsayiArttirici);
                Point yNoktasi = new Point(yeniX, yeniY);
                TenisTopu.Location = yNoktasi;
                hareketKontrol = kontrolcu.CaprazSagaGidisAsagi;
            }
            else
            {
                hareketKontrol = kontrolcu.CaprazSolaGidis;
                TenisTopu.Location = new Point((panel1.Width - TenisTopu.Width) / 2, (panel1.Height - TenisTopu.Height) / 2);
            }
            katsayiArttirici++;
        }

        
        void CaprazSagaGidisAsagi()
        {
            if (TenisTopu.Location.Y < panel1.Height - TenisTopu.Width && TenisTopu.Location.Y < panel1.Height - TenisTopu.Width)
            {
                int yeniX = TenisTopu.Location.X - (xKatsayi * katsayiArttirici);
                int yeniY = TenisTopu.Location.Y + (yKatsayi * katsayiArttirici);
                Point yNoktasi = new Point(yeniX, yeniY);
                TenisTopu.Location = yNoktasi;
                hareketKontrol = kontrolcu.CaprazSagaGidis;
            }
            else
            {
                hareketKontrol = kontrolcu.CaprazSolaGidis;
                TenisTopu.Location = new Point((panel1.Width - TenisTopu.Width) / 2, (panel1.Height - TenisTopu.Height) / 2);
            }
            katsayiArttirici++;
        }

        int katsayiArttirici2 = 1;
        void CaprazSolaGidis()
        {
            if (TenisTopu.Location.X < panel1.Width - TenisTopu.Width && TenisTopu.Location.Y < panel1.Height - TenisTopu.Width)
            {
                int yeniX = TenisTopu.Location.X - (xKatsayi * katsayiArttirici2);
                int yeniY = TenisTopu.Location.Y - (yKatsayi * katsayiArttirici2);
                Point yNoktasi = new Point(yeniX, yeniY);
                TenisTopu.Location = yNoktasi;
                hareketKontrol = kontrolcu.CaprazSolaGidisAsagi;
            }
            else
            {
                hareketKontrol = kontrolcu.AsagiYukariSagaGidis;
                TenisTopu.Location = new Point(3,3);
            }
            katsayiArttirici2++;
        }

        void CaprazSolaGidisAsagi()
        {
            if (TenisTopu.Location.Y < panel1.Height - TenisTopu.Width && TenisTopu.Location.Y < panel1.Height - TenisTopu.Width)
            {
                int yeniX = TenisTopu.Location.X + (xKatsayi * katsayiArttirici2);
                int yeniY = TenisTopu.Location.Y + (yKatsayi * katsayiArttirici2);
                Point yNoktasi = new Point(yeniX, yeniY);
                TenisTopu.Location = yNoktasi;
                hareketKontrol = kontrolcu.CaprazSolaGidis;
            }
            else
            {
                hareketKontrol = kontrolcu.AsagiYukariSagaGidis;
                TenisTopu.Location = new Point(3,3);
            }
            katsayiArttirici2++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            surecik++;
            LokasyonDebug.Text = TenisTopu.Location.X.ToString() + ", " + TenisTopu.Location.Y.ToString();
            TimerDebug.Text = surecik.ToString();
            if (hareketKontrol == kontrolcu.AsagiYukariSagaGidis)
            {
                xKatsayi = panel1.Width / 10;
                yKatsayi = panel1.Height / 10;
                katsayiArttirici = 1;
                katsayiArttirici2 = 1;
                AsagiYukariSagaGidis();
            }
            else if (hareketKontrol == kontrolcu.AsagiYukariSolaGidis)
            {
                AsagiYukariSolaGidis();
            }
            else if (hareketKontrol == kontrolcu.SagaSolaAsagiGidis)
            {
                SagaSolaAsagiGidis();
            }
            else if (hareketKontrol == kontrolcu.SagaSolaYukariGidis)
            {
                SagaSolaYukariGidis();
            }
            else if (hareketKontrol == kontrolcu.CaprazSagaGidis)
            {
                CaprazSagaGidis();
            }
            else if (hareketKontrol == kontrolcu.CaprazSagaGidisAsagi)
            {
                CaprazSagaGidisAsagi();
            }
            else if (hareketKontrol == kontrolcu.CaprazSolaGidis)
            {
                CaprazSolaGidis();
            }
            else if (hareketKontrol == kontrolcu.CaprazSolaGidisAsagi)
            {
                CaprazSolaGidisAsagi();
            }
        }

        private void ObjectMoveForm_Load(object sender, EventArgs e)
        {

        }
    }
}
