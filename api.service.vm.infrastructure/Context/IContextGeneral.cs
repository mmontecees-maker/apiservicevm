namespace api.service.vm.domain.interfaces;


public interface IContextGeneral<T> where T : class
{
    // Obtener todos los registros de la tabla
    Task<List<T>> GetAll();

    // Buscar un registro específico por su ID primaria
    Task<T?> GetById(int id);

    // Insertar un nuevo registro
    Task<T> Add(T entity);

    // Actualizar un registro existente
    Task Update(T entity);

    // Eliminar un registro de la base de datos
    Task Delete(T entity);
}