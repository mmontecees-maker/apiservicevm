using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.service.vm.presentation.endpoints;

public static class PagoEndpoints
{
    public static void MapPagoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/pagos").WithTags("Pagos");

        group.MapGet("/", async (IContextGeneral<Pago> repo) => 
            Results.Ok(await repo.GetAll()));

        group.MapPost("/", async ([FromBody] Pago pago, IContextGeneral<Pago> repo) =>
        {
            var nuevo = await repo.Add(pago);
            return Results.Created($"/api/pagos/{nuevo.IdPago}", nuevo);
        });
    }
}