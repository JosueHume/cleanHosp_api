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

            pessoaCadastrada.ds_nome = pessoa.ds_nome;
            pessoaCadastrada.nr_cpf = pessoa.nr_cpf;
            pessoaCadastrada.nr_telefone = pessoa.nr_telefone;
            pessoaCadastrada.ds_email = pessoa.ds_email;
            pessoaCadastrada.ds_login  = pessoa.ds_login;
            pessoaCadastrada.ds_senha = pessoa.ds_senha;

            _cleanDBContext.Update(pessoaCadastrada);
            await _cleanDBContext.SaveChangesAsync();

            return pessoaCadastrada;
        }

        public async Task<PessoaModel?> BuscarPorId(int Id)
        {
            return await _cleanDBContext.pessoa.FirstOrDefaultAsync(p => p.pessoa_id == Id);
        }

        public async Task<List<PessoaModel>> BuscarTodasPessoas()
        {
            return await _cleanDBContext.pessoa.ToListAsync();
        }

        public async Task<PessoaModel?> Cadastrar(PessoaModel pessoa)
        {
            await _cleanDBContext.pessoa.AddAsync(pessoa);
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

            _cleanDBContext.Remove(pessoaCadastrada.pessoa_id);
            await _cleanDBContext.SaveChangesAsync();

            return true;
        }
    }
}
