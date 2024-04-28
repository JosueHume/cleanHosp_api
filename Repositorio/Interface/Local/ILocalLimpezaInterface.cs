using CleanHosp_API.Model.LocalLimpeza;

namespace CleanHosp_API.Repositorio.Interface.Local
{
    public interface ILocalLimpezaInterface
    {
        Task<List<LocalLimpezaModel>> BuscarTodosLocalLimpeza();
        Task<LocalLimpezaModel?> BuscarPorId(int Id);
        Task<LocalLimpezaModel?> Cadastrar(LocalLimpezaModel localLimpeza);
        Task<LocalLimpezaModel?> Atualizar(LocalLimpezaModel localLimpeza, int Id);
        Task<bool> Deletar(int Id);
    }
}
