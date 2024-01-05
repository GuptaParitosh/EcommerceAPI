using Ecommerce.Domain.CustomException;
using Ecommerce.Application.Product.Queries;
using Ecommerce.Application.Product.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] Guid productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { ProductId = productId});

            //throw new ProductNotFoundException(product.ProductId, product.ProductName);

            return Ok(product);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Ecommerce.Domain.ViewModels.Request.Product product)
        {
            var products = await _mediator.Send(new CreateProductCommand { ProductName = product.ProductName, Price = product.Price, ProductType = product.ProductType, CategoryId = product.CategoryId});
            return Ok(products);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Ecommerce.Domain.ViewModels.Request.Product product)
        {
            var products = await _mediator.Send(new UpdateProductCommand { ProductName = product.ProductName, Price = product.Price, ProductType = product.ProductType, CategoryId = product.CategoryId });
            return Ok(products);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid productId)
        {
            await _mediator.Send(new DeleteProductCommand { ProductId = productId  });
            return Ok();
        }
    }
}
