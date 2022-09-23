using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Models
{
    public class CreateServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Precision(9, 2)]
        public decimal Price { get; set; }
    }
}
