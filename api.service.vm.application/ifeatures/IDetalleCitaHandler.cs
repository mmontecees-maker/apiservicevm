using api.service.vm.application.commons.dtos;

namespace api.service.vm.application.ifeatures;

public interface IDetalleCitaHandler
{
    Task<List<DetalleCitaResponseDto>> GetAll();
    Task<List<DetalleCitaResponseDto>> GetByCitaId(int idCita);
    Task<DetalleCitaResponseDto?> GetById(int id);
    Task<DetalleCitaResponseDto> Insert(DetalleCitaRequestDto detalleRequest);
    Task<(bool, string?)> UpdateAsync(DetalleCitaRequestDto detalleRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}