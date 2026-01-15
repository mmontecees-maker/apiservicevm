using api.service.vm.domain.clases;

namespace api.service.vm.application.interfaces;

public interface IServicioContext : IContextGeneral<Servicio>
{
    Task<List<Servicio>> GetAllAsync();
    Task<Servicio?> GetByIdAsync(int id);
    Task<Servicio> InsertAsync(Servicio servicio);
    Task<(bool, string?)> UpdateAsync(Servicio servicio);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}