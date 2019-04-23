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
                agrega_items();             //Agrega items a la tabla
                bloquea_campos_cant();      //Bloquea campos cantidad/documento
                desbloquea_campos_grupo();   //Desbloque campos grupo
            }
        }

        protected void bloquea_campos_cant()
        {
            cant_medidores.Disabled = true; //Bloquea cantidad
            doc_entrada.Enabled = false;    //Bloquea documento entrada
            act_cantidad.Enabled = false;     //Bloquea actualizar
        }

        protected void desbloquea_campos_grupo()
        {
            tipoGrupo.Enabled = true;       //Bloquea cantidad
            act_grupo.Enabled = true;       //Desbloquea actualizar
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

        public bool ValidarCamposGrupo()
        {
            if (this.tipoGrupo.Text.Equals("0"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Seleccione el tipo de grupo');</script>");
                agrega_items();             //Agrega items a la tabla
                return false;
            }
            return true;
        }

        protected void definirGrupo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void act_grupo_Click(object sender, EventArgs e)
        {
            bool campos = ValidarCamposGrupo();                  //Valida campos
            if (campos == true)
            {
                int cant = int.Parse(cant_medidores.Value);      //Toma la cantidad de medidores
                string tipo = tipoGrupo.SelectedItem.Value;    //Pasa el valor de la lista
                string doc = doc_entrada.Text;    //Pasa el valor de la lista
                Session["cantidad"] = cant;                     //Asigna cantidad a variable Session
                Session["tipo"] = tipo;                         //Asigna tipo a variable Session
                Session["docEntrada"] = doc;                         //Asigna tipo a variable Session
                Response.Redirect("DefinirGrupo.aspx");         //Redirecciona a Definicion grupo
            }
        }

        protected void act_serial_Click(object sender, EventArgs e)
        {

        }
    }
}