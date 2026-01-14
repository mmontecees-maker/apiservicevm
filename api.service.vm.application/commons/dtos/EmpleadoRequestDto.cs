using System;

namespace api.service.vm.application.commons.dtos;

public sealed record EmpleadoRequestDto(
    string Identificacion,
    string Nombres,
    string Apellidos,
    string? Especialidad,
    string? Telefono,
    string? Email
);