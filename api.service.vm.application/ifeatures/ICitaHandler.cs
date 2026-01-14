using api.service.vm.application.commons.dtos;

namespace api.service.vm.application.ifeatures;

public interface ICitaHandler
{
    Task<List<CitaResponseDto>> GetAll();
    Task<CitaResponseDto?> GetById(int id);
    Task<CitaResponseDto> Insert(CitaRequestDto citaRequest);
    Task<(bool, string?)> UpdateAsync(CitaRequestDto citaRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}