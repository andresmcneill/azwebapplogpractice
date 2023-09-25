using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace azwebapplogpractice.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("GetStatusCode")]
    public IActionResult Get(int statusCode)
    {
        _logger.LogTrace($"Beginning request processing for status code ${statusCode}");
        string logMessage = "Returning status code: " + statusCode;
        if (statusCode == (int)HttpStatusCode.OK) {
            _logger.LogInformation(logMessage);
        } else if (statusCode == (int)HttpStatusCode.BadRequest) {
            _logger.LogWarning(logMessage);
        } else if (statusCode >= 500) {
            _logger.LogError(logMessage);
        }
        System.Diagnostics.Trace.TraceWarning("System.Diagnostics.Trace a warning");


        var response = new ObjectResult(logMessage)
        {
            StatusCode = statusCode
        };
        return response;
    }
}
