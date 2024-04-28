using CleanHosp_API.Data;
using CleanHosp_API.Model.Ala;
using CleanHosp_API.Repositorio.Interface.Ala;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Ala
{
    public class AlaRepositorio : IAlaInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public AlaRepositorio(CleanHospDBContext cleanHospDBContext) 
        {
            _cleanDBContext = cleanHospDBContext;
        }

        public async Task<AlaModel?> Atualizar(AlaModel ala, int Id)
        {
            AlaModel? alaCadastrada = await BuscarPorId(Id);
            
            if (alaCadastrada == null)
            {
                throw new Exception($"Ala para o Id: {Id} não encontrado!");
            }

            alaCadastrada.Descricao = ala.Descricao;

            _cleanDBContext.Update(alaCadastrada);
            await _cleanDBContext.SaveChangesAsync();

            return alaCadastrada;
        }

        public async Task<AlaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.Alas.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<List<AlaModel>> BuscarTodasAlas()
        {
            return await _cleanDBContext.Alas.ToListAsync();
        }

        public async Task<AlaModel?> Cadastrar(AlaModel ala)
        {
            await _cleanDBContext.Alas.AddAsync(ala);
            await _cleanDBContext.SaveChangesAsync();

            return ala;
        }

        public async Task<bool> Deletar(int Id)
        {
            AlaModel? alaCadastrada = await BuscarPorId(Id);

            if (alaCadastrada == null)
            {
                throw new Exception($"Ala para o Id: {Id} não encontrado!");
            }

            _cleanDBContext.Remove(alaCadastrada.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
