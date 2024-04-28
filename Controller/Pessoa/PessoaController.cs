using CleanHosp_API.Model.Pessoa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Pessoa
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PessoaModel>> GetPessoas()
        {
            return Ok();
        }
    }
}
