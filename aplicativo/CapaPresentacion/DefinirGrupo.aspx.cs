using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CapaPresentacion
{
    public partial class DefinirGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cant_medidores.Text = Session["cantidad"].ToString();      //Pasa funcion para llenar cantidad
                doc_entrada.Text = Session["docEntrada"].ToString();      //Pasa funcion para llenar cantidad
                tipoGrupo.SelectedValue = Session["tipo"].ToString();          //Pasa funcion para llenar cantidad
                llenar_marca();         //Pasa funcion para llenar lista
                llenar_modelo();        //Pasa funcion para llenar lista
            }
        }
            protected void llenar_marca()
        {
            Grupo dg = new Grupo();               //Crea una instancia de clase
            DataTable dt = dg.getMarca();   //Pasa el metodo consulta inicial
            marca.Items.Clear();
            marca.AppendDataBoundItems = true;
            marca.Items.Add("Seleccione...");
            this.marca.DataSource = dt;            //Agrega al GridView el dataset
            marca.DataTextField = "MARK";     //Selecciona el campo a mostrar
            marca.DataValueField = "MARK";    //Selecciona el campo para el valor
            marca.DataBind();
        }

        protected void llenar_modelo()
        {
            Grupo dg = new Grupo();               //Crea una instancia de clase
            dg.Marca = marca.SelectedItem.Value;  //Pasa el valor de la lista
            DataTable dt = dg.getModelo();        //Pasa el metodo consulta inicial
            modelo.Items.Clear();
            modelo.AppendDataBoundItems = true;
            modelo.Items.Add("Seleccione...");
            this.modelo.DataSource = dt;            //Agrega al GridView el dataset
            modelo.DataTextField = "NAME_MODEL";     //Selecciona el campo a mostrar
            modelo.DataValueField = "NAME_MODEL";    //Selecciona el campo para el valor
            modelo.DataBind();
        }

        protected void cerrar_Click(object sender, EventArgs e)
        {
            /*int salida;
salida = Convert.ToInt32(logout.Value);//Toma el valor del contador
Response.Write("<script language=javascript> alert('Respuesta es " + salida + "'); </script>");*/
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_modelo(); //Llena lista modelo
        }

        protected void modelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void continuar_Click(object sender, EventArgs e)
        {
            bool campo = ValidarCampos();
            if(campo == true)
            {
                string nomGrupo = "";   //Variable para nombre de grupo
                nomGrupo = marca.SelectedItem.Value.Substring(0, 3); //Toma los 3 primeros de marca
                int cantModelo = modelo.SelectedItem.Value.Length; //Cantidad de caracteres de filtro modelo
                int index = cantModelo - 4; //Le resta 4 a ese total
                nomGrupo = nomGrupo + modelo.SelectedItem.Value.Substring(index, 4); //Toma los 4 ultimos de modelo
                nomGrupo = nomGrupo + fase.SelectedItem.Value.Substring(0, 1); //Toma el valor de fase
                nomGrupo = nomGrupo + energia.SelectedItem.Value.Substring(0, 1); //Toma el valor de energia
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Nombre grupo "+nomGrupo+"');</script>");
                nombreGrupo.Value = nomGrupo;    //Pone valor a campo nombre grupo
                Response.Redirect("Medidores.aspx?nomGrupo="+nombreGrupo.Value); //Redirecciona a medidores
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Faltan campos');</script>");
            }
        }

        public bool ValidarCampos()
        {
            if (this.marca.Text.Equals("Seleccione..."))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Seleccione marca');</script>");
                return false;
            }
            else if (this.modelo.Text.Equals("Seleccione..."))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Seleccione modelo');</script>");
                return false;
            }
            else if (this.energia.Text.Equals("0"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Seleccione energia');</script>");
                return false;
            }
            else if (this.fase.Text.Equals("0"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Seleccione fase');</script>");
                return false;
            }
            return true;
        }

        protected void energia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cancelar_Click(object sender, EventArgs e)
        {

        }

        protected void actualizar_Click(object sender, EventArgs e)
        {

        }

        protected void definirGrupo_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}