using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Repositorio.Interface.Local
{
    public interface ILocalInterface
    {
        Task<List<LocalModel>> BuscarTodosLocalLimpeza();
        Task<LocalModel?> BuscarPorId(int Id);
        Task<LocalModel?> Cadastrar(LocalModel local);
        Task<LocalModel?> Atualizar(LocalModel local, int Id);
        Task<bool> Deletar(int Id);
    }
}
