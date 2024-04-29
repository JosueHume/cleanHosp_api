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

            equipamentoCadastrado.ds_nome = equipamento.ds_nome;
            equipamentoCadastrado.ds_marca = equipamento.ds_marca;
            equipamentoCadastrado.ds_modelo = equipamento.ds_modelo; 
            equipamentoCadastrado.dt_aquisicao = equipamentoCadastrado.dt_aquisicao;
            equipamentoCadastrado.ds_descricao = equipamentoCadastrado.ds_descricao;
            equipamentoCadastrado.vl_aquisicao = equipamentoCadastrado.vl_aquisicao;
            equipamentoCadastrado.xAtivo = equipamentoCadastrado.xAtivo;

            _cleanDBContext.Update(equipamentoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return equipamentoCadastrado;
        }

        public async Task<EquipamentoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.equipamento.FirstOrDefaultAsync(a => a.equipamento_id == Id);
        }

        public async Task<List<EquipamentoModel>> BuscarTodosEquipamentos()
        {
            return await _cleanDBContext.equipamento.ToListAsync();
        }

        public async Task<EquipamentoModel?> Cadastrar(EquipamentoModel equipamento)
        {
            await _cleanDBContext.equipamento.AddAsync(equipamento);
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

            _cleanDBContext.Remove(equipamentoCadastrado.equipamento_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
