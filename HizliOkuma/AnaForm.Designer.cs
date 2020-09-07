namespace HizliOkuma
{
    partial class AnaForm
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
            this.TenisTopuAlistirma = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.KayanNesneAlistirma = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TenisTopuAlistirma
            // 
            this.TenisTopuAlistirma.Location = new System.Drawing.Point(713, 12);
            this.TenisTopuAlistirma.Name = "TenisTopuAlistirma";
            this.TenisTopuAlistirma.Size = new System.Drawing.Size(75, 23);
            this.TenisTopuAlistirma.TabIndex = 0;
            this.TenisTopuAlistirma.Text = "Alıştırma 1";
            this.TenisTopuAlistirma.UseVisualStyleBackColor = true;
            this.TenisTopuAlistirma.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Tenis Topu Göz Alıştırması",
            "Hareket Eden Nesne Alıştırması",
            "Hareket Eden Yazı Alıştırması"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(298, 424);
            this.checkedListBox1.TabIndex = 1;
            // 
            // KayanNesneAlistirma
            // 
            this.KayanNesneAlistirma.Location = new System.Drawing.Point(713, 41);
            this.KayanNesneAlistirma.Name = "KayanNesneAlistirma";
            this.KayanNesneAlistirma.Size = new System.Drawing.Size(75, 23);
            this.KayanNesneAlistirma.TabIndex = 2;
            this.KayanNesneAlistirma.Text = "Alıştırma 2";
            this.KayanNesneAlistirma.UseVisualStyleBackColor = true;
            this.KayanNesneAlistirma.Click += new System.EventHandler(this.KayanNesneAlistirma_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Alıştırma 3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.KayanNesneAlistirma);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.TenisTopuAlistirma);
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TenisTopuAlistirma;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button KayanNesneAlistirma;
        private System.Windows.Forms.Button button1;
    }
}

