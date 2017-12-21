﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{   
    public class ProducerViewModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }   
}