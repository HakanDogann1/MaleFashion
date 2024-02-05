using MaleFashion.PresentetionLayer.Models.HeaderModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.ViewComponents
{
    [ViewComponent(Name = "HomePageHeoSectionViewComponent")]
    public class HomePageHeoSectionViewComponent:ViewComponent
    {
       private readonly HttpClient _httpClient;

        public HomePageHeoSectionViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultHeaderModel>>("https://localhost:7088/api/Headers");
            return View(value);
        }
    }
}
