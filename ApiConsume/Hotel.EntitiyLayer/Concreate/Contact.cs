using Hotel.EntitiyLayer.Abstract;

namespace Hotel.EntitiyLayer.Concreate
{
    public class Contact:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
