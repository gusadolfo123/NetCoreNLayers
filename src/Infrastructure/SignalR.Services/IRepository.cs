namespace SignalR.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Repositorio Generico Para Manejo de Acceso a Datos
    /// </summary>
    /// <typeparam name="T">Tipo de entidad a la cual realizar las operaciones</typeparam>
    public interface IRepository<T>: IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T Add(T entity);
        bool Delete(int id);
        bool Update(T entity);
        Task<IEnumerable<T>> GetByFilter(Entities.QueryParameters<T> queryParameters);
        int SaveChanges();
    }
}