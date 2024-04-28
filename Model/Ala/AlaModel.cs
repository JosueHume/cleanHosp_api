using CleanHosp_API.Model.Local;

namespace CleanHosp_API.Model.Ala
{
    public class AlaModel
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public List<LocalModel>? Locais { get; set; }  
    }
}
