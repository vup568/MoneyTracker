using PersonalLifeOS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalLifeOS.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = new List<TransactionViewModel>();
            var categories = new List<CategoryViewModel>();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            try
            {
                var client = _httpClientFactory.CreateClient("PersonalLifeOSApi");

                // 1. Fetch Transactions
                var transResponse = await client.GetAsync("api/transactions");
                if (transResponse.IsSuccessStatusCode)
                {
                    string transData = await transResponse.Content.ReadAsStringAsync();
                    transactions = JsonSerializer.Deserialize<List<TransactionViewModel>>(transData, options) ?? new List<TransactionViewModel>();
                }
                else
                {
                    ViewBag.ErrorMessage = $"Failed to fetch transactions. Status: {transResponse.StatusCode}";
                }

                // 2. Fetch Categories (for create/edit dropdowns)
                var catResponse = await client.GetAsync("api/categories");
                if (catResponse.IsSuccessStatusCode)
                {
                    string catData = await catResponse.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(catData, options) ?? new List<CategoryViewModel>();
                }
                else
                {
                    ViewBag.ErrorMessage = (ViewBag.ErrorMessage ?? "") + " Failed to fetch categories for dropdown.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Connection Error: {ex.Message}";
            }

            ViewBag.Categories = categories;
            return View(transactions);
        }
    }
}
