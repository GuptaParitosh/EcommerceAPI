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
    public class GetCategoryByIdQueryHandler: IRequestHandler<GetCategoryByIdQuery, Ecommerce.Domain.Entities.Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<GetCategoryByIdQueryHandler> _logger;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, ILogger<GetCategoryByIdQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Domain.Entities.Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryById(request.CategoryId);
        }
    }
}
