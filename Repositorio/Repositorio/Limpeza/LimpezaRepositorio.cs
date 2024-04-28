using CleanHosp_API.Data;
using CleanHosp_API.Model.Limpeza;
using CleanHosp_API.Repositorio.Interface.Limpeza;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Limpeza
{
    public class LimpezaRepositorio : ILimpezaInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public LimpezaRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<LimpezaModel?> Atualizar(LimpezaModel limpeza, int Id)
        {
            LimpezaModel? limpezaCadastrada = await BuscarPorId(Id);

            if (limpezaCadastrada == null)
            {
                throw new Exception($"Limpeza para o Id: {Id} não encontrado!");
            }

            limpezaCadastrada.Descricao = limpeza.Descricao;

            _cleanDBContext.Update(limpezaCadastrada);
            await _cleanDBContext.SaveChangesAsync();

            return limpezaCadastrada;
        }

        public async Task<LimpezaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.Limpezas.FirstOrDefaultAsync(l => l.Id == Id);
        }

        public async Task<List<LimpezaModel>> BuscarTodasLimpeza()
        {
            return await _cleanDBContext.Limpezas.ToListAsync();
        }

        public async Task<LimpezaModel?> Cadastrar(LimpezaModel limpeza)
        {
            await _cleanDBContext.Limpezas.AddAsync(limpeza);
            await _cleanDBContext.SaveChangesAsync();

            return limpeza;
        }

        public async Task<bool> Deletar(int Id)
        {
            LimpezaModel? limpezaCadastrada = await BuscarPorId(Id);

            if (limpezaCadastrada == null)
            {
                throw new Exception($"Limpeza para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(limpezaCadastrada.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
