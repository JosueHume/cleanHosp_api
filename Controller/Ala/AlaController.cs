using CleanHosp_API.Model.Ala;
using CleanHosp_API.Repositorio.Interface.Ala;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Ala
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlaController : ControllerBase
    {
        private readonly IAlaInterface _alaInterface;

        public AlaController(IAlaInterface alaInterface)
        {
            _alaInterface = alaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlaModel>>> GetAlas()
        {
            List<AlaModel> alas = await _alaInterface.BuscarTodasAlas();
            return Ok(alas);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AlaModel>> BuscarPorId(int Id)
        {
            AlaModel? ala = await _alaInterface.BuscarPorId(Id);
            return Ok(ala);
        }

        [HttpPost]
        public async Task<ActionResult<AlaModel>> Cadastrar([FromBody] AlaModel alaModel)
        {
            AlaModel? ala = await _alaInterface.Cadastrar(alaModel);
            return Ok(ala);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<AlaModel>> Atualizar([FromBody] AlaModel alaModel, int Id)
        {
            alaModel.Id = Id;
            AlaModel? ala = await _alaInterface.Atualizar(alaModel, Id);
            return Ok(ala);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<AlaModel>> Deletar(int Id)
        {
            bool alaApagada = await _alaInterface.Deletar(Id);
            return Ok(alaApagada);
        }
    }
}
