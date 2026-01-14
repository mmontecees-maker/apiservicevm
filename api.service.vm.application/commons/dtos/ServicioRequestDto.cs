using System;

namespace api.service.vm.application.commons.dtos;

public sealed record ServicioRequestDto(
    string Nombre,
    string? Descripcion,
    int DuracionMinutos,
    decimal Precio
);