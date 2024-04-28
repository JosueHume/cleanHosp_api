using CleanHosp_API.Model.Ala;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Ala
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<AlaModel>> GetAlas()
        {
            return Ok();
        }
    }
}
