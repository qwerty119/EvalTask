using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EvalTask.Common.Attributes
{
    /// <summary>
    /// Executing ModelState validation and returns BadRequest result with 422 status code
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DataValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            context.Result = new BadRequestObjectResult(context.ModelState)
            {
                StatusCode = 422
            };
        }
    }

}