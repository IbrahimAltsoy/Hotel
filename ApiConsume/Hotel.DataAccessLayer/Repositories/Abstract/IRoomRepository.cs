using Hotel.EntitiyLayer.Concreate;

namespace Hotel.DataAccessLayer.Repositories.Abstract
{
    public interface IRoomRepository:IRepository<Room>
    {
        int RoomCount();
    }
}
