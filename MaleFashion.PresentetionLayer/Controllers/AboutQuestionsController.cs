using MaleFashion.PresentetionLayer.Models.AboutQuestionModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.PresentetionLayer.Controllers
{
    public class AboutQuestionsController : Controller
    {
        private readonly HttpClient _httpClient;

        public AboutQuestionsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultAboutQuestionModel>>("https://localhost:7088/api/AboutQuestions");
            return View(value);
        }
    }
}
