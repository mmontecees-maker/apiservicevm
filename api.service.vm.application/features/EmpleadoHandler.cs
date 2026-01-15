using api.service.vm.application.commons.dtos;
using api.service.vm.application.commons.mappings;
using api.service.vm.application.ifeatures;
using api.service.vm.application.interfaces;
using api.service.vm.domain.clases;

namespace api.service.vm.application.features;

public class EmpleadoHandler : IEmpleadoHandler
{
    private readonly Mappings _mapper;
    private readonly IEmpleadoContext _context;

    public EmpleadoHandler(IEmpleadoContext context)
    {
        // Instanciamos el Mapper generado por Mapperly
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<EmpleadoResponseDto>> GetAll()
    {
        var empleados = await _context.GetAllAsync();
        return _mapper.ToResponseDto(empleados);
    }

    public async Task<EmpleadoResponseDto?> GetById(int id)
    {
        var empleado = await _context.GetByIdAsync(id);
        return empleado == null ? null : _mapper.ToResponseDto(empleado);
    }

    public async Task<EmpleadoResponseDto> Insert(EmpleadoRequestDto empleadoRequest)
    { 
        // Convertimos el DTO de entrada a la Entidad de Dominio
        var empleado = _mapper.ToEntity(empleadoRequest);
        
        var empleadoGuardado = await _context.InsertAsync(empleado);
        
        // Retornamos el DTO de respuesta
        return _mapper.ToResponseDto(empleadoGuardado);
    }

    public async Task<(bool, string?)> UpdateAsync(EmpleadoRequestDto empleadoRequest, int id)
    { 
        var empleado = _mapper.ToEntity(empleadoRequest);

        // Asignamos el ID que viene de la URL (Ruta)
        empleado.IdEmpleado = id;
        
        var result = await _context.UpdateAsync(empleado);

        return result;
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    { 
        var result = await _context.Delete(id, softDelete);

        return result;
    }
}