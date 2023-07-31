using BurgerApp.Mappers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Abstraction
{
    public interface IBurgerService
    {
        List<BurgerViewModel> GetBurgersFromDropDown();
        string GetBurgerNameOnPromotion();
    }
}
