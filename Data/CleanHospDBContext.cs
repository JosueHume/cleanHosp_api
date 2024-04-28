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
        protected CleanHospDBContext(DbContextOptions<CleanHospDBContext> options
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
            base.OnModelCreating(modelBuilder);
        }

    }
}
