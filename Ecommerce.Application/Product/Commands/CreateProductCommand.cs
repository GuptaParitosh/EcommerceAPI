using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ecommerce.Application.Product.Commands
{
    public class CreateProductCommand: IRequest<Ecommerce.Domain.Entities.Product>
    {
        public string ProductName { get; set; }
        public long Price { get; set; }
        public string ProductType { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
