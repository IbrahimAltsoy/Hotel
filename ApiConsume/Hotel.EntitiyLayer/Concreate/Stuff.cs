using Hotel.EntitiyLayer.Abstract;

namespace Hotel.EntitiyLayer.Concreate
{
	public class Stuff:IEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string LinkedinUrl { get; set; }
		public string TwitterUrl { get; set; }
		public string InstagramUrl { get; set; }
		public bool IsActive { get; set; } = false;
	}
}
//[Guid("701F4FA5-B90C-4060-9979-8368A4F3A424")] [Guid("381A22D1-F126-47C8-AA92-4FA1EA984BE9")]