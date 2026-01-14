using System;

namespace api.service.vm.application.commons.dtos;

public sealed record DetalleCitaRequestDto(
    int IdCita,
    int IdServicio,
    decimal PrecioAplicado
);
