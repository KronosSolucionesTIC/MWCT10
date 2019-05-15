using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Consulta ci = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            ci.Usuario = usu;                           //Pasa el valor de usuario
            string Id = ci.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            string cli = ci.getCliente();               //Pasa el metodo getId para validar si existe el usuario     
            ci.Cliente = Id;                            //Pasa el valor de la lista
            usuario.Text = usu;                         //Pone nombre usuario
            cliente.Text = cli;                         //Pone nombre cliente
            string doc = Convert.ToString(Session["Documento"]); //Lee la variable Sessiondoc
            documento.Value = doc;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#registroModal').modal('show');</script>");      
        }

        protected void redireccionar(object sender, EventArgs e)
        {
            Response.Redirect("Creacion.aspx");
        }

        protected void cerrar_Click(object sender, EventArgs e)
        {

        }
    }
}