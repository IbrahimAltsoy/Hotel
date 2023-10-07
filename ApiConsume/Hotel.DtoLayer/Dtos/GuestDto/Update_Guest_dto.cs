namespace Hotel.DtoLayer.Dtos.GuestDto
{
    public class Update_Guest_dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
