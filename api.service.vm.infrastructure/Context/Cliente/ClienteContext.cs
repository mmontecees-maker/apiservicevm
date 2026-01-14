using api.service.vm.domain.clases;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.infrastructure.context.cliente;

public class ClienteContext : ContextGeneral<Cliente>, IClienteContext
{
    private readonly ProyectoBDContext _context;

    public ClienteContext(ProyectoBDContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        // Solo traemos los activos por defecto
        return await _context.Clientes.Where(c => c.Activo == true).ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await GetById(id); // Usa el método de ContextGeneral
    }

    public async Task<Cliente> InsertAsync(Cliente cliente)
    {
        return await Add(cliente); // Usa el método de ContextGeneral
    }

    public async Task<(bool, string?)> UpdateAsync(Cliente cliente)
    {
        try
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    {
        try
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return (false, "Cliente no encontrado");

            if (softDelete)
            {
                cliente.Activo = false;
                _context.Clientes.Update(cliente);
            }
            else
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}