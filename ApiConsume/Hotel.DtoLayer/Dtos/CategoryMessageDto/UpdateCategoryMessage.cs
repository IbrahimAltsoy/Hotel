using Hotel.EntitiyLayer.Concreate;

namespace Hotel.DtoLayer.Dtos.CategoryMessageDto
{
    public class UpdateCategoryMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = false;
        public List<Contact> Contacts { get; set; }
    }
}
