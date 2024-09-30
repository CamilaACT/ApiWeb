using ApiProyecto.model.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        [HttpPost]

        [Route("listarMenu")]
        public Respuesta m_1_Login_1_1([FromBody] int us_id)
        {
            Respuesta res = model.proc.Menu.listaMenu(us_id);
            return res;
        }

    }
}
