using CleanHosp_API.Model.Pessoa;

namespace CleanHosp_API.Repositorio.Interface.Pessoa
{
    public interface IPessoaInterface
    {
        Task<List<PessoaModel>> BuscarTodasPessoas();
        Task<PessoaModel?> BuscarPorId(int Id);
        Task<PessoaModel?> Cadastrar(PessoaModel pessoa);
        Task<PessoaModel?> Atualizar(PessoaModel pessoa, int Id);
        Task<bool> Deletar(int Id);
    }
}
