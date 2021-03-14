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
        //Coordenadas principales
        int x = 111;
        int y = 111;
        //Labels
        Label[] labels = new Label[10];

        // Boton principal
        public PictureBox button = new PictureBox();
        Botones boton1 = new Botones(false, true, false, true);
        //

        //Caritas
        PictureBox face = new PictureBox();
        PictureBox face2 = new PictureBox();
        PictureBox face3 = new PictureBox();
        Botones boton2 = new Botones(false, true, false, true);
        Botones boton3 = new Botones(true, false, false, true);
        Botones boton4 = new Botones(false, true, true, false);
        //

        //Botones
        Button[] botones = new Button[5];
        int[] lefts = new int[5];
        int[] tops = new int[5];
        Botones[] btns = new Botones[5];
        //

        //Colores
        Color[] colors = { Color.Red, Color.Blue, Color.LightGray, Color.PaleGreen, Color.Yellow };
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
            this.ClientSize = new System.Drawing.Size(500, 261);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.Program_Shown);
            this.ResumeLayout(false);

            //Propiedades de las caritas
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

        private void Program_Shown(object sender, EventArgs e)
        {
            // Propiedades de los 5 botoness
            btns[0] = new Botones(false, true, true, false);
            btns[1] = new Botones(true, false, true, false);
            btns[2] = new Botones(false, true, false, true);
            btns[3] = new Botones(true, false, false, true);
            btns[4] = new Botones(true, false, true, false);

            for (int i = 0; i < 5; i++)
            {
                botones[i] = new Button();

                botones[i].Location = new System.Drawing.Point(x+ (5*i), y-(5*i));
                botones[i].Text = "Hola";
                botones[i].BackColor = colors[i];
                tops[i] = botones[i].Top;
                lefts[i] = botones[i].Left;

            }
            //

            //Propiedades del boton principal
            button.ImageLocation = "https://learnhotdogs.com/wp-content/uploads/2012/09/magic-button-400x400.png";
            button.SizeMode = PictureBoxSizeMode.StretchImage;
            button.Location = new System.Drawing.Point(x, y);
            this.Controls.Add(button);


        }
        public void changeColor(int top, int left)
        {
            //Evaluamos la posicion del boton principal y el color actual de la forma
            if (top > 0 && top < 10)
            {
                if (this.BackColor == System.Drawing.Color.FromArgb(65, 105, 225) || this.BackColor == Color.Orange)
                    this.BackColor = System.Drawing.Color.FromArgb(255, 204, 0);
            }
            else if (top < (this.ClientSize.Height - 36) && top > (this.ClientSize.Height - 50))
            {
                if (this.BackColor == System.Drawing.Color.FromArgb(255, 204, 0) || this.BackColor == System.Drawing.Color.FromArgb(0, 0, 0))
                    this.BackColor = System.Drawing.Color.FromArgb(65, 105, 225);
            }
            else if (left > (this.ClientSize.Width - 110))
            {
                if (this.BackColor == System.Drawing.Color.FromArgb(255, 204, 0) || this.BackColor == System.Drawing.Color.FromArgb(65, 105, 225))
                    this.BackColor = Color.Orange;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Varianbles dinamicas para almacenar las coordenadas
            int top = button.Top;
            int left = button.Left;

            int top1 = face.Top;
            int left1 = face.Left;

            int top2 = face2.Top;
            int left2 = face2.Left;

            int top3 = face3.Top;
            int left3 = face3.Left;

            if (!boton1.case6)
            {
                //Movemos el boton
                boton1.Move(this.ClientSize.Height, this.ClientSize.Width, ref top, ref left, true);
                button.Top = top;
                button.Left = left;
                changeColor(top, left);
                if (boton1.case1)
                {
                    //Añadimos las caritas
                    this.Controls.Add(face);
                    this.Controls.Add(face2);
                    this.Controls.Add(face3);
                    //Movemos las caritas y camnbiamos coordeanada
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
                if (boton1.case2)
                {
                    //Quitamos las caritas
                    this.Controls.Remove(face);
                    this.Controls.Remove(face2);
                    this.Controls.Remove(face3);
                    boton1.case2 = false;
                    boton1.case1 = false;

                }
                if (boton1.case3)
                {
                    //Agregamos los 10 labels

                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (!this.Controls.Contains(labels[i]))
                        {
                            labels[i] = new Label();
                            labels[i].Text = "Jordi Espinoza Mendoza";
                            labels[i].Text = "Jordi Espinoza Mendoza";
                            labels[i].Location = new System.Drawing.Point(0, 25 * i);
                            this.Controls.Add(labels[i]);
                        }
                    }
                    boton1.case3 = false;
                }

                if (boton1.case4)
                {
                    //Quitamos los 10 labels
                    for (int i = 0; i < labels.Length; i++)
                        this.Controls.Remove(labels[i]);
                    
                    boton1.case3 = false;
                    boton1.case4 = false;
                }

                if (boton1.case5)
                {
                    //Agregamos los 5 botones
                    for (int i = 0; i < 5; i++)
                    {
                        this.Controls.Add(botones[i]);
                        btns[i].Move(this.ClientSize.Height, this.ClientSize.Width, ref tops[i], ref lefts[i]);
                        botones[i].Top = tops[i];
                        botones[i].Left = lefts[i];
                    }
                }
            }
            else
            {
                //Limpiamos y reseteamos los 6 casos
                this.Controls.Clear();
                this.Controls.Add(button); //Agregamos el boton pricipal
                boton1.case6 = false;
                boton1.case1 = false;
                boton1.case2 = false;
                boton1.case3 = false;
                boton1.case4 = false;
                boton1.case5 = false;

                //Movemos el boton principal
                boton1.Move(this.ClientSize.Height, this.ClientSize.Width, ref top, ref left, true);
                button.Top = top;
                button.Left = left;
                changeColor(top, left);
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
            public bool case3 = false;
            public bool case4 = false;
            public bool case5 = false;
            public bool case6 = false;

            //Contructor
            public Botones(bool toUp, bool toDown, bool toLeft, bool toRight)
            {
                this.toDown = toDown;
                this.toLeft = toLeft;
                this.toRight = toRight;
                this.toUp = toUp;
            }

            //Metodo para mover al botó
            public void Move(int ClientHeight, int ClientWidth, ref int y, ref int x, bool admin = false)
            {
                int velocidad = 18;
                //Si toca arriba a la derecha
                if ( y < (ClientHeight - 36) && y > (ClientHeight-50) && x > (ClientWidth-150))
                {
                    case4 = true;
                    case3 = false;
                }
                if (x > (ClientWidth - 110))
                    case5 = true;
                if (x > 0 && x < 5) //Si toca la izquierda
                {
                    case6 = true;
                }

                //
                if (y < (ClientHeight - 36) && toDown)
                {
                    y = y + velocidad;
                    if (x < (ClientWidth - 105) && toRight)
                    {
                        x = x + velocidad;
                        if ( y > 0 && y < 10)
                        {
                            case2 = true;
                            case1 = false;
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
                        if (x > (ClientWidth - 150) && y > 0 && y < 10)
                        {
                            case2 = true;
                            case1 = false;
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
                    if(y < (ClientHeight - 36) && y > (ClientHeight - 50))
                        if (!case4)
                        {
                            case4 = false;
                            case3 = true;
                        }
                    case4 = false;
                    toDown = false;
                    toUp = true;

                }
                if (y > 0 && toUp)
                {
                    y = y - velocidad;
                    if (x < (ClientWidth - 105) && toRight) { 
                    
                        x = x + velocidad;
                    }
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
                    if (y > 0 && y < 10)
                    {
                        if (admin && !case2)
                        {

                            case1 = true;
                            case2 = false;
                        }
                    }
                    toDown = true;
                    toUp = false;
                }

            }
        }
    }

}
