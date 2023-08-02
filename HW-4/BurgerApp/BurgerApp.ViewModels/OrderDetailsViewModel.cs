using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public User FullName { get; set; }
        public bool IsDelivered { get; set; }

        public string Location { get; set; }

        public List<string> BurgerNames { get; set; }
    }
}
