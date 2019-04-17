﻿using CapaLogica;
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
                llenar_marca();        //Pasa funcion para llenar lista
                llenar_modelo();       //Pasa funcion para llenar lista
                /*llenar_grupo();                     //Pasa funcion para llenar lista
                TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd"); //Toma la fecha actual
                DateTime fecha = DateTime.Today.AddDays(-15);
                TextBox1.Text = fecha.ToString("yyyy-MM-dd");*/
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

        protected void docEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void modelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void continuar_Click(object sender, EventArgs e)
        {
            bool campo = ValidarCampos();
            if(campo == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Campos ok');</script>");
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
    }
}