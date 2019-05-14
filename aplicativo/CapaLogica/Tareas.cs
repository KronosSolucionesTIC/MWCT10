using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Tareas : TareasDAO
    {
        //atributos o campos 
        private string cliente; 
        private string zona;
        private string codigo;
        private string documento;
        private string serial;
        private string marca;
        private string modelo;

        //metodos get y set 
        public string Cliente
        {
            get
            { return cliente; }
            set
            { cliente = value; }
        }

        public string Zona
        {
            get
            { return zona; }
            set
            { zona = value; }
        }

        public string Codigo
        {
            get
            { return codigo; }
            set
            { codigo = value; }
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

        public string Marca
        {
            get
            { return marca; }
            set
            { marca = value; }
        }

        public string Modelo
        {
            get
            { return modelo; }
            set
            { modelo = value; }
        }

        //Metodo para guardar la tarea
        public string getGuardarTarea()
        {
           string ok = SP_guardar_tarea(this.cliente,this.zona,this.codigo,this.documento,this.serial,this.marca,this.modelo);
            return ok;
        }
    }

}
