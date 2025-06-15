namespace Lab13_RamiroSuico.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
        Task<T?> GetByIdAsync(object id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}