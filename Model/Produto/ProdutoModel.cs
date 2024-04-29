namespace CleanHosp_API.Model.Produto
{
    public class ProdutoModel
    {
        public int produto_id { get; set; }
        public required string ds_nome { get; set; }
        public required string ds_marca { get; set; }
        public required string ds_descricao { get; set; }
        public required int qtde_estoque { get; set; }
        public required decimal vl_unitario { get; set; }
    }
}