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

            
        }

        public Beneficiarios benef = new Beneficiarios();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void CargarDatos()
        {
            dgvBeneficiarios.Rows.Clear();
            using (Sistema_BeneficiarioEntities1 db = new Sistema_BeneficiarioEntities1())
            {


                var Beneficiarios = db.Beneficiarios;
                foreach (var iterarB in Beneficiarios)
                {
                    dgvBeneficiarios.Rows.Add(iterarB.IdBeneficiario, iterarB.Nombre, iterarB.Dui);
                }
            }

        }


        public void limpiar()
        {
            txtDui.Text = "";
            txtNombre.Text = "";
           

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDui.Text != "")

            {

                using (Sistema_BeneficiarioEntities1 db = new Sistema_BeneficiarioEntities1())
                {

                    benef.Nombre = txtNombre.Text;
                    benef.Dui = txtDui.Text;
                    db.Beneficiarios.Add(benef);
                    db.SaveChanges();
                    CargarDatos();
                    limpiar();

                }
            }
            else
            {

                MessageBox.Show("Los datos estan incompletos");

            }
        }

        private void dgvBeneficiarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                      

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            using(Sistema_BeneficiarioEntities1 db = new Sistema_BeneficiarioEntities1())
            {

                string Id = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
                int ID = int.Parse(Id);
                benef = db.Beneficiarios.Where(VerificarId => VerificarId.IdBeneficiario == ID).First();
                benef.Nombre = txtNombre.Text;
                benef.Dui = txtDui.Text;
                db.Entry(benef).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            CargarDatos();
            limpiar();
        }

        private void frmAdministrador1_Load(object sender, EventArgs e)
        {
            CargarDatos();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            using ( Sistema_BeneficiarioEntities1 db = new Sistema_BeneficiarioEntities1())
            {
                string Id = dgvBeneficiarios.CurrentRow.Cells[0].Value.ToString();
                benef = db.Beneficiarios.Find(int.Parse(Id));
                db.Beneficiarios.Remove(benef);
                db.SaveChanges();


            }
            CargarDatos();
            limpiar();

        }

        private void dgvBeneficiarios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string nombre = dgvBeneficiarios.CurrentRow.Cells[1].Value.ToString();
            string dui = dgvBeneficiarios.CurrentRow.Cells[2].Value.ToString();

            txtNombre.Text = nombre;
            txtDui.Text = dui;
        }
    }
}
