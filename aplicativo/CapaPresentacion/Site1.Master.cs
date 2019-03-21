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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Session["Login"] == null)
            {


                Session.RemoveAll();

                Response.Redirect("Login.aspx");
            }

        }



            protected void cerrar_Click(object sender, EventArgs e)
            {
                int salida;
                salida = Convert.ToInt32(logout.Value);//Toma el valor del contador
                Response.Write("<script language=javascript> alert('Respuesta es " + salida + "'); </script>");
            //Session.RemoveAll();

            //Response.Redirect("Login.aspx");
            }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ciudad_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
    }
