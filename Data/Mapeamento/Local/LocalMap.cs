using CleanHosp_API.Model.Local;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Local
{
    public class LocalMap : IEntityTypeConfiguration<LocalModel>
    {
        public void Configure(EntityTypeBuilder<LocalModel> localMap)
        {
            localMap.HasKey(x => x.local_id);
            localMap.Property(x => x.ala_id).IsRequired();
            localMap.Property(x => x.ds_descricao).IsRequired().HasMaxLength(100);
        }
    }
}