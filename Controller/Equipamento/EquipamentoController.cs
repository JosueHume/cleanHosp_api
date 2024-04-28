using CleanHosp_API.Model.Equipamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Equipamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EquipamentoModel>> GetEquipamentos()
        {
            return Ok();
        }
    }
}
