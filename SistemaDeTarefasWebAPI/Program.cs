using Microsoft.EntityFrameworkCore;
using Refit;
using SistemaDeTarefasWebAPI.Data;
using SistemaDeTarefasWebAPI.Integracao;
using SistemaDeTarefasWebAPI.Integracao.Interfaces;
using SistemaDeTarefasWebAPI.Integracao.Refit;
using SistemaDeTarefasWebAPI.Repositorios;
using SistemaDeTarefasWebAPI.Repositorios.Interfaces;

namespace SistemaDeTarefasWebAPI
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

            //configuração do banco de dados
            builder.Services.AddEntityFrameworkSqlServer()
                            .AddDbContext<MeuDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Configuração de injeção de dependência
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();


            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>()
                            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br/"));


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
