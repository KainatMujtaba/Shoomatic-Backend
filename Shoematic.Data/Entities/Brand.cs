﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Size> Sizes { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
