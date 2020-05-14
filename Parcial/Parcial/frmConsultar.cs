using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial.Model;
using Parcial.View;

namespace Parcial
{
    public partial class frmConsultar : Form
    {
        public frmConsultar()
        {
            InitializeComponent();
            lblBeneficiario.Hide();
            lblNombre.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Sistema_BeneficiarioEntities1 db = new Sistema_BeneficiarioEntities1())
            {

                frmLogin A = new frmLogin();
                A.ShowDialog();

            }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            using(Sistema_BeneficiarioEntities1 db = new Sistema_BeneficiarioEntities1())
            {

                lblBeneficiario.Hide();
                lblNombre.Hide();

                string Dui = txtDuiCons.Text;
                var lista = from benef in db.Beneficiarios
                            where benef.Dui == Dui
                            select new
                            {
                                Nombre = benef.Nombre
                            };
                if (lista.Count() > 0)
                {
                    lblBeneficiario.Show();
                    foreach (var it in lista)
                    {
                        lblNombre.Text = it.Nombre.ToString();
                        lblNombre.Show();

                    }


                }else
                {
                    lblNombre.Text = "NO ES BENEFICIARIO";
                    lblBeneficiario.Hide();
                    lblNombre.Show();
                    txtDuiCons.Text = "";

                }

            }

        }

        private void txtDuiCons_TextChanged(object sender, EventArgs e)
        {
            lblNombre.Hide();
            lblBeneficiario.Hide();
        }

        private void frmConsultar_Load(object sender, EventArgs e)
        {
            
        }
    }
}
