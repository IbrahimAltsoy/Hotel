namespace Hotel.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserWithWorkLocationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string WorkLocationName { get; set; }
        public string ImageUrl { get; set; }
        public Guid WorkLocationId { get; set; }
    }
}
