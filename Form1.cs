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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsLocalidad objLocalidad;
        clsProfesion objProfesion;
        clsEncuesta objEncuesta;
        private void Form1_Load(object sender, EventArgs e)
        {

            objLocalidad = new clsLocalidad();
            objProfesion = new clsProfesion();
            objEncuesta = new clsEncuesta();

            grlDatos.Rows.Clear();
            grlDatos.Columns.Clear();
           

            objProfesion.Listar(grlDatos);
            objLocalidad.Listar(grlDatos);

            DataTable varTablaE = objEncuesta.getAll();

            foreach (DataRow fila in varTablaE.Rows)
            {
                int varLocalidadId = Convert.ToInt32(fila.ItemArray[0]);
                int varProfesionId = Convert.ToInt32(fila.ItemArray[1]); 

                string varLocalidad = objLocalidad.Busqueda(varLocalidadId);
                string varProfesion = objProfesion.Busqueda(varProfesionId);

                int columnaProfesionIndex = -1;

                for (int i = 0; i < grlDatos.Columns.Count; i++)
                {
                    if (grlDatos.Columns[i].HeaderText == varProfesion)
                    {
                        columnaProfesionIndex = i;
                        break;
                    }
                }
                if (columnaProfesionIndex != -1)
                {
                    foreach (DataGridViewRow filaGrilla in grlDatos.Rows)
                    {
                        if (filaGrilla.Cells[0].Value.ToString() == varLocalidad)
                        {
                            filaGrilla.Cells[columnaProfesionIndex].Value = fila["cantidad"];
                        }
                    }

                }
            }


        }

        private void grlDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        

    }
}
