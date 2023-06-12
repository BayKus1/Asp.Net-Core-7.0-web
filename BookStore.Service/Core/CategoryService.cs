using BookStore.Service.Data;
using BookStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Core
{
	public class CategoryService
	{
		private readonly AppDbContext _db;
		public CategoryService(AppDbContext db)
		{ 
			_db = db;

		}
		public Category GetById(int id) 
		{
			return _db.Categories.First(p => p.Id == id);
		}

		public List<Category> GetAll()
		{
			var models = _db.Categories.ToList();
			return models;
		}
		public void Save(Category model) 
		{
			
			
				if (model.Id == 0)
				{
					_db.Categories.Add(model);
				}
				else
				{
					_db.Categories.Update(model);
				}
				_db.SaveChanges();

			}
		public void Delete(int id)
		{


			var model = _db.Categories.Find(id);
			if(model != null)
			{
                _db.Categories.Remove(model);
                _db.SaveChanges();
            }
			
		}
	}
}
