using Microsoft.EntityFrameworkCore;
using api.service.vm.infrastructure; // Namespace de tu ProyectoBDContext
using api.service.vm.domain.interfaces;

namespace api.service.vm.infrastructure.repositories;

public class ContextGeneral<T> : IContextGeneral<T> where T : class
{
    // Usamos tu contexto específico
    private readonly ProyectoBDContext _context;

    public ContextGeneral(ProyectoBDContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> Add(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}