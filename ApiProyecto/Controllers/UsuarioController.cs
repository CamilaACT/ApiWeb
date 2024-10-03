using ApiProyecto.model.proc;
using ApiProyecto.model.Request;
using ApiProyecto.model.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]

        [Route("listaUsuarios")]
        public Respuesta m_1_Login_1_1([FromBody] Usuario_id us_id)
        {
            Respuesta res = model.proc.Usuarios.listaUsuarios(us_id);
            return res;
        }

        [HttpPost]

        [Route("login")]
        public Respuesta m_1_Login_1_2([FromBody] Login log)
        {
            Respuesta res = model.proc.Usuarios.iniciarSesion(log);
            return res;
        }


        [HttpPost]

        [Route("registrar")]
        public Respuesta m_1_Login_1_3([FromBody] Usuario log)
        {
            Respuesta res = model.proc.Usuarios.registar(log);
            return res;
        }

        [HttpPut]

        [Route("editar")]
        public Respuesta m_1_Login_1_4([FromBody] Usuario log)
        {
            Respuesta res = model.proc.Usuarios.modificar(log);
            return res;
        }

        [HttpPost]

        [Route("buscar")]
        public Respuesta m_1_Login_1_5([FromBody] Usuario_nombre us_id)
        {
            Respuesta res = model.proc.Usuarios.buscar(us_id);
            return res;
        }

        [HttpDelete]

        [Route("eliminar/{us_id}")]
        public Respuesta m_1_Login_1_6( int us_id)
        {
            Respuesta res = model.proc.Usuarios.eliminar(us_id);
            return res;
        }


    }
}
