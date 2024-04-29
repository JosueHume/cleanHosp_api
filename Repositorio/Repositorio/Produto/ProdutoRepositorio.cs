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

            produtoCadastrado.ds_nome = produto.ds_nome;
            produtoCadastrado.ds_marca = produto.ds_marca;
            produtoCadastrado.ds_descricao = produto.ds_descricao;
            produtoCadastrado.qtde_estoque = produto.qtde_estoque;
            produtoCadastrado.vl_unitario = produto.vl_unitario;    

            _cleanDBContext.Update(produtoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return produtoCadastrado;
        }

        public async Task<ProdutoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.produto.FirstOrDefaultAsync(p => p.produto_id == Id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _cleanDBContext.produto.ToListAsync();
        }

        public async Task<ProdutoModel?> Cadastrar(ProdutoModel produto)
        {
            await _cleanDBContext.produto.AddAsync(produto);
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

            _cleanDBContext.Remove(produtoCadastrado.produto_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
