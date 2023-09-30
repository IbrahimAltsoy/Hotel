using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.DataAccessLayer.Repositories.Concreate;
using Hotel.EntitiyLayer.Abstract;

namespace Hotel.BusinessLayer.Concreate
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
	{
		public Service(AppDbContext _context) : base(_context)
		{

		}
	}
}
