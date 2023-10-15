using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace Hotel.BusinessLayer.Concreate
{
    public class CategoryMessageService : ICategoryMessageService
    {
        private readonly AppDbContext _context;

        public CategoryMessageService(AppDbContext _dbContext)
        {
            this._context = _dbContext;
        }
        public async Task<List<CategoryMessage>> GetAllCategoryMessage()
        {
            var model = await _context.CategoryMessages.ToListAsync();
            return  model;
        }
    }
}
