﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Shop.Domain.Common;

namespace T_Shop.Domain.Models
{
    public class Category : BaseModel
    {
       

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
