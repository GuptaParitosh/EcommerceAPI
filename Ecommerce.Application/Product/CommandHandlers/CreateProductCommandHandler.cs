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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Ecommerce.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository productRepository, ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Domain.Entities.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new Domain.Entities.Product();
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.ProductType = request.ProductType;
            product.CategoryId = request.CategoryId;

            return await _productRepository.AddProduct(product);
        }
    }
}
