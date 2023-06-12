using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryArla_Tp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        clsLocalidad objLocalidad;
        clsProfesion objProfesion;
        clsEncuesta objEncuesta;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objLocalidad = new clsLocalidad();
                objProfesion = new clsProfesion();
                objEncuesta = new clsEncuesta();

                grlDatos.Rows.Clear();
                grlDatos.Columns.Clear();


                objProfesion.cmdListar(grlDatos);
                objLocalidad.cmdListar(grlDatos);
                objEncuesta.cmdCargar(grlDatos);
            }
            catch (Exception Mensajito)
            {

                MessageBox.Show("Error en la carga de datos: \n" + Mensajito.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
           

            
        }

        private void grlDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        

    }
}
