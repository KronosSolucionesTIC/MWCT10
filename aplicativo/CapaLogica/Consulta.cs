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

        //metodos get y set 
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
            DataTable ok = SP_consulta_inicial();
            return ok;
        }

        //Metodo para consulta actualizar
        public DataTable getConsultaActualizar()
        {
            DataTable ok = SP_consulta_actualizar(this.estado);
            return ok;
        }
    }

}
