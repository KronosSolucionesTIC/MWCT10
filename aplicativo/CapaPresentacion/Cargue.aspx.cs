using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using System.Data.OleDb;

namespace CapaPresentacion
{
    public partial class Cargue : System.Web.UI.Page
    {
        #region "Metodos ADO.NET"
        private void procesarArchivoTxt()
        {
            List<string> lista = leerArchivoTxt();
            DataTable dt = getDataTableTxt(lista);
            gv.DataSource = dt;
            gv.DataBind();
        }

        private List<string> leerArchivoTxt()
        {
            int counter = 0;
            string line;
            List<string> listaLine = new List<string>();
            string ruta = Server.MapPath("~/tmp/archivotmp.txt");

            using (System.IO.StreamReader archivo = new System.IO.StreamReader(ruta))
            {
                while ((line = archivo.ReadLine()) != null)
                {
                    listaLine.Add(line);
                    counter++;
                }
            }

            return listaLine;
        }
        /// Obtiene el data table de un archivo con extension .csv que se leyo previamente
        /// <param name="lista">Lista de datos del archivo csv</param>

        private System.Data.DataTable getDataTableTxt(List<string> lista)
        {
            DataTable dt = armandoColumnDataTable();
            int cont = 0;
            foreach (string item in lista)
            {
                if (cont < 8)
                {
                    string[] ListItems = item.Split(';');
                    dt.Rows.Add(ListItems);
                }
                cont++;
            }
            return dt;
        }

        /// Armando un data table para la carga de los archivos
        private System.Data.DataTable armandoColumnDataTable()
        {
            DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Serial");
            dt.Columns.Add("Marca");
            dt.Columns.Add("Modelo");
            dt.Columns.Add("Fases");
            dt.Columns.Add("Hilos");
            dt.Columns.Add("Energia");
            dt.Columns.Add("Zona");
            dt.Columns.Add("Codigo de ingreso");

            return dt;
        }
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        #endregion

        #region "Metodos"

        /// <summary>
        /// Leé el archivo csv para despues procesarlo
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Procesa el archivo con extensión .csv
        /// </summary>



        /// <summary>
        /// Verifica si la extension es correcta del archivo.
        /// Las extenciones válidas son txt, xls, xlsx, csv
        /// </summary>
        /// <param name="extencion">Exteción del archivo a evaluar</param>
        /// <returns></returns>
        private bool isExtencion(string extencion)
        {
            List<string> listaExteciones = new List<string>
                {
                    ".txt"
                };
            return listaExteciones.Exists(ex => ex == extencion.ToLower());
        }

        #endregion

        #region "Contructor"
        #endregion

        /// <summary>
        /// Procesa los archivos suvidos por el uploadFile :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }

        protected void cerrar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            bool isArchivo = false;
            string ruta = Server.MapPath("~/tmp/archivotmp");

            //Verifica si el componente uploadFile contiene un archivo
            if (fuPrueba.HasFile)
            {

                string archivoExtension = System.IO.Path.GetExtension(fuPrueba.FileName).ToLower();
                isArchivo = this.isExtencion(archivoExtension);//Verifica si las exteciones son correctas

                if (isArchivo)
                {
                    try
                    {
                        if (System.IO.File.Exists(ruta + archivoExtension))
                        {
                            System.IO.File.Delete(ruta + archivoExtension);//Si existe el archivo temporal se lo elimina para crear el nuevo archivo
                        }

                        fuPrueba.PostedFile.SaveAs(ruta + archivoExtension);
                        lblMensaje.Text = "Archivo cargado correctamente";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;

                        switch (archivoExtension)
                        {
                            case ".txt":
                                procesarArchivoTxt();
                                break;
                            default:
                                //Not tiene implementación :(
                                break;
                        }
                    }
                    catch (Exception m)
                    {
                        lblMensaje.Text = "ocurrio un problema en el cargado del archivo"
                            + Environment.NewLine + m.Message;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se puede cargar el archivo ya que no es valido";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}