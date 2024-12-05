namespace Vendor_Bidding_Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
    }
}
