using api.service.vm.application.features;
using api.service.vm.application.ifeatures;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.vm.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registro de Handlers para cada entidad
        services.AddScoped<IClienteHandler, ClienteHandler>();
        services.AddScoped<IEmpleadoHandler, EmpleadoHandler>();
        services.AddScoped<ICitaHandler, CitaHandler>();
        services.AddScoped<IPagoHandler, PagoHandler>();
        services.AddScoped<IServicioHandler, ServicioHandler>();
        services.AddScoped<IDetalleCitaHandler, DetalleCitaHandler>();

        return services;
    }
}