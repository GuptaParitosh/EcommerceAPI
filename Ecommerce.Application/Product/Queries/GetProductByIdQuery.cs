using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Product.Queries
{
    public class GetProductByIdQuery : IRequest<Ecommerce.Domain.Entities.Product>
    {
        public Guid ProductId { get; set; }
    }
}
