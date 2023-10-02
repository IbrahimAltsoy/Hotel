namespace Hotel.WebUI.Dtos.Subscribe
{
    public class DeleteSubscribeDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
