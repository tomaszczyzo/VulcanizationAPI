using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Entities.Abstract;

namespace VulcanizationAPI.Core.Entities
{
    public class Service
        : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public long VulcanizationId { get; set; }
        public virtual Vulcanization Vulcanization { get; set; }

    }
}
