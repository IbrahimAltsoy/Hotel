namespace Hotel.WebUI.Dtos.UINewsLetterStart
{
    public class Create_SubscribeDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
