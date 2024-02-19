using MaleFashion.PresentetionLayer.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultBlogModel>>("https://localhost:7088/api/Blogs");
            return View(value);
        }
    }
}
