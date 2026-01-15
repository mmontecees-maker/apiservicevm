using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.service.vm.presentation.endpoints;

public static class ServicioEndpoints
{
    public static void MapServicioEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/servicios").WithTags("Servicios");

        group.MapGet("/", async ([FromServices] IContextGeneral<Servicio> repo) => 
            Results.Ok(await repo.GetAll()));

        group.MapPost("/", async ([FromBody] Servicio serv, [FromServices] IContextGeneral<Servicio> repo) =>
        {
            var nuevo = await repo.Add(serv);
            return Results.Created($"/api/servicios/{nuevo.IdServicio}", nuevo);
        });
    }
}