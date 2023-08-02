using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Abstraction;
using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Repositories.Implementation.StaticDbImplementation
{
    public class BurgerRepository : IBurgerRepository
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetBurgerOnPromotion()
        {
            return StaticDb.Burgers.FirstOrDefault(burger => burger.IsVegetarian);
        }

        public Burger GetById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burger == null)
            {
                throw new Exception($"Burger with id {id} was not found.");
            }
            StaticDb.Burgers.Remove(burger);
        }

        public int Insert(Burger entity)
        {
            entity.Id = ++StaticDb.BurgerId;
            StaticDb.Burgers.Add(entity);
            return entity.Id;
        }

        public int Update(Burger entity)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == entity.Id);
            if (burger == null)
            {
                throw new Exception($"Burger with id {entity.Id} was not found. ");
            }
            int index = StaticDb.Burgers.IndexOf(entity);
            StaticDb.Burgers[index] = entity;
        }
    }
}
