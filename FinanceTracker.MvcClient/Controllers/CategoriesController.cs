using FinanceTracker.MvcClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;  // ← namespace chứa JsonSerializer


namespace FinanceTracker.MvcClient.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("FinanceAPI");
                var response = await client.GetAsync("api/categories"); //call API

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"API Error: Status {response.StatusCode} ({response.ReasonPhrase})";
                    return View(new List<CategoryViewModel>());
                }

                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<CategoryViewModel> categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(strData, options) ?? new List<CategoryViewModel>();
                return View(categories);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Connection Error: Could not connect to API. Details: {ex.Message}";
                return View(new List<CategoryViewModel>());
            }
        }
    }
}
