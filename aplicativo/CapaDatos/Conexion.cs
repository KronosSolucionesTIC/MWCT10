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
            conn = new SqlConnection(cadenaconexion);
        }
    }
}