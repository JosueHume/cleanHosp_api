using CleanHosp_API.Model.Equipamento; 
using CleanHosp_API.Repositorio.Interface.Equipamento; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.EquipamentoUtilizado
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoUtilizadoController : ControllerBase
    {
        private readonly IEquipamentoUtilizadoInterface _equipamentoUtilizadoInterface;

        public EquipamentoUtilizadoController(IEquipamentoUtilizadoInterface equipamentoUtilizadoInterface)
        {
            _equipamentoUtilizadoInterface = equipamentoUtilizadoInterface;
        }

        [HttpGet]
        public ActionResult<List<EquipamentoUtilizadoModel>> GetEquipamentosUtilizados()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<EquipamentoUtilizadoModel>> BuscarPorId(int Id)
        {
            EquipamentoUtilizadoModel? equipamentoUtilizado = await _equipamentoUtilizadoInterface.BuscarPorId(Id);
            return Ok(equipamentoUtilizado);
        }

        [HttpPost]
        public async Task<ActionResult<EquipamentoUtilizadoModel>> Cadastrar([FromBody] EquipamentoUtilizadoModel equipamentoUtilizadoModel)
        {
            EquipamentoUtilizadoModel? equipamentoUtilizado = await _equipamentoUtilizadoInterface.Cadastrar(equipamentoUtilizadoModel);
            return Ok(equipamentoUtilizado);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<EquipamentoUtilizadoModel>> Atualizar([FromBody] EquipamentoUtilizadoModel equipamentoUtilizadoModel, int Id)
        {
            equipamentoUtilizadoModel.Id = Id;
            EquipamentoUtilizadoModel? equipamentoUtilizado = await _equipamentoUtilizadoInterface.Atualizar(equipamentoUtilizadoModel, Id);
            return Ok(equipamentoUtilizado);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Deletar(int Id)
        {
            bool equipamentoUtilizadoApagado = await _equipamentoUtilizadoInterface.Deletar(Id);
            return Ok(equipamentoUtilizadoApagado);
        }
    }
}
