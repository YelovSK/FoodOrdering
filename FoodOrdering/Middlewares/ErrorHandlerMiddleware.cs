using FoodOrdering.Exceptions;
using Newtonsoft.Json;

namespace FoodOrdering.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FoodOrderingException error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var responseContent = new ResponseContent()
            {
                error = error.Message
            };

            response.StatusCode = StatusCodes.Status400BadRequest;
            
            var jsonResult = JsonConvert.SerializeObject(responseContent);
            await response.WriteAsync(jsonResult);
        }
    }

    private class ResponseContent
    {
        public string error { get; set; }
    }
}