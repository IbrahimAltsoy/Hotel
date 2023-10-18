using Hotel.EntitiyLayer.Concreate;

namespace Hotel.BusinessLayer.Abstract
{
    public interface IAppUserService
    {
        Task<List<AppUser>> UserListWithWorkLocation();
        int AppUserCount();
        //Task<List<AppRole>> GetAllRolesAsync();
        //Task<List<AppUser>> GetUsers();
    }
}
