using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvalTask.Common.Attributes;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Products;
using EvalTask.Features.Products.Commands;
using EvalTask.Features.Products.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILoggerFactory logger) : base(logger)
        {
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts() => 
            Ok(await Mediator.Send(new GetAllProductsQuery()));

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id) => 
            Ok(await Mediator.Send(new GetProductByIdQuery(id)));

        /// <summary>
        /// Create new product
        /// </summary>
        [HttpPost]
        [Authorize]
        [DataValidate]
        public async Task<IActionResult> Create([FromBody] CreateProductDto payload) => 
            Ok(await Mediator.Send(new CreateProductCommand(payload, UserContext)));

        /// <summary>
        /// Update product
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        [DataValidate]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto payload, Guid id) => 
            Ok(await Mediator.Send(new UpdateProductCommand(id, payload, UserContext)));
        
        /// <summary>
        /// Set delete product
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id) => 
            Ok(await Mediator.Send(new DeleteProductCommand(id, UserContext)));
    }
}