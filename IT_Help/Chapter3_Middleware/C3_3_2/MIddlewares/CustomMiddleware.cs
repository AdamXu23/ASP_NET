namespace SampleMiddleware.Middleware;

public static class CustomMiddlewareExtetion
{
    public static void UseCustom( this IApplicationBuilder app)
    {}
}

public class CustomMiddleware
{
    RequestDelegate _next;
    public CustomMiddleware(RequestDelegate netx)
    {
        _next = netx;
    }
}