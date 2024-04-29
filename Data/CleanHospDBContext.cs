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

        public DbSet<AlaModel> ala { get; set; }
        public DbSet<EquipamentoModel> equipamento { get; set; }
        public DbSet<EquipamentoUtilizadoModel> equipamentos_utilizados { get; set; }
        public DbSet<LimpezaModel> limpeza { get; set; }
        public DbSet<LocalModel> local { get; set; }
        public DbSet<LocalLimpezaModel> local_limpeza { get; set; }
        public DbSet<PessoaModel> pessoa { get; set; }
        public DbSet<ProdutoModel> produto { get; set; }
        public DbSet<ProdutoUtilizadoModel> produtos_utilizados { get; set; }

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
