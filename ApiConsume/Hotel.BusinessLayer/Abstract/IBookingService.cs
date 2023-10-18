using Hotel.EntitiyLayer.Concreate;

namespace Hotel.BusinessLayer.Abstract
{
    public interface IBookingService
    {

        Task<Booking> BookingStatusChangeApproved(Guid id);
        int GetBookingCount();

    }
}
