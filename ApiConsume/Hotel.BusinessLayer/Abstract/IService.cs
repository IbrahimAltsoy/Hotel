using Hotel.DataAccessLayer.Repositories.Abstract;
using Hotel.EntitiyLayer.Abstract;

namespace Hotel.BusinessLayer.Abstract
{
	public interface IService<T> : IRepository<T> where T : class, IEntity, new()
	{

	}
}
