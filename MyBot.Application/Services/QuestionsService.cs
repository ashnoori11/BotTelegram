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
    public class QuestionsService : IQuestionsService
    {
        #region injection
        private readonly IBaseRepository<Question> _baseRepository;

        public QuestionsService(IBaseRepository<Question> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

    }
}
