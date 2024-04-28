using CleanHosp_API.Model.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoModel>> GetProdutos()
        {
            return Ok();
        }
    }
}
