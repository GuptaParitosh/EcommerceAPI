using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Domain.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = Guid.NewGuid(), ProductName = "System Design By Paritosh Gupta", Price = 2500, ProductType = "TextBooks", CategoryId = new Guid("f382d6f5-37e9-4ae1-b957-6df092654021") },
                            new Product { Id = Guid.NewGuid(), ProductName = "Two States By Chetan Bhagat", Price = 250, ProductType = "FictionBooks", CategoryId = new Guid("f382d6f5-37e9-4ae1-b957-6df092654021") },
                            new Product { Id = Guid.NewGuid(), ProductName = "Harry Potter and the Philosopher Stone by J.K. Rowling", Price = 500, ProductType = "KidsBooks", CategoryId = new Guid("f382d6f5-37e9-4ae1-b957-6df092654021") },
                            new Product { Id = Guid.NewGuid(), ProductName = "IQOO Z6", Price = 30000, ProductType = "Mobiles", CategoryId = new Guid("738bff8a-b670-4d29-af79-9eb31058dd64") },
                            new Product { Id = Guid.NewGuid(), ProductName = "Samsung Galaxy Tab A9+", Price = 18000, ProductType = "Tablets", CategoryId = new Guid("738bff8a-b670-4d29-af79-9eb31058dd64") },
                            new Product { Id = Guid.NewGuid(), ProductName = "Fossil Gen 6 Digital Black Dial Men's Watch-FTW4061", Price =  11997, ProductType= " MensWatches", CategoryId= new Guid("2aef81d8-f6f9-4dd1-ad4b-377f2996ac02") },
                            new Product { Id = Guid.NewGuid(), ProductName = "Fastrack New Limitless FS1 Smart Watch", Price = 1197, ProductType = " WomensWatches", CategoryId = new Guid("3f85c6ef-0e1b-449b-8f15-989575379024") }
                );
        }
    }
}
