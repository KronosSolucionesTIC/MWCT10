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
                llenar_cliente();
            }
            calcular_fecha();

            string cadenaconexion = "Data Source=.;Initial Catalog =PROYECTO; Integrated security=true";//cadena de conexion  \\
            SqlConnection conn = new SqlConnection(cadenaconexion);

            //Se declara el dataadapter
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TB_ACTY_MTR", conn);
            //Contenedor de datos
            DataTable dt = new DataTable();
            //Se llena el contenedor
            da.Fill(dt);
            //Agregamos a datagriedview con datasource
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void llenar_cliente()
        {
            cliente.DataSource = consultar("SELECT ID_TBCLIENT,NAME_CLIENT FROM TB_CLIENT");
            cliente.DataTextField = "NAME_CLIENT";
            cliente.DataValueField = "ID_TBCLIENT";
            cliente.DataBind();
        }

        protected void calcular_fecha()
        {
            //txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

        protected void TxtFecha_TextChanged(object sender, EventArgs e)
        {

        }


        protected void cerrar_Click(object sender, EventArgs e)
        {
            /*int salida;
            salida = Convert.ToInt32(logout.Value);//Toma el valor del contador
            Response.Write("<script language=javascript> alert('Respuesta es " + salida + "'); </script>");*/
            Session.RemoveAll();

            Response.Redirect("Login.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            string cadenaconexion = "Data Source=.;Initial Catalog =PROYECTO; Integrated security=true";//cadena de conexion  \\
            SqlConnection conn = new SqlConnection(cadenaconexion);

            //Se declara el dataadapter
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TB_ACTY_MTR WHERE ID_STATE = '" + estado.SelectedValue + " '", conn);
            //Contenedor de datos
            DataTable dt = new DataTable();
            //Se llena el contenedor
            da.Fill(dt);
            //Agregamos a datagriedview con datasource
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}