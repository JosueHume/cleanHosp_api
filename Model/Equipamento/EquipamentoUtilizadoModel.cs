using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Model.Equipamento
{
    public class EquipamentoUtilizadoModel
    {
        public int Id { get; set; }
        public required int Nr_TempoUso { get; set; }
        public required int IdEquipamento { get; set; }
        public List<EquipamentoModel>? Equipamentos { get; set; }
    }
}
