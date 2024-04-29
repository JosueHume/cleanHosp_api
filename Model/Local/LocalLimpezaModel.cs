using CleanHosp_API.Enum;
using CleanHosp_API.Model.Equipamento;
using CleanHosp_API.Model.Produto;

namespace CleanHosp_API.Model.Local
{
    public class LocalLimpezaModel
    {
        public int localLimpeza_id { get; set; }
        public required int ala_id { get; set; }
        public required int pessoa_id { get; set; }
        public required DateTime? dt_inicio { get; set; }
        public required DateTime? dt_fim { get; set; }
        public required int limpeza_id { get; set; }
        public required int produtos_utilizados_id { get; set; }
        public List<ProdutoUtilizadoModel>? produtosUtilizados { get; set; }
        public required int equipamentos_utilizados_id { get; set; }
        public List<EquipamentoUtilizadoModel>? equipamentosUtilizado { get; set; }
        public required string ds_descricao { get; set; }
        public StatusLimpeza status { get; set; }
    }
}
