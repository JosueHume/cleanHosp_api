using CleanHosp_API.Model.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanHosp_API.Data.Mapeamento.Pessoa
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> pessoaMap)
        {
            pessoaMap.HasKey(x => x.pessoa_id);
            pessoaMap.Property(x => x.ds_nome).IsRequired().HasMaxLength(100);
            pessoaMap.Property(x => x.nr_cpf).IsRequired().HasMaxLength(11);
            pessoaMap.Property(x => x.nr_telefone).HasMaxLength(20);
            pessoaMap.Property(x => x.ds_email).IsRequired().HasMaxLength(50);
            pessoaMap.Property(x => x.ds_login).IsRequired().HasMaxLength(100);
            pessoaMap.Property(x => x.ds_senha).IsRequired().HasMaxLength(100);
        }
    }
}
