using CleanHosp_API.Data;
using CleanHosp_API.Model.Produto;
using CleanHosp_API.Repositorio.Interface.Produto;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Produto
{
    public class ProdutoUtilizadoRepositorio : IProdutoUtilizadoInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public ProdutoUtilizadoRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<ProdutoUtilizadoModel?> Atualizar(ProdutoUtilizadoModel produtoUtilizado, int Id)
        {
            ProdutoUtilizadoModel? produtoUtilizadoCadastrado = await BuscarPorId(Id);

            if (produtoUtilizadoCadastrado == null)
            {
                throw new Exception($"Produto Utilizado para o Id: {Id} não encontrado!");
            }

            produtoUtilizadoCadastrado.Quantidade = produtoUtilizado.Quantidade;
            produtoUtilizadoCadastrado.IdProduto = produtoUtilizado.IdProduto;

            _cleanDBContext.Update(produtoUtilizadoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return produtoUtilizadoCadastrado;
        }

        public async Task<ProdutoUtilizadoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.ProdutosUtilizados.FirstOrDefaultAsync(pu => pu.Id == Id);
        }

        public async Task<List<ProdutoUtilizadoModel>> BuscarTodosProdutosUtilizados()
        {
            return await _cleanDBContext.ProdutosUtilizados.ToListAsync();
        }

        public async Task<ProdutoUtilizadoModel?> Cadastrar(ProdutoUtilizadoModel produtoUtilizado)
        {
            await _cleanDBContext.ProdutosUtilizados.AddAsync(produtoUtilizado);
            await _cleanDBContext.SaveChangesAsync();

            return produtoUtilizado;
        }

        public async Task<bool> Deletar(int Id)
        {
            ProdutoUtilizadoModel? produtoUtilizadoCadastrado = await BuscarPorId(Id);

            if (produtoUtilizadoCadastrado == null)
            {
                throw new Exception($"Produto Utilizado para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(produtoUtilizadoCadastrado.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
