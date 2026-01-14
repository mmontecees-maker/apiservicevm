using System;

namespace api.service.vm.application.commons.dtos;

public sealed record PagoResponseDto(
    int IdPago,
    int IdCita,
    string MetodoPago,
    decimal Monto,
    DateTime? FechaPago,
    bool Activo
);