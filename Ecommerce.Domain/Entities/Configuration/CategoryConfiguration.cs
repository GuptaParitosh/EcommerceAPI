using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(s => s.CategoryName)
                .IsRequired(false);
            builder.HasData(new Category { Id = new Guid("f382d6f5-37e9-4ae1-b957-6df092654021"), CategoryName = "Books" },
                            new Category { Id = new Guid("738bff8a-b670-4d29-af79-9eb31058dd64"), CategoryName = "Mobiles, Computers" },
                            new Category { Id = new Guid("9a3768da-4464-4702-b24d-48288dd96eb0"), CategoryName = "TV, Appliances, Electronics" },
                            new Category { Id = new Guid("2aef81d8-f6f9-4dd1-ad4b-377f2996ac02"), CategoryName = "Men's Fashion" },
                            new Category { Id = new Guid("3f85c6ef-0e1b-449b-8f15-989575379024"), CategoryName = "Women's Fashion" },
                            new Category { Id = new Guid("7eef79a6-745a-4c4e-8d9c-99d71bb4ccd5"), CategoryName = "Toy, Baby Products, Kid's Fashion" }
                );
        }
    }
}
