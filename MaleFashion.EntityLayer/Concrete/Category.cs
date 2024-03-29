﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ImageUrl { get; set; }

        public List<Image> Images { get; set; }
        public List<Product> Products { get; set; }
        public List<Size> Sizes { get; set; }
    }
}
