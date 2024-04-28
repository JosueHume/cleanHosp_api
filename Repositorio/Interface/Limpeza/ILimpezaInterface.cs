using CleanHosp_API.Model.Limpeza;

namespace CleanHosp_API.Repositorio.Interface.Limpeza
{
    public interface ILimpezaInterface
    {
        Task<List<LimpezaModel>> BuscarTodasLimpeza();
        Task<LimpezaModel?> BuscarPorId(int Id);
        Task<LimpezaModel?> Cadastrar(LimpezaModel limpeza);
        Task<LimpezaModel?> Atualizar(LimpezaModel limpeza, int Id);
        Task<bool> Deletar(int Id);
    }
}
