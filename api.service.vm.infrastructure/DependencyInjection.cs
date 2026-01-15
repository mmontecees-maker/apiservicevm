using api.service.vm.application.interfaces;
using api.service.vm.infrastructure.Context;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.vm.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Conexión a Base de Datos
        services.AddDbContext<ProyectoBDContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // 2. Repositorio Genérico
        services.AddScoped(typeof(IContextGeneral<>), typeof(ContextGeneral<>));

        // 3. Registro de Contextos Específicos
        services.AddScoped<IClienteContext, ClienteContext>();
        services.AddScoped<IEmpleadoContext, EmpleadoContext>();
        services.AddScoped<ICitaContext, CitaContext>();
        services.AddScoped<IPagoContext, PagoContext>();
        services.AddScoped<IServicioContext, ServicioContext>();
        services.AddScoped<IDetalleCitaContext, DetalleCitaContext>();

        return services;
    }
}