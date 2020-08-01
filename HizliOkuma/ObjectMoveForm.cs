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
    // Çapraz gitme yapılacak.
    // Ekrandan çıkma sorunu ve tekleme yeniden düzenlenecek
    // Zaman 90 saniye olacak ve Seviyeye Göre değişecek Hız
    // TimeInterval 300 altına düşmeyecek
    public partial class ObjectMoveForm : Form
    {
        int width, height, surecik;
        bool first, second, third, fourth;
        Point TenisTopuReset;
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
            TenisTopuReset = TenisTopu.Location;
        }

        private void ObjectMoveForm_Resize(object sender, EventArgs e)
        {
            WidthDebug.Text = "Width = " + this.panel1.Width.ToString();
            HeightDebug.Text = "Height = " + this.panel1.Height.ToString();
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
                    first = false;
                    second = true;
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

        // Resimdeki Topun Sola Gidiş Fonksiyonu
        void AsagiYukariSolaGidis()
        {
            //System.Windows.Forms.MessageBox.Show("Vololooooooooo");
            if (TenisTopu.Location.Y + TenisTopu.Height >= panel1.Height)
            {
                Point yNoktasi = new Point();
                if (TenisTopu.Location.X - TenisTopu.Width * 2 <= 0)
                {
                    third = true;
                    second = false;
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
            if(TenisTopu.Location.Y + TenisTopu.Height *2 <= panel1.Height)
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
                third = false;
                fourth = true;
                TenisTopu.Location = new Point(3, TenisTopu.Location.Y);
            }
        }

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

            if(TenisTopu.Location.Y < 0)
            {
                fourth = false;
                first = true;
                timer1.Interval -= 100;
                TenisTopu.Location = new Point(3, TenisTopu.Location.Y - TenisTopu.Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            surecik++;
            LokasyonDebug.Text = TenisTopu.Location.X.ToString() + ", " + TenisTopu.Location.Y.ToString();
            TimerDebug.Text = surecik.ToString();
            if (first)
                AsagiYukariSagaGidis();
            else if (second)
            {
                AsagiYukariSolaGidis();
            }
            else if (third)
            {
                SagaSolaAsagiGidis();
            }
            else if(fourth)
            {
                SagaSolaYukariGidis();
            }
        }

        private void ObjectMoveForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
