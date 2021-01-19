using System;
using System.Threading.Tasks;
using EvalTask.Common.Attributes;
using EvalTask.Dto.Categories;
using EvalTask.Features.Categories.Commands;
using EvalTask.Features.Categories.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(ILoggerFactory logger) : base(logger)
        {
        }
        
        /// <summary>
        /// Get all not deleted categories
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCategories() => 
            Ok(await Mediator.Send(new GetAllCategoriesQuery()));
        
        /// <summary>
        /// Create new category
        /// </summary>
        [HttpPost]
        [Authorize]
        [DataValidate]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto payload) => 
            Ok(await Mediator.Send(new CreateCategoryCommand(payload, UserContext)));
        
        /// <summary>
        /// Set delete category
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id) => 
            Ok(await Mediator.Send(new DeleteCategoryCommand(id, UserContext)));
        
        /// <summary>
        /// Update category
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryDto payload) => 
            Ok(await Mediator.Send(new UpdateCategoryCommand(id, payload, UserContext)));
    }
}