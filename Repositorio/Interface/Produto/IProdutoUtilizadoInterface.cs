using CleanHosp_API.Model.Produto;

namespace CleanHosp_API.Repositorio.Interface.Produto
{
    public interface IProdutoUtilizadoInterface
    {
        Task<List<ProdutoUtilizadoModel>> BuscarTodosProdutosUtilizados();
        Task<ProdutoUtilizadoModel?> BuscarPorId(int Id);
        Task<ProdutoUtilizadoModel?> Cadastrar(ProdutoUtilizadoModel produtoUtilizado);
        Task<ProdutoUtilizadoModel?> Atualizar(ProdutoUtilizadoModel produtoUtilizado, int Id);
        Task<bool> Deletar(int Id);
    }
}
