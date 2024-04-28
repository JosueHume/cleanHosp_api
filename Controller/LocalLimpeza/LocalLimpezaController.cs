﻿using CleanHosp_API.Model.LocalLimpeza;
using CleanHosp_API.Repositorio.Interface.Local;
using Microsoft.AspNetCore.Mvc;

namespace CleanHosp_API.Controller.LocalLimpeza
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalLimpezaController : ControllerBase
    {
        private readonly ILocalLimpezaInterface _localLimpezaInterface;

        public LocalLimpezaController(ILocalLimpezaInterface localLimpezaInterface)
        {
            _localLimpezaInterface = localLimpezaInterface;
        }

        [HttpGet]
        public ActionResult<List<LocalLimpezaModel>> GetLocalLimpeza()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<LocalLimpezaModel>> BuscarPorId(int Id)
        {
            LocalLimpezaModel? localLimpeza = await _localLimpezaInterface.BuscarPorId(Id);
            return Ok(localLimpeza);
        }

        [HttpPost]
        public async Task<ActionResult<LocalLimpezaModel>> Cadastrar([FromBody] LocalLimpezaModel localLimpezaModel)
        {
            LocalLimpezaModel? localLimpeza = await _localLimpezaInterface.Cadastrar(localLimpezaModel);
            return Ok(localLimpeza);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<LocalLimpezaModel>> Atualizar([FromBody] LocalLimpezaModel localLimpezaModel, int Id)
        {
            localLimpezaModel.Id = Id;
            LocalLimpezaModel? localLimpeza = await _localLimpezaInterface.Atualizar(localLimpezaModel, Id);
            return Ok(localLimpeza);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<LocalLimpezaModel>> Deletar(int Id)
        {
            bool localLimpezaApagado = await _localLimpezaInterface.Deletar(Id);
            return Ok(localLimpezaApagado);
        }
    }
}
