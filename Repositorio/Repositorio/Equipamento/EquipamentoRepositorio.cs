using CleanHosp_API.Data;
using CleanHosp_API.Model.Equipamento;
using CleanHosp_API.Repositorio.Interface.Equipamento;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Equipamento
{
    public class EquipamentoRepositorio : IEquipamentoInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public EquipamentoRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<EquipamentoModel?> Atualizar(EquipamentoModel equipamento, int Id)
        {
            EquipamentoModel? equipamentoCadastrado = await BuscarPorId(Id);

            if (equipamentoCadastrado == null)
            {
                throw new Exception($"Equiapmento para o Id: {Id} não encontrado!");
            }

            equipamentoCadastrado.Nome = equipamento.Nome;
            equipamentoCadastrado.Marca = equipamento.Marca;
            equipamentoCadastrado.Modelo = equipamento.Modelo; 
            equipamentoCadastrado.Dt_aquisicao = equipamentoCadastrado.Dt_aquisicao;
            equipamentoCadastrado.Descricao = equipamentoCadastrado.Descricao;
            equipamentoCadastrado.Vl_aquisicao = equipamentoCadastrado.Vl_aquisicao;
            equipamentoCadastrado.XAtivo = equipamentoCadastrado.XAtivo;

            _cleanDBContext.Update(equipamentoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return equipamentoCadastrado;
        }

        public async Task<EquipamentoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.Equipamentos.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<List<EquipamentoModel>> BuscarTodosEquipamentos()
        {
            return await _cleanDBContext.Equipamentos.ToListAsync();
        }

        public async Task<EquipamentoModel?> Cadastrar(EquipamentoModel equipamento)
        {
            await _cleanDBContext.Equipamentos.AddAsync(equipamento);
            await _cleanDBContext.SaveChangesAsync();

            return equipamento;
        }

        public async Task<bool> Deletar(int Id)
        {
            EquipamentoModel? equipamentoCadastrado = await BuscarPorId(Id);

            if (equipamentoCadastrado == null)
            {
                throw new Exception($"Equipamento para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(equipamentoCadastrado.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
