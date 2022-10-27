using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

public class HomeController : Controller
{
    [OutputCache(PolicyName = "default")]
    public IActionResult TimeCached()
    {
        return this.Content(DateTime.Now.ToString());
    }

    [OutputCache(PolicyName = "default")]
    public IActionResult TimeNotCached()
    {
        return this.Content(DateTime.Now.ToString());
    }
}