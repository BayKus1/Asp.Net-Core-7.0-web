using Microsoft.AspNetCore.Mvc;
using BookStore.Service.Models;
using BookStore.Service.Core;
using BookStore.Service.DTO;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService) 
        {
            _loginService = loginService;
        }

        public SessionInfo UserSession 
        { 
            get
            {
                var value = HttpContext.Session.GetString("UserSessionInfo");
                return value == null ? default(SessionInfo) : JsonConvert.DeserializeObject<SessionInfo>(value);
            }

            set
            {
                JsonSerializerSettings jss = new JsonSerializerSettings();
                var jsonString = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString("UserSessionInfo" , jsonString);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(Login viewModel)
        {
            var user = _loginService.CheckUser(viewModel);
            if (user == null)
            {
                TempData["error"] = "Hata Oluştu!!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["succes"] = "Giriş Başarılı";
            }

            UserSession = new SessionInfo
            {
                UserId = user.Id,
                UserFullName = user.UserName
            };
            return RedirectToAction("Index","Book");

        }


    }
    }