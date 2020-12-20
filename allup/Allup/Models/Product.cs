using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public double? Discount { get; set; }
        public int? Rate { get; set; }
        public int? SaleCount { get; set; }
        [Required]
        public int Count { get; set; }
        public double ExTax { get; set; }
        public string Brand { get; set; }
        public string Tags { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}