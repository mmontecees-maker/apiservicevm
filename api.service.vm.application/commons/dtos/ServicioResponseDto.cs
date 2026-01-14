using System;

namespace api.service.vm.application.commons.dtos;

public sealed record ServicioResponseDto(
    int IdServicio,
    string Nombre,
    string? Descripcion,
    int DuracionMinutos,
    decimal Precio,
    bool Activo
);