using Api.Filters;

namespace Api.V1.Tests;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/tests/exception")]
public class ExceptionTestController : ControllerBase
{
    [HttpGet]
    [TypeFilter<DevelopmentOnlyAttribute>]
    public IActionResult Get()
    {
        throw new Exception("This is a test exception - expect 500 http response");
    }
}

