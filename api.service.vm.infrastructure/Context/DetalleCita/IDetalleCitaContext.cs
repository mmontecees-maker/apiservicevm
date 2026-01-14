using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.context.detallecita;

public interface IDetalleCitaContext : IContextGeneral<DetalleCita>
{
    Task<List<DetalleCita>> GetAllAsync();
    Task<List<DetalleCita>> GetByCitaIdAsync(int idCita);
    Task<DetalleCita?> GetByIdAsync(int id);
    Task<DetalleCita> InsertAsync(DetalleCita detalle);
    Task<(bool, string?)> UpdateAsync(DetalleCita detalle);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}