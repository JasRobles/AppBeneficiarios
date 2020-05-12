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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = "master";
            string contraseña = "123";
            if(txtUsuario.Text == usuario && txtContraseña.Text == contraseña)
            {

                frmAdministrador1 A = new frmAdministrador1();
                A.ShowDialog();

            }
            else
            {
                MessageBox.Show("El usuario es invalido");
            }
        }
    }
}
