using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

public class HomeController : Controller
{
    [OutputCache(PolicyName = "default")]
    public IActionResult Index()
    {
        return this.View();
    }
}