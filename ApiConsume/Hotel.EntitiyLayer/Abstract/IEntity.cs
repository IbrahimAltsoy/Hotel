﻿namespace Hotel.EntitiyLayer.Abstract
{
	public interface IEntity
	{
		Guid Id { get; set; }
		bool IsActive { get; set; }
	}
}
