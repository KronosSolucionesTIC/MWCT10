using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
            //    string cadenaconexion = "Server=dbantsgsql.chvqhnsfueef.us-east-1.rds.amazonaws.com;Database=DBSIGELAB_MZL;User Id=WebApp;Password=DBl0g1nSQL19;";//cadena de conexion  \\ Data Source=.;Initial Catalog =PROYECTO; Integrated security=true
            string cadenaconexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
            //string cadenaconexion = "Data Source=chvqhnsfueef.us-east-1.rds.amazonaws.com\\dbantsgsql;Initial Catalog =DBSIGELAB_MZL;User ID=webapp; Password=DBl0g1nSQL19; Integrated security=true";
            conn = new SqlConnection(cadenaconexion);
        }
    }
}