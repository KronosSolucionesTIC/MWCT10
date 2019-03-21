using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenar_ciudad();
            }
        }

        protected void llenar_ciudad()
        {
            ciudad.DataSource = consultar("SELECT * FROM ciudad");
            ciudad.DataTextField = "NOMBRE";
            ciudad.DataValueField = "ID_CIUDAD";
            ciudad.DataBind();
        }

        public DataSet consultar(string sentencia)
        {
            string cadenaconexion = "Data Source=.;Initial Catalog =PROYECTO; Integrated security=true";//cadena de conexion  \\
            SqlConnection conn = new SqlConnection(cadenaconexion);

            conn.Open();
            SqlCommand cmd = new SqlCommand(sentencia, conn);
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            SDA.Fill(ds);
            conn.Close();
            return ds;
        }

        protected void ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}