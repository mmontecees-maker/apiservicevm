using System;

namespace api.service.vm.application.commons.dtos;

public sealed record PagoRequestDto(
    int IdCita,
    string MetodoPago,
    decimal Monto
);
