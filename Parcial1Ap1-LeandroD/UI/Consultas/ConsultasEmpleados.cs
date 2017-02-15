using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parcial1Ap1_LeandroD.UI.Consultas
{
    public partial class ConsultasEmpleados : Form
    {
        public ConsultasEmpleados()
        {
            InitializeComponent();
        }



        private void ConsultasEmpleados_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        public void LlenarCombo()
        {
            comboBox1.Items.Insert(0, "Nombre");
            comboBox1.Items.Insert(1, "Fecha");
            comboBox1.Items.Insert(2, "Todos");
            comboBox1.DataSource = comboBox1.Items;
            comboBox1.DisplayMember = "Nombre";

        }

        public void SeleccionarOpcion()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                empleadosDataGridView.DataSource = BLL.EmpleadosBLL.GetListNombre(buscaText.Text);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (desdeDateTimePicker.Value.Date <= HastadateTimePicker1.Value.Date)
                {
                    empleadosDataGridView.DataSource = BLL.EmpleadosBLL.GetListFecha(desdeDateTimePicker.Value.Date, HastadateTimePicker1.Value.Date);
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                empleadosDataGridView.DataSource = BLL.EmpleadosBLL.GetList();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarOpcion();
        }
    }


}
