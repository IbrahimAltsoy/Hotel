using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.DataAccessLayer.Repositories.Concreate;

namespace Hotel.BusinessLayer.Concreate
{
    public class StuffService : StuffRepository, IStuffService
    {
        public StuffService(AppDbContext _dbContext, AppDbContext context) : base(_dbContext, context)
        {
        }
    }
}
