using BookStore.Service.Data;
using Microsoft.AspNetCore.Mvc;
using BookStore.Service.Models;
using BookStore.Service.Core;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
	public class CategoryController: Controller
	{
		private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
			_categoryService = categoryService;
        }

        public IActionResult Index()
		{

			var models = _categoryService.GetAll();
			return View(models);
		}

		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Edit(int id)
		{
			var model =_categoryService.GetById(id);

			return View(model);
		}

		public IActionResult Save(Category model)
        {
			if(ModelState.IsValid)
			{
				_categoryService.Save(model);
				TempData["succes"] = "Bilgiler Kaydedildi.";

                return RedirectToAction("Index");
            }
			TempData["error"] = "Hata Oluştu.";
			return View("Create",model);
			
        }
		public IActionResult Delete(int id) 
		{
			try 
			{_categoryService.Delete(id);
			}
			catch(Exception ) 
			{TempData["error"]="Bir Hata Oluştu";
				return RedirectToAction("Index");
			}
			
			TempData["succes"] = "Kayıt Silindi";
			return RedirectToAction("Index");
		}

    }
}
