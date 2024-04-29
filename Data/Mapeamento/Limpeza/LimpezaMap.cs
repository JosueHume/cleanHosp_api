using CleanHosp_API.Model.Limpeza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Limpeza
{
    public class LimpezaMap : IEntityTypeConfiguration<LimpezaModel>
    {
        public void Configure(EntityTypeBuilder<LimpezaModel> limpezaMap)
        {
            limpezaMap.HasKey(x => x.limpeza_id);
            limpezaMap.Property(x => x.ds_descricao).IsRequired().HasMaxLength(100);
        }
    }
}
