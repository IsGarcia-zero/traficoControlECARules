namespace traficoControlECARules
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            iniciarBtn = new Button();
            pausaBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            randomLlenar = new Button();
            hScrollBar1 = new HScrollBar();
            label5 = new Label();
            hScrollBar2 = new HScrollBar();
            label6 = new Label();
            hScrollBar3 = new HScrollBar();
            label7 = new Label();
            limpiarBtn = new Button();
            label8 = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(801, 801);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // iniciarBtn
            // 
            iniciarBtn.Location = new Point(851, 12);
            iniciarBtn.Name = "iniciarBtn";
            iniciarBtn.Size = new Size(75, 23);
            iniciarBtn.TabIndex = 1;
            iniciarBtn.Text = "Iniciar";
            iniciarBtn.UseVisualStyleBackColor = true;
            iniciarBtn.Click += iniciarBtn_Click;
            // 
            // pausaBtn
            // 
            pausaBtn.Location = new Point(851, 41);
            pausaBtn.Name = "pausaBtn";
            pausaBtn.Size = new Size(75, 23);
            pausaBtn.TabIndex = 2;
            pausaBtn.Text = "Pausa";
            pausaBtn.UseVisualStyleBackColor = true;
            pausaBtn.Click += pausaBtn_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(876, 304);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(876, 319);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(876, 334);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(876, 349);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 6;
            label4.Text = "label4";
            // 
            // randomLlenar
            // 
            randomLlenar.Location = new Point(836, 117);
            randomLlenar.Name = "randomLlenar";
            randomLlenar.Size = new Size(110, 41);
            randomLlenar.TabIndex = 7;
            randomLlenar.Text = "Llenar el circuito Random";
            randomLlenar.UseVisualStyleBackColor = true;
            randomLlenar.Click += randomLlenar_Click;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(836, 92);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(110, 22);
            hScrollBar1.TabIndex = 8;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(851, 66);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 9;
            label5.Text = "Porcentaje 50%";
            // 
            // hScrollBar2
            // 
            hScrollBar2.Location = new Point(819, 185);
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(158, 20);
            hScrollBar2.TabIndex = 10;
            hScrollBar2.Scroll += hScrollBar2_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(819, 161);
            label6.Name = "label6";
            label6.Size = new Size(127, 15);
            label6.TabIndex = 11;
            label6.Text = "Porcentaje Vuelta: 15%";
            // 
            // hScrollBar3
            // 
            hScrollBar3.Location = new Point(819, 238);
            hScrollBar3.Name = "hScrollBar3";
            hScrollBar3.Size = new Size(158, 20);
            hScrollBar3.TabIndex = 12;
            hScrollBar3.Scroll += hScrollBar3_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(819, 214);
            label7.Name = "label7";
            label7.Size = new Size(161, 15);
            label7.TabIndex = 13;
            label7.Text = "Porcentaje Cambio Carril: 5%";
            // 
            // limpiarBtn
            // 
            limpiarBtn.Location = new Point(864, 769);
            limpiarBtn.Name = "limpiarBtn";
            limpiarBtn.Size = new Size(75, 23);
            limpiarBtn.TabIndex = 14;
            limpiarBtn.Text = "Limpiar";
            limpiarBtn.UseVisualStyleBackColor = true;
            limpiarBtn.Click += limpiarBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(852, 448);
            label8.Name = "label8";
            label8.Size = new Size(87, 15);
            label8.TabIndex = 15;
            label8.Text = "Generación = 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 825);
            Controls.Add(label8);
            Controls.Add(limpiarBtn);
            Controls.Add(label7);
            Controls.Add(hScrollBar3);
            Controls.Add(label6);
            Controls.Add(hScrollBar2);
            Controls.Add(label5);
            Controls.Add(hScrollBar1);
            Controls.Add(randomLlenar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pausaBtn);
            Controls.Add(iniciarBtn);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button iniciarBtn;
        private Button pausaBtn;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button randomLlenar;
        private HScrollBar hScrollBar1;
        private Label label5;
        private HScrollBar hScrollBar2;
        private Label label6;
        private HScrollBar hScrollBar3;
        private Label label7;
        private Button limpiarBtn;
        private Label label8;
        private System.Windows.Forms.Timer timer2;
    }
}
