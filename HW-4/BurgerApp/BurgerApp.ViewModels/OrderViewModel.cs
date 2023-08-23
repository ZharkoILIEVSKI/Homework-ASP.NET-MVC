using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id {get; set; }
        public string FullName { get; set; }   
        public bool IsDelivered { get; set; }
        public string Location{ get; set; }
        public int UserId { get; set; }
    }
}
