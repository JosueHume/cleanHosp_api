using CleanHosp_API.Model.Produto;

namespace CleanHosp_API.Repositorio.Interface.Produto
{
    public interface IProdutoInterface
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel?> BuscarPorId(int Id);
        Task<ProdutoModel?> Cadastrar(ProdutoModel produto);
        Task<ProdutoModel?> Atualizar(ProdutoModel produto, int Id);
        Task<bool> Deletar(int Id);
    }
}
