using MaleFashion.PresentetionLayer.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.ViewComponents
{
    [ViewComponent(Name = "HomePageBannerViewComponent")]
    public class HomePageBannerViewComponent:ViewComponent
    {
        private readonly HttpClient _httpClient;

        public HomePageBannerViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultCategoryModel>>("https://localhost:7088/api/Categories");
            return View(value);
        }
    }
}
