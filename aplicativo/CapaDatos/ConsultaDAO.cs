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

        public DataTable SP_consulta_inicial(string cliente)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(cliente);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_consulta_inicial", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@ID_TBCLIENT", SqlDbType.BigInt).Value = a;

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

        public DataTable SP_consulta_actualizar(string estado,string cliente)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(estado);
            int b = int.Parse(cliente);
            try
            {              
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_consulta_actualizar", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@ESTADO", SqlDbType.BigInt).Value = a;
                comando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = b;

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

        public string SP_id(string usuario)//Procedimiento que trae el ID del usuario
        {
            try
            {
                string Id = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_id", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Id = rpt["ID_TBCLIENT"].ToString();
                }
                return Id;
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

        public DataTable SP_documentos_entrada(string cliente)//Procedimiento para documentos entrada
        {
            int a = int.Parse(cliente);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_documentos_entrada", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@ID_TBCLIENT", SqlDbType.BigInt).Value = a;

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

        public DataTable SP_numero_serial(string cliente)//Procedimiento para numero serial
        {
            int a = int.Parse(cliente);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_numero_serial", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@ID_TBCLIENT", SqlDbType.BigInt).Value = a;

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

        public DataTable SP_grupo(string cliente)//Procedimiento para numero serial
        {
            int a = int.Parse(cliente);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_grupo", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@ID_TBCLIENT", SqlDbType.BigInt).Value = a;

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