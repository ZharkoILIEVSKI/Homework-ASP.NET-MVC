using BurgerApp.Domain.Models;
using BurgerApp.Mappers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks; 

    public static class BurgerMapper
    {
        public static BurgerViewModel MapToBurgerViewModel(this Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                BurgerName = burger.Name,
                Price = burger.Price,
            };
        }
    };
