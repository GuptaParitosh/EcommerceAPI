using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Application.Product.Queries;
using Ecommerce.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Product.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Ecommerce.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IProductRepository productRepository, ILogger<GetProductByIdQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductById(request.ProductId);
        }
    }
}
