using Ecommerce.Application.Category.Commands;
using Ecommerce.Application.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IMediator _mediator;

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> Details([FromQuery] Guid categoryId)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery { CategoryId = categoryId });
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Ecommerce.API.ViewModels.Request.Category category)
        {
            var categoryResponse = await _mediator.Send(new CreateCategoryCommand { CategoryId = category.CategoryId, CategoryName = category.Name });
            return Ok(categoryResponse);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] Ecommerce.API.ViewModels.Request.Category category)
        {
            var categoryResponse = await _mediator.Send(new UpdateCategoryCommand { CategoryId = category.CategoryId, CategoryName = category.Name });
            return Ok(categoryResponse);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromQuery] Guid categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand { CategoryId = categoryId });
            return Ok();
        }
    }
}
