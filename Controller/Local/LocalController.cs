using CleanHosp_API.Model.Local;
using CleanHosp_API.Repositorio.Interface.Local;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocalInterface _localInterface;

        public LocalController(ILocalInterface localInterface)
        {
            _localInterface = localInterface;
        }

        [HttpGet]
        public ActionResult<List<LocalModel>> GetLocais()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<LocalModel>> BuscarPorId(int Id)
        {
            LocalModel? local = await _localInterface.BuscarPorId(Id);
            return Ok(local);
        }

        [HttpPost]
        public async Task<ActionResult<LocalModel>> Cadastrar([FromBody] LocalModel localModel)
        {
            LocalModel? local = await _localInterface.Cadastrar(localModel);
            return Ok(local);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<LocalModel>> Atualizar([FromBody] LocalModel localModel, int Id)
        {
            localModel.local_id = Id;
            LocalModel? local = await _localInterface.Atualizar(localModel, Id);
            return Ok(local);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<LocalModel>> Deletar(int Id)
        {
            bool localApagado = await _localInterface.Deletar(Id);
            return Ok(localApagado);
        }
    }
}
