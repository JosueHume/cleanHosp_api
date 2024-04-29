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

            localCadastrado.ala_id = local.ala_id;
            localCadastrado.ds_descricao = local.ds_descricao;

            _cleanDBContext.Update(localCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return localCadastrado;
        }

        public async Task<LocalModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.local.FirstOrDefaultAsync(l => l.local_id == Id);
        }

        public async Task<List<LocalModel>> BuscarTodosLocalLimpeza()
        {
            return await _cleanDBContext.local.ToListAsync();
        }

        public async Task<LocalModel?> Cadastrar(LocalModel local)
        {
            await _cleanDBContext.local.AddAsync(local);
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

            _cleanDBContext.Remove(localCadastrado.local_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
