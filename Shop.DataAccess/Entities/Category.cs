﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; } = null!;
    
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();

    }
}
