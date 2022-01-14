using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot.Data.Context
{
    public class BotContext : DbContext
    {
        #region ctor
        public BotContext(DbContextOptions<DbContext> dbContext)
            :base(dbContext)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        #region models

        #endregion
    }
}
