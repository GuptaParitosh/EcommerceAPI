using Ecommerce.Application.Category.Queries;
using Ecommerce.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Category.QueryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Ecommerce.Domain.Entities.Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<GetAllCategoriesQueryHandler> _logger;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, ILogger<GetAllCategoriesQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<List<Domain.Entities.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return (List<Domain.Entities.Category>)await _categoryRepository.GetAll();
        }
    }
}
