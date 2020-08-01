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
    public partial class ObjectMoveForm : Form
    {
        int width, height, surecik;
        public ObjectMoveForm()
        {
            InitializeComponent();
            width = this.panel1.Width;
            height = this.panel1.Height;
            StartButton.Text = "Sureci";
            surecik = 0;
            WidthDebug.Text = "Width = " + width.ToString();
            HeightDebug.Text = "Height = " + height.ToString();
            TimerDebug.Text = surecik.ToString();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 100;
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
        // To do
        // Nesne isimleri değiştirilecek
        // Resim sağa kayacak ve devam edecek
        // Sona geldiği zaman Duracak 
        // Her tur sonrasında daha da hızlanacak
        private void timer1_Tick(object sender, EventArgs e)
        {
            surecik++;
            TimerDebug.Text = surecik.ToString();
            if( TenisTopu.Location.Y + TenisTopu.Height >= panel1.Height)
            {
                Point yNoktasi = new Point(TenisTopu.Location.X, 0);
                TenisTopu.Location = yNoktasi;
            }
            else
            { 
                Point yNoktasi = new Point(TenisTopu.Location.X, panel1.Height - (TenisTopu.Height));
                TenisTopu.Location = yNoktasi;
            }
        }

        private void ObjectMoveForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
