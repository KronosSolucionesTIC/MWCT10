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
    public partial class Medidores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Request.QueryString["nomGrupo"].ToString();
                llenar_zona();        //Pasa funcion para llenar lista
                llenar_codigos();     //Pasa funcion para llenar lista 
                llenar_ayuda();       //Pasa funcion para llenar lista 
            }
        }

        protected void llenar_ayuda()
        {
            Medidor ayu = new Medidor();               //Crea una instancia de clase  
            DataTable dt = ayu.getAyuda();     //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
            GridView1.DataBind();
        }

        protected void llenar_zona()
        {
            Medidor med = new Medidor();               //Crea una instancia de clase
            DataTable dt = med.getZona();   //Pasa el metodo consulta inicial
            zona.Items.Clear();
            zona.AppendDataBoundItems = true;
            zona.Items.Add("Seleccione...");
            this.zona.DataSource = dt;            //Agrega al GridView el dataset
            zona.DataTextField = "NAME_ZONE";     //Selecciona el campo a mostrar
            zona.DataValueField = "NAME_ZONE";    //Selecciona el campo para el valor
            zona.DataBind();
        }

        protected void llenar_codigos()
        {
            Medidor med = new Medidor();               //Crea una instancia de clase
            DataTable dt = med.getCodigos();   //Pasa el metodo consulta inicial
            codigos.Items.Clear();
            codigos.AppendDataBoundItems = true;
            codigos.Items.Add("Seleccione...");
            this.codigos.DataSource = dt;            //Agrega al GridView el dataset
            codigos.DataTextField = "CODE";     //Selecciona el campo a mostrar
            codigos.DataValueField = "CODE";    //Selecciona el campo para el valor
            codigos.DataBind();
        }

        protected void cerrar_Click(object sender, EventArgs e)
        {

        }

        protected void zona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ayuda_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == true)
            {
                GridView1.Visible = false;
            } else
            {
                GridView1.Visible = true;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void continuar_Click(object sender, EventArgs e)
        {

        }

        protected void cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}