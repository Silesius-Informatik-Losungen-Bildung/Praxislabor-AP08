namespace StempelAppCore.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}