namespace Hotel.EntitiyLayer.Concreate
{
	public class Room
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public float Price { get; set; }
		public string RoomNumber { get; set; }
		public int BedCount { get; set; }
		public int BathCount { get; set; }
		public bool Wifi { get; set; }=true;
		public bool IsActive { get; set; }=false;

	}
}
