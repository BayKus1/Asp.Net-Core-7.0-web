using BookStore.Service.Data;
using Microsoft.AspNetCore.Mvc;
using BookStore.Service.Models;
using BookStore.Service.Core;
using Microsoft.EntityFrameworkCore;
using BookStore.Service.DTO;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
	public class BookController: ControllerBase
	{
		private readonly BookService _BookService;
        

        public BookController(BookService BookService)
        {
			_BookService = BookService;
        }

       

        public IActionResult Index()
		{

			var models = _BookService.GetAll();
			return View(models);
		}

		public IActionResult Create()
		{
			var createViewModel =_BookService.GetCreateViewModel();
			return View(createViewModel);
		}
		public IActionResult Edit(int id)
		{
			var editModel =_BookService.GetEditViewModel(id);

			return View(editModel);
		}

        [HttpPost]
        public IActionResult Edit(BookDTO viewmodel)
        {


            if (ModelState.IsValid)
            {
                _BookService.Save(viewmodel);
                TempData["succes"] = "Bilgiler Kaydedildi.";

                return RedirectToAction("Index");
            }
            TempData["error"] = "Hata Oluştu.";
            return View("Edit", viewmodel);

        }

        [HttpPost]
		public IActionResult Create(BookDTO viewmodel)
        {
            DateTimeOffset utcDateTimeOffset = DateTimeOffset.UtcNow;

            viewmodel.CreateDate = utcDateTimeOffset;


            if (ModelState.IsValid)
			{
				_BookService.Save(viewmodel);
				TempData["succes"] = "Bilgiler Kaydedildi.";

                return RedirectToAction("Index");
            }
			TempData["error"] = "Hata Oluştu.";
			return View("Edit", viewmodel);
			
        }
		public IActionResult Delete(int id) 
		{
			try 
			{_BookService.Delete(id);
			}
			catch(Exception) 
			{TempData["error"]="Bir Hata Oluştu";
				return RedirectToAction("Index");
			}
			
			TempData["succes"] = "Kayıt Silindi";
			return RedirectToAction("Index");
		}

    }
}
