using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mmaf_inf.Database;
using mmaf_inf.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace mmaf_inf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("collection")]
        public IActionResult Collection()
        {
            var rows = DatabaseConnector.GetRows("select * from product");
            List<string> names = new List<string>();
            foreach (var row in rows)
            {
                names.Add(row["naam"].ToString());
            }
            return View(names);
        }

        public IActionResult News()
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
