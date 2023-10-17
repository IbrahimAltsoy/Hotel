using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Hotel.BusinessLayer.Concreate
{
    public class AppUserService:IAppUserService
    {
        private readonly AppDbContext _context;
        
        

        public AppUserService(AppDbContext _dbContext)
        {
            this._context = _dbContext;           
           

        }



        public async Task<List<AppUser>> UserListWithWorkLocation()
        {
            var model = _context.Users.Include(u => u.WorkLocation).ToList();

           
            return model;
        }

        


    }
}
