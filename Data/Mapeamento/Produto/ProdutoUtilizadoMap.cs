using CleanHosp_API.Model.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Produto
{
    public class ProdutoUtilizadoMap : IEntityTypeConfiguration<ProdutoUtilizadoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoUtilizadoModel> produtoUtilizadoMap)
        {
            produtoUtilizadoMap.HasKey(x => x.Id);
            produtoUtilizadoMap.Property(x => x.IdProduto).IsRequired();
            produtoUtilizadoMap.Property(x => x.Quantidade).IsRequired();

            produtoUtilizadoMap.HasMany(x => x.Produtos);
        }
    }
}
