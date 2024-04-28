using CleanHosp_API.Model.Equipamento;

namespace CleanHosp_API.Repositorio.Interface.Equipamento
{
    public interface IEquipamentoUtilizadoInterface
    {
        Task<List<EquipamentoUtilizadoModel>> BuscarTodosEquipamentosUtilizados();
        Task<EquipamentoUtilizadoModel?> BuscarPorId(int Id);
        Task<EquipamentoUtilizadoModel?> Cadastrar(EquipamentoUtilizadoModel equipamentoUtilizado);
        Task<EquipamentoUtilizadoModel?> Atualizar(EquipamentoUtilizadoModel equipamentoUtilizado, int Id);
        Task<bool> Deletar(int Id);
    }
}
