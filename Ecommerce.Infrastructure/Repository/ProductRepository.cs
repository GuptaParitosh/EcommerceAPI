using Ecommerce.Domain.CustomException;
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

        public async Task DeleteProduct(Guid productId)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId, string.Empty);
            }
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

        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == productId);
            product.Category = await GetCategoryById(product?.CategoryId);
            return product;
        }

        public async Task<Product> UpdateProduct(Guid id, string name, long price, string productType, Guid? categoryId)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
            var category = await GetCategoryById(categoryId);
            if (product == null)
            {
                throw new ProductNotFoundException(id, name);
            }

            if(categoryId != null && category == null)
            {
                throw new CategoryNotFoundException((Guid)categoryId, string.Empty);
            }
            product.ProductName = name;
            product.Price = price;
            product.ProductType = productType;
            product.CategoryId = categoryId;
            
            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            product.Category = await GetCategoryById(product?.CategoryId);
            return product;
        }

        private async Task<Category> GetCategoryById(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return null;
            }
            return await _context.Category.FirstOrDefaultAsync(c => c.Id == categoryId);

        }
    }
}
