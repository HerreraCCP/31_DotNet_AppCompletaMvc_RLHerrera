using Microsoft.Extensions.DependencyInjection;
using RLHerrera.Business.Interfaces;
using RLHerrera.Data.Context;
using RLHerrera.Data.Repository;

namespace RLHerrera.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            //services.AddScoped<INotificador, Notificador>();
            //services.AddScoped<IFornecedorService, FornecedorService>();
            //services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
