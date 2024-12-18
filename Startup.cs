using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Repository;
using CRUDFinal.Service;
using CRUDFinal.Controller;
using Microsoft.Extensions.DependencyInjection;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal
{
    internal static class Startup
    {
        public static void DependencyInjection(ServiceCollection services)
        {

            services.AddScoped<IRepository<Carro>, CarroRepository>();
            services.AddScoped<IRepositoryVendido<CarroVendido>, CarroRepository>();

            services.AddScoped<IRepository<Motocicleta>, MotocicletaRepository>();
            services.AddScoped<IRepositoryVendido<MotocicletaVendida>, MotocicletaRepository>();
            
            services.AddScoped<IMotocicletaService, MotocicletaService>();
            services.AddScoped<ICarroService, CarroService>();
            
            services.AddScoped<MotocicletaController>();
            services.AddScoped<CarroController>();
        }
    }
}