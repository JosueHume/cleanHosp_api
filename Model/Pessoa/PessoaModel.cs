namespace CleanHosp_API.Model.Pessoa
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required int Cpf { get; set; }
        public int? Telefone { get; set; }
        public required string Email {  get; set; }
        public required string Login {  get; set; }
        public required string Senha { get; set; }
    }
}
