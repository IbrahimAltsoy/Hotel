using Hotel.EntitiyLayer.Concreate;

namespace Hotel.WebUI.Dtos.WorkLocationDto
{
    public class CreateWorkLocationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }

        public bool IsActive { get; set; }
        
    }
}
