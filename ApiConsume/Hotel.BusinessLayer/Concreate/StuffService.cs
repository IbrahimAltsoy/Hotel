using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer.Context;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hotel.BusinessLayer.Concreate
{
	public class StuffService: IStuffService
	{
		private readonly Context _context;

		public StuffService(Context context)
		{
			_context= context;
		}
		public async Task<List<Stuff>> GetAllAsync()
		{
			var models = await _context.Stuffs.Where(x=>x.IsActive).ToListAsync();
			return models;
		}
		public async Task<List<Stuff>> GetAllDeletedAsync()
		{
			var models = await _context.Stuffs.Where(x => !x.IsActive).ToListAsync();
			return models;
		}
		public async Task<Stuff> GetByIdAsync(Guid id)
		{
			return await _context.Stuffs.FirstOrDefaultAsync(x => x.Id == id);
		}
		public async Task<int> AddStuffAsync(Stuff stuff)
		{			
			await _context.Stuffs.AddAsync(stuff);
			return _context.SaveChanges();
			
		}
		
		public async Task<int> SafeDeletedStuff(Stuff stuff)
		{
			var stuff1 = await _context.Stuffs.FirstOrDefaultAsync(x => x.Id == stuff.Id);
			if (stuff1.IsActive)
			{				
				stuff1.IsActive = false;
				
			}
			else
			{
				stuff1.IsActive = true;				
			}
			_context.Stuffs.Update(stuff1);
			return _context.SaveChanges();

		}
		public async Task UpdateStaffAsync(Stuff stuff)
		{
			 _context.Stuffs.Update(stuff);
			await _context.SaveChangesAsync();
		}
		//public void Update(T entity)
		//{
		//	context.Update(entity);
		//}


		//public int Add(T entity)
		//{
		//	dbSet.Add(entity);
		//	return SaveChanges();
		//}

		//public async Task AddAsync(T entity)
		//{
		//	await context.AddAsync(entity);
		//}
	}
}
