using Microsoft.AspNetCore.Identity;

namespace Hotel.EntitiyLayer.Concreate
{
    public class AppUser: IdentityUser<Guid>
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}
