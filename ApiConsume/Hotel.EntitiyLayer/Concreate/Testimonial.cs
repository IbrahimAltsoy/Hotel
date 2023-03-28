using Hotel.EntitiyLayer.Abstract;

namespace Hotel.EntitiyLayer.Concreate
{
	public class Testimonial:IEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public bool IsActive { get; set; } = false;
	}
}
