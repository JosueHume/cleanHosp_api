using CleanHosp_API.Model.Limpeza;
using CleanHosp_API.Repositorio.Interface.Limpeza;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Limpeza
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimpezaController : ControllerBase
    {
        private readonly ILimpezaInterface _limpezaInterface;

        public LimpezaController(ILimpezaInterface limpezaInterface)
        {
            _limpezaInterface = limpezaInterface;
        }

        [HttpGet]
        public ActionResult<List<LimpezaModel>> GetLimpezas()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<LimpezaModel>> BuscarPorId(int Id)
        {
            LimpezaModel? limpeza = await _limpezaInterface.BuscarPorId(Id);
            return Ok(limpeza);
        }

        [HttpPost]
        public async Task<ActionResult<LimpezaModel>> Cadastrar([FromBody] LimpezaModel limpezaModel)
        {
            LimpezaModel? limpeza = await _limpezaInterface.Cadastrar(limpezaModel);
            return Ok(limpeza);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<LimpezaModel>> Atualizar([FromBody] LimpezaModel limpezaModel, int Id)
        {
            limpezaModel.limpeza_id = Id;
            LimpezaModel? limpeza = await _limpezaInterface.Atualizar(limpezaModel, Id);
            return Ok(limpeza);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<LimpezaModel>> Deletar(int Id)
        {
            bool limpezaApagada = await _limpezaInterface.Deletar(Id);
            return Ok(limpezaApagada);
        }
    }
}