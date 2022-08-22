namespace SampleMiddleware.Middleware;

public static class CustomMiddlewareExtetion
{
    public static void UseCustom( this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomMiddleware>();
    }
}

public class CustomMiddleware
{
    RequestDelegate _next;
    public CustomMiddleware(RequestDelegate netx)
    {
        _next = netx;
    }
    public async Task Invoke (HttpContext context)
    {
        await context.Response.WriteAsync("use ext start \r\n");
        await _next.Invoke(context);
        await context.Response.WriteAsync("use ext end \r\n");
        
    }
}