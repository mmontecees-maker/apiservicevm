using Microsoft.EntityFrameworkCore;
using api.service.vm.infrastructure;
using api.service.vm.infrastructure.repositories;
using api.service.vm.domain.interfaces;
using api.service.vm.application.ifeatures;
using api.service.vm.application.features;
using api.service.vm.infrastructure.context.cliente;
using api.service.vm.infrastructure.context.empleado;
using api.service.vm.infrastructure.context.cita;
using api.service.vm.infrastructure.context.pago;
using api.service.vm.infrastructure.context.servicio;
using api.service.vm.infrastructure.context.detallecita;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";

#region SERVICIOS

// --- CORRECCIÓN OPENAPI ---
// Si usas .NET 9 y quieres Swagger, basta con estas dos:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
// Si AddOpenApi() te da error, puedes comentarlo o verificar que tengas el paquete 
// Microsoft.AspNetCore.OpenApi instalado.
// builder.Services.AddOpenApi(); 

// 1. Conexión a Base de Datos
builder.Services.AddDbContext<ProyectoBDContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Repositorio Genérico
builder.Services.AddScoped(typeof(IContextGeneral<>), typeof(ContextGeneral<>));

// 3. REGISTRO DE CONTEXTOS (Infrastructure)
builder.Services.AddScoped<IClienteContext, ClienteContext>();
builder.Services.AddScoped<IEmpleadoContext, EmpleadoContext>();
builder.Services.AddScoped<ICitaContext, CitaContext>();
builder.Services.AddScoped<IPagoContext, PagoContext>();
builder.Services.AddScoped<IServicioContext, ServicioContext>();
builder.Services.AddScoped<IDetalleCitaContext, DetalleCitaContext>();

// 4. REGISTRO DE HANDLERS (Application)
builder.Services.AddScoped<IClienteHandler, ClienteHandler>();
builder.Services.AddScoped<IEmpleadoHandler, EmpleadoHandler>();
builder.Services.AddScoped<ICitaHandler, CitaHandler>();
builder.Services.AddScoped<IPagoHandler, PagoHandler>();
builder.Services.AddScoped<IServicioHandler, ServicioHandler>();
builder.Services.AddScoped<IDetalleCitaHandler, DetalleCitaHandler>();

#endregion SERVICIOS

var app = builder.Build();

#region MIDDLEWARE

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API de Citas v1.0 funcionando");

// Ejemplo usando el HANDLER (Forma correcta de tu arquitectura)
app.MapGet("/v1/clientes", async (IClienteHandler handler) => 
{
    return Results.Ok(await handler.GetAll());
});

#endregion MIDDLEWARE

app.Run(url);