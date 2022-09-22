using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Models
{
    public class UpdateVulcanizationDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
