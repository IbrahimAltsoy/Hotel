using Hotel.DataAccessLayer.Repositories.Abstract;
using Hotel.EntitiyLayer.Concreate;

namespace Hotel.DataAccessLayer.Repositories.Concreate
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext _dbContext, AppDbContext context) : base(_dbContext)
        {
            _context = context;
        }
        public int RoomCount()
        {
            

            return _context.Rooms.Count();
        }
    }
}
