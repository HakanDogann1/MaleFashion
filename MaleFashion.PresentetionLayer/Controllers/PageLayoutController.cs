using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.Controllers
{
    public class PageLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
