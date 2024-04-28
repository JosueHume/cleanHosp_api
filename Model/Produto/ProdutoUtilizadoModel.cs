using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Model.Produto
{
    public class ProdutoUtilizadoModel
    {
        public int Id { get; set; }
        public required int Quantidade { get; set; }
        public required int IdProduto { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}
