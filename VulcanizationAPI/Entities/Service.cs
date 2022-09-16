﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulcanizationAPI.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int VulcanizationId { get; set; }
        public virtual Vulcanization Vulcanization { get; set; }

    }
}
