using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.ViewComponents
{
    [ViewComponent(Name = "HomePageScriptViewComponent")]
    public class HomePageScriptViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
