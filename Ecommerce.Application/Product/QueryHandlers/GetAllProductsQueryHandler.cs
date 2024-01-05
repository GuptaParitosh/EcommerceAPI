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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Ecommerce.Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IProductRepository productRepository, ILogger<GetAllProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<List<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return (List<Domain.Entities.Product>)await _productRepository.GetAll();
        }
    }
}
