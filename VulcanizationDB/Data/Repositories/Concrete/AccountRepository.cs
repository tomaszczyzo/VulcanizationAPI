using Microsoft.EntityFrameworkCore;
using MyWebApi.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Entities;
using VulcanizationAPI.Infrastructure.Data.Repositories.Abstract;

namespace VulcanizationAPI.Infrastructure.Data.Repositories.Concrete
{
    public class AccountRepository
        : GenericRepository<User>
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }

    }
}
