using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(EcommerceDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            product.Category = await GetCategoryById(product?.CategoryId);
            return product;
        }

        public async Task DeleteProduct(Guid ProductId)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == ProductId);
            if (product == null)
                return;
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            var products = await _context.Product.ToListAsync();
            foreach(var product in products)
            {
                product.Category = await GetCategoryById(product?.CategoryId);
            }
            return products;
        }

        public async Task<Product> GetProductById(Guid ProductId)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == ProductId);
            product.Category = await GetCategoryById(product?.CategoryId);
            return product;
        }

        public async Task<Product> UpdateProduct(Guid Id, string name, long Price, string ProductType, Guid? CategoryId)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == Id);
            product.ProductName = name;
            product.Price = Price;
            product.ProductType = ProductType;
            product.CategoryId = CategoryId;
            
            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            product.Category = await GetCategoryById(product?.CategoryId);
            return product;
        }

        private async Task<Category> GetCategoryById(Guid? CategoryId)
        {
            if (CategoryId == null)
            {
                return null;
            }
            return await _context.Category.FirstOrDefaultAsync(c => c.Id == CategoryId);

        }
    }
}
