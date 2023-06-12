using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using BookStore.Service.Models;
using Azure;
using BookStore.Service.DTO;

namespace BookStore.Controllers
{
    public class ControllerBase : Controller
    {
        private string _controller;
        private string _action;

        #region Session

        public SessionInfo CurrentSession
        {
            get
            {
                var value = HttpContext.Session.GetString("UserSessionInfo");
                return value == null ? default(SessionInfo) : JsonConvert.DeserializeObject<SessionInfo>(value);
            }
        }

        #endregion Session

        public void SetCurrentSession(SessionInfo value)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            var jsonString = JsonConvert.SerializeObject(value);
            HttpContext.Session.SetString("UserSessionInfo", jsonString);
        }

        public bool IsSessionAlive
        {
            get
            {
                return CurrentSession != null;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsSessionAlive == false)
            {
                filterContext.Result = RedirectToLoginPage();
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        protected IActionResult RedirectToLoginPage(string redirectAction = "Index")
        {
            return RedirectToAction("Index", "Login", new { redirectAction = redirectAction });
        }
    }
}
