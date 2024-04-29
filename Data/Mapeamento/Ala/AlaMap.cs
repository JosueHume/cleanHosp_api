using CleanHosp_API.Model.Ala;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Ala
{
    public class AlaMap : IEntityTypeConfiguration<AlaModel>
    {
        public void Configure(EntityTypeBuilder<AlaModel> alaMap)
        {
            alaMap.HasKey(x => x.ala_id);
            alaMap.Property(x => x.ds_descricao).IsRequired().HasMaxLength(100);
        }
    }
}
