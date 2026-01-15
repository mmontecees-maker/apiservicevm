using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.service.vm.presentation.endpoints;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/clientes").WithTags("Clientes");

        // Obtener todos los clientes
        group.MapGet("/", async ([FromServices] IContextGeneral<Cliente> repo) =>
        {
            var clientes = await repo.GetAll();
            return Results.Ok(clientes);
        });

        // Obtener cliente por ID
        group.MapGet("/{id}", async (int id, [FromServices] IContextGeneral<Cliente> repo) =>
        {
            var cliente = await repo.GetById(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        });

        // Crear un nuevo cliente
        group.MapPost("/", async ([FromBody] Cliente cliente, [FromServices] IContextGeneral<Cliente> repo) =>
        {
            var nuevoCliente = await repo.Add(cliente);
            return Results.Created($"/api/clientes/{nuevoCliente.IdCliente}", nuevoCliente);
        });

        // Actualizar cliente
        group.MapPut("/{id}", async (int id, [FromBody] Cliente cliente, [FromServices] IContextGeneral<Cliente> repo) =>
        {
            var existente = await repo.GetById(id);
            if (existente is null) return Results.NotFound();

            await repo.Update(cliente);
            return Results.NoContent();
        });

        // Eliminar cliente
        group.MapDelete("/{id}", async (int id, [FromServices] IContextGeneral<Cliente> repo) =>
        {
            var cliente = await repo.GetById(id);
            if (cliente is null) return Results.NotFound();

            await repo.Delete(cliente);
            return Results.NoContent();
        });
    }
}