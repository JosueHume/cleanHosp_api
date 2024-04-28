using CleanHosp_API.Model.Ala;

namespace CleanHosp_API.Model.Local
{
    public class LocalModel
    {
        public int Id { get; set; }
        public required int IdAla { get; set; }
        public required string Descricao { get; set; }
        public AlaModel? Ala { get; set; }
    }
}
