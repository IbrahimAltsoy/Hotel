using Hotel.EntitiyLayer.Concreate;

namespace Hotel.DataAccessLayer.Repositories.Abstract
{
    public interface IStuffRepository:IRepository<Stuff>
    {
        int StuffCount();
        Task<List<Stuff>> StuffLastFour();
    }
}
