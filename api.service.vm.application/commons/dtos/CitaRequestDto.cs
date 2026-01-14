using System;

namespace api.service.vm.application.commons.dtos;

public sealed record CitaRequestDto(
    int IdCliente,
    int IdEmpleado,
    DateOnly Fecha,
    TimeOnly Hora,
    string Estado
);