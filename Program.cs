var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddOutputCache((x) => 
{
    x.AddPolicy("default", (builder) =>
    {
        builder.With((context) =>
        {
            if (context.HttpContext.Request.Path.HasValue && context.HttpContext.Request.Path.Value.Contains("TimeCached", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }).Cache();
    });
});

var app = builder.Build();
app.UseRouting();
app.UseOutputCache();
app.UseEndpoints((endpoints) =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// this is cached, expected
app.MapGet("/TimeCached", () => DateTime.Now.ToString())
	.CacheOutput("default");

// this is not cached, expected
app.MapGet("/TimeNotCached", () => DateTime.Now.ToString())
	.CacheOutput("default");

app.Run();
