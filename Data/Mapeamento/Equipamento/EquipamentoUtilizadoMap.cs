using CleanHosp_API.Model.Equipamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Equipamento
{
    public class EquipamentoUtilizadoMap : IEntityTypeConfiguration<EquipamentoUtilizadoModel>
    {
        public void Configure(EntityTypeBuilder<EquipamentoUtilizadoModel> equipamentoUtilizadoMap)
        {
            equipamentoUtilizadoMap.HasKey(x => x.equipamentos_utilizados_id);
            equipamentoUtilizadoMap.Property(x => x.nr_tempoUso).IsRequired();
            equipamentoUtilizadoMap.Property(x => x.equipamento_id).IsRequired();
        }
    }
}