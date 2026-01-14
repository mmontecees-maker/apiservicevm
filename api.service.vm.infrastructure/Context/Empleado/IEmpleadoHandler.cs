using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.context.empleado;

public interface IEmpleadoContext : IContextGeneral<Empleado>
{
    Task<List<Empleado>> GetAllAsync();
    Task<Empleado?> GetByIdAsync(int id);
    Task<Empleado> InsertAsync(Empleado empleado);
    Task<(bool, string?)> UpdateAsync(Empleado empleado);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}