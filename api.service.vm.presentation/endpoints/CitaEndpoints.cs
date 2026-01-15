using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.service.vm.presentation.endpoints;

public static class CitaEndpoints
{
    public static void MapCitaEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/citas").WithTags("Citas");

        group.MapGet("/", async ([FromServices] IContextGeneral<Cita> repo) =>
        {
            return Results.Ok(await repo.GetAll());
        });

        group.MapGet("/{id}", async (int id, [FromServices] IContextGeneral<Cita> repo) =>
        {
            var cita = await repo.GetById(id);
            return cita is not null ? Results.Ok(cita) : Results.NotFound();
        });

        group.MapPost("/", async ([FromBody] Cita cita, [FromServices] IContextGeneral<Cita> repo) =>
        {
            var nuevaCita = await repo.Add(cita);
            return Results.Created($"/api/citas/{nuevaCita.IdCita}", nuevaCita);
        });

        group.MapPut("/{id}", async (int id, [FromBody] Cita cita, [FromServices] IContextGeneral<Cita> repo) =>
        {
            var existente = await repo.GetById(id);
            if (existente is null) return Results.NotFound();
            await repo.Update(cita);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, [FromServices] IContextGeneral<Cita> repo) =>
        {
            var cita = await repo.GetById(id);
            if (cita is null) return Results.NotFound();
            await repo.Delete(cita);
            return Results.NoContent();
        });
    }
}