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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(EcommerceDbContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Category> AddCategory(Category Category)
        {
            _context.Category.Add(Category);
            await _context.SaveChangesAsync();
            return Category;
        }

        public async Task DeleteCategory(Guid CategoryId)
        {
            var Category = _context.Category.FirstOrDefault(p => p.Id == CategoryId);
            if (Category == null)
                return;
            _context.Category.Remove(Category);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAll()
        {
            var categories = await _context.Category.ToListAsync();
            foreach(var category in categories)
            {
                category.Products = await GetProductByCategoryId(category.Id);
            }
            return categories;
        }

        public async Task<Category> GetCategoryById(Guid CategoryId)
        {
            var category = await _context.Category.FirstOrDefaultAsync(p => p.Id == CategoryId);
            category.Products = await GetProductByCategoryId(category.Id);
            return category;
        }

        public async Task<Category> UpdateCategory(Guid CategoryId, string CategoryName)
        {
            var category = await _context.Category.FirstOrDefaultAsync(p => p.Id == CategoryId);
            category.CategoryName = CategoryName;

            _context.Category.Update(category);
            await _context.SaveChangesAsync();

            category.Products = await GetProductByCategoryId(category.Id);
            return category;
        }

        private async Task<List<Product>> GetProductByCategoryId(Guid categoryId)
        {
            return await _context.Product?.Where(p => p.CategoryId == categoryId)?.ToListAsync();
        }
    }
}
