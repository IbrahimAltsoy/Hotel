using Hotel.DataAccessLayer.Repositories.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccessLayer.Repositories.Concreate
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly AppDbContext _context;
        public BookingRepository(AppDbContext _dbContext, AppDbContext context) : base(_dbContext)
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
        public int GetBookingCount()
        {
            return _context.Bookings.Count();
        }

        public List<Booking> BookingSixtList()
        {
            //var model = await _context.Bookings.ToListAsync();
            return _context.Bookings.Take(4).ToList();
        }
    }
}
