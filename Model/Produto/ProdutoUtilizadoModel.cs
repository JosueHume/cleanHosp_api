using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Model.Produto
{
    public class ProdutoUtilizadoModel
    {
        public int produtos_utilizados_id { get; set; }
        public required int quantidade { get; set; }
        public required int produto_id { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}
