using CleanHosp_API.Model.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<LocalModel>> GetLocais()
        {
            return Ok();
        }
    }
}
