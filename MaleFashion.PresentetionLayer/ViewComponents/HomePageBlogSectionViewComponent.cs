using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.ViewComponents
{
    [ViewComponent(Name = "HomePageBlogSectionViewComponent")]
    public class HomePageBlogSectionViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
