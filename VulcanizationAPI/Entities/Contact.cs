using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Vulcanization Vulcanization { get; set; }

    }
}
