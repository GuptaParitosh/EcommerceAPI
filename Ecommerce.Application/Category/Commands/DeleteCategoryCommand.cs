using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Category.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
    }
}
