using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VulcanizationAPI.Core.Entities.Abstract;

namespace VulcanizationAPI.Core.Entities
{
    public class Contact
        : Entity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Vulcanization Vulcanization { get; set; }

    }
}
