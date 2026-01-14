using api.service.vm.application.commons.dtos;
using api.service.vm.domain.clases;
using Riok.Mapperly.Abstractions;

namespace api.service.vm.application.commons.mappings;

[Mapper]
public partial class Mappings
{
    // --- CLIENTES ---
    public partial ClienteResponseDto ToResponseDto(Cliente cliente);
    public partial List<ClienteResponseDto> ToResponseDto(List<Cliente> clientes);
    public partial Cliente ToEntity(ClienteRequestDto clienteRequestDto);

    // --- EMPLEADOS ---
    public partial EmpleadoResponseDto ToResponseDto(Empleado empleado);
    public partial List<EmpleadoResponseDto> ToResponseDto(List<Empleado> empleados);
    public partial Empleado ToEntity(EmpleadoRequestDto empleadoRequestDto);

    // --- SERVICIOS ---
    public partial ServicioResponseDto ToResponseDto(Servicio servicio);
    public partial List<ServicioResponseDto> ToResponseDto(List<Servicio> servicios);
    public partial Servicio ToEntity(ServicioRequestDto servicioRequestDto);

    // --- CITAS ---
    public partial CitaResponseDto ToResponseDto(Cita cita);
    public partial List<CitaResponseDto> ToResponseDto(List<Cita> citas);
    public partial Cita ToEntity(CitaRequestDto citaRequestDto);

    // --- PAGOS ---
    public partial PagoResponseDto ToResponseDto(Pago pago);
    public partial List<PagoResponseDto> ToResponseDto(List<Pago> pagos);
    public partial Pago ToEntity(PagoRequestDto pagoRequestDto);

    // --- DETALLE CITA ---
    public partial DetalleCitaResponseDto ToResponseDto(DetalleCita detalle);
    public partial List<DetalleCitaResponseDto> ToResponseDto(List<DetalleCita> detalles);
    public partial DetalleCita ToEntity(DetalleCitaRequestDto detalleRequestDto);
}