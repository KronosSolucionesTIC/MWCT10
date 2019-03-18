using System;
using System.Collections.Generic;
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
          
                Session.RemoveAll();

                Response.Redirect("Login.aspx");
            }


        }
    }
