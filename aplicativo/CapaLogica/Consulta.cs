using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Consulta : ConsultaDAO
    {
        //atributos o campos 
        private string estado;
        private string cliente;
        private string usuario;

        //metodos get y set 
        public string Estado
        {
            get
            { return estado; }
            set
            { estado = value; }
        }

        public string Cliente
        {
            get
            { return cliente; }
            set
            { cliente = value; }
        }

        public string Usuario
        {
            get
            { return usuario; }
            set
            { usuario = value; }
        }

        //Metidi para consulta inicial
        public DataTable getConsultaInicial()
        {
            DataTable ok = SP_consulta_inicial(this.cliente);
            return ok;
        }

        //Metodo para consulta actualizar
        public DataTable getConsultaActualizar()
        {
            DataTable ok = SP_consulta_actualizar(this.estado,this.cliente);
            return ok;
        }

        //Metodo para retornar el ID
        public string getId()
        {
            string Id = SP_id(this.usuario);
            return Id;
        }

        //Metodo para documentos entrada
        public DataTable getDocumentosEntrada()
        {
            DataTable ok = SP_documentos_entrada();
            return ok;
        }

        //Metodo para numero serial
        public DataTable getNumeroSerial()
        {
            DataTable ok = SP_numero_serial();
            return ok;
        }

        //Metodo para grupo
        public DataTable getGrupo()
        {
            DataTable ok = SP_grupo();
            return ok;
        }
    }

}
