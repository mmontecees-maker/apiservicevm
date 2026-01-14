using api.service.vm.domain.clases;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.infrastructure.context.pago;

public class PagoContext : ContextGeneral<Pago>, IPagoContext
{
    private readonly ProyectoBDContext _context;

    public PagoContext(ProyectoBDContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Pago>> GetAllAsync()
    {
        // Incluimos la navegación a la cita para reportes o consultas
        return await _context.Pagos
            .Include(p => p.IdCitaNavigation)
            .Where(p => p.Activo == true)
            .ToListAsync();
    }

    public async Task<Pago?> GetByIdAsync(int id)
    {
        return await _context.Pagos
            .Include(p => p.IdCitaNavigation)
            .FirstOrDefaultAsync(p => p.IdPago == id);
    }

    public async Task<Pago> InsertAsync(Pago pago)
    {
        // Aseguramos que la fecha se asigne si viene nula (aunque la DB tiene default)
        if (pago.FechaPago == null) pago.FechaPago = DateTime.Now;
        
        return await Add(pago);
    }

    public async Task<(bool, string?)> UpdateAsync(Pago pago)
    {
        try
        {
            _context.Pagos.Update(pago);
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
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null) return (false, "Registro de pago no encontrado");

            if (softDelete)
            {
                pago.Activo = false;
                _context.Pagos.Update(pago);
            }
            else
            {
                _context.Pagos.Remove(pago);
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