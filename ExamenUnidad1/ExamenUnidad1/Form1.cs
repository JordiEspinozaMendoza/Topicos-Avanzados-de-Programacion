using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenUnidad1
{
    //Espinoza Mendoza Jordi
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int contador=0;
        //Eventos desencadenados por el usuario
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = "Hiciste click";
        }
        private void label1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "Estas escribiendo";
        }
        //Eventos de sistema
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = "Has seleccionado la fecha " + dateTimePicker1.Value.ToString();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Estas haciendo hover sobre el botón");
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Text = Cursor.Position.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("La forma ha cargado correctamente");
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = "Contador: "+ contador.ToString();
            contador++;
        }
    }
}
