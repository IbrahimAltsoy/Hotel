using Hotel.EntitiyLayer.Concreate;

namespace Hotel.WebUI.Dtos.CategoryMessage
{
    public class UpdateCategoryMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = false;
        public List<Contact> Contacts { get; set; }
    }
}
