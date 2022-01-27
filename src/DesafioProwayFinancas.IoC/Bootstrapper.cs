using DesafioProwayFinancas.Dados.Repositories.ContaRepository;
using DesafioProwayFinancas.Dados.Repositories.DespesaRepository;
using DesafioProwayFinancas.Dados.Repositories.ReceitaRepository;
using DesafioProwayFinancas.Database;
using DesafioProwayFinancas.Services.Services.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioProwayFinancas.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DbContext, DesafioProwayFinancasDbContext>();
            
            serviceCollection.AddScoped<IReceitaService, ReceitaService>();
            
            serviceCollection.AddScoped<IReceitaRepository, ReceitaRepository>();
            serviceCollection.AddScoped<IDespesaRepository, DespesaRepository>();
            serviceCollection.AddScoped<IContaRepository, ContaRepository>();

            return serviceCollection;
        }
    }
}
