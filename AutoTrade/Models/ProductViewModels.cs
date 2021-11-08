using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Models
{
    public class ProductAddViewModel
    {
        public string Name { get; set; }
        public string Priority { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
    }
    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string InventoryStatus { get; set; }
        public int Rating { get; set; }
    }

}
