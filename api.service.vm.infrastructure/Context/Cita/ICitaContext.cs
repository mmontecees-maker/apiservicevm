using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.context.cita;

public interface ICitaContext : IContextGeneral<Cita>
{
    Task<List<Cita>> GetAllAsync();
    Task<Cita?> GetByIdAsync(int id);
    Task<Cita> InsertAsync(Cita cita);
    Task<(bool, string?)> UpdateAsync(Cita cita);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}