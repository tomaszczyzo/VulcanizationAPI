using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Core.Entities.Concrete
{
    public class UserVulcanization
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long VulcanizationId { get; set; }
        public virtual Vulcanization Vulcanization { get; set; }
    }
}
