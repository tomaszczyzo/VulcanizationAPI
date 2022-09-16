using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Entities
{
    public class Vulcanization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int AddressId { get; set; }
        public int ContactId { get; set; }

        public virtual Address Address { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual List<Service> Services { get; set; }
    }
}
