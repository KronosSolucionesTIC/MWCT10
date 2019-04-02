using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConsultaDAO : conexion
    {

        public DataTable SP_consulta_inicial()//Procedimiento para inicio de sesion
        {
            try
            {
                //Se declara el dataadapter
                SqlDataAdapter da = new SqlDataAdapter("SP_consulta_inicial", conn);
                //Contenedor de datos
                DataTable dt = new DataTable();
                //Se llena el contenedor
                da.Fill(dt);
                //Retorna el valor de dt
                return dt;
            }
            finally
            {
                conn.Close();
            }

        }

        public DataTable SP_consulta_actualizar(string estado)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(estado);
            try
            {              
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_consulta_actualizar", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@ESTADO", SqlDbType.BigInt).Value = a;

                //Se declara el DataAdapter
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                //Contenedor de datos
                DataTable dt = new DataTable();
                //Se llena el contenedor
                da.Fill(dt);
                //Retorna el valor de dt
                return dt;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}