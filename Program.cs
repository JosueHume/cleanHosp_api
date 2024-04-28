
using CleanHosp_API.Data;
using CleanHosp_API.Repositorio.Interface.Ala;
using CleanHosp_API.Repositorio.Interface.Equipamento;
using CleanHosp_API.Repositorio.Interface.Limpeza;
using CleanHosp_API.Repositorio.Interface.Local;
using CleanHosp_API.Repositorio.Interface.Pessoa;
using CleanHosp_API.Repositorio.Interface.Produto;
using CleanHosp_API.Repositorio.Repositorio.Ala;
using CleanHosp_API.Repositorio.Repositorio.Equipamento;
using CleanHosp_API.Repositorio.Repositorio.Limpeza;
using CleanHosp_API.Repositorio.Repositorio.Local;
using CleanHosp_API.Repositorio.Repositorio.Pessoa;
using CleanHosp_API.Repositorio.Repositorio.Produto;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CleanHospDBContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
            });

            builder.Services.AddScoped<IAlaInterface, AlaRepositorio>();
            builder.Services.AddScoped<IEquipamentoInterface, EquipamentoRepositorio>();
            builder.Services.AddScoped<IEquipamentoUtilizadoInterface, EquipamentoUtilizadoRepositorio>();
            builder.Services.AddScoped<ILimpezaInterface, LimpezaRepositorio>();
            builder.Services.AddScoped<ILocalInterface, LocalRepositorio>();
            builder.Services.AddScoped<ILocalLimpezaInterface, LocalLimpezaRepositorio>();
            builder.Services.AddScoped<IPessoaInterface, PessoaRepositorio>();
            builder.Services.AddScoped<IProdutoInterface, ProdutoRepositorio>();
            builder.Services.AddScoped<IProdutoUtilizadoInterface, ProdutoUtilizadoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
