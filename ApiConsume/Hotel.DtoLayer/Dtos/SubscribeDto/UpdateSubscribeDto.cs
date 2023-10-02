namespace Hotel.DtoLayer.Dtos.SubscribeDto
{
    public class UpdateSubscribeDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
