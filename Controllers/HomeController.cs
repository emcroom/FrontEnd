using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using FrontEnd.Data;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private JokesClient _client;

        public HomeController(ILogger<HomeController> logger, JokesClient client)
        {
            _logger = logger;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRandomJoke()
        {
            var joke = await _client.GetRandomJoke();
            return Json(new
            {
                success = true,
                joke = joke
            });
        }

        public async Task<IActionResult> SearchJokes(string searchTerm)
        {
            var jokes = await _client.SerachJokes(searchTerm);
            return Json(new
            {
                success = true,
                jokes = jokes
            });
        }


    }
}
