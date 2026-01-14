using System;

namespace api.service.vm.application.commons.dtos;

public sealed record CitaResponseDto(
    int IdCita,
    int IdCliente,
    int IdEmpleado,
    DateOnly Fecha,
    TimeOnly Hora,
    string Estado,
    bool Activo
);