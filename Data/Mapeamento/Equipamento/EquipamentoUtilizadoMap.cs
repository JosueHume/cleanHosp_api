using CleanHosp_API.Data.Mapeamento.Produto;
using CleanHosp_API.Model.Equipamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Equipamento
{
    public class EquipamentoUtilizadoMap : IEntityTypeConfiguration<EquipamentoUtilizadoModel>
    {
        public void Configure(EntityTypeBuilder<EquipamentoUtilizadoModel> equipamentoUtilizadoMap)
        {
            equipamentoUtilizadoMap.HasKey(x => x.Id);
            equipamentoUtilizadoMap.Property(x => x.Nr_TempoUso).IsRequired();
            equipamentoUtilizadoMap.Property(x => x.IdEquipamento).IsRequired();


            equipamentoUtilizadoMap.HasMany(x => x.Equipamentos);
        }
    }
}