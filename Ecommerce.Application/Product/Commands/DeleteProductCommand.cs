using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
    }
}
