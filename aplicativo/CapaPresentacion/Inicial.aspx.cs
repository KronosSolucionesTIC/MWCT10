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
    public partial class Inicial : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["existencias"] = false;
            if (!IsPostBack)
            {
                llenar_documentos_entrada();        //Pasa funcion para llenar lista
                llenar_num_serial();                //Pasa funcion para llenar lista
                llenar_grupo();                     //Pasa funcion para llenar lista
                TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd"); //Toma la fecha actual
                DateTime fecha = DateTime.Today.AddDays(-15);
                TextBox1.Text = fecha.ToString("yyyy-MM-dd");
            }

            Consulta ci = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            ci.Usuario = usu;                           //Pasa el valor de usuario
            string Id = ci.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            string cli = ci.getCliente();                     //Pasa el metodo getId para validar si existe el usuario     
            ci.Cliente = Id;                            //Pasa el valor de la lista
            DataTable dt = ci.getConsultaInicial();     //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
            GridView1.DataBind();
            usuario.Text = usu;                         //Pone nombre usuario
            cliente.Text = cli;                         //Pone nombre cliente

            if(dt.Rows.Count <= 0)
            {
                exportar.Enabled = false;
            } 
        }

        protected void llenar_documentos_entrada()
        {
            Consulta de = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            de.Usuario = usu;                           //Pasa el valor de usuario
            string Id = de.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            de.Cliente = Id;                            //Pasa el valor de la lista
            DataTable dt = de.getDocumentosEntrada();   //Pasa el metodo consulta inicial
            docEntrada.AppendDataBoundItems = true;
            docEntrada.Items.Add("Seleccione...");
            this.docEntrada.DataSource = dt;            //Agrega al GridView el dataset
            docEntrada.DataTextField = "DOC_ENTRY";     //Selecciona el campo a mostrar
            docEntrada.DataValueField = "DOC_ENTRY";    //Selecciona el campo para el valor
            docEntrada.DataBind();
        }

        protected void llenar_num_serial()
        {
            Consulta nm = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            nm.Usuario = usu;                           //Pasa el valor de usuario
            string Id = nm.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            nm.Cliente = Id;                            //Pasa el valor de la lista
            DataTable dt = nm.getNumeroSerial();   //Pasa el metodo consulta inicial
            numeroSerial.AppendDataBoundItems = true;
            numeroSerial.Items.Add("Seleccione...");
            this.numeroSerial.DataSource = dt;            //Agrega al GridView el dataset
            numeroSerial.DataTextField = "NUM_SERIAL";     //Selecciona el campo a mostrar
            numeroSerial.DataValueField = "NUM_SERIAL";    //Selecciona el campo para el valor
            numeroSerial.DataBind();
        }

        protected void llenar_grupo()
        {
            Consulta gru = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            gru.Usuario = usu;                           //Pasa el valor de usuario
            string Id = gru.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            gru.Cliente = Id;                            //Pasa el valor de la lista
            DataTable dt = gru.getGrupo();   //Pasa el metodo consulta inicial
            nombreGrupo.AppendDataBoundItems = true;
            nombreGrupo.Items.Add("Seleccione...");
            this.nombreGrupo.DataSource = dt;            //Agrega al GridView el dataset
            nombreGrupo.DataTextField = "NAME_GROUP";     //Selecciona el campo a mostrar
            nombreGrupo.DataValueField = "NAME_GROUP";    //Selecciona el campo para el valor
            nombreGrupo.DataBind();
        }


        public bool ValidarCampos()
        {
            if (this.TextBox1.Text.Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo fecha inicial no puede ser vacio');</script>");
                return false;
            } else if (this.TextBox2.Text.Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo fecha final no puede ser vacio');</script>");
                return false;
            }
            return true;
        }

        public bool Rango60()
        {
            DateTime ini = DateTime.Parse(TextBox1.Text);
            DateTime fin = DateTime.Parse(TextBox2.Text);
            TimeSpan tSpan = fin - ini;
            int dias = tSpan.Days;
            if(dias > 60)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Rango " + dias + ", el rango debe ser menor a 60 dias');</script>");
                return false;
            }
            return true;
        }


        protected void ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtFecha_TextChanged(object sender, EventArgs e)
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

        protected void actualizar_Click(object sender, EventArgs e)
        {
            actualiza();    //Proceso de actualizar
            llenar_documentos_entrada_actualizar();     //Proceso de llenar documento entrada
            llenar_numero_serial_actualizar();          //Proceso de llenar numero serial
            llenar_grupo_actualizar();                  //Proceso de llenar grupo
        }

        protected void llenar_documentos_entrada_actualizar()
        {
            Consulta de = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            de.Usuario = usu;                           //Pasa el valor de usuario
            string Id = de.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            de.Cliente = Id;                            //Pasa el valor de la lista
            de.Inicial = TextBox1.Text;                          //Pasa el valor de la lista
            de.Final = TextBox2.Text;                            //Pasa el valor de la lista
            de.Documento = docEntrada.SelectedItem.Value;     //Pasa el valor de la lista
            de.Serial = numeroSerial.SelectedItem.Value;     //Pasa el valor de la lista
            de.Grupo = nombreGrupo.SelectedItem.Value;     //Pasa el valor de la lista
            de.Estado = estadoActividad.SelectedItem.Value;     //Pasa el valor de la lista
            DataTable dt = de.getDEActualizar();   //Pasa el metodo consulta inicial
            docEntrada.Items.Clear();
            docEntrada.AppendDataBoundItems = true;
            docEntrada.Items.Add("Seleccione...");
            this.docEntrada.DataSource = dt;            //Agrega al GridView el dataset
            docEntrada.DataTextField = "DOC_ENTRY";     //Selecciona el campo a mostrar
            docEntrada.DataValueField = "DOC_ENTRY";    //Selecciona el campo para el valor
            docEntrada.DataBind();
        }

        protected void llenar_numero_serial_actualizar()
        {
            Consulta nm = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            nm.Usuario = usu;                           //Pasa el valor de usuario
            string Id = nm.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            nm.Cliente = Id;                            //Pasa el valor de la lista
            nm.Inicial = TextBox1.Text;                          //Pasa el valor de la lista
            nm.Final = TextBox2.Text;                            //Pasa el valor de la lista
            nm.Documento = docEntrada.SelectedItem.Value;     //Pasa el valor de la lista
            nm.Serial = numeroSerial.SelectedItem.Value;     //Pasa el valor de la lista
            nm.Grupo = nombreGrupo.SelectedItem.Value;     //Pasa el valor de la lista
            nm.Estado = estadoActividad.SelectedItem.Value;     //Pasa el valor de la lista

            DataTable dt = nm.getNSActualizar();   //Pasa el metodo consulta inicial
            numeroSerial.Items.Clear();
            numeroSerial.AppendDataBoundItems = true;
            numeroSerial.Items.Add("Seleccione...");
            this.numeroSerial.DataSource = dt;            //Agrega al GridView el dataset
            numeroSerial.DataTextField = "NUM_SERIAL";     //Selecciona el campo a mostrar
            numeroSerial.DataValueField = "NUM_SERIAL";    //Selecciona el campo para el valor
            numeroSerial.DataBind();
        }

        protected void llenar_grupo_actualizar()
        {
            Consulta gru = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            gru.Usuario = usu;                           //Pasa el valor de usuario
            string Id = gru.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            gru.Cliente = Id;                            //Pasa el valor de la lista
            gru.Inicial = TextBox1.Text;                          //Pasa el valor de la lista
            gru.Final = TextBox2.Text;                            //Pasa el valor de la lista
            gru.Documento = docEntrada.SelectedItem.Value;     //Pasa el valor de la lista
            gru.Serial = numeroSerial.SelectedItem.Value;     //Pasa el valor de la lista
            gru.Grupo = nombreGrupo.SelectedItem.Value;     //Pasa el valor de la lista
            gru.Estado = estadoActividad.SelectedItem.Value;     //Pasa el valor de la lista

            DataTable dt = gru.getGRUActualizar();   //Pasa el metodo consulta inicial
            nombreGrupo.Items.Clear();
            nombreGrupo.AppendDataBoundItems = true;
            nombreGrupo.Items.Add("Seleccione...");
            this.nombreGrupo.DataSource = dt;            //Agrega al GridView el dataset
            nombreGrupo.DataTextField = "NAME_GROUP";     //Selecciona el campo a mostrar
            nombreGrupo.DataValueField = "NAME_GROUP";    //Selecciona el campo para el valor
            nombreGrupo.DataBind();
        }

        protected void actualiza()
        {
            bool revision = ValidarCampos();                                    //Valida las fechas
            if (revision == true)
            {
                bool dias = Rango60();
                if (dias == true)
                {
                    Consulta ca = new Consulta();                       //Crea una instancia de clase
                    string usu = Convert.ToString(Session["Login"]);    //Lee la variable Session
                    ca.Usuario = usu;                                   //Pasa el valor de usuario
                    string Id = ca.getId();                             //Pasa el metodo getId para validar si existe el usuario     
                    ca.Cliente = Id;                                    //Pasa el valor de la lista
                    ca.Inicial = TextBox1.Text;                          //Pasa el valor de la lista
                    ca.Final = TextBox2.Text;                            //Pasa el valor de la lista
                    ca.Documento = docEntrada.SelectedItem.Value;     //Pasa el valor de la lista
                    ca.Serial = numeroSerial.SelectedItem.Value;     //Pasa el valor de la lista
                    ca.Grupo = nombreGrupo.SelectedItem.Value;     //Pasa el valor de la lista
                    ca.Estado = estadoActividad.SelectedItem.Value;     //Pasa el valor de la lista
                    DataTable dt = ca.getConsultaActualizar();          //Pasa el metodo consulta inicial
                    this.GridView1.DataSource = dt;                     //Agrega al GridView el dataset
                    GridView1.DataBind();
                }
            }
        }

        protected void tareas_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void exportar_click(object sender, EventArgs e)
        {
            actualiza();

                    StringWriter stringWrite = new StringWriter();
                    for (int i = 0; i <= (GridView1.Rows.Count - 1); i++)
                    {
                        stringWrite.WriteLine(GridView1.Rows[i].Cells[0].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[1].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[2].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[3].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[4].Text.ToString() + "\t"
                                );
                        stringWrite.WriteLine("");
                    }
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=prueba.txt");
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.text";
                    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                    Response.Write(stringWrite.ToString());
                    Response.End();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}