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
            string ok = em.inicio_sesion();
            string Id = em.getId();
            string bloqueo = em.getBloqueo();
            string activo = em.getActivo();
            int contador = 0;

            /*if (CARGO == "Administrador")
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario Invalido');</script>");
            }*/

            if (Id != "")//Valida si existe el usuario
            {
                if (bloqueo == "1")//Valida si esta bloqueado
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario Bloqueado. Contacte al Administrador');</script>");
                } else
                {
                    //Valida si esta activo
                    if(activo == "0")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario Deshabilitado. Contacte al administrador');</script>");
                    } else
                    {
                        if (ok == "true")
                        {    
                            Session["Login"] = Usuario.Text;
                            Response.Redirect("Inicial.aspx");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Bienvenido a MWCT10. '" + Usuario.Text + "');</script>");

                        } else
                        {
                            contador = contador++;
                            Response.Write("<script language=javascript> alert('" + contador + "'); </script>");
                        }
                    }
                    
                }
            } else
            {
                Usuario.Text = string.Empty;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario Invalido');</script>");
            }
        }
    }
}