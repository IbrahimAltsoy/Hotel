using Hotel.DataAccessLayer.Repositories.Abstract;
using Hotel.EntitiyLayer.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccessLayer.Repositories.Concreate
{
	public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
		private readonly DbContext _context;

		public Repository(DbContext _dbContext)
		{
			this._context = _dbContext;
		}
		private DbSet<T> Table { get => _context.Set<T>(); }
		public async Task<List<T>> GetAllIsActiveTrueAsync()
		{
			var models = await _context.Set<T>().Where(x=>x.IsActive).ToListAsync();				
			return models;
		}
		public async Task<List<T>> GetAllIsActiveFalseAsync()
		{
			var models = await _context.Set<T>().Where(x => !x.IsActive).ToListAsync();
			return models;
		}
		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);				
		}
		public async Task<int> AddAsync(T entitiy)
		{
			await _context.Set<T>().AddAsync(entitiy);
			return _context.SaveChanges();

		}

		public async Task<int> SafeDeletedAsync(T entity)
		{
			var stuff1 = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
			if (stuff1.IsActive)
			{
				stuff1.IsActive = false;

			}
			else
			{
				stuff1.IsActive = true;
			}
			_context.Set<T>().Update(stuff1);
			return _context.SaveChanges();

		}
		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}
		public async Task CompletelyDeletedAsync(Guid id)
		{
			var model = await _context.Set<T>().FirstOrDefaultAsync<T>(x=>x.Id==id);
			_context.Set<T>().Remove(model);
			await _context.SaveChangesAsync();

		}
	}
}
