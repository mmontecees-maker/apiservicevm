using System;

namespace api.service.vm.application.commons.dtos;

public sealed record ClienteResponseDto(
    int IdCliente,
    string Identificacion,
    string Nombres,
    string Apellidos,
    string? Telefono,
    string? Email,
    bool Activo
);