using BurgerApp.Domain.Models;
using BurgerApp.Mappers.Extensions;
using BurgerApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    public class BurgerService : IBurgerService
    {
        private IBurgerRepository _burgerRepository;

        public BurgerService (IBurgerRepository burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public string GetBurgerNameOnPromotion()
        {
            return _burgerRepository.GetBurgerOnPromotion().Name;
        }

        public List<BurgerViewModel> GetBurgersFromDropDown()
        {
            List<Burger> burgerDb = _burgerRepository.GetAll();
            return burgerDb.Select(x => x.MapToBurgerViewModel()).ToList();
        }
    }
}
