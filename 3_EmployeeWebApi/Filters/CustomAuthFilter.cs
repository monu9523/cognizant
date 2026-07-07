using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApiDemo.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                // Short-circuits the pipeline with a 400 response
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            string authHeaderValue = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (!authHeaderValue.Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}