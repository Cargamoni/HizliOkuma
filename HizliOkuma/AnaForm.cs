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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TenisTopuForm tenisTopu = new TenisTopuForm();
            tenisTopu.ShowDialog();
            System.GC.SuppressFinalize(tenisTopu);
            this.Show();
        }

        private void KayanNesneAlistirma_Click(object sender, EventArgs e)
        {
            this.Hide();
            KayanResimlerForm kayanResimler = new KayanResimlerForm();
            kayanResimler.ShowDialog();
            System.GC.SuppressFinalize(kayanResimler);
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            KayanYazilarForm kayanYazilar = new KayanYazilarForm();
            kayanYazilar.ShowDialog();
            System.GC.SuppressFinalize(kayanYazilar);
            this.Show();
        }
    }
}
