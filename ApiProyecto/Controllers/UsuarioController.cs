using ApiProyecto.model.proc;
using ApiProyecto.model.Request;
using ApiProyecto.model.Response;
using Microsoft.AspNetCore.Mvc;
using ApiProyecto.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly Utilidades _utilidades;
        public UsuarioController(Utilidades utilidades)
        {
            _utilidades = utilidades;
        }


        [HttpPost]

        [Route("listaUsuarios")]
        public Respuesta m_1_Login_1_1([FromBody] Usuario_id us_id)
        {
            Respuesta res = model.proc.p_Usuarios.listaUsuarios(us_id);
            return res;
        }


        [HttpPost]

        [Route("registrar")]
        public Respuesta m_1_Login_1_3([FromBody] Usuario log)
        {
            var contrasenia = _utilidades.encriptaSHA256(log.clave);
            log.clave = contrasenia;
            Respuesta res = model.proc.p_Usuarios.registar(log);
            return res;
        }

        [HttpPut]

        [Route("editar")]
        public Respuesta m_1_Login_1_4([FromBody] Usuario log)
        {
            var contrasenia = _utilidades.encriptaSHA256(log.clave);
            log.clave = contrasenia;
            Respuesta res = model.proc.p_Usuarios.modificar(log);
            return res;
        }

        [HttpPost]

        [Route("buscar")]
        public Respuesta m_1_Login_1_5([FromBody] Usuario_nombre us_id)
        {
            Respuesta res = model.proc.p_Usuarios.buscar(us_id);
            return res;
        }

        [HttpDelete]

        [Route("eliminar/{us_id}")]
        public Respuesta m_1_Login_1_6( int us_id)
        {
            Respuesta res = model.proc.p_Usuarios.eliminar(us_id);
            return res;
        }


    }
}
