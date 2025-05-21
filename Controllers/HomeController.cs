using IntegrationRickAndMortyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using IntegrationRickAndMortyAPI.Models;

namespace IntegrationRickAndMortyAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly APIService _apiService;

        public HomeController(ILogger<HomeController> logger, APIService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.CurrentPage = page;
            try
            {
                var characters = await _apiService.GetAllCharactersAsync(page);
                if (!characters.Any())
                {
                    _logger.LogWarning("No characters found on page {Page}", page);
                    return View(new List<Character>());
                }
                return View(characters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching characters");
                return View(new List<Character>());
            }
        }
    }
}
