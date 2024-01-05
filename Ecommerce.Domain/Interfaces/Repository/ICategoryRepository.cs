using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAll();

        Task<Category> GetCategoryById(Guid CategoryId);

        Task<Category> AddCategory(Category Category);

        Task<Category> UpdateCategory(Guid CategoryId, string CategoryName);

        Task DeleteCategory(Guid CategoryId);
    }
}
