using CleanHosp_API.Data;
using CleanHosp_API.Model.Pessoa;
using CleanHosp_API.Repositorio.Interface.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Repositorio.Repositorio.Pessoa
{
    public class PessoaRepositorio : IPessoaInterface
    {
        private readonly CleanHospDBContext _cleanDBContext;

        public PessoaRepositorio(CleanHospDBContext cleanDBContext)
        {
            _cleanDBContext = cleanDBContext;
        }

        public async Task<PessoaModel?> Atualizar(PessoaModel pessoa, int Id)
        {
            PessoaModel? pessoaCadastrada = await BuscarPorId(Id);

            if (pessoaCadastrada == null)
            {
                throw new Exception($"Pessoa para o Id: {Id} não encontrada!");
            }

            pessoaCadastrada.Nome = pessoa.Nome;
            pessoaCadastrada.Cpf = pessoa.Cpf;
            pessoaCadastrada.Telefone = pessoa.Telefone;
            pessoaCadastrada.Email = pessoa.Email;
            pessoaCadastrada.Login  = pessoa.Login;
            pessoaCadastrada.Senha = pessoa.Senha;

            _cleanDBContext.Update(pessoaCadastrada);
            await _cleanDBContext.SaveChangesAsync();

            return pessoaCadastrada;
        }

        public async Task<PessoaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.Pessoas.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<List<PessoaModel>> BuscarTodasPessoas()
        {
            return await _cleanDBContext.Pessoas.ToListAsync();
        }

        public async Task<PessoaModel?> Cadastrar(PessoaModel pessoa)
        {
            await _cleanDBContext.Pessoas.AddAsync(pessoa);
            await _cleanDBContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<bool> Deletar(int Id)
        {
            PessoaModel? pessoaCadastrada = await BuscarPorId(Id);

            if (pessoaCadastrada == null)
            {
                throw new Exception($"Pessoa para o Id: {Id} não encontrada!");
            }

            _cleanDBContext.Remove(pessoaCadastrada.Id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
