using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogica
{
    public class Empleado : conexion
    { 
        //atributos o campos 
        private string usuario;
        private string contraseña;
        private string rol;


        //metodos get y set 
        public string Usuario
        {
            get
            { return usuario; }
            set
            { usuario = value; }
        }

        public string Contraseña
        {
            get
            { return contraseña; }
            set
            { contraseña = value; }
        }

        public string inicio_sesion()
        {
            string ok = SP_inicio_Sesion(this.usuario, this.contraseña);
            return ok;
        }

        public string getId()
        {
            string Id = SP_id(this.usuario);
            return Id;
        }

        public string getBloqueo()
        {
            string bloqueo = SP_bloqueo(this.usuario);
            return bloqueo;
        }

        public string getActivo()
        {
            string activo = SP_activo(this.usuario);
            return activo;
        }
    }

}
