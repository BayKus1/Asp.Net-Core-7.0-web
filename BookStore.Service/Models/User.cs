﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
