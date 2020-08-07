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
        int width, height, surecik, xKatsayi, yKatsayi, seviye;
        Point TenisTopuReset, YeniNokta;
        kontrolcu hareketKontrol;
        public ObjectMoveForm()
        {
            InitializeComponent();
            width = this.panel1.Width;
            height = this.panel1.Height;
            surecik = 0;

            // Seviye diğer formdan gelecek
            seviye = 1;
            
            TopunHizi = new System.Windows.Forms.Timer();
            TopunHizi.Tick += new EventHandler(timer1_Tick);
            if ( seviye == 1)
                TopunHizi.Interval = 1000;
            else
                TopunHizi.Interval = (1000 / 10) * seviye;
            TopunHizi.Enabled = true;

            CalismaSuresi = new System.Windows.Forms.Timer();
            CalismaSuresi.Tick += new EventHandler(CalismaSuresi_Tick);
            CalismaSuresi.Interval = 1000;
            CalismaSuresi.Enabled = true;
            

            hareketKontrol = kontrolcu.AsagiYukariSagaGidis;

            xKatsayi = panel1.Width / 10;
            yKatsayi = panel1.Height / 10;


            TenisTopuReset = TenisTopu.Location;
        }

        private void ObjectMoveForm_Resize(object sender, EventArgs e)
        {
            xKatsayi = panel1.Width / 10;
            yKatsayi = panel1.Height / 10;
        }

        // Resimdeki Topun Sağa Gidiş Fonksiyonu
        void AsagiYukariSagaGidis()
        {
            if (TenisTopu.Location.Y + TenisTopu.Height >= panel1.Height)
            {
                if (TenisTopu.Location.X + TenisTopu.Width * 2 >= panel1.Width)
                {
                    hareketKontrol = kontrolcu.AsagiYukariSolaGidis;
                    AsagiYukariSolaGidis();
                }
                else
                {
                    YeniNokta = new Point(TenisTopu.Location.X + TenisTopu.Width * 2, 0);
                    TenisTopu.Location = YeniNokta;
                }
            }
            else
            {
                YeniNokta = new Point(TenisTopu.Location.X, panel1.Height - (TenisTopu.Height));
                TenisTopu.Location = YeniNokta;
            }
        }

        // Resimdeki Topun Sola Gidiş Fonksiyonu
        void AsagiYukariSolaGidis()
        {
            if (TenisTopu.Location.Y + TenisTopu.Height >= panel1.Height)
            {
                if (TenisTopu.Location.X - TenisTopu.Width * 2 <= 0)
                {
                    hareketKontrol = kontrolcu.SagaSolaAsagiGidis;
                    TenisTopu.Location = new Point(TenisTopuReset.X, TenisTopuReset.Y);
                    SagaSolaAsagiGidis();
                }
                else
                {
                    YeniNokta = new Point(TenisTopu.Location.X - TenisTopu.Width * 2, 0);
                    TenisTopu.Location = YeniNokta;
                }
            }
            else
            {
                YeniNokta = new Point(TenisTopu.Location.X, panel1.Height - (TenisTopu.Height));
                TenisTopu.Location = YeniNokta;
            }
        }

        // Bu fonksiyon sağa sola aşağı doğru gidişi sağlar.
        void SagaSolaAsagiGidis()
        {
            if (TenisTopu.Location.Y + TenisTopu.Height * 2 <= panel1.Height)
            {
                if (TenisTopu.Location.X + TenisTopu.Width * 2 <= panel1.Width)
                {
                    YeniNokta = new Point(panel1.Width - TenisTopu.Width, TenisTopu.Location.Y);
                    TenisTopu.Location = YeniNokta;
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
            if (TenisTopu.Location.X + TenisTopu.Width * 2 <= panel1.Width)
            {
                YeniNokta = new Point(panel1.Width - TenisTopu.Width, TenisTopu.Location.Y - TenisTopu.Height);
                TenisTopu.Location = YeniNokta;
            }
            else
            {
                TenisTopu.Location = new Point(3, TenisTopu.Location.Y);
            }

            if (TenisTopu.Location.Y < 0)
            {
                hareketKontrol = kontrolcu.CaprazSagaGidis;
                YeniNokta = new Point((panel1.Width - TenisTopu.Width) / 2, (panel1.Height - TenisTopu.Height) / 2);
                TenisTopu.Location = YeniNokta;
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
                YeniNokta = new Point(yeniX, yeniY);
                TenisTopu.Location = YeniNokta;
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
                YeniNokta = new Point(yeniX, yeniY);
                TenisTopu.Location = YeniNokta;
                hareketKontrol = kontrolcu.CaprazSagaGidis;
            }
            else
            {
                hareketKontrol = kontrolcu.CaprazSolaGidis;
                TenisTopu.Location = new Point((panel1.Width - TenisTopu.Width) / 2, (panel1.Height - TenisTopu.Height) / 2);
            }
            katsayiArttirici++;
        }

        
        private void CalismaSuresi_Tick(object sender, EventArgs e)
        {
            if (surecik < 90)
            {
                surecik++;
                label1.Text = surecik.ToString();
            }
            else
                this.Close();
        }

        int katsayiArttirici2 = 1;
        void CaprazSolaGidis()
        {
            if (TenisTopu.Location.X < panel1.Width - TenisTopu.Width && TenisTopu.Location.Y < panel1.Height - TenisTopu.Width)
            {
                int yeniX = TenisTopu.Location.X - (xKatsayi * katsayiArttirici2);
                int yeniY = TenisTopu.Location.Y - (yKatsayi * katsayiArttirici2);
                YeniNokta = new Point(yeniX, yeniY);
                TenisTopu.Location = YeniNokta;
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
                YeniNokta = new Point(yeniX, yeniY);
                TenisTopu.Location = YeniNokta;
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
            System.GC.SuppressFinalize(YeniNokta);
        }

        private void ObjectMoveForm_Load(object sender, EventArgs e)
        {

        }
    }
}
