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

        protected void actualizar_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCampos();    //Valida campos
            if(campos == true)
            {
                //agrega_items();             //Agrega items a la tabla
                bloquea_campos_cant();      //Bloquea campos cantidad/documento
                desbloquea_campos_grupo();   //Desbloque campos grupo
            }
        }

        protected void bloquea_campos_cant()
        {
            //tipoGrupo.Enabled = false;       //Bloquea cantidad
            cant_medidores.Disabled = true; //Bloquea cantidad
            doc_entrada.Enabled = false;    //Bloquea documento entrada
            act_cantidad.Enabled = false;     //Bloquea actualizar
        }

        protected void desbloquea_campos_grupo()
        {
            //act_grupo.Enabled = true;       //Desbloquea actualizar
        }

        protected void agrega_items()
        {
            // Generate rows and cells. 
            int cant = int.Parse(cant_medidores.Value);
            int numRows =  cant;
            int numCells = 2;
            int counter = 1;

            for (int rowNum = 0; rowNum<numRows; rowNum++)
            {
                TableRow rw = new TableRow();
                for (int cellNum = 0; cellNum<numCells; cellNum++)
                {
                    TableCell cel = new TableCell();
                    if(cellNum == 0)
                    {
                        cel.Text = doc_entrada.Text.ToString();
                    } else
                    {
                        cel.Text = "";
                    }                    
                    rw.Cells.Add(cel);
                    counter++;
                }
                Table1.Rows.Add(rw);
                Table1.GridLines = GridLines.Both;
                Table1.CellPadding = 4;
                Table1.CellSpacing = 0;
            }
        }

        public bool ValidarCampos()
        {
            if (this.cant_medidores.Value.Equals("0"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('La cantidad debe ser mayor a 0');</script>");
                return false;
            }
            else if (this.doc_entrada.Text.Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El documento de entrada no puede ser vacio');</script>");
                return false;
            }
            return true;
        }

        protected void act_grupo_Click(object sender, EventArgs e)
        {
                int cant = int.Parse(cant_medidores.Value);      //Toma la cantidad de medidores
                //string tipo = tipoGrupo.SelectedItem.Value;    //Pasa el valor de la lista
                string doc = doc_entrada.Text;    //Pasa el valor de la lista
                Session["cantidad"] = cant;                     //Asigna cantidad a variable Session
                //Session["tipo"] = tipo;                         //Asigna tipo a variable Session
                Session["docEntrada"] = doc;                         //Asigna tipo a variable Session
                Response.Redirect("DefinirGrupo.aspx");         //Redirecciona a Definicion grupo
        }

        protected void act_serial_Click(object sender, EventArgs e)
        {

        }

        protected void act_serial_Click1(object sender, EventArgs e)
        {

        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Creacion.aspx");//Redirecciona creacion tarea
        }

        protected void marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_modelo();        //LLena modelo
        }

        protected void llenar_modelo()
        {
            /*
            Grupo dg = new Grupo();               //Crea una instancia de clase
            dg.Marca = marca.SelectedItem.Value;  //Pasa el valor de la lista
            DataTable dt = dg.getModelo();        //Pasa el metodo consulta inicial
            modelo.Items.Clear();
            modelo.AppendDataBoundItems = true;
            modelo.Items.Add("Seleccione...");
            this.modelo.DataSource = dt;            //Agrega al GridView el dataset
            modelo.DataTextField = "NAME_MODEL";     //Selecciona el campo a mostrar
            modelo.DataValueField = "NAME_MODEL";    //Selecciona el campo para el valor
            modelo.DataBind();*/
        }
    }
}