using api.service.vm.application.commons.dtos;
using api.service.vm.application.commons.mappings;
using api.service.vm.application.ifeatures;
using api.service.vm.application.interfaces;
using api.service.vm.domain.clases;

namespace api.service.vm.application.features;

public class PagoHandler : IPagoHandler
{
    private readonly Mappings _mapper;
    private readonly IPagoContext _context;

    public PagoHandler(IPagoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<PagoResponseDto>> GetAll()
    {
        var pagos = await _context.GetAllAsync();
        return _mapper.ToResponseDto(pagos);
    }

    public async Task<PagoResponseDto?> GetById(int id)
    {
        var pago = await _context.GetByIdAsync(id);
        return pago == null ? null : _mapper.ToResponseDto(pago);
    }

    public async Task<PagoResponseDto> Insert(PagoRequestDto pagoRequest)
    { 
        // Mapeo de RequestDto a la Entidad de Dominio
        var pago = _mapper.ToEntity(pagoRequest);
        
        // Persistencia en Infraestructura
        var pagoGuardado = await _context.InsertAsync(pago);
        
        // Mapeo de Entidad a ResponseDto para el cliente
        return _mapper.ToResponseDto(pagoGuardado);
    }

    public async Task<(bool, string?)> UpdateAsync(PagoRequestDto pagoRequest, int id)
    { 
        var pago = _mapper.ToEntity(pagoRequest);

        // Sincronizamos el ID del objeto con el de la URL
        pago.IdPago = id;
        
        var result = await _context.UpdateAsync(pago);

        return result;
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    { 
        var result = await _context.Delete(id, softDelete);

        return result;
    }
}