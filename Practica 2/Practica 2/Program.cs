using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Practica_2
{
    class Program: Form
    {
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        int x = 111;
        int y = 111;
        public PictureBox dvd = new PictureBox();

        public Program()
        {
            InitializeComponent(); //A
            this.ShowDialog();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
        }

        private void InitializeComponent() //A
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Program
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(385, 261);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.Program_Shown);
            this.ResumeLayout(false);
            timer1.Start();


        }
        private void Program_Shown(object sender, EventArgs e)
        {
            dvd.ImageLocation = "https://images.vexels.com/media/users/3/143400/isolated/preview/992599758a1b913574417e3ce37c3c37-logo-de-dvd-dorado-by-vexels.png";
            dvd.SizeMode = PictureBoxSizeMode.StretchImage;
            dvd.Location = new System.Drawing.Point(x, y);
            this.Controls.Add(dvd);
        }

        bool toUp = false;
        bool toDown = true;
        bool toLeft = false;
        bool toRight = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int velocidad = 5;
            if (dvd.Top < 225 && toDown)
            {
                dvd.Top = dvd.Top + velocidad;
                if (dvd.Left < 280 && toRight)
                {
                    dvd.Left = dvd.Left + velocidad;
                }
                else
                {
                    toRight = false;
                    toLeft = true;
                }

                if (dvd.Left > 0 && toLeft)
                {
                    dvd.Left = dvd.Left - velocidad;
                }
                else
                {
                    toRight = true;
                    toLeft = false;
                }

            }
            else
            {
                toDown = false;
                toUp = true; 
            }

            if(dvd.Top > 0 && toUp)
            {
                dvd.Top = dvd.Top - velocidad;
                if (dvd.Left < 280 && toRight)
                {
                    dvd.Left = dvd.Left + velocidad;
                }
                else
                {
                    toRight = false;
                    toLeft = true;
                }

                if (dvd.Left > 0 && toLeft)
                {
                    dvd.Left = dvd.Left - velocidad;
                }
                else
                {
                    toRight = true;
                    toLeft = false;
                }
            }
            else
            {
                toDown = true;
                toUp = false;
            }


        }
    }
}
