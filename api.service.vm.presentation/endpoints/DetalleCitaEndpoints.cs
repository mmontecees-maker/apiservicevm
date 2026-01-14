using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.service.vm.presentation.endpoints;

public static class DetalleCitaEndpoints
{
    public static void MapDetalleCitaEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/detalles-cita").WithTags("Detalles de Cita");

        group.MapGet("/", async (IContextGeneral<DetalleCita> repo) => 
            Results.Ok(await repo.GetAll()));

        group.MapPost("/", async ([FromBody] DetalleCita detalle, IContextGeneral<DetalleCita> repo) =>
        {
            var nuevo = await repo.Add(detalle);
            return Results.Created($"/api/detalles-cita/{nuevo.IdDetalle}", nuevo);
        });
    }
}