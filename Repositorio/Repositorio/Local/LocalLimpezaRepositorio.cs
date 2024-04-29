using CleanHosp_API.Data;
using CleanHosp_API.Model.Local;
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

            localLimpezaCadastrado.ala_id = localLimpeza.ala_id;
            localLimpezaCadastrado.pessoa_id = localLimpeza.pessoa_id;
            localLimpezaCadastrado.dt_inicio = localLimpeza.dt_inicio;
            localLimpezaCadastrado.dt_fim = localLimpeza.dt_fim;
            localLimpezaCadastrado.limpeza_id = localLimpeza.limpeza_id;
            localLimpezaCadastrado.produtos_utilizados_id = localLimpeza.produtos_utilizados_id;
            localLimpezaCadastrado.equipamentos_utilizados_id = localLimpeza.equipamentos_utilizados_id;
            localLimpezaCadastrado.ds_descricao = localLimpeza.ds_descricao;
            localLimpezaCadastrado.status = localLimpeza.status;

        _cleanDBContext.Update(localLimpezaCadastrado);
            await _cleanDBContext.SaveChangesAsync();

            return localLimpezaCadastrado;
        }

        public async Task<LocalLimpezaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.local_limpeza.FirstOrDefaultAsync(lp => lp.localLimpeza_id == Id);
        }

        public async Task<List<LocalLimpezaModel>> BuscarTodosLocalLimpeza()
        {

            return await _cleanDBContext.local_limpeza.ToListAsync();
        }

        public async Task<LocalLimpezaModel?> Cadastrar(LocalLimpezaModel localLimpeza)
        {
            await _cleanDBContext.local_limpeza.AddAsync(localLimpeza);
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

            _cleanDBContext.Remove(localLimpezaCadastrado.localLimpeza_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
