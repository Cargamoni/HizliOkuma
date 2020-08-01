namespace HizliOkuma
{
    partial class ObjectMoveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectMoveForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TenisTopu = new System.Windows.Forms.PictureBox();
            this.WidthDebug = new System.Windows.Forms.Label();
            this.HeightDebug = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerDebug = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.LokasyonDebug = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TenisTopu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LokasyonDebug);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.TimerDebug);
            this.panel1.Controls.Add(this.TenisTopu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // TenisTopu
            // 
            this.TenisTopu.Image = ((System.Drawing.Image)(resources.GetObject("TenisTopu.Image")));
            this.TenisTopu.Location = new System.Drawing.Point(3, 3);
            this.TenisTopu.Name = "TenisTopu";
            this.TenisTopu.Size = new System.Drawing.Size(80, 80);
            this.TenisTopu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TenisTopu.TabIndex = 0;
            this.TenisTopu.TabStop = false;
            // 
            // WidthDebug
            // 
            this.WidthDebug.AutoSize = true;
            this.WidthDebug.Location = new System.Drawing.Point(9, -1);
            this.WidthDebug.Name = "WidthDebug";
            this.WidthDebug.Size = new System.Drawing.Size(35, 13);
            this.WidthDebug.TabIndex = 1;
            this.WidthDebug.Text = "label1";
            // 
            // HeightDebug
            // 
            this.HeightDebug.AutoSize = true;
            this.HeightDebug.Location = new System.Drawing.Point(126, -1);
            this.HeightDebug.Name = "HeightDebug";
            this.HeightDebug.Size = new System.Drawing.Size(35, 13);
            this.HeightDebug.TabIndex = 2;
            this.HeightDebug.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerDebug
            // 
            this.TimerDebug.AutoSize = true;
            this.TimerDebug.Location = new System.Drawing.Point(262, 0);
            this.TimerDebug.Name = "TimerDebug";
            this.TimerDebug.Size = new System.Drawing.Size(35, 13);
            this.TimerDebug.TabIndex = 3;
            this.TimerDebug.Text = "label3";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(722, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "button1";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LokasyonDebug
            // 
            this.LokasyonDebug.AutoSize = true;
            this.LokasyonDebug.Location = new System.Drawing.Point(385, 3);
            this.LokasyonDebug.Name = "LokasyonDebug";
            this.LokasyonDebug.Size = new System.Drawing.Size(35, 13);
            this.LokasyonDebug.TabIndex = 5;
            this.LokasyonDebug.Text = "label3";
            // 
            // ObjectMoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HeightDebug);
            this.Controls.Add(this.WidthDebug);
            this.Controls.Add(this.panel1);
            this.Name = "ObjectMoveForm";
            this.Text = "ObjectMoveForm";
            this.Load += new System.EventHandler(this.ObjectMoveForm_Load);
            this.Resize += new System.EventHandler(this.ObjectMoveForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TenisTopu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox TenisTopu;
        private System.Windows.Forms.Label WidthDebug;
        private System.Windows.Forms.Label HeightDebug;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label TimerDebug;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label LokasyonDebug;
    }
}