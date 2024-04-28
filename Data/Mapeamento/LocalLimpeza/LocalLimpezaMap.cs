using CleanHosp_API.Model.LocalLimpeza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.LocalLimpeza
{
    public class LocalLimpezaMap : IEntityTypeConfiguration<LocalLimpezaModel>
    {
        public void Configure(EntityTypeBuilder<LocalLimpezaModel> localLimpezaMap)
        {
            localLimpezaMap.HasKey(x => x.Id);
            localLimpezaMap.Property(x => x.IdAla).IsRequired();
            localLimpezaMap.Property(x => x.IdPessoa).IsRequired();
            localLimpezaMap.Property(x => x.Dt_Inicio);
            localLimpezaMap.Property(x => x.Dt_Fim);
            localLimpezaMap.Property(x => x.IdLimpeza).IsRequired();
            localLimpezaMap.Property(x => x.IdProdutoUtilizado).IsRequired();
            localLimpezaMap.Property(x => x.IdEquipamentoUtilizado).IsRequired();
            localLimpezaMap.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            localLimpezaMap.Property(x => x.Status).IsRequired();
        }
    }
}