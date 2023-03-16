using Microsoft.AspNetCore.OutputCaching;

class CustomCachePolicy : IOutputCachePolicy
{
    public ValueTask CacheRequestAsync(OutputCacheContext context, CancellationToken cancellation)
    {
        var httpContext = context.HttpContext;

        context.AllowCacheLookup = true;
        context.AllowCacheStorage = true;
        context.AllowLocking = true;
        context.EnableOutputCaching = true;
        context.ResponseExpirationTimeSpan = TimeSpan.FromMinutes(10);
        return ValueTask.CompletedTask;
    }

    public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellation)
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken cancellation)
    {
        return ValueTask.CompletedTask;
    }
}