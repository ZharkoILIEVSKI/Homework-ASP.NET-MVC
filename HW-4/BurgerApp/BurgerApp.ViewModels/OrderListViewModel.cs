using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels
{
    internal class OrderListViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public bool Delivered { get; set; }
        public List<string> BurgerNames { get; set; }
        public string OrderLocation { get; set; }
    }
}
