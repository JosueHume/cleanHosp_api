namespace CleanHosp_API.Model.Produto
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Marca { get; set; }
        public required string Descricao { get; set; }
        public required int Quantidade { get; set; }
        public required decimal Valor { get; set; }
    }
}