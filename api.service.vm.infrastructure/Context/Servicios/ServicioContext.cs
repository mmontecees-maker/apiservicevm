using api.service.vm.domain.clases;
using api.service.vm.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.infrastructure.context.servicio;

public class ServicioContext : ContextGeneral<Servicio>, IServicioContext
{
    private readonly ProyectoBDContext _context;

    public ServicioContext(ProyectoBDContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Servicio>> GetAllAsync()
    {
        // Traemos los servicios que están activos en el catálogo
        return await _context.Servicios
            .Where(s => s.Activo == true)
            .ToListAsync();
    }

    public async Task<Servicio?> GetByIdAsync(int id)
    {
        // Buscamos por la llave primaria IdServicio
        return await GetById(id); 
    }

    public async Task<Servicio> InsertAsync(Servicio servicio)
    {
        return await Add(servicio);
    }

    public async Task<(bool, string?)> UpdateAsync(Servicio servicio)
    {
        try
        {
            _context.Servicios.Update(servicio);
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
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null) return (false, "Servicio no encontrado");

            if (softDelete)
            {
                // Desactivamos el servicio en lugar de borrarlo para no romper 
                // el histórico de DetalleCita
                servicio.Activo = false;
                _context.Servicios.Update(servicio);
            }
            else
            {
                _context.Servicios.Remove(servicio);
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