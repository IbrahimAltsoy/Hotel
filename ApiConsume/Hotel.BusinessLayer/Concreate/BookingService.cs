using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.DataAccessLayer.Repositories.Concreate;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hotel.BusinessLayer.Concreate
{
    public class BookingService : BookingRepository, IBookingService
    {
        public BookingService(AppDbContext _dbContext, AppDbContext context) : base(_dbContext, context)
        {
        }
    }
}
