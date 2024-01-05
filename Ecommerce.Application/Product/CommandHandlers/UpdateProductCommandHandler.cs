using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Application.Product.Commands;
using Ecommerce.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Product.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Ecommerce.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Domain.Entities.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.UpdateProduct(request.ProductId, request.ProductName, request.Price, request.ProductType,request.CategoryId);
        }

    }
}
