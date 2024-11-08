using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Repository;
using CRUDFinal.Service;
using CRUDFinal.Controller;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDFinal
{
    internal static class Startup
    {
        public static void DependencyInjection(ServiceCollection services)
        {
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<IMotocicletaRepository, MotocicletaRepository>();
            services.AddScoped<IMotocicletaService, MotocicletaService>();
            services.AddScoped<MotocicletaController>();
            services.AddScoped<CarroController>();
        }
    }
}