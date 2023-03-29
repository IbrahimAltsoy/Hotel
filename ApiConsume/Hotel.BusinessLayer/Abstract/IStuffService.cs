using Hotel.EntitiyLayer.Concreate;

namespace Hotel.BusinessLayer.Abstract
{
	public interface IStuffService
	{
		Task<List<Stuff>> GetAllAsync();
		Task<int> AddStuffAsync(Stuff stuff);
		Task<Stuff> GetByIdAsync(Guid id);
		Task<int> SafeDeletedStuff(Stuff stuff);
		Task<List<Stuff>> GetAllDeletedAsync();
		Task UpdateStaffAsync(Stuff stuff);
	}
}
