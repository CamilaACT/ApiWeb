using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProyecto.model.Request
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public int idRol { get; set; }
        public string rolDescripcion { get; set; }
        public string clave { get; set; }
        public int status { get; set; }


    }
}
