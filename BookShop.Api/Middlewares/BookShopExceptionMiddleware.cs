using BookShop.Domain.Models.Response;
using BookShop.Service.Exceptions;

namespace BookShop.Api.Middlewares;

public class BookShopExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<BookShopExceptionMiddleware> _logger;
    public BookShopExceptionMiddleware(RequestDelegate next ,ILogger<BookShopExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (BookShopException ex)
        {
            await HandleException(context, ex.Code, ex.Message, ex.Global);
        }   
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            await HandleException(context, 500, "", true);
        }
    }
    public async Task HandleException(HttpContext context,int code, string message, bool? global)
    {
        context.Response.StatusCode = code;
        await context.Response.WriteAsJsonAsync(new 
        ResponseModel<string> 
        { 
            Status = false,
            Error = message,
            Data = null,
            Global = global
        });
          
    }
}
