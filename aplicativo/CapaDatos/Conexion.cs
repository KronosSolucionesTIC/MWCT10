using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class conexion //clase publica conexion //
    {
        private string texto;// variable tipo privado que permite mandar mensajes// 
        public SqlConnection conn;//svariable pera connectar la base de daatos con el proyecto// 


        public string Texto
        {
            get { return texto; }// get es para obteneer datos //
            set { texto = value; }// set es para modificar datos //
        }

        


        public conexion()
        {
            string cadenaconexion = "Data Source=.;Initial Catalog =PROYECTO; Integrated security=true";//cadena de conexion  \\
                                                                                                                           //string cadenaconexion = "Data Source=DESKTOP-V53MDQU\\SQLEXPRESS;Initial Catalog =PROYECTOVDAGV; Integrated security=true";//cadena de conexion  \\
                                                                                                                           // string cadenaconexion = "Data Source=DESKTOP-V53MDQU\\SQLEXPRESS;Initial Catalog =PROYECTOVDAGV; Integrated security=true";//cadena de conexion  \\

            conn = new SqlConnection(cadenaconexion);


        }
       
       
        public string SP_inicio_Sesion(string usuario, string contraseña)
        {
            try
            {
                string Cargo = "";


                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_inicio_Sesion", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;
                comando.Parameters.Add("@PASS", SqlDbType.VarChar, 15).Value = contraseña;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Cargo = rpt["ROL"].ToString();

                }
                return Cargo;
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




