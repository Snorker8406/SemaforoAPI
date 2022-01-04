﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Semaforo.Logic.BO
{
    public class CategoryBO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? Enabled { get; set; }

    }
}
