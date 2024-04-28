using CleanHosp_API.Model.Produto;
using CleanHosp_API.Repositorio.Interface.Produto; 
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;

        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet]
        public ActionResult<List<ProdutoModel>> GetProdutos()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int Id)
        {
            ProdutoModel? produto = await _produtoInterface.BuscarPorId(Id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel? produto = await _produtoInterface.Cadastrar(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int Id)
        {
            produtoModel.Id = Id;
            ProdutoModel? produto = await _produtoInterface.Atualizar(produtoModel, Id);
            return Ok(produto);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Deletar(int Id)
        {
            bool produtoApagado = await _produtoInterface.Deletar(Id);
            return Ok(produtoApagado);
        }
    }
}
