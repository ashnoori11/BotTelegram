using MyBot.Application.InterfaceServices;
using MyBot.Domain.InterfaceRepositories;
using MyBot.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot.Application.Services
{
    public class UsersService : IUsersService
    {
        #region injections
        private readonly IBaseRepository<User> _baseRepository;

        public UsersService(IBaseRepository<User> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion
    }
}
