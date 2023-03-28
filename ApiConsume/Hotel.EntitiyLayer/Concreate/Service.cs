namespace Hotel.EntitiyLayer.Concreate
{
	public class Service
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public bool IsActive { get; set; } = false;
	}
}
