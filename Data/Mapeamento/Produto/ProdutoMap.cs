using CleanHosp_API.Model.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Produto
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> produtoMap)
        {
            produtoMap.HasKey(x => x.Id);
            produtoMap.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            produtoMap.Property(x => x.Valor).IsRequired();
            produtoMap.Property(x => x.Quantidade).IsRequired();
        }
    }
}
