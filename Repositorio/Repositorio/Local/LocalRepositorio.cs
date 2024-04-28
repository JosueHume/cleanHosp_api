using CleanHosp_API.Data;
using CleanHosp_API.Model.Local;
using CleanHosp_API.Repositorio.Interface.Local;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Local
{
    public class LocalRepositorio : ILocalInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public LocalRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<LocalModel?> Atualizar(LocalModel local, int Id)
        {
            LocalModel? localCadastrado = await BuscarPorId(Id);

            if (localCadastrado == null)
            {
                throw new Exception($"Ala para o Id: {Id} não encontrado!");
            }

            localCadastrado.IdAla = local.IdAla;
            localCadastrado.Descricao = local.Descricao;

            _cleanDBContext.Update(localCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return localCadastrado;
        }

        public async Task<LocalModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.Locais.FirstOrDefaultAsync(l => l.Id == Id);
        }

        public async Task<List<LocalModel>> BuscarTodosLocalLimpeza()
        {
            return await _cleanDBContext.Locais.ToListAsync();
        }

        public async Task<LocalModel?> Cadastrar(LocalModel local)
        {
            await _cleanDBContext.Locais.AddAsync(local);
            await _cleanDBContext.SaveChangesAsync();

            return local;
        }

        public async Task<bool> Deletar(int Id)
        {
            LocalModel? localCadastrado = await BuscarPorId(Id);

            if (localCadastrado == null)
            {
                throw new Exception($"Local para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(localCadastrado.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
