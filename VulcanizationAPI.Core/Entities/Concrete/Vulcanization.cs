using VulcanizationAPI.Core.Entities.Abstract;
using VulcanizationAPI.Core.Entities.Concrete;

namespace VulcanizationAPI.Core.Entities
{
    public class Vulcanization
        : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int AddressId { get; set; }
        public int ContactId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual List<Service> Services { get; set; }
    }
}
