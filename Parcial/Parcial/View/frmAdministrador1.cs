using Parcial.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Parcial.View
{
    public partial class frmAdministrador1 : Form
    {


        public frmAdministrador1()
        {
            InitializeComponent();

            CargarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void CargarDatos()
        {

            using (Sistema_BeneficiarioEntities db = new Sistema_BeneficiarioEntities())
            {

                var lista = from B in db.Beneficiarios
                           select new 
                           { 
                             ID = B.IdBeneficiario,
                             NOMBRE = B.Nombre, 
                             DUI = B.Dui 
                           };

                dgvBeneficiarios.DataSource = lista.ToList();

            }

        }


        public void limpiar()
        {
            txtDui.Text = "";
            txtNombre.Text = "";
            txtNombre.Enabled = false;
            txtDui.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtNombre.Text != "" && txtDui.Text != "")

            {


                using (Sistema_BeneficiarioEntities db = new Sistema_BeneficiarioEntities())
                {

                    


                }
            }
            else
            {

                MessageBox.Show("Los datos estan incompletos");

            }
        }

        private void dgvBeneficiarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Id = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvBeneficiarios.CurrentRow.Cells[1].Value.ToString();
            string dui = dgvBeneficiarios.CurrentRow.Cells[2].Value.ToString();
            txtDui.Enabled = true;
            txtNombre.Enabled = true;
            txtNombre.Text = nombre;
            txtDui.Text = dui;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = false;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
