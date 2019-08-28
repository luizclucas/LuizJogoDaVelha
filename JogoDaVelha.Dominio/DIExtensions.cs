using JogoDaVelha.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace JogoDaVelha.Dominio
{
    public static class DIExtensions
    {
        public static IServiceCollection AdicionarDominio(this IServiceCollection services)
        {
            services.AddSingleton<PartidaServico>();
            return services;
        }
    }
}
