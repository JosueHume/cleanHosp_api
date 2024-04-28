using CleanHosp_API.Model.Produto;
using CleanHosp_API.Repositorio.Interface.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.ProdutoUtilizado
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoUtilizadoController : ControllerBase
    {
        private readonly IProdutoUtilizadoInterface _produtoUtilizadoInterface;

        public ProdutoUtilizadoController(IProdutoUtilizadoInterface produtoUtilizadoInterface)
        {
            _produtoUtilizadoInterface = produtoUtilizadoInterface;
        }

        [HttpGet]
        public ActionResult<List<ProdutoUtilizadoModel>> GetProdutosUtilizados()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProdutoUtilizadoModel>> BuscarPorId(int Id)
        {
            ProdutoUtilizadoModel? produtoUtilizado = await _produtoUtilizadoInterface.BuscarPorId(Id);
            return Ok(produtoUtilizado);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoUtilizadoModel>> Cadastrar([FromBody] ProdutoUtilizadoModel produtoUtilizadoModel)
        {
            ProdutoUtilizadoModel? produtoUtilizado = await _produtoUtilizadoInterface.Cadastrar(produtoUtilizadoModel);
            return Ok(produtoUtilizado);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ProdutoUtilizadoModel>> Atualizar([FromBody] ProdutoUtilizadoModel produtoUtilizadoModel, int Id)
        {
            produtoUtilizadoModel.Id = Id;
            ProdutoUtilizadoModel? produtoUtilizado = await _produtoUtilizadoInterface.Atualizar(produtoUtilizadoModel, Id);
            return Ok(produtoUtilizado);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Deletar(int Id)
        {
            bool produtoUtilizadoApagado = await _produtoUtilizadoInterface.Deletar(Id);
            return Ok(produtoUtilizadoApagado);
        }
    }
}
