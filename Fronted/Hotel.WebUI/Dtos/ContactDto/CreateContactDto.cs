﻿namespace Hotel.WebUI.Dtos.ContactDto
{
    public class CreateContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
