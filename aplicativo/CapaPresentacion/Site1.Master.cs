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




        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ciudad_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Inicial.aspx");//Redirecciona consulta tarea
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Creacion.aspx");//Redirecciona creacion tarea
        }
    }
    }
