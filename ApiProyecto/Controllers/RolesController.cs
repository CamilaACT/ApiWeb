using ApiProyecto.model.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet]

        [Route("listarRoles")]
        public Respuesta m_1_Login_1_1()
        {
            Respuesta res = model.proc.p_Rol.listaRoles();
            return res;
        }

    }
}
