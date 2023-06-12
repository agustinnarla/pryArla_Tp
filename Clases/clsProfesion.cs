using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
namespace pryArla_Tp
{
    internal class clsProfesion
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        public clsProfesion()
        {
            conector = new OleDbConnection(Properties.Settings.Default.CADENA);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Profesiones";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[1];
            dc[0] = tabla.Columns["profesion"];
            tabla.PrimaryKey = dc;
        }

        public void cmdListar(DataGridView Grilla)
        {

            Grilla.Columns.Add("localidades and profesion", "Localidades / Profesion");
            foreach (DataRow varFilaProf in tabla.Rows)
            {

                Grilla.Columns.Add(varFilaProf["profesion"].ToString(), varFilaProf["nombre"].ToString());

            }

        }
        public DataTable getAll()
        {
            return tabla;
        }

    }
}
