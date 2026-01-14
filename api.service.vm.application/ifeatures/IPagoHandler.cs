using api.service.vm.application.commons.dtos;

namespace api.service.vm.application.ifeatures;

public interface IPagoHandler
{
    Task<List<PagoResponseDto>> GetAll();
    Task<PagoResponseDto?> GetById(int id);
    Task<PagoResponseDto> Insert(PagoRequestDto pagoRequest);
    Task<(bool, string?)> UpdateAsync(PagoRequestDto pagoRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}