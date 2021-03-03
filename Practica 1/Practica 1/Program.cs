using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Practica_1
{
    public partial class Program:Form
    {
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
            this.ClientSize = new System.Drawing.Size(385, 261);
            this.Name = "Practica 1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Button newButton = new Button();
            newButton.Text = "boton";
            newButton.Location = new System.Drawing.Point(144, 111);
            this.Controls.Add(newButton);
        }

    }
}
