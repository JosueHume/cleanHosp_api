using CleanHosp_API.Model.Equipamento;

namespace CleanHosp_API.Repositorio.Interface.Equipamento
{
    public interface IEquipamentoInterface
    {
        Task<List<EquipamentoModel>> BuscarTodosEquipamentos();
        Task<EquipamentoModel?> BuscarPorId(int Id);
        Task<EquipamentoModel?> Cadastrar(EquipamentoModel equipamento);
        Task<EquipamentoModel?> Atualizar(EquipamentoModel equipamento, int Id);
        Task<bool> Deletar(int Id);
    }
}
