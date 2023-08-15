using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Abstraction;
using BurgerApp.DataAccess.Repositories.Implementation.EntityFrameworkImplementation;
using BurgerApp.DataAccess.Repositories.Implementation.StaticDbImplementation;
using BurgerApp.Domain.Models;
using BurgerApp.Services;
using BurgerApp.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BurgerApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
          //services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBurgerService, BurgerService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            //staticDb
          //  services.AddTransient<IRepository<Order>, OrderRepository>();
          ////services.AddTransient<IRepository<User>, UserRepository>();
          //  services.AddTransient<IRepository<Burger>, BurgerRepository>();

            //EntityFramework
            services.AddTransient<IRepository<Order>, OrderRepositoryEntity>();
         // services.AddTransient<IRepository<User>, UserRepositoryEntity>();
            services.AddTransient<IRepository<Burger>, BurgerRepositoryEntity>();
        }
        public static void InjectDbContext(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<BurgerAppDbContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
