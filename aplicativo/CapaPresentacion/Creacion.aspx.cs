using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefinirGrupo.aspx"); //Direcciona a definicion de grupo
        }
    }
}