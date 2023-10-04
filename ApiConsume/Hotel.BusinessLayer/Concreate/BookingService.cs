using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.EntitiyLayer.Concreate;
using System;

namespace Hotel.BusinessLayer.Concreate
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;
        public BookingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Booking> BookingStatusChangeApproved(Guid id)
        {
            var value = _context.Bookings.Where(x => x.Id == id).FirstOrDefault();
            if (value is not null)
            {
                value.Status = "Onaylandı";
            }
            await _context.SaveChangesAsync();
            return value; 
        }
        
    }
}
