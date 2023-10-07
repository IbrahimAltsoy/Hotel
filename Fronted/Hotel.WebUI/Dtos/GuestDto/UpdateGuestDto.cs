namespace Hotel.WebUI.Dtos.GuestDto
{
    public class UpdateGuestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
