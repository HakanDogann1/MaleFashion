using MaleFashion.PresentetionLayer.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.ViewComponents
{
    [ViewComponent(Name = "HomePageProductSectionViewComponent")]
    public class HomePageProductSectionViewComponent:ViewComponent
    {
        private readonly HttpClient _httpClient;

        public HomePageProductSectionViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _httpClient.GetFromJsonAsync<List<ResultProductModel>>("https://localhost:7088/api/Products");
            return View(products);
        }
    }
}
