using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
