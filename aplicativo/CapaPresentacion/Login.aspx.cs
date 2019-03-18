using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void Iniciar_Click(object sender, EventArgs e)
        {

            Empleado em = new Empleado();
            em.Usuario = Usuario.Text;
            em.Contraseña = Contraseña.Text;
            string CARGO = em.inicio_sesion();

            if (CARGO == "Administrador")
            {

                Session["Login"] = Usuario.Text;
                Response.Redirect("Inicial.aspx");



            }
            else


            if (CARGO == "Usuario")
            {
                Session["Login"] = Usuario.Text;
                Response.Redirect("Inicial.aspx");
            }
            else
            {

                Console.WriteLine("Error");
            }
        }
    }
}