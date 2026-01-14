using api.service.vm.application.commons.dtos;

namespace api.service.vm.application.ifeatures;

public interface IEmpleadoHandler
{
    Task<List<EmpleadoResponseDto>> GetAll();
    Task<EmpleadoResponseDto?> GetById(int id);
    Task<EmpleadoResponseDto> Insert(EmpleadoRequestDto empleadoRequest);
    Task<(bool, string?)> UpdateAsync(EmpleadoRequestDto empleadoRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}