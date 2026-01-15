using api.service.vm.application.commons.dtos;
using api.service.vm.application.commons.mappings;
using api.service.vm.application.ifeatures;
using api.service.vm.application.interfaces;
using api.service.vm.domain.clases;

namespace api.service.vm.application.features;

public class ServicioHandler : IServicioHandler
{
    private readonly Mappings _mapper;
    private readonly IServicioContext _context;

    public ServicioHandler(IServicioContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<ServicioResponseDto>> GetAll()
    {
        var servicios = await _context.GetAllAsync();
        return _mapper.ToResponseDto(servicios);
    }

    public async Task<ServicioResponseDto?> GetById(int id)
    {
        var servicio = await _context.GetByIdAsync(id);
        return servicio == null ? null : _mapper.ToResponseDto(servicio);
    }

    public async Task<ServicioResponseDto> Insert(ServicioRequestDto servicioRequest)
    { 
        // Convertimos el DTO de entrada a la Entidad Servicio
        var servicio = _mapper.ToEntity(servicioRequest);
        
        var servicioGuardado = await _context.InsertAsync(servicio);
        
        // Retornamos el DTO de respuesta procesado
        return _mapper.ToResponseDto(servicioGuardado);
    }

    public async Task<(bool, string?)> UpdateAsync(ServicioRequestDto servicioRequest, int id)
    { 
        var servicio = _mapper.ToEntity(servicioRequest);

        // Importante: Asignar el ID de la entidad basándose en el parámetro de la ruta
        servicio.IdServicio = id;
        
        var result = await _context.UpdateAsync(servicio);

        return result;
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    { 
        // Llamada al contexto de infraestructura para borrado lógico o físico
        var result = await _context.Delete(id, softDelete);

        return result;
    }
}