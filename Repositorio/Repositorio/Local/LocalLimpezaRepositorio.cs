using CleanHosp_API.Data;
using CleanHosp_API.Model.LocalLimpeza;
using CleanHosp_API.Repositorio.Interface.Local;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Local
{
    public class LocalLimpezaRepositorio : ILocalLimpezaInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public LocalLimpezaRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<LocalLimpezaModel?> Atualizar(LocalLimpezaModel localLimpeza, int Id)
        {
            LocalLimpezaModel? localLimpezaCadastrado = await BuscarPorId(Id);

            if (localLimpezaCadastrado == null)
            {
                throw new Exception($"Local de Limpeza para o Id: {Id} não encontrado!");
            }

            localLimpezaCadastrado.IdAla = localLimpeza.IdAla;
            localLimpezaCadastrado.IdPessoa = localLimpeza.IdPessoa;
            localLimpezaCadastrado.Dt_Inicio = localLimpeza.Dt_Inicio;
            localLimpezaCadastrado.Dt_Fim = localLimpeza.Dt_Fim;
            localLimpezaCadastrado.IdLimpeza = localLimpeza.IdLimpeza;
            localLimpezaCadastrado.IdProdutoUtilizado = localLimpeza.IdProdutoUtilizado;
            localLimpezaCadastrado.IdEquipamentoUtilizado = localLimpeza.IdEquipamentoUtilizado;
            localLimpezaCadastrado.Descricao = localLimpeza.Descricao;
            localLimpezaCadastrado.Status = localLimpeza.Status; 

            _cleanDBContext.Update(localLimpezaCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return localLimpezaCadastrado;
        }

        public async Task<LocalLimpezaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.LocalLimpezas.FirstOrDefaultAsync(lp => lp.Id == Id);
        }

        public async Task<List<LocalLimpezaModel>> BuscarTodosLocalLimpeza()
        {

            return await _cleanDBContext.LocalLimpezas.ToListAsync();
        }

        public async Task<LocalLimpezaModel?> Cadastrar(LocalLimpezaModel localLimpeza)
        {
            await _cleanDBContext.LocalLimpezas.AddAsync(localLimpeza);
            await _cleanDBContext.SaveChangesAsync();

            return localLimpeza;
        }

        public async Task<bool> Deletar(int Id)
        {
            LocalLimpezaModel? localLimpezaCadastrado = await BuscarPorId(Id);

            if (localLimpezaCadastrado == null)
            {
                throw new Exception($"Local de Limpeza para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(localLimpezaCadastrado.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
