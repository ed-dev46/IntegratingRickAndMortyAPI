using IntegrationRickAndMortyAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var characters = await _apiService.GetAllCharactersAsync(page);          
                return View(characters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching characters");
                return View();
            }
        }
    }
}
