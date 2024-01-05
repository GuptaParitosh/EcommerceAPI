using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ecommerce.Application.Category.Queries
{
    public class GetCategoryByIdQuery : IRequest<Ecommerce.Domain.Entities.Category>
    {
        public Guid CategoryId { get; set; }
    }
}
