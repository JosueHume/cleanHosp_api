using CleanHosp_API.Model.Ala;

namespace CleanHosp_API.Repositorio.Interface.Ala
{
    public interface IAlaInterface
    {
        Task<List<AlaModel>> BuscarTodasAlas();
        Task<AlaModel?> BuscarPorId(int Id);
        Task<AlaModel?> Cadastrar(AlaModel ala);
        Task<AlaModel?> Atualizar(AlaModel ala, int Id);
        Task<bool> Deletar(int Id);
    }
}
