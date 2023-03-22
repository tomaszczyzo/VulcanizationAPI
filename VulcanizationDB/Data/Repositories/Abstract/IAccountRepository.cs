using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Entities;

namespace VulcanizationAPI.Infrastructure.Data.Repositories.Abstract
{
    public interface IAccountRepository
        : IGenericRepository<User>
    {
    }
}
