using CleanHosp_API.Model.Equipamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Equipamento
{
    public class EquipamentoMap : IEntityTypeConfiguration<EquipamentoModel>
    {
        public void Configure(EntityTypeBuilder<EquipamentoModel> equipamentoMap)
        {
            equipamentoMap.HasKey(x => x.equipamento_id);
            equipamentoMap.Property(x => x.ds_nome).IsRequired().HasMaxLength(100);
            equipamentoMap.Property(x => x.ds_marca).IsRequired().HasMaxLength(100);
            equipamentoMap.Property(x => x.ds_modelo).IsRequired().HasMaxLength(100);
            equipamentoMap.Property(x => x.dt_aquisicao);
            equipamentoMap.Property(x => x.ds_descricao).IsRequired().HasMaxLength(100);
            equipamentoMap.Property(x => x.vl_aquisicao).IsRequired();
            equipamentoMap.Property(x => x.xAtivo);
        }
    }
}
