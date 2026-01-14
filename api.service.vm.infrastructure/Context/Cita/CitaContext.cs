using api.service.vm.domain.clases;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.infrastructure.context.cita;

public class CitaContext : ContextGeneral<Cita>, ICitaContext
{
    private readonly ProyectoBDContext _context;

    public CitaContext(ProyectoBDContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Cita>> GetAllAsync()
    {
        // Traemos las citas incluyendo la información del cliente y empleado
        return await _context.Citas
            .Include(c => c.IdClienteNavigation)
            .Include(c => c.IdEmpleadoNavigation)
            .Where(c => c.Activo == true)
            .ToListAsync();
    }

    public async Task<Cita?> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.IdClienteNavigation)
            .Include(c => c.IdEmpleadoNavigation)
            .FirstOrDefaultAsync(c => c.IdCita == id);
    }

    public async Task<Cita> InsertAsync(Cita cita)
    {
        return await Add(cita); // Método de ContextGeneral
    }

    public async Task<(bool, string?)> UpdateAsync(Cita cita)
    {
        try
        {
            _context.Citas.Update(cita);
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
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return (false, "Cita no encontrada");

            if (softDelete)
            {
                cita.Activo = false;
                _context.Citas.Update(cita);
            }
            else
            {
                _context.Citas.Remove(cita);
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