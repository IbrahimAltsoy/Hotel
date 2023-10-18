using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.DataAccessLayer.Repositories.Concreate;
using Hotel.EntitiyLayer.Concreate;

namespace Hotel.BusinessLayer.Concreate
{
    public class RoomService : RoomRepository, IRoomService
    {
        public RoomService(AppDbContext _dbContext, AppDbContext context) : base(_dbContext, context)
        {
        }
    }
}
