using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TareasDAO : conexion
    {
        //Procedimiento para guardar la tarea
        public string SP_guardar_tarea(string cliente, string zona, string codigo, string documento, string serial, string marca, string modelo)
        {
            try
            {
                string registro = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_guardar_tarea", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID_TBCLIENT", SqlDbType.Int).Value = cliente;
                comando.Parameters.Add("@ID_TBCLZONE", SqlDbType.Int).Value = zona;
                comando.Parameters.Add("@ID_TBINCODEMTR", SqlDbType.Int).Value = codigo;
                comando.Parameters.Add("@DOC_ENTRY", SqlDbType.VarChar).Value = documento;
                comando.Parameters.Add("@NUM_SERIAL", SqlDbType.VarChar).Value = serial;
                comando.Parameters.Add("@MARK", SqlDbType.VarChar).Value = marca;
                comando.Parameters.Add("@NAME_MODEL", SqlDbType.VarChar).Value = modelo;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    registro = rpt["ID_TBPRELOADMTR"].ToString();
                }
                return registro;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }
    }
}