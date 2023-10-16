using Hotel.EntitiyLayer.Concreate;

namespace Hotel.DtoLayer.Dtos.WorkLocationDto
{
    public class UpdateWorkLocationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }

        public bool IsActive { get; set; }
        public List<AppUser>? AppUsers { get; }
    }
}
