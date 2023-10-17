namespace Hotel.WebApi.Models
{
    public class AppUserWithWorkLocaionViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string WorkLocationName { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public Guid WorkLocationId { get; set; }
    }
}
