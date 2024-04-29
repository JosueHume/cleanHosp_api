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

            equipamentoUtilizadoCadastrado.nr_tempoUso = equipamentoUtilizado.nr_tempoUso;
            equipamentoUtilizadoCadastrado.equipamento_id = equipamentoUtilizado.equipamento_id;

            _cleanDBContext.Update(equipamentoUtilizadoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return equipamentoUtilizadoCadastrado;
        }

        public async Task<EquipamentoUtilizadoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.equipamentos_utilizados.FirstOrDefaultAsync(eu => eu.equipamento_id == Id);
        }

        public async Task<List<EquipamentoUtilizadoModel>> BuscarTodosEquipamentosUtilizados()
        {
            return await _cleanDBContext.equipamentos_utilizados.ToListAsync();
        }

        public async Task<EquipamentoUtilizadoModel?> Cadastrar(EquipamentoUtilizadoModel equipamentoUtilizado)
        {
            await _cleanDBContext.equipamentos_utilizados.AddAsync(equipamentoUtilizado);
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

            _cleanDBContext.Remove(equipamentoUtilizadoCadastrado.equipamento_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
