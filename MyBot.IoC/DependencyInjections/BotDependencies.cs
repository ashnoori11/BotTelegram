using Microsoft.Extensions.DependencyInjection;
using MyBot.Application.InterfaceServices;
using MyBot.Application.Services;
using MyBot.Data.Repositories;
using MyBot.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot.IoC.DependencyInjections
{
    public static class BotDependencies
    {
        public static void BotServicesRegistery(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IQuestionsService, QuestionsService>();
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}
