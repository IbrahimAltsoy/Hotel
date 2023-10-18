using Hotel.DataAccessLayer.Repositories.Abstract;
using Hotel.EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccessLayer.Repositories.Concreate
{
    internal class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
