using Hotel.EntitiyLayer.Abstract;

namespace Hotel.EntitiyLayer.Concreate
{
	public class Subscribe : IEntity
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }=false;
	}
}
