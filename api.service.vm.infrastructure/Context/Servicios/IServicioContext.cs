using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.context.servicio;

public interface IServicioContext : IContextGeneral<Servicio>
{
    Task<List<Servicio>> GetAllAsync();
    Task<Servicio?> GetByIdAsync(int id);
    Task<Servicio> InsertAsync(Servicio servicio);
    Task<(bool, string?)> UpdateAsync(Servicio servicio);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}