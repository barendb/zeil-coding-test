using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Use this filter if you want to restrict some actions to development only 
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class DevelopmentOnlyAttribute : ActionFilterAttribute
{
    private readonly IHostEnvironment _hostEnvironment;

    public DevelopmentOnlyAttribute(IHostEnvironment hostEnvironment) =>
        _hostEnvironment = hostEnvironment;

    public override void OnActionExecuting(ActionExecutingContext actionContext) 
    {
        if (!_hostEnvironment.IsDevelopment())
        {
            actionContext.Result = new StatusCodeResult(404);
        }
    }
}