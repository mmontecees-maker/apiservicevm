using api.service.vm.domain.clases;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.infrastructure.context.empleado;

public class EmpleadoContext : ContextGeneral<Empleado>, IEmpleadoContext
{
    private readonly ProyectoBDContext _context;

    public EmpleadoContext(ProyectoBDContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Empleado>> GetAllAsync()
    {
        return await _context.Empleados.Where(e => e.Activo == true).ToListAsync();
    }

    public async Task<Empleado?> GetByIdAsync(int id)
    {
        return await GetById(id); // Usa el método de ContextGeneral
    }

    public async Task<Empleado> InsertAsync(Empleado empleado)
    {
        return await Add(empleado); // Usa el método de ContextGeneral
    }

    public async Task<(bool, string?)> UpdateAsync(Empleado empleado)
    {
        try
        {
            _context.Empleados.Update(empleado);
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
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return (false, "Empleado no encontrado");

            if (softDelete)
            {
                empleado.Activo = false;
                _context.Empleados.Update(empleado);
            }
            else
            {
                _context.Empleados.Remove(empleado);
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