using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels
{
    public class BurgerOrderViewModel
    {
        public int Id { get; set; } 
        public int OrderId { get; set;}
        public Burger burger { get; set; }
    }
}
