namespace CleanHosp_API.Model.Pessoa
{
    public class PessoaModel
    {
        public int pessoa_id { get; set; }
        public required string ds_nome { get; set; }
        public required int nr_cpf { get; set; }
        public int? nr_telefone { get; set; }
        public required string ds_email {  get; set; }
        public required string ds_login {  get; set; }
        public required string ds_senha { get; set; }
    }
}
