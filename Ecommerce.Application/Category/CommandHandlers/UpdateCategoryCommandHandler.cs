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
    public class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand, Ecommerce.Domain.Entities.Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Domain.Entities.Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.UpdateCategory(request.CategoryId, request.CategoryName);
        }
    }
}
