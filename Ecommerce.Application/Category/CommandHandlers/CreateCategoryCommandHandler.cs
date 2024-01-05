using Ecommerce.Application.Category.Commands;
using Ecommerce.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Category.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Ecommerce.Domain.Entities.Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<CreateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Domain.Entities.Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.AddCategory(new Domain.Entities.Category { Id = request.CategoryId, CategoryName = request.CategoryName });
        }
    }
}
