using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices.WindowsRuntime;

namespace pryArla_Tp
{
    internal class clsEncuesta
    {

        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        public clsEncuesta()
        {
            conector = new OleDbConnection(Properties.Settings.Default.CADENA);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Encuestas";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[2];
            dc[0] = tabla.Columns["localidad"];
            dc[1] = tabla.Columns["profesion"];
            tabla.PrimaryKey = dc;
        }

        public void cmdCargar(DataGridView Grilla)
        {
           
            foreach (DataRow fila in tabla.Rows)
            {
                string localidad = fila["localidad"].ToString();
                string profesion = fila["profesion"].ToString();
                object cantidad = fila["cantidad"];

                foreach (DataGridViewRow filaG in Grilla.Rows)
                {
                    if (filaG.Tag.ToString() == localidad)
                    {
                        foreach (DataGridViewColumn columnaG in Grilla.Columns)
                        {
                            if (columnaG.Name.ToString() == profesion)
                            {
                                Grilla.Rows[filaG.Index].Cells[columnaG.Index].Value = cantidad;
                                break;
                            }
                        }
                        break;
                    }
                }
            }

        }
    
    }
}
