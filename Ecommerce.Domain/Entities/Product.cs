using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public string ProductType { get; set; }

        [ForeignKey("CategoryId")]
        public Guid? CategoryId { get; set; } // Foreign key
        public Category Category { get; set; } // Reference navigation
    }
}