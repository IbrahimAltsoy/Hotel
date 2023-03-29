using System.Linq.Expressions;

namespace Hotel.DataAccessLayer.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
		List<T> GetAll(Expression<Func<T, bool>> expression); // Get metodunda entity frazmework x=>x. şeklinde yaptığımız lamda experesion larınını kullabilmek için 
		T Get(Expression<Func<T, bool>> expression);// Özel sorgu kullanarak 1 tane kayıt getiren metot imzası 
		T Find(int id);
		int Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		int SaveChanges();
		// Asekron metotlar
		Task<T> FindAsync(int id);
		Task<T> FirstOfDefaultAsync(Expression<Func<T, bool>> expression);
		IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression);
		Task<List<T>> GetAllAsync();
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		Task<int> SaveChangesAsync();
	}
}
