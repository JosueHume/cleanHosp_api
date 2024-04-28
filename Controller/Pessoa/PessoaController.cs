using CleanHosp_API.Model.Pessoa;
using CleanHosp_API.Repositorio.Interface.Pessoa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Pessoa
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;

        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet]
        public ActionResult<List<PessoaModel>> GetPessoas()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPorId(int Id)
        {
            PessoaModel? pessoa = await _pessoaInterface.BuscarPorId(Id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel? pessoa = await _pessoaInterface.Cadastrar(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel pessoaModel, int Id)
        {
            pessoaModel.Id = Id;
            PessoaModel? pessoa = await _pessoaInterface.Atualizar(pessoaModel, Id);
            return Ok(pessoa);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Deletar(int Id)
        {
            bool pessoaApagada = await _pessoaInterface.Deletar(Id);
            return Ok(pessoaApagada);
        }
    }
}
