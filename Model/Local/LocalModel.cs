using CleanHosp_API.Model.Ala;

namespace CleanHosp_API.Model.Local
{
    public class LocalModel
    {
        public int local_id { get; set; }
        public required int ala_id { get; set; }
        public required string ds_descricao { get; set; }
    }
}
