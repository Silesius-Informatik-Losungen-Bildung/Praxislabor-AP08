using Microsoft.EntityFrameworkCore;
using StempelAppCore.Data;
using StempelAppCore.Models.Interfaces;

namespace StempelAppCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StempelAppContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(StempelAppContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
