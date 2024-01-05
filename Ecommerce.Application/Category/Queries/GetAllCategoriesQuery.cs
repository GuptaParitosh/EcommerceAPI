using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<Ecommerce.Domain.Entities.Category>>
    {
    }
}
