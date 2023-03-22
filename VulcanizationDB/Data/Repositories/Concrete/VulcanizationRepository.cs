using Microsoft.EntityFrameworkCore;
using MyWebApi.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Entities;

namespace VulcanizationAPI.Infrastructure.Data.Repositories.Concrete
{
    public class VulcanizationRepository
        : GenericRepository<Vulcanization>
    {
        public VulcanizationRepository(DbContext context) : base(context)
        {
        }
    }
}
