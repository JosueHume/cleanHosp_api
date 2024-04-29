using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Model.Equipamento
{
    public class EquipamentoUtilizadoModel
    {
        public int equipamentos_utilizados_id { get; set; }
        public required int equipamento_id { get; set; }
        public required int nr_tempoUso { get; set; }
    }
}
