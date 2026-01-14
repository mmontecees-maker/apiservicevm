using System;

namespace api.service.vm.application.commons.dtos;

public sealed record ClienteRequestDto(
    string Identificacion,
    string Nombres,
    string Apellidos,
    string? Telefono,
    string? Email
);