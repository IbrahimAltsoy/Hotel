using Hotel.EntitiyLayer.Concreate;

namespace Hotel.WebUI.Dtos.ContactDto
{
    public class CreateContactDto
    {
        //public Guid Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Subject { get; set; }
        //public string Message { get; set; }
        //public DateTime CreatedDate { get; set; }=DateTime.Now;
        //public bool IsActive { get; set; } = true;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid? CategoryMessageId { get; set; }
        public bool IsActive { get; set; } = false;

        //public Hotel.EntitiyLayer.Concreate.CategoryMessage? CategoryMessage { get; set; }
    }
}
