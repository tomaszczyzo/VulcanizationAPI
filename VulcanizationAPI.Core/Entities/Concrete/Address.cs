using VulcanizationAPI.Core.Entities.Abstract;

namespace VulcanizationAPI.Core.Entities.Concrete
{
    public class Address
        : Entity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public virtual Vulcanization Vulcanization { get; set; }


    }
}
