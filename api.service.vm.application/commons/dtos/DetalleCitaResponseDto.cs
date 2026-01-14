using System;

namespace api.service.vm.application.commons.dtos;

public sealed record DetalleCitaResponseDto(
    int IdDetalle,
    int IdCita,
    int IdServicio,
    decimal PrecioAplicado,
    bool Activo
);