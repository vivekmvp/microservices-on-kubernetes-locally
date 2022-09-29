using frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            this.configuration = configuration;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var client = new RestClient(configuration["backendbaseurl"] + "/Product");
            var request = new RestRequest();
            var response = await client.GetAsync(request);
            List<Product> products = new List<Product>();
            
            if (response.IsSuccessStatusCode)            
                products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}