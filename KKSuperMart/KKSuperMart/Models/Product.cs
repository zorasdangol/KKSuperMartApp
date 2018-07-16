using System;
using System.Collections.Generic;

namespace KKSuperMart.Models
{
    public class Product:BaseModel
    {
        public string Category { get; set; }
        public List<CategoryItem> CategoryItemsList { get; set; }       
    }

    public class CategoryItem:BaseModel
    {
        public string IconImage { get; set; }
        public string ProductName { get; set; }
        public string Seller { get; set; }
    }
}
