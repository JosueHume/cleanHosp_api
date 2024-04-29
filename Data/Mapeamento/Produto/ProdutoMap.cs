using CleanHosp_API.Model.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Produto
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> produtoMap)
        {
            produtoMap.HasKey(x => x.produto_id);
            produtoMap.Property(x => x.ds_nome).IsRequired().HasMaxLength(100);
            produtoMap.Property(x => x.ds_marca).IsRequired().HasMaxLength(100);
            produtoMap.Property(x => x.ds_descricao).IsRequired().HasMaxLength(100);
            produtoMap.Property(x => x.vl_unitario).IsRequired();
            produtoMap.Property(x => x.qtde_estoque).IsRequired();
        }
    }
}
