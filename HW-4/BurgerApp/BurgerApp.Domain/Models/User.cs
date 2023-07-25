﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }    
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
