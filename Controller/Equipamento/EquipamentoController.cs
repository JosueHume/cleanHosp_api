using CleanHosp_API.Model.Equipamento;
using CleanHosp_API.Repositorio.Interface.Equipamento;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.Equipamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoInterface _equipamentoInterface;

        public EquipamentoController(IEquipamentoInterface equipamentoInterface)
        {
            _equipamentoInterface = equipamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipamentoModel>>> GetEquipamentos()
        {
            List<EquipamentoModel> equipamentos = await _equipamentoInterface.BuscarTodosEquipamentos();
            return Ok(equipamentos);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<EquipamentoModel>> BuscarPorId(int Id)
        {
            EquipamentoModel? equipamento = await _equipamentoInterface.BuscarPorId(Id);
            return Ok(equipamento);
        }

        [HttpPost]
        public async Task<ActionResult<EquipamentoModel>> Cadastrar([FromBody] EquipamentoModel equipamentoModel)
        {
            EquipamentoModel? equipamento = await _equipamentoInterface.Cadastrar(equipamentoModel);
            return Ok(equipamento);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<EquipamentoModel>> Atualizar([FromBody] EquipamentoModel equipamentoModel, int Id)
        {
            equipamentoModel.equipamento_id = Id;
            EquipamentoModel? equipamento = await _equipamentoInterface.Atualizar(equipamentoModel, Id);
            return Ok(equipamento);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<EquipamentoModel>> Deletar(int Id)
        {
            bool equipamentoApagado = await _equipamentoInterface.Deletar(Id);
            return Ok(equipamentoApagado);
        }
    }
}
