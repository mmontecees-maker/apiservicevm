using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.service.vm.presentation.endpoints;

public static class EmpleadoEndpoints
{
    public static void MapEmpleadoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/empleados").WithTags("Empleados");

        group.MapGet("/", async ([FromServices] IContextGeneral<Empleado> repo) =>
            Results.Ok(await repo.GetAll()));

        group.MapGet("/{id}", async (int id, [FromServices] IContextGeneral<Empleado> repo) =>
        {
            var emp = await repo.GetById(id);
            return emp is not null ? Results.Ok(emp) : Results.NotFound();
        });

        group.MapPost("/", async ([FromBody] Empleado emp, [FromServices] IContextGeneral<Empleado> repo) =>
        {
            var nuevo = await repo.Add(emp);
            return Results.Created($"/api/empleados/{nuevo.IdEmpleado}", nuevo);
        });
        
        // Puedes agregar Put y Delete siguiendo el mismo patrón de Clientes
    }
}