using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Consulta ci = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            ci.Usuario = usu;                           //Pasa el valor de usuario
            string Id = ci.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            string cli = ci.getCliente();               //Pasa el metodo getId para validar si existe el usuario     
            ci.Cliente = Id;                            //Pasa el valor de la lista
            usuario.Text = usu;                         //Pone nombre usuario
            cliente.Text = cli;                         //Pone nombre cliente

            if (!IsPostBack)
            {
                llenar_marca();         //Pasa funcion para llenar lista
                llenar_modelo();        //Pasa funcion para llenar lista
                llenar_zona();        //Pasa funcion para llenar lista
                llenar_codigos();     //Pasa funcion para llenar lista 
                llenar_ayuda();       //Pasa funcion para llenar lista
            }
            else {
                habilitar_grupo.Disabled = false;
                if (nombreGrupo.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#exampleModalLive').modal('show');</script>");
                } else
                {
                    habilitar_serial.Disabled = false;
                }
                bloquea_campos_cant();
                if (ok.Value == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#modalSerial').modal('show');</script>");
                }
            }
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
            if (campos == true)
            {
                //agrega_items();             //Agrega items a la tabla
                bloquea_campos_cant();      //Bloquea campos cantidad/documento
                desbloquea_campos_grupo();   //Desbloque campos grupo
            }
        }

        protected void llenar_marca()
        {
            Grupo dg = new Grupo();               //Crea una instancia de clase
            DataTable dt = dg.getMarca();   //Pasa el metodo consulta inicial
            //marca.AppendDataBoundItems = true;
            DataRow fila = dt.NewRow();
            fila["MARK"] = "Seleccione...";
            dt.Rows.InsertAt(fila, 0);
            marca.DataTextField = "MARK";     //Selecciona el campo a mostrar
            marca.DataValueField = "MARK";    //Selecciona el campo para el valor
            this.marca.DataSource = dt;            //Agrega al GridView el dataset
            marca.DataBind();
        }

        protected void bloquea_campos_cant()
        {
            if (Individual.Checked == true)
            {
                Individual.Disabled = true;   //Deshabilita boton habilitar grupo    
                Individual.Checked = true;
            } else
            {
                Individual.Disabled = true;   //Deshabilita boton habilitar grupo   
            }
            if (Unico.Checked == true)
            {
                Unico.Disabled = true;
                Unico.Checked = true;
            } else
            {
                Unico.Disabled = true;
            }
            cant_medidores.Disabled = true;     //Bloquea cantidad
            doc_entrada.Disabled = true;        //Bloquea documento entrada
            act_cantidad.Enabled = false;       //Bloquea actualizar
        }

        protected void desbloquea_campos_grupo()
        {
            //act_grupo.Enabled = true;       //Desbloquea actualizar
        }

        protected void agrega_items()
        {
            // Generate rows and cells. 
            int cant = 1;
            int numRows =  cant;
            int numCells = 4;
            int counter = 1;

            for (int rowNum = 0; rowNum<numRows; rowNum++)
            {
                TableRow rw = new TableRow();
                for (int cellNum = 0; cellNum<numCells; cellNum++)
                {
                    TableCell cel = new TableCell();
                    if(cellNum == 0)
                    {
                        cel.Text = serial.Value.ToString();
                    }
                    if (cellNum == 1)
                    {
                        cel.Text = nombreGrupo.Text.ToString();
                    }
                    if (cellNum == 2)
                    {
                        cel.Text = zona.SelectedValue.ToString();
                    }
                    if (cellNum == 3)
                    {
                        cel.Text = codigos.SelectedValue.ToString();
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
            if(Individual.Checked == false)
            {
                if (Unico.Checked == false)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Seleccione tipo grupo');</script>");
                    return false;
                }
            }
            if (this.cant_medidores.Value.Equals("0"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('La cantidad debe ser mayor a 0');</script>");
                return false;
            }
            else if (this.doc_entrada.Value.Equals(""))
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
                string doc = doc_entrada.Value;    //Pasa el valor de la lista
                Session["cantidad"] = cant;                     //Asigna cantidad a variable Session
                //Session["tipo"] = tipo;                         //Asigna tipo a variable Session
                Session["docEntrada"] = doc;                         //Asigna tipo a variable Session
                //Response.Redirect("DefinirGrupo.aspx");         //Redirecciona a Definicion grupo
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

        protected void marca_Selected(object sender, EventArgs e)
        {   
            llenar_modelo();        //LLena modelo
        }

        protected void llenar_modelo()
        {
            Grupo dg = new Grupo();               //Crea una instancia de clase
            dg.Marca = marca.SelectedValue;  //Pasa el valor de la lista
            DataTable dt = dg.getModelo();        //Pasa el metodo consulta inicial
            modelo.Items.Clear();
            modelo.AppendDataBoundItems = true;
            modelo.Items.Add("Seleccione...");
            this.modelo.DataSource = dt;            //Agrega al GridView el dataset
            modelo.DataTextField = "NAME_MODEL";     //Selecciona el campo a mostrar
            modelo.DataValueField = "NAME_MODEL";    //Selecciona el campo para el valor
            modelo.DataBind();
        }

        protected void mostrar_errores()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#error').show();</script>"); //Esconde los alert   
        }

        public bool ValidarCamposGrupo()
        {
            if (this.marca.Text.Equals("Seleccione..."))
            {
                return false;
            }
            else if (this.modelo.Text.Equals("Seleccione..."))
            {
                return false;
            }
            else if (this.energia.Text.Equals("0"))
            {
                return false;
            }
            else if (this.fase.Text.Equals("0"))
            {
                return false;
            }
            return true;
        }

        public bool ValidarCamposSerial()
        {
            if (this.serial.Value.Equals(""))
            {
                return false;
            }
            else if (this.zona.SelectedValue.Equals("Seleccione..."))
            {
                return false;
            }
            else if (this.codigos.SelectedValue.Equals("Seleccione..."))
            {
                return false;
            }
            return true;
        }

        protected void ayuda_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == true)
            {
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
            }
        }

        protected void continuar_Click(object sender, EventArgs e)
        {
            //error.Visible = true;
            bool campo = ValidarCamposGrupo();
            if (campo == true)
            {
                string nomGrupo = "";   //Variable para nombre de grupo
                nomGrupo = marca.SelectedItem.Value.Substring(0, 3); //Toma los 3 primeros de marca
                int cantModelo = modelo.SelectedItem.Value.Length; //Cantidad de caracteres de filtro modelo
                int index = cantModelo - 4; //Le resta 4 a ese total
                nomGrupo = nomGrupo + modelo.SelectedItem.Value.Substring(index, 4); //Toma los 4 ultimos de modelo
                nomGrupo = nomGrupo + fase.SelectedItem.Value.Substring(0, 1); //Toma el valor de fase
                nomGrupo = nomGrupo + energia.SelectedItem.Value.Substring(0, 1); //Toma el valor de energia
                nombreGrupo.Text = nomGrupo;    //Pone valor a campo nombre grupo
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#modalSerial').modal('show');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#exampleModalLive').modal('hide');</script>");
                //Response.Redirect("Medidores.aspx?nomGrupo=" + nombreGrupo.Value); //Redirecciona a medidores
            }
            else
            {
                //error.Visible = true;
            }
        }

        protected void asignaSerial(object sender, EventArgs e)
        {
            bool campo = ValidarCamposSerial();
            if (campo == true)
            {
                ok.Value = "1";    //Pone valor a campo ok
                if (Unico.Checked == true)
                {
                    deshabilita_grupo();    //Deshabilita boton habilitar grupo                    
                }
                bloquea_campos_cant();
                agrega_items();
                agrega_array();
                activa_agregar();
            } else
            {
                //error.Visible = true;
            }
        }

        protected void activa_agregar()
        {
            act_cantidad.Enabled = true;
        }
        protected void agrega_array()
        {
            
        }

        protected void deshabilita_grupo()
        {
            habilitar_grupo.Disabled = true;    //Deshabilita boton de habilitar grupo
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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Archivo.aspx");//Redirecciona cargue por archivo plano
        }
    }
}