using CleanHosp_API.Model.Local;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Local
{
    public class LocalMap : IEntityTypeConfiguration<LocalModel>
    {
        public void Configure(EntityTypeBuilder<LocalModel> localMap)
        {
            localMap.HasKey(x => x.Id);
            localMap.Property(x => x.IdAla).IsRequired();
            localMap.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
        }
    }
}