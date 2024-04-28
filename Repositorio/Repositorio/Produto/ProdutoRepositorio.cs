using CleanHosp_API.Data;
using CleanHosp_API.Model.Produto;
using CleanHosp_API.Repositorio.Interface.Produto;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Produto
{
    public class ProdutoRepositorio : IProdutoInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public ProdutoRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<ProdutoModel?> Atualizar(ProdutoModel produto, int Id)
        {
            ProdutoModel? produtoCadastrado = await BuscarPorId(Id);

            if (produtoCadastrado == null)
            {
                throw new Exception($"Produto para o Id: {Id} não encontrado!");
            }

            produtoCadastrado.Nome = produto.Nome;
            produtoCadastrado.Marca = produto.Marca;
            produtoCadastrado.Descricao = produto.Descricao;
            produtoCadastrado.Quantidade = produto.Quantidade;
            produtoCadastrado.Valor = produto.Valor;    

            _cleanDBContext.Update(produtoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return produtoCadastrado;
        }

        public async Task<ProdutoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.Produtos.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _cleanDBContext.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel?> Cadastrar(ProdutoModel produto)
        {
            await _cleanDBContext.Produtos.AddAsync(produto);
            await _cleanDBContext.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Deletar(int Id)
        {
            ProdutoModel? produtoCadastrado = await BuscarPorId(Id);

            if (produtoCadastrado == null)
            {
                throw new Exception($"Produto para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(produtoCadastrado.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
