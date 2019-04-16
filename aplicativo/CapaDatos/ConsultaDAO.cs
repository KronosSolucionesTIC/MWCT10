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

        public DataTable SP_consulta_actualizar(string cliente,string documento, string serial, string grupo, string inicial,string final,string estado)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(cliente);

            if(documento == "Seleccione...")
            {
                documento = "";
            }

            if (serial == "Seleccione...")
            {
                serial = "";
            }

            if (grupo == "Seleccione...")
            {
                grupo = "";
            }

            DateTime e = DateTime.Parse(inicial);
            DateTime f = DateTime.Parse(final);
 
            int g = int.Parse(estado);

            try
            {              
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_consulta_actualizar", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = a;
                comando.Parameters.Add("@DOC_ENTRADA", SqlDbType.VarChar).Value = documento;
                comando.Parameters.Add("@NUM_SERIAL", SqlDbType.VarChar).Value = serial;
                comando.Parameters.Add("@GRUPO", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.Add("@FECHAINI", SqlDbType.Date).Value = e;
                comando.Parameters.Add("@FECHAFIN", SqlDbType.Date).Value = f;
                comando.Parameters.Add("@ESTADO", SqlDbType.BigInt).Value = g;

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

        public DataTable SP_de_actualizar(string cliente, string documento, string serial, string grupo, string inicial, string final, string estado)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(cliente);

            if (documento == "Seleccione...")
            {
                documento = "";
            }

            if (serial == "Seleccione...")
            {
                serial = "";
            }

            if (grupo == "Seleccione...")
            {
                grupo = "";
            }

            DateTime e = DateTime.Parse(inicial);
            DateTime f = DateTime.Parse(final);

            int g = int.Parse(estado);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_documentos_entrada_actualizar", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = a;
                comando.Parameters.Add("@DOC_ENTRADA", SqlDbType.VarChar).Value = documento;
                comando.Parameters.Add("@NUM_SERIAL", SqlDbType.VarChar).Value = serial;
                comando.Parameters.Add("@GRUPO", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.Add("@FECHAINI", SqlDbType.Date).Value = e;
                comando.Parameters.Add("@FECHAFIN", SqlDbType.Date).Value = f;
                comando.Parameters.Add("@ESTADO", SqlDbType.BigInt).Value = g;

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

        public DataTable SP_ns_actualizar(string cliente, string documento, string serial, string grupo, string inicial, string final, string estado)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(cliente);

            if (documento == "Seleccione...")
            {
                documento = "";
            }

            if (serial == "Seleccione...")
            {
                serial = "";
            }

            if (grupo == "Seleccione...")
            {
                grupo = "";
            }

            DateTime e = DateTime.Parse(inicial);
            DateTime f = DateTime.Parse(final);

            int g = int.Parse(estado);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_numero_serial_actualizar", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = a;
                comando.Parameters.Add("@DOC_ENTRADA", SqlDbType.VarChar).Value = documento;
                comando.Parameters.Add("@NUM_SERIAL", SqlDbType.VarChar).Value = serial;
                comando.Parameters.Add("@GRUPO", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.Add("@FECHAINI", SqlDbType.Date).Value = e;
                comando.Parameters.Add("@FECHAFIN", SqlDbType.Date).Value = f;
                comando.Parameters.Add("@ESTADO", SqlDbType.BigInt).Value = g;

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

        public DataTable SP_gru_actualizar(string cliente, string documento, string serial, string grupo, string inicial, string final, string estado)//Procedimiento para inicio de sesion
        {

            int a = int.Parse(cliente);

            if (documento == "Seleccione...")
            {
                documento = "";
            }

            if (serial == "Seleccione...")
            {
                serial = "";
            }

            if (grupo == "Seleccione...")
            {
                grupo = "";
            }

            DateTime e = DateTime.Parse(inicial);
            DateTime f = DateTime.Parse(final);

            int g = int.Parse(estado);

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_grupo_actualizar", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = a;
                comando.Parameters.Add("@DOC_ENTRADA", SqlDbType.VarChar).Value = documento;
                comando.Parameters.Add("@NUM_SERIAL", SqlDbType.VarChar).Value = serial;
                comando.Parameters.Add("@GRUPO", SqlDbType.VarChar).Value = grupo;
                comando.Parameters.Add("@FECHAINI", SqlDbType.Date).Value = e;
                comando.Parameters.Add("@FECHAFIN", SqlDbType.Date).Value = f;
                comando.Parameters.Add("@ESTADO", SqlDbType.BigInt).Value = g;

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