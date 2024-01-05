using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public class EcommerceDbContext : DbContext
    {
        private readonly ILogger<EcommerceDbContext> _logger;
        public EcommerceDbContext(DbContextOptions options, ILogger<EcommerceDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
