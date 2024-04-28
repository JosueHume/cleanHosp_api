using CleanHosp_API.Model.Ala;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Ala
{
    public class AlaMap : IEntityTypeConfiguration<AlaModel>
    {
        public void Configure(EntityTypeBuilder<AlaModel> alaMap)
        {
            alaMap.HasKey(x => x.Id);
            alaMap.Property(x => x.Descricao).IsRequired().HasMaxLength(100);

            alaMap.HasMany(x => x.Locais);
        }
    }
}
