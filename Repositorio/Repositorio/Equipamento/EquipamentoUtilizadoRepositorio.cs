using CleanHosp_API.Data;
using CleanHosp_API.Model.Equipamento;
using CleanHosp_API.Repositorio.Interface.Equipamento;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Equipamento
{
    public class EquipamentoUtilizadoRepositorio : IEquipamentoUtilizadoInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public EquipamentoUtilizadoRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<EquipamentoUtilizadoModel?> Atualizar(EquipamentoUtilizadoModel equipamentoUtilizado, int Id)
        {
            EquipamentoUtilizadoModel? equipamentoUtilizadoCadastrado = await BuscarPorId(Id);

            if (equipamentoUtilizadoCadastrado == null)
            {
                throw new Exception($"Equipamento Utilizado para o Id: {Id} não encontrado!");
            }

            equipamentoUtilizadoCadastrado.Nr_TempoUso = equipamentoUtilizado.Nr_TempoUso;
            equipamentoUtilizadoCadastrado.IdEquipamento = equipamentoUtilizado.IdEquipamento;

            _cleanDBContext.Update(equipamentoUtilizadoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return equipamentoUtilizadoCadastrado;
        }

        public async Task<EquipamentoUtilizadoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.EquipamentosUtilizados.FirstOrDefaultAsync(eu => eu.Id == Id);
        }

        public async Task<List<EquipamentoUtilizadoModel>> BuscarTodosEquipamentosUtilizados()
        {
            return await _cleanDBContext.EquipamentosUtilizados.ToListAsync();
        }

        public async Task<EquipamentoUtilizadoModel?> Cadastrar(EquipamentoUtilizadoModel equipamentoUtilizado)
        {
            await _cleanDBContext.EquipamentosUtilizados.AddAsync(equipamentoUtilizado);
            await _cleanDBContext.SaveChangesAsync();

            return equipamentoUtilizado;
        }

        public async Task<bool> Deletar(int Id)
        {
            EquipamentoUtilizadoModel? equipamentoUtilizadoCadastrado = await BuscarPorId(Id);

            if (equipamentoUtilizadoCadastrado == null)
            {
                throw new Exception($"Equipamento Utilizado para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(equipamentoUtilizadoCadastrado.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
