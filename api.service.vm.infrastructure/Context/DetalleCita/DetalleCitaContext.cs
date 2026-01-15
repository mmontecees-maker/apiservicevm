using api.service.vm.application.interfaces;
using api.service.vm.domain.clases;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.infrastructure.Context;

public class DetalleCitaContext : ContextGeneral<DetalleCita>, IDetalleCitaContext
{
    private readonly ProyectoBDContext _context;

    public DetalleCitaContext(ProyectoBDContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<DetalleCita>> GetAllAsync()
    {
        return await _context.DetalleCita
            .Include(d => d.IdServicioNavigation)
            .Where(d => d.Activo == true)
            .ToListAsync();
    }

    public async Task<List<DetalleCita>> GetByCitaIdAsync(int idCita)
    {
        // Método útil para ver el detalle de una cita específica
        return await _context.DetalleCita
            .Include(d => d.IdServicioNavigation)
            .Where(d => d.IdCita == idCita && d.Activo == true)
            .ToListAsync();
    }

    public async Task<DetalleCita?> GetByIdAsync(int id)
    {
        return await _context.DetalleCita
            .Include(d => d.IdServicioNavigation)
            .FirstOrDefaultAsync(d => d.IdDetalle == id);
    }

    public async Task<DetalleCita> InsertAsync(DetalleCita detalle)
    {
        return await Add(detalle);
    }

    public async Task<(bool, string?)> UpdateAsync(DetalleCita detalle)
    {
        try
        {
            _context.DetalleCita.Update(detalle);
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
            var detalle = await _context.DetalleCita.FindAsync(id);
            if (detalle == null) return (false, "Detalle no encontrado");

            if (softDelete)
            {
                detalle.Activo = false;
                _context.DetalleCita.Update(detalle);
            }
            else
            {
                _context.DetalleCita.Remove(detalle);
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