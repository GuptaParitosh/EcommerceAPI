using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Product.Commands
{
    public class UpdateProductCommand: IRequest<Ecommerce.Domain.Entities.Product>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public string ProductType { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
