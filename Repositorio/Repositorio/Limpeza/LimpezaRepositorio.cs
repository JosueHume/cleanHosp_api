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

            limpezaCadastrada.ds_descricao = limpeza.ds_descricao;

            _cleanDBContext.Update(limpezaCadastrada);
            await _cleanDBContext.SaveChangesAsync();

            return limpezaCadastrada;
        }

        public async Task<LimpezaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.limpeza.FirstOrDefaultAsync(l => l.limpeza_id == Id);
        }

        public async Task<List<LimpezaModel>> BuscarTodasLimpeza()
        {
            return await _cleanDBContext.limpeza.ToListAsync();
        }

        public async Task<LimpezaModel?> Cadastrar(LimpezaModel limpeza)
        {
            await _cleanDBContext.limpeza.AddAsync(limpeza);
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

            _cleanDBContext.Remove(limpezaCadastrada.limpeza_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
