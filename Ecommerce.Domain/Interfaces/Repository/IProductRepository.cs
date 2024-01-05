using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAll();

        Task<Product> GetProductById(Guid ProductId);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Guid Id, string name, long Price, string ProductType, Guid? CategoryId);

        Task DeleteProduct(Guid ProductId);
    }
}
