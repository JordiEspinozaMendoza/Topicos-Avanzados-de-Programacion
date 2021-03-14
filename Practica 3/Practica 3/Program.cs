using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Practica_3
{
    class Program : Form
    {
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        int x = 111;
        int y = 111;

       public PictureBox button = new PictureBox();
       Botones boton1 = new Botones(false, true, false, true);
        PictureBox face = new PictureBox();
        PictureBox face2 = new PictureBox();
        PictureBox face3 = new PictureBox();
        Botones boton2 = new Botones(false, true, false, true);
        Botones boton3 = new Botones(true, false, false, true);
        Botones boton4 = new Botones(false, true, true, false);


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
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Program
            // 
            this.BackColor = System.Drawing.Color.FromArgb(0,0,0);
            this.ClientSize = new System.Drawing.Size(385, 261);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.Program_Shown);
            this.ResumeLayout(false);

            face.ImageLocation = "https://i.pinimg.com/originals/a3/22/50/a32250504476526183fce2b82b1398e7.png";
            face.SizeMode = PictureBoxSizeMode.StretchImage;

            face2.ImageLocation = "https://i.pinimg.com/originals/93/7c/28/937c28e56fe63a5565f330e1ec2a675a.png";
            face2.SizeMode = PictureBoxSizeMode.StretchImage;

            face3.ImageLocation = "https://i.pinimg.com/originals/87/32/7b/87327b1289cfd25dee0d868684390603.png";
            face3.SizeMode = PictureBoxSizeMode.StretchImage;

            face.Location = new System.Drawing.Point(x, y);
            face2.Location = new System.Drawing.Point(x, y);
            face3.Location = new System.Drawing.Point(x, y);
        }

        public void CreateFaces() { 
        
        }
        private void Program_Shown(object sender, EventArgs e)
        {
            button.ImageLocation = "https://learnhotdogs.com/wp-content/uploads/2012/09/magic-button-400x400.png";
            button.SizeMode = PictureBoxSizeMode.StretchImage;
            button.Location = new System.Drawing.Point(x, y);
            this.Controls.Add(button);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int top = button.Top;
            int left = button.Left;

            int top1 = face.Top;
            int left1 = face.Left;

            int top2 = face2.Top;
            int left2 = face2.Left;

            int top3 = face3.Top;
            int left3 = face3.Left;


            boton1.Move(this.ClientSize.Height, this.ClientSize.Width, ref top, ref left, true);
            button.Top = top;
            button.Left = left;

            if (boton1.case1)
            {
                this.BackColor = System.Drawing.Color.FromArgb(255,204, 0);
                if (boton1.case2)
                {

                    this.Controls.Remove(face);
                    this.Controls.Remove(face2);
                    this.Controls.Remove(face3);
                }
                if (!this.Controls.Contains(face) && !boton1.case2) { 

                    this.Controls.Add(face);
                    this.Controls.Add(face2);
                    this.Controls.Add(face3);
                }
                boton2.Move(this.ClientSize.Height, this.ClientSize.Width, ref top1, ref left1);
                face.Top = top1;
                face.Left = left1;

                boton3.Move(this.ClientSize.Height, this.ClientSize.Width, ref top2, ref left2);
                face2.Top = top2;
                face2.Left = left2;

                boton4.Move(this.ClientSize.Height, this.ClientSize.Width, ref top3, ref left3);
                face3.Top = top3;
                face3.Left = left3;
            }
        }
    }
    class Botones
    {
        //Direccionales
        bool toUp;
        bool toDown;
        bool toLeft;
        bool toRight;
        //Casos 
        public bool case1 = false;
        public bool case2 = false;
        bool case3 = false;
        bool case4 = false;
        bool case5 = false;
        bool case6 = false;
        //Contructor
        public Botones(bool toUp, bool toDown, bool toLeft, bool toRight)
        {
            this.toDown = toDown;
            this.toLeft = toLeft;
            this.toRight = toRight;
            this.toUp = toUp;
        }

        //Metodo para mover al botó
        public  void Move(int ClientHeight, int ClientWidth, ref int y,ref int x, bool admin=false)
        {
            int velocidad = 15;
            if (y < (ClientHeight- 36) && toDown)
            {
                y = y + velocidad;
                if (x < (ClientWidth - 105) && toRight)
                {
                    x = x + velocidad;
                    if (x > (ClientWidth - 200) && y > 0 && y < 10)
                    {
                        case2 = true;
                    }
                }
                else
                {
                    toRight = false;
                    toLeft = true;
                }
                if (x > 0 && toLeft)
                {
                    x = x - velocidad;
                    if (x > (ClientWidth - 200) && y > 0 && y < 10)
                    {
                        case2 = true;
                    }

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
            if (y > 0 && toUp)
            {
                y = y - velocidad;
                if (x < (ClientWidth - 105) && toRight)
                    x = x + velocidad;
                else
                {
                    toRight = false;
                    toLeft = true;
                }
                if (x > 0 && toLeft)
                    x = x - velocidad;
                else
                {
                    toRight = true;
                    toLeft = false;
                }
            }
            else
            {
                if(y > 0 && y<10)
                {
                    if (admin)
                    {
                        case1 = true;

                    }
                }
                toDown = true;
                toUp = false;
            }
        }
    }
}
