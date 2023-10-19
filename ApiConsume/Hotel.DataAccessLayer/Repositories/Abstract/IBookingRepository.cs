using Hotel.EntitiyLayer.Concreate;

namespace Hotel.DataAccessLayer.Repositories.Abstract
{
    public interface IBookingRepository:IRepository<Booking>
    {
        Task<Booking> BookingStatusChangeApproved(Guid id);
        int GetBookingCount();
        List<Booking> BookingSixtList();
    }
}
