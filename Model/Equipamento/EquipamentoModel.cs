namespace CleanHosp_API.Model.Equipamento
{
    public class EquipamentoModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public DateTime? Dt_aquisicao { get; set; }
        public required string Descricao { get; set; }
        public required decimal Vl_aquisicao { get; set; }
        public bool? XAtivo { get; set; }
        public EquipamentoUtilizadoModel? EquipamentoUtilizado { get; set; }
    }
}
