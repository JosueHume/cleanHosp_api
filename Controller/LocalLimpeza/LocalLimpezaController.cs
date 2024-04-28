using CleanHosp_API.Model.LocalLimpeza;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.LocalLimpeza
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalLimpezaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<LocalLimpezaModel>> GetLocalLimpeza()
        {
            return Ok();
        }
    }
}
