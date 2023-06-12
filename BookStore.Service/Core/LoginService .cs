using BookStore.Service.Data;
using BookStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Core
{
    public class LoginService
	{
		private readonly AppDbContext _db;
		public LoginService(AppDbContext db)
		{ 
			_db = db;

		}
		public User CheckUser(Login viewModel) 
		{
			var user = _db.Users.FirstOrDefault(p => p.UserName==viewModel.UserName && p.Password==viewModel.Password);
			return user;
		}

		
	}
}
