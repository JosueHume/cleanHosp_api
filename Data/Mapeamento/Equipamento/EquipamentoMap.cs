using CleanHosp_API.Model.Equipamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Equipamento
{
    public class EquipamentoMap : IEntityTypeConfiguration<EquipamentoModel>
    {
        public void Configure(EntityTypeBuilder<EquipamentoModel> equipamentoMap)
        {
            equipamentoMap.HasKey(x => x.Id);
            equipamentoMap.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            equipamentoMap.Property(x => x.Marca).IsRequired().HasMaxLength(50);
            equipamentoMap.Property(x => x.Modelo).IsRequired().HasMaxLength(50);
            equipamentoMap.Property(x => x.Dt_aquisicao);
            equipamentoMap.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            equipamentoMap.Property(x => x.Vl_aquisicao).IsRequired();
            equipamentoMap.Property(x => x.XAtivo);
        }
    }
}
