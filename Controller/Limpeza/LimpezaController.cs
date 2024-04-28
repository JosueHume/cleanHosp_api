using CleanHosp_API.Model.Limpeza;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Limpeza
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimpezaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<LimpezaModel>> GetLimpezas()
        {
            return Ok();
        }
    }
}
