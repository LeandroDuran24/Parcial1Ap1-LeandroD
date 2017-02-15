using System;
using System.Windows.Forms;
using Parcial1Ap1_LeandroD.UI.Consultas;
using Parcial1Ap1_LeandroD.UI.Registros;

namespace Parcial1Ap1_LeandroD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosForm empleado = new EmpleadosForm();
            empleado.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasEmpleados consulta = new ConsultasEmpleados();
            consulta.Show();

        }
    }
}
