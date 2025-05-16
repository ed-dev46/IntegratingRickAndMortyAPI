using Microsoft.AspNetCore.Mvc;

namespace IntegrationRickAndMortyAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dictionary<int, string> characters = new Dictionary<int, string>
            {
                { 1, "Rick Sanchez" },
                { 2, "Morty Smith" },
                { 3, "Summer Smith" },
                { 4, "Beth Smith" },
                { 5, "Jerry Smith" }
            };
            return View(characters);
        }
    }
}
