using CleanHosp_API.Model.Local;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.LocalLimpeza
{
    public class LocalLimpezaMap : IEntityTypeConfiguration<LocalLimpezaModel>
    {
        public void Configure(EntityTypeBuilder<LocalLimpezaModel> localLimpezaMap)
        {
            localLimpezaMap.HasKey(x => x.localLimpeza_id);
            localLimpezaMap.Property(x => x.ala_id).IsRequired();
            localLimpezaMap.Property(x => x.pessoa_id).IsRequired();
            localLimpezaMap.Property(x => x.dt_inicio);
            localLimpezaMap.Property(x => x.dt_fim);
            localLimpezaMap.Property(x => x.limpeza_id).IsRequired();
            localLimpezaMap.Property(x => x.produtos_utilizados_id).IsRequired();
            localLimpezaMap.Property(x => x.equipamentos_utilizados_id).IsRequired();
            localLimpezaMap.Property(x => x.ds_descricao).IsRequired().HasMaxLength(100);
            localLimpezaMap.Property(x => x.status).IsRequired();
        }
    }
}