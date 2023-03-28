using Hotel.EntitiyLayer.Abstract;

namespace Hotel.EntitiyLayer.Concreate
{
	public class Slider:IEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public bool IsActive { get; set; } = false;
			
	}
}
