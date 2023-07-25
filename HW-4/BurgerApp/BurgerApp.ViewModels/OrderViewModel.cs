using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels
{
    internal class OrderViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }   
        public bool IsDelivered { get; set; }
        public int UserId { get; set; }
    }
}
