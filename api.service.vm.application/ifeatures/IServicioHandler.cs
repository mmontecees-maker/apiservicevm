using api.service.vm.application.commons.dtos;

namespace api.service.vm.application.ifeatures;

public interface IServicioHandler
{
    Task<List<ServicioResponseDto>> GetAll();
    Task<ServicioResponseDto?> GetById(int id);
    Task<ServicioResponseDto> Insert(ServicioRequestDto servicioRequest);
    Task<(bool, string?)> UpdateAsync(ServicioRequestDto servicioRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}