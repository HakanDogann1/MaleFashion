using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
