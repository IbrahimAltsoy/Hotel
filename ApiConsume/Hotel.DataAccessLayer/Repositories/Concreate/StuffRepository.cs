using Hotel.DataAccessLayer.Repositories.Abstract;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccessLayer.Repositories.Concreate
{
    public class StuffRepository : Repository<Stuff>, IStuffRepository
    {
        private readonly AppDbContext _context;

        //public StuffRepository(AppContext appContext)
        //{
        //    this.appContext = appContext;
        //}

        public StuffRepository(AppDbContext _dbContext, AppDbContext context) : base(_dbContext)
        {
            this._context = context;
        }
        public int StuffCount ()
        {
            using var  context= new AppDbContext();
            
            return context.Stuffs.Count();
        }
        public async Task<List<Stuff>> StuffLastFour()
        {
            return await _context.Stuffs.Take(4).ToListAsync();
        }
    }
}
