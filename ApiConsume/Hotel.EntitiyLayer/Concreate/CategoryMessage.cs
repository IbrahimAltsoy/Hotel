using Hotel.EntitiyLayer.Abstract;

namespace Hotel.EntitiyLayer.Concreate
{
    public class CategoryMessage : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = false;
        public List<Contact> Contacts { get; set; }
    }
}
