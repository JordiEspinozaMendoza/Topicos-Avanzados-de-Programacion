
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace ProyectoUnidad1
{
    class Program : Form
    {
        private Timer timer1;
        private System.ComponentModel.IContainer components;

        //List para almacenar los botones principales
        List<Botones> buttons = new List<Botones>();
        //List para almacenar temporalmente los botones a agregar despues de cada iteracion
        List<Botones> buttonsToAdd = new List<Botones>();
        //List para almacenar temporalmente los botones a eliminar despues de cada iteracion
        List<Botones> buttonsToDelete = new List<Botones>();

        //Array para los indices
        static int[] pares = { 2, 4, 6, 8, 10 };
        static int[] impares = { 1, 3, 5, 7, 9 };
        //Botón random a usar
        static Random b = new Random();
        public Program()
        {
            InitializeComponent(); //A
            this.ShowDialog();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
        }

        private void InitializeComponent() //Propiedades para la ventana principal
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Program_Shown);
            this.ResumeLayout(false);

        }
        private void Program_Shown(object sender, EventArgs e)
        {
            //Cuando el programa inicie llamamos al metodo de botones padre
            MainButtons();
        }
        public void MainButtons()
        {
            //Llamamos 2 veces al metodo de crear botones pasando un true para que sean pares
            for (int i = 0; i < 2; i++)
                CreateButtons(true);
            //Llamamos 2 veces al metodo de crear botones pasando un false para que sean impares
            for (int i = 0; i < 2; i++)
                CreateButtons(false);
        }
        public void CreateButtons(bool par)
        {
            //La variable booleano indica si el boton a crear debe ser par o no
            //Array para almacenar los posibles direccionales a tomar
            bool[] boleans = { true, false };
            //Boton a crear
            Botones boton;

            if (par) //Para crear botones par
                 boton = new Botones(boleans[b.Next(0, boleans.Length)], boleans[b.Next(0, boleans.Length)], boleans[b.Next(0, boleans.Length)], boleans[b.Next(0, boleans.Length)], par, pares[b.Next(0, pares.Length)]);
            else //Para crear botones impar
                 boton = new Botones(boleans[b.Next(0, boleans.Length)], boleans[b.Next(0, boleans.Length)], boleans[b.Next(0, boleans.Length)], boleans[b.Next(0, boleans.Length)], par, impares[b.Next(0, impares.Length)]);

            //Creamos un punto random para la ubicacion
            generate:
            Point pt = new Point(int.Parse(b.Next(this.ClientSize.Width).ToString()),
                        int.Parse(b.Next(this.ClientSize.Height).ToString()));
            boton.Location = pt;
            foreach (Botones item in buttons)
            {
                if(boton!=item)
                    if (boton.Bounds.IntersectsWith(item.Bounds))
                        goto generate;
            }
            buttonsToAdd.Add(boton);
        }
        public void PreDeleteButtons(Botones Boton) //Metodo que se encarga de evaluar previamente si es necesario eliminar botones pares o impares
        {
            //Si es par
            if (Boton.par == true)
                for (int i = 0; i < Boton.val; i++)
                    DeleteButtons(false);
            //Si es impar
            else if (Boton.par == false)
                for (int i = 0; i < Boton.val; i++)
                    DeleteButtons(true);
        }
        public void DeleteButtons(bool par)
        {
            //Indice del boton a eliminar
            int indexToDelete;
            //Boleana que nos dice si ha encontrado algo
            bool found;
            do
            {
                //Tomamos un indice aleatorio
                indexToDelete = b.Next(0, buttons.Count);
                if (buttons[indexToDelete].par == par) //Si el boton en el indice encontrado es igual al parametro de par
                {
                    found = true; 
                }
                else
                    found = false;

            } while (!found);
            //Eliminamos el boton
            buttonsToDelete.Add(buttons[indexToDelete]);
        }
        public void UpdateLists()
        {
            //Actualizamos la listas
            foreach (Botones A in buttonsToDelete)
            {
                //Removemos de la lista principal
                buttons.Remove(A);
                //Quitamos de la forma
                this.Controls.Remove(A);
            }
            //Limpiamos la lista temporal
            buttonsToDelete.Clear();
            //Actualizamos la lista a agregar
            foreach (Botones A in buttonsToAdd)
            {
                //Agregamos a la principal
                buttons.Add(A);
                //Agregamos a la forma
                this.Controls.Add(A);
            }
            //Limpiamos la lista temporal
            buttonsToAdd.Clear();
        }
        public void RestartForm()
        {
            //Contadores que se encargan de almacenar la cantidad de botones pares o impares respectivamente
            int contadorPares = 0, contadorImpares = 0;
            //Iteramos cada uno de los botones en la lista principal
            foreach (Botones item in buttons)
            {
                //Si el boton es par
                if (item.par == true)
                    contadorPares += 1;
                //Si el boton es impar
                if (item.par == false)
                    contadorImpares += 1;
            }
            //Si alguno de los 2 contadores es nulo
            if (contadorImpares == 0 || contadorPares == 0)
            {
                //Limpiamos la lista padre
                buttons.Clear();
                //Limpiamos los controles de la forma
                this.Controls.Clear();
                //Creamos los botones padre
                MainButtons();
                //Regresamos el color default
                this.BackColor = Color.Black;
                //Mensaje para el usuario
                if (contadorImpares == 0)
                    MessageBox.Show("Ganaron los pares");
                if (contadorPares == 0)
                    MessageBox.Show("Ganaron los impares");
            }
        }
        public void ChangeColor() //Funcion para cambiar color de la forma
        {
            if (buttons.Count >= 50)
                this.BackColor = Color.Blue;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Iteramos todos los botones existentes
            foreach (Botones A in buttons)
            {
                //Los movemos de posicion
                A.Move(this.ClientSize.Height, this.ClientSize.Width);
                //Iteramos todos de nuevo para compararlos
                foreach (Botones B in buttons)
                {
                    if (A != B) //Evitamos que el primer iterado sea comparado consigo mismo en la segunda iteracion
                    {
                        if (A.Bounds.IntersectsWith(B.Bounds)) //Si intersectan
                        {
                            //Efecto de rebote
                            if (A.toDown) //Si venias hacia abajo cambia tu direccional para arriba
                            {
                                A.toUp = true;
                                A.toDown = false;
                            }
                            else//Si venias hacia arriba cambia tu direccional para abajo
                            {
                                A.toUp = false;
                                A.toDown = true;
                            }
                            //Si ambos son pares
                            if (A.par == B.par)
                            {
                                //Los botones que vamos a crear
                                int buttonsToCreate = (A.val + B.val);
                                //Si el boton a crear es par
                                if (A.par)
                                {
                                    for (int i = 0; i < buttonsToCreate; i++)
                                    {
                                        Task.Delay(10).Wait(); //Esperamos 10 milisegundos
                                        //Creamos un boton par
                                        CreateButtons(true);                                        
                                    }
                                }
                                //Si el boton a crear es impar
                                else
                                {
                                    for (int i = 0; i < buttonsToCreate; i++)
                                    {
                                        Task.Delay(10).Wait(); //Esperamos 10 milisegundos
                                        //Creamos un boton impar
                                        CreateButtons(false);
                                    }
                                }
                            }
                            //Si el valor de A es mayor al de B
                            else if(A.val > B.val)
                            {
                                PreDeleteButtons(A); //Enviamos el boton para que sea evaluado antes de ejecutar alguna eliminacion
                            }
                            //Si el valor de B es mayor al de A
                            else if (A.val < B.val)
                            {
                                PreDeleteButtons(B);//Enviamos el boton para que sea evaluado antes de ejecutar alguna eliminacion
                            }
                        }
                    }
                }
            }
            //Llamamos a los metodos de update, comprobacion de la cantidad de botones, comprobacion de que si es necesario reiniciar la forma
            UpdateLists();
            ChangeColor();
            RestartForm();
        }
    }
    //Class Botones que hereda de la clase de Forms Button
    class Botones: Button
    {
        //Direccionales
        public bool toUp;
        public bool toDown;
        public bool toLeft;
        public bool toRight;
        //Bool que dice si es par o impar
        public bool par;
        //Indice
        public int val;

        //Contructor
        public Botones(bool toUp, bool toDown, bool toLeft, bool toRight, bool par, int val)
        {
            this.toDown = toDown;
            this.toLeft = toLeft;
            this.toRight = toRight;
            this.toUp = toUp;
            this.par = par;
            this.val = val;
            //Agregamos el indice al texto
            this.Text = this.val.ToString();
            this.ForeColor = Color.White;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //Si recibimos ambos direccionales verticales como true
            if (this.toDown && this.toUp)
                this.toDown = false;
            //Si recibimos ambos direccionales horizontales como true
            if (this.toRight && this.toLeft)
                this.toLeft = false;

            //Si es par lo pintamos de azul
            if (this.par)
                this.BackColor = Color.Blue;
            //Si es impar lo pintamos de rojo
            else
                this.BackColor = Color.Red;
        }

        //Metodo para mover al botón
        public void Move(int ClientHeight, int ClientWidth) //Recibe el valor del tamaño de la pantalla
        { 
            int velocidad = 10; //Velocidad de movimiento
            if (this.Top < (ClientHeight - 20) && toDown) //Si vas hacia abajo y no tocas el borde de la pantalla
            {
                this.Top = this.Top + velocidad; //Aumentamos en Y
                if (this.Left < (ClientWidth -50) && toRight) //Si vas para la derecha y no tocas el borde de la pantalla
                {
                    this.Left = this.Left + velocidad; //Aumentamos en X
                }
                else
                {//Si no cambiamos tus direccionales
                    toRight = false;
                    toLeft = true;
                }
                if (this.Left > 0 && toLeft) //Lo mismo que en toright solo que ahora restamos
                {
                    this.Left = this.Left - velocidad;
                }
                else
                {//Si no cambiamos tus direcciona;es
                    toRight = true;
                    toLeft = false;
                }
            }
            else
            { //Si no cambiamos tus direccionales en Y
                toDown = false;
                toUp = true;
            }
            if (this.Top > 20 && toUp) //Lo mismo pero ahora con el borde superior
            {
                this.Top = this.Top - velocidad;
                if (this.Left < (ClientWidth - 50) && toRight)
                {

                    this.Left = this.Left + velocidad;
                }
                else
                {
                    toRight = false;
                    toLeft = true;
                }
                if (this.Left > 20 && toLeft)
                    this.Left = this.Left - velocidad;
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