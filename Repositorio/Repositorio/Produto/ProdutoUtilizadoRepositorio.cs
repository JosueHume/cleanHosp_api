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

            produtoUtilizadoCadastrado.quantidade = produtoUtilizado.quantidade;
            produtoUtilizadoCadastrado.produto_id = produtoUtilizado.produto_id;

            _cleanDBContext.Update(produtoUtilizadoCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return produtoUtilizadoCadastrado;
        }

        public async Task<ProdutoUtilizadoModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.produtos_utilizados.FirstOrDefaultAsync(pu => pu.produtos_utilizados_id == Id);
        }

        public async Task<List<ProdutoUtilizadoModel>> BuscarTodosProdutosUtilizados()
        {
            return await _cleanDBContext.produtos_utilizados.ToListAsync();
        }

        public async Task<ProdutoUtilizadoModel?> Cadastrar(ProdutoUtilizadoModel produtoUtilizado)
        {
            await _cleanDBContext.produtos_utilizados.AddAsync(produtoUtilizado);
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

            _cleanDBContext.Remove(produtoUtilizadoCadastrado.produtos_utilizados_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
