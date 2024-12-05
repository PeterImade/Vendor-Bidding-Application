using Microsoft.EntityFrameworkCore;
using Vendor_Bidding_Application.Contracts;
using Vendor_Bidding_Application.Data;

namespace Vendor_Bidding_Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync(); 
        }

        public async Task<T> GetAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
