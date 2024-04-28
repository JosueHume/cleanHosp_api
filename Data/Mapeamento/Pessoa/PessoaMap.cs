using CleanHosp_API.Model.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Pessoa
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> pessoaMap)
        {
            pessoaMap.HasKey(x => x.Id);
            pessoaMap.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            pessoaMap.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            pessoaMap.Property(x => x.Telefone);
            pessoaMap.Property(x => x.Email).IsRequired().HasMaxLength(100);
            pessoaMap.Property(x => x.Login).IsRequired().HasMaxLength(50);
            pessoaMap.Property(x => x.Senha).IsRequired().HasMaxLength(50);
        }
    }
}
