using ApiProyecto.model.Request;
using ApiProyecto.model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiProyecto.Custom;
using ApiProyecto.model.proc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly Utilidades _utilidades;

        public LoginController(Utilidades utilidades)
        {
            _utilidades = utilidades;
        }
        [HttpPost]
        [Route("registrarse")]
        public Respuesta m_1_Login_1_1([FromBody] Usuario usaurio1)
        {
            var contrasenia = _utilidades.encriptaSHA256(usaurio1.clave);
            usaurio1.clave = contrasenia;

            Respuesta res = model.proc.p_Usuarios.registar(usaurio1);
            return res;
        }

        [HttpPost]
        [Route("inicioSesion")]
        public Respuesta m_1_Login_1_2([FromBody] Login log)
        {
            var contrasenia = _utilidades.encriptaSHA256(log.clave);
            log.clave = contrasenia;



            Respuesta res = model.proc.p_Login.iniciarSesion(log);

            if (res.CodigoError == -1)
            {
                Usuario_id id_usuario = new Usuario_id();
                var respusta = res.Message.Split('|');
                id_usuario.us_id = int.Parse(respusta[0].ToString());

                Respuesta resUsuario = model.proc.p_Login.buscaUsuario(id_usuario);
                Usuario usuarioEncontrado = new Usuario();

                if (resUsuario.Result != null)
                {

                    var dataAsList = resUsuario.Result as List<Dictionary<string, object>>;

                    if (dataAsList != null && dataAsList.Count > 0)
                    {
                        var item = dataAsList[0];


                        usuarioEncontrado = new Usuario
                        {
                            idUsuario = Convert.ToInt32(item["idUsuario"]),
                            nombre = item["nombre"].ToString(),
                            correo = item["correo"].ToString(),
                            idRol = Convert.ToInt32(item["idRol"]),
                            rolDescripcion = item["rolDescripcion"].ToString(),
                            clave = item["clave"].ToString(),
                            status = Convert.ToInt32(item["status"])
                        };


                    }



                    res.Message = res.Message +"|"+_utilidades.generarJWT(usuarioEncontrado);
                }
                
            }

            return res;

        }
    }

}
