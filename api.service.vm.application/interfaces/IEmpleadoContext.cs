using api.service.vm.domain.clases;

namespace api.service.vm.application.interfaces;

public interface IEmpleadoContext : IContextGeneral<Empleado>
{
    Task<List<Empleado>> GetAllAsync();
    Task<Empleado?> GetByIdAsync(int id);
    Task<Empleado> InsertAsync(Empleado empleado);
    Task<(bool, string?)> UpdateAsync(Empleado empleado);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}