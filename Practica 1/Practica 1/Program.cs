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
            InitializeComponent(); 
        }

        static void Main(string[] args)
        {
            Console.Write("Presione cualquier tecla para generar la forma con el botón...");
            Console.ReadKey();

            Program program = new Program();
            program.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(385, 261);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);
            Button newButton = new Button();
            newButton.Text = "hola";
            newButton.Location = new System.Drawing.Point(144, 111);
            this.Controls.Add(newButton);
            
        }

        private void Program_Load(object sender, EventArgs e)
        {

        }
    }
}
