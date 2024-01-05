using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Category.Commands
{
    public class CreateCategoryCommand : IRequest<Ecommerce.Domain.Entities.Category>
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
