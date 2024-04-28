using CleanHosp_API.Enum;
using CleanHosp_API.Model.Equipamento;
using CleanHosp_API.Model.Produto;

namespace CleanHosp_API.Model.LocalLimpeza
{
    public class LocalLimpezaModel
    {
        public int Id { get; set; } 
        public required int IdAla { get; set; }
        public required int IdPessoa { get; set; }
        public required DateTime? Dt_Inicio { get; set; }
        public required DateTime? Dt_Fim {  get; set; }
        public required int IdLimpeza { get; set; } 
        public required int IdProdutoUtilizado { get; set; }
        public List<ProdutoUtilizadoModel>? ProdutosUtilizados { get; set; }
        public required int IdEquipamentoUtilizado { get; set; }
        public List<EquipamentoUtilizadoModel>? EquipamentosUtilizado { get; set; }
        public required string Descricao { get; set; }
        public StatusLimpeza Status { get; set; }
    }
}
