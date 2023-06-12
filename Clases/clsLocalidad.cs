using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pryArla_Tp
{
    internal class clsLocalidad
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        public clsLocalidad()
        {
            conector = new OleDbConnection(Properties.Settings.Default.CADENA);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Localidades";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[1];
            dc[0] = tabla.Columns["localidad"];
            tabla.PrimaryKey = dc;
        }

        public void cmdListar(DataGridView Grilla)
        {
            int i = 0;
            
            foreach (DataRow fila in tabla.Rows)
            {
                
                Grilla.Rows.Add();
                Grilla.Rows[i].HeaderCell.Value = fila["nombre"];
                Grilla.Rows[i].Tag = fila["localidad"];
                i++;
            }

        }
        public DataTable getAll()
        {
            return tabla;
        }
        
    }
}
