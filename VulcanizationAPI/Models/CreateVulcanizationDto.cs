using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Models
{
    public class CreateVulcanizationDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(45)]
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
