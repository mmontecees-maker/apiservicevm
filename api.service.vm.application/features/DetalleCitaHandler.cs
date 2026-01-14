using api.service.vm.application.commons.dtos;
using api.service.vm.application.commons.mappings;
using api.service.vm.application.ifeatures;
using api.service.vm.infrastructure.context.detallecita;
using api.service.vm.domain.clases;

namespace api.service.vm.application.features;

public class DetalleCitaHandler : IDetalleCitaHandler
{
    private readonly Mappings _mapper;
    private readonly IDetalleCitaContext _context;

    public DetalleCitaHandler(IDetalleCitaContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<DetalleCitaResponseDto>> GetAll()
    {
        var detalles = await _context.GetAllAsync();
        return _mapper.ToResponseDto(detalles);
    }

    public async Task<List<DetalleCitaResponseDto>> GetByCitaId(int idCita)
    {
        var detalles = await _context.GetByCitaIdAsync(idCita);
        return _mapper.ToResponseDto(detalles);
    }

    public async Task<DetalleCitaResponseDto?> GetById(int id)
    {
        var detalle = await _context.GetByIdAsync(id);
        return detalle == null ? null : _mapper.ToResponseDto(detalle);
    }

    public async Task<DetalleCitaResponseDto> Insert(DetalleCitaRequestDto detalleRequest)
    { 
        var detalle = _mapper.ToEntity(detalleRequest);
        var detalleGuardado = await _context.InsertAsync(detalle);
        return _mapper.ToResponseDto(detalleGuardado);
    }

    public async Task<(bool, string?)> UpdateAsync(DetalleCitaRequestDto detalleRequest, int id)
    { 
        var detalle = _mapper.ToEntity(detalleRequest);
        
        // Sincronizamos con el ID de la llave primaria de DetalleCita
        detalle.IdDetalle = id;
        
        var result = await _context.UpdateAsync(detalle);
        return result;
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    { 
        var result = await _context.Delete(id, softDelete);
        return result;
    }
}