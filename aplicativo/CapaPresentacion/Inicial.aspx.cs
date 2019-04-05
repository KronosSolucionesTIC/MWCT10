using CapaLogica;
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

            Consulta ci = new Consulta();               //Crea una instancia de clase
            DataTable dt = ci.getConsultaInicial();     //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
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
            Consulta ca = new Consulta();               //Crea una instancia de clase
            ca.Estado = estado.SelectedItem.Value;            //Pasa el valor de la lista
            DataTable dt = ca.getConsultaActualizar();  //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
            GridView1.DataBind();
        }
    }
}