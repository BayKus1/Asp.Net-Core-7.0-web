using BookStore.Service.Data;
using BookStore.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Core
{
	public class BookService
	{
		private readonly AppDbContext _db;
		public BookService(AppDbContext db)
		{ 
			_db = db;

		}
		public BookDTO GetCreateViewModel()
		{

			var dto = new BookDTO();
			dto.CategoryList = _db.Categories.ToList();
			return dto;
		}
		public BookDTO GetEditViewModel(int id) 
		{
			
			var model= _db.Books.First(p => p.Id == id);
			var dto = new BookDTO
			{
				Id = model.Id,
				Name = model.Name,
				Writer = model.Writer,
				CategoryId = model.CategoryId,
				Year = model.Year,

			};
           dto.CategoryList = _db.Categories.ToList();
            return dto;	
		}

		public List<BookDTO> GetAll()
		{
			var models = _db.Books.Include(p=>p.Category).ToList();
			var dtoList= new List<BookDTO>();
			foreach (var model in models)
			{
				var dto = new BookDTO
				{
					Id = model.Id,
					Name = model.Name,
					Writer = model.Writer,
					CategoryId = model.CategoryId,
					Year = model.Year,
					CategoryName=model.Category.Name,
				};
				dtoList.Add(dto);
			}
			return dtoList;
		}
		public void Save(BookDTO dto) 
		{            


            if (dto.Writer != null && dto.Name != null) {
                if (dto.Id == 0)
                {
                    var model = new Book
                    {
                        CategoryId = dto.CategoryId,
                        Name = dto.Name,
                        Writer = dto.Writer,
                        Year = dto.Year,
						CreateDate = dto.CreateDate

                    };
                    _db.Books.Add(model);
                }
                else
                {
                    var model = _db.Books.Find(dto.Id);
					if(model != null) {
                        model.Writer = dto.Writer;
                        model.CategoryId = dto.CategoryId;
                        model.Name = dto.Name;
                        model.Year = dto.Year;

                        _db.Books.Update(model);
                    }
                    
                }
                _db.SaveChanges();
            }
				

			}
		public void Delete(int id)
		{


			var model = _db.Books.Find(id);
			if(model != null) {
                _db.Books.Remove(model);
                _db.SaveChanges();
            }
			
		}
	}
}
