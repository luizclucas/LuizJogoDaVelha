using JogoDaVelha.Dominio.Interfaces.Repositorios;
using JogoDaVelha.Infra.Dados.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace JogoDaVelha.Infra.Dados
{
    public static class DIExtensions
    {
        public static IServiceCollection AdicionarRepositorio(this IServiceCollection services)
        {
            services.AddSingleton<IPartidaRepositorio, PartidaRepositorio>();
            return services;
        }
    }
}
