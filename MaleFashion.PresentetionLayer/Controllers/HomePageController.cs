using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
