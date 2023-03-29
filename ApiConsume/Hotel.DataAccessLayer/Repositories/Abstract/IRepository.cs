using System.Linq.Expressions;

namespace Hotel.DataAccessLayer.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
		Task<List<T>> GetAllIsActiveTrueAsync();
		Task<List<T>> GetAllIsActiveFalseAsync();
		Task<T> GetByIdAsync(Guid id);
		Task<int> AddAsync(T entitiy);
		Task<int> SafeDeletedAsync(T entity);
		Task UpdateAsync(T entity);
		Task CompletelyDeletedAsync(Guid id);
	}
}
