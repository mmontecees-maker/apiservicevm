using api.service.vm.domain.clases;
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.context.cliente;

public interface IClienteContext : IContextGeneral<Cliente>
{
    // Métodos específicos que tu Handler está llamando
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task<Cliente> InsertAsync(Cliente cliente);
    Task<(bool, string?)> UpdateAsync(Cliente cliente);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}