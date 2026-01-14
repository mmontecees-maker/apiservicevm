using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.context.pago;

public interface IPagoContext : IContextGeneral<Pago>
{
    Task<List<Pago>> GetAllAsync();
    Task<Pago?> GetByIdAsync(int id);
    Task<Pago> InsertAsync(Pago pago);
    Task<(bool, string?)> UpdateAsync(Pago pago);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}