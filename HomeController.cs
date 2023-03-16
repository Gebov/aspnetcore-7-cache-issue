using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

public class HomeController : Controller
{
    [OutputCache(PolicyName = "default")]
    public IActionResult Index()
    {
        var ocFeature = this.HttpContext.Features.Get<IOutputCacheFeature>();

        if (ocFeature != null)
        {
            ocFeature.Context.CacheVaryByRules.QueryKeys = new Microsoft.Extensions.Primitives.StringValues("page");
        }

        return this.View();
    }
}