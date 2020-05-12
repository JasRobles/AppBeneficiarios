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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Sistema_BeneficiarioEntities db = new Sistema_BeneficiarioEntities())
            {

                frmLogin A = new frmLogin();
                A.ShowDialog();

            }
            
        }
    }
}
