﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models
{
    public class Category
    {
        
        public int CategoryId{ get; set; }
        public string Name{ get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}