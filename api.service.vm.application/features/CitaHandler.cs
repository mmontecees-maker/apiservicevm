using api.service.vm.application.commons.dtos;
using api.service.vm.application.commons.mappings;
using api.service.vm.application.ifeatures;
using api.service.vm.infrastructure.context.cita;
using api.service.vm.domain.clases;

namespace api.service.vm.application.features;

public class CitaHandler : ICitaHandler
{
    private readonly Mappings _mapper;
    private readonly ICitaContext _context;

    public CitaHandler(ICitaContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<CitaResponseDto>> GetAll()
    {
        var citas = await _context.GetAllAsync();
        return _mapper.ToResponseDto(citas);
    }

    public async Task<CitaResponseDto?> GetById(int id)
    {
        var cita = await _context.GetByIdAsync(id);
        return cita == null ? null : _mapper.ToResponseDto(cita);
    }

    public async Task<CitaResponseDto> Insert(CitaRequestDto citaRequest)
    { 
        // Convertimos el Request a la Entidad Cita
        var cita = _mapper.ToEntity(citaRequest);
        
        // Guardamos en la base de datos
        var citaGuardada = await _context.InsertAsync(cita);
        
        // Retornamos el ResponseDto
        return _mapper.ToResponseDto(citaGuardada);
    }

    public async Task<(bool, string?)> UpdateAsync(CitaRequestDto citaRequest, int id)
    { 
        var cita = _mapper.ToEntity(citaRequest);

        // Asignamos el ID de la ruta a la entidad para asegurar la actualización correcta
        cita.IdCita = id;
        
        var result = await _context.UpdateAsync(cita);

        return result;
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    { 
        var result = await _context.Delete(id, softDelete);

        return result;
    }
}