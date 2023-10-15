using Hotel.EntitiyLayer.Concreate;

namespace Hotel.BusinessLayer.Abstract
{
    public interface ICategoryMessageService
    {
        Task<List<CategoryMessage>> GetAllCategoryMessage();
    }
}
