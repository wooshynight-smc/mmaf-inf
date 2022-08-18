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

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(Person person)
        {

            ViewData["voornaam"] = person.FirstName;
            ViewData["achternaam"] = person.LastName;

            if (ModelState.IsValid)
                return Redirect("/success");

            return View(person);
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

        [Route("blog")]
        public IActionResult Blog()
        {
            return View();
        }

        [Route("visit")]
        public IActionResult Visit()
        {
            return View();
        }

        [Route("studiom")]
        public IActionResult StudioM()
        {
            return View();
        }

        [Route("detail/{id}")]
        public IActionResult Details(int id)
        {
            var product = GetProduct(id);

            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
