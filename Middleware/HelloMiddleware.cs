using Microsoft.AspNetCore.Http;

namespace app.middleware;

public class HelloMiddleware
{
  private readonly ILogger<HelloMiddleware> logger;
  private readonly RequestDelegate next;
  public HelloMiddleware(RequestDelegate next, ILogger<HelloMiddleware> logger)
  {
    this.next = next;
    this.logger = logger; 
  }
  
  public Task Invoke(HttpContext httpContext)
  {
    httpContext.Items["token"] = "123";
    logger.LogInformation(httpContext.Items["token"]!.ToString());
    return next(httpContext);
  }
}