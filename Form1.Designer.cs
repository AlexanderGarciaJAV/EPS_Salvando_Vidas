namespace Fase3JavierGarcia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            iniDeSesiónToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            label2 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { iniDeSesiónToolStripMenuItem, acercaDeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1265, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // iniDeSesiónToolStripMenuItem
            // 
            iniDeSesiónToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            iniDeSesiónToolStripMenuItem.Name = "iniDeSesiónToolStripMenuItem";
            iniDeSesiónToolStripMenuItem.Size = new Size(112, 24);
            iniDeSesiónToolStripMenuItem.Text = "Iniciar  sesión";
            iniDeSesiónToolStripMenuItem.Click += iniDeSesiónToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(89, 24);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 128);
            button1.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            button1.Location = new Point(1046, 318);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(148, 33);
            button1.TabIndex = 108;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SkyBlue;
            button2.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            button2.Location = new Point(708, 318);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(149, 33);
            button2.TabIndex = 109;
            button2.Text = "Ingresar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Imprint MT Shadow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(582, 80);
            label5.Name = "label5";
            label5.Size = new Size(666, 27);
            label5.TabIndex = 112;
            label5.Text = "SISTEMA DE REGISTRO DE USUARIOS EN CENTRO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Imprint MT Shadow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(803, 116);
            label2.Name = "label2";
            label2.Size = new Size(274, 33);
            label2.TabIndex = 113;
            label2.Text = "EPS Salvando vidas";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label4.Location = new Point(742, 169);
            label4.Name = "label4";
            label4.Size = new Size(390, 26);
            label4.TabIndex = 115;
            label4.Text = "Digite la contraseña para el ingreso :";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Silver;
            textBox1.Location = new Point(853, 227);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 27);
            textBox1.TabIndex = 116;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(564, 370);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 117;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 450);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = " Inicio de sesión";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem iniDeSesiónToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Label label5;
        private Label label2;
        private Label label4;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}
