using CleanHosp_API.Data.Mapeamento.Ala;
using CleanHosp_API.Data.Mapeamento.Equipamento;
using CleanHosp_API.Data.Mapeamento.Limpeza;
using CleanHosp_API.Data.Mapeamento.Local;
using CleanHosp_API.Data.Mapeamento.LocalLimpeza;
using CleanHosp_API.Data.Mapeamento.Pessoa;
using CleanHosp_API.Data.Mapeamento.Produto;
using CleanHosp_API.Model.Ala;
using CleanHosp_API.Model.Equipamento;
using CleanHosp_API.Model.Limpeza;
using CleanHosp_API.Model.Local;
using CleanHosp_API.Model.LocalLimpeza;
using CleanHosp_API.Model.Pessoa;
using CleanHosp_API.Model.Produto;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API.Data
{
    public class CleanHospDBContext : DbContext
    {
        public CleanHospDBContext(DbContextOptions<CleanHospDBContext> options
            ) : base(options)
        {
        }

        public DbSet<AlaModel> Alas { get; set; }
        public DbSet<EquipamentoModel> Equipamentos { get; set; }
        public DbSet<EquipamentoUtilizadoModel> EquipamentosUtilizados { get; set; }
        public DbSet<LimpezaModel> Limpezas { get; set; }
        public DbSet<LocalModel> Locais { get; set; }
        public DbSet<LocalLimpezaModel> LocalLimpezas { get; set; }
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ProdutoUtilizadoModel> ProdutosUtilizados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlaMap());
            modelBuilder.ApplyConfiguration(new EquipamentoMap());
            modelBuilder.ApplyConfiguration(new EquipamentoUtilizadoMap());
            modelBuilder.ApplyConfiguration(new LimpezaMap());
            modelBuilder.ApplyConfiguration(new LocalMap());
            modelBuilder.ApplyConfiguration(new LocalLimpezaMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoUtilizadoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
