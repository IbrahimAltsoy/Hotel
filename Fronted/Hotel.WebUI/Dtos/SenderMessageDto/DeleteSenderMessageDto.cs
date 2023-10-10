namespace Hotel.WebUI.Dtos.SenderMessageDto
{
    public class DeleteSenderMessageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
