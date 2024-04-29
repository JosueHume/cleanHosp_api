namespace CleanHosp_API.Model.Equipamento
{
    public class EquipamentoModel
    {
        public int equipamento_id { get; set; }
        public required string ds_nome { get; set; }
        public required string ds_marca { get; set; }
        public required string ds_modelo { get; set; }
        public DateTime? dt_aquisicao { get; set; }
        public required string ds_descricao { get; set; }
        public required decimal vl_aquisicao { get; set; }
        public bool? xAtivo { get; set; }
        public EquipamentoUtilizadoModel? EquipamentoUtilizado { get; set; }
    }
}
