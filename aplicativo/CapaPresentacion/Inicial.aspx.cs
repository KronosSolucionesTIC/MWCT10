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
                llenar_documentos_entrada();
                llenar_num_serial();
                llenar_grupo();
            }
            calcular_fecha();

            Consulta ci = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            ci.Usuario = usu;                       //Pasa el valor de usuario
            string Id = ci.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            ci.Cliente = Id;                           //Pasa el valor de la lista
            DataTable dt = ci.getConsultaInicial();     //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
            GridView1.DataBind();
        }

        protected void llenar_documentos_entrada()
        {
            Consulta de = new Consulta();               //Crea una instancia de clase
            DataTable dt = de.getDocumentosEntrada();   //Pasa el metodo consulta inicial
            this.docEntrada.DataSource = dt;            //Agrega al GridView el dataset
            docEntrada.DataTextField = "DOC_ENTRY";     //Selecciona el campo a mostrar
            docEntrada.DataValueField = "DOC_ENTRY";    //Selecciona el campo para el valor
            docEntrada.DataBind();
        }

        protected void llenar_num_serial()
        {
            Consulta de = new Consulta();               //Crea una instancia de clase
            DataTable dt = de.getNumeroSerial();   //Pasa el metodo consulta inicial
            this.numeroSerial.DataSource = dt;            //Agrega al GridView el dataset
            numeroSerial.DataTextField = "NUM_SERIAL";     //Selecciona el campo a mostrar
            numeroSerial.DataValueField = "NUM_SERIAL";    //Selecciona el campo para el valor
            numeroSerial.DataBind();
        }

        protected void llenar_grupo()
        {
            Consulta gru = new Consulta();               //Crea una instancia de clase
            DataTable dt = gru.getGrupo();   //Pasa el metodo consulta inicial
            this.nombreGrupo.DataSource = dt;            //Agrega al GridView el dataset
            nombreGrupo.DataTextField = "NAME_GROUP";     //Selecciona el campo a mostrar
            nombreGrupo.DataValueField = "NAME_GROUP";    //Selecciona el campo para el valor
            nombreGrupo.DataBind();
        }

        protected void calcular_fecha()
        {
            //txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            ca.Estado = estadoActividad.SelectedItem.Value;            //Pasa el valor de la lista
            DataTable dt = ca.getConsultaActualizar();  //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
            GridView1.DataBind();
        }

        protected void tareas_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}