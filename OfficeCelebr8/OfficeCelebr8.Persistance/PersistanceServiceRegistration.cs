    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeCelebr8.Domain.Entities;
using OfficeCelebr8.Domain.Interfaces;
using OfficeCelebr8.Persistance.Authentication;
using OfficeCelebr8.Persistance.Celebr8AppDbContexts;
using OfficeCelebr8.Persistance.Repsitories;


namespace OfficeCelebr8.Persistance.PersistanceServiceRegistration
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Celebr8AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IJwtTokenGenrator, JwtTokenGenrator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;
        }
    }
}
