using System;

namespace Ecommerce.Domain.ViewModels.Request
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public string ProductType { get; set; }
        public Guid? CategoryId { get; set; }
    }
}