using Hotel.EntitiyLayer.Abstract;
using System.Runtime.InteropServices;

namespace Hotel.EntitiyLayer.Concreate
{
    public class WorkLocation:IEntity
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }

        public bool IsActive { get; set; }
        public List<AppUser>? AppUsers { get;}
    }
}
