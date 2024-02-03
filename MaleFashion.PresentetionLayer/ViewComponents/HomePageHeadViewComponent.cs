using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.ViewComponents
{
    [ViewComponent(Name = "HomePageHeadViewComponent")]
    public class HomePageHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
