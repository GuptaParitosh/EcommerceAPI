using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repository;
using Ecommerce.Domain.CustomException;
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

        public async Task<Category> AddCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var Category = _context.Category.FirstOrDefault(p => p.Id == categoryId);
            if (Category == null)
            {
                throw new CategoryNotFoundException(categoryId, string.Empty);
            }
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

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            var category = await _context.Category.FirstOrDefaultAsync(p => p.Id == categoryId);
            category.Products = await GetProductByCategoryId(category.Id);
            return category;
        }

        public async Task<Category> UpdateCategory(Guid categoryId, string categoryName)
        {
            var category = await _context.Category.FirstOrDefaultAsync(p => p.Id == categoryId);
            if(category == null)
            {
                throw new CategoryNotFoundException(categoryId, categoryName);
            }
            category.CategoryName = categoryName;

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
