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
        private string usuario;
        private string cliente;
        private string documento;
        private string serial;
        private string grupo;
        private string inicial;
        private string final;
        private string estado;

        //metodos get y set 
        public string Usuario
        {
            get
            { return usuario; }
            set
            { usuario = value; }
        }

        public string Cliente
        {
            get
            { return cliente; }
            set
            { cliente = value; }
        }

        public string Documento
        {
            get
            { return documento; }
            set
            { documento = value; }
        }
        public string Serial
        {
            get
            { return serial; }
            set
            { serial = value; }
        }

        public string Grupo
        {
            get
            { return grupo; }
            set
            { grupo = value; }
        }

        public string Inicial
        {
            get
            { return inicial; }
            set
            { inicial = value; }
        }

        public string Final
        {
            get
            { return final; }
            set
            { final = value; }
        }

        public string Estado
        {
            get
            { return estado; }
            set
            { estado = value; }
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
            DataTable ok = SP_consulta_actualizar(this.cliente, this.documento, this.serial,this.grupo, this.inicial, this.final, this.estado);
            return ok;
        }

        //Metodo para consulta actualizar
        public DataTable getDEActualizar()
        {
            DataTable ok = SP_documentos_entrada_actualizar(this.cliente, this.documento, this.serial, this.grupo, this.inicial, this.final, this.estado);
            return ok;
        }

        //Metodo para consulta actualizar
        public DataTable getNSActualizar()
        {
            DataTable ok = SP_numero_serial_actualizar(this.cliente, this.documento, this.serial, this.grupo, this.inicial, this.final, this.estado);
            return ok;
        }

        //Metodo para consulta actualizar
        public DataTable getGRUActualizar()
        {
            DataTable ok = SP_grupo_actualizar(this.cliente, this.documento, this.serial, this.grupo, this.inicial, this.final, this.estado);
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
            DataTable ok = SP_documentos_entrada(this.cliente);
            return ok;
        }

        //Metodo para numero serial
        public DataTable getNumeroSerial()
        {
            DataTable ok = SP_numero_serial(this.cliente);
            return ok;
        }

        //Metodo para grupo
        public DataTable getGrupo()
        {
            DataTable ok = SP_grupo(this.cliente);
            return ok;
        }
    }

}
