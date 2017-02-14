using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parcial1Ap1_LeandroD;
using Parcial1Ap1_LeandroD.Entidades;

namespace Parcial1Ap1_LeandroD.UI.Registros
{
    public partial class EmpleadosForm : Form
    {
        public EmpleadosForm()
        {
            InitializeComponent();
        }


        private void EmpleadosForm_Load(object sender, EventArgs e)
        {


        }

        public void Limpiar()
        {
            empleadoIdTextBox.Clear();
            nombresTextBox.Clear();
            fechaNacimientoDateTimePicker.Value = DateTime.Today;
            sueldoTextBox.Clear();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(nombresTextBox.Text))
            {
                errorProvider1.SetError(nombresTextBox, "Por favor llenar ");
                return false;
            }

            if (string.IsNullOrEmpty(fechaNacimientoDateTimePicker.Text))
            {
                errorProvider1.SetError(fechaNacimientoDateTimePicker, "Por favor llenar ");
                return false;
            }

            if (string.IsNullOrEmpty(sueldoTextBox.Text))
            {
                errorProvider1.SetError(sueldoTextBox, "Por favor llenar ");
                return false;
            }
            return true;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            var guardado = new Empleados();
            guardado.EmpleadoId = (Utilitarios.TOINT(empleadoIdTextBox.Text));
            guardado.Nombres = nombresTextBox.Text;
            guardado.FechaNacimiento = fechaNacimientoDateTimePicker.Value;
            guardado.Sueldo = (Utilitarios.TOINT(sueldoTextBox.Text));

            if (!Validar())
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            else
            {
                BLL.EmpleadosBLL.Guardar(guardado);
                MessageBox.Show("Se ha guardado correctamente");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var busca = BLL.EmpleadosBLL.Buscar(Utilitarios.TOINT(empleadoIdTextBox.Text));
            if (busca != null)
            {
                nombresTextBox.Text = busca.Nombres;
                fechaNacimientoDateTimePicker.Value = busca.FechaNacimiento;
                sueldoTextBox.Text = Convert.ToString(busca.Sueldo);
                MessageBox.Show("Se ha encontrado correctamente");
            }
            else
            {
                MessageBox.Show("No existe ese usuario");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            var elimina = BLL.EmpleadosBLL.Buscar(Utilitarios.TOINT(empleadoIdTextBox.Text));
            if (elimina != null)
            {
                BLL.EmpleadosBLL.Eliminar(elimina);
                MessageBox.Show("Se ha eliminado el usuario");
            }
            else 
            {
                MessageBox.Show("No existe ese usuario");
            }
        }
    }
}
