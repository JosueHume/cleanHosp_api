using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Model.Ala
{
    public class AlaModel
    {
        public int ala_id { get; set; }
        public required string ds_descricao { get; set; }
        public LocalModel? Local { get; set; }  
    }
}
