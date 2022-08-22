var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Map("/map1/submap",Map1submap);
app.Map("/map1",Map1);
app.Map("/map2",Map2);
app.Map("/v1",v1);

app.Run(async context =>
    {
        await context.Response.WriteAsync("RUN \r\t");
    });

app.Run();

static void Map1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 1");
    });
}
static void v1(IApplicationBuilder app)
{
    app.Map("/v2a",v2a);
    app.Map("/v2b",v2b);
}
static void v2a(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("v2a");
    });
}
static void v2b(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("v2b");
    });
}
static void Map1submap(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 1 / submap");
    });
}
static void Map2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 2");
    });
}