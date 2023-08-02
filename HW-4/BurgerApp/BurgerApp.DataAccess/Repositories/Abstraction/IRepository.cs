using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity 
    {
        List<T> GetAll();

        T GetById(int id);

        int Insert(T entity);
        
        int Update(T entity);

        void DeleteById(int id);
    }
}
