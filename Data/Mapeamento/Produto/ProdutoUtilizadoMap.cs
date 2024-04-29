using CleanHosp_API.Model.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Produto
{
    public class ProdutoUtilizadoMap : IEntityTypeConfiguration<ProdutoUtilizadoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoUtilizadoModel> produtoUtilizadoMap)
        {
            produtoUtilizadoMap.HasKey(x => x.produtos_utilizados_id);
            produtoUtilizadoMap.Property(x => x.produto_id).IsRequired();
            produtoUtilizadoMap.Property(x => x.quantidade).IsRequired();

            produtoUtilizadoMap.HasMany(x => x.Produtos);
        }
    }
}
