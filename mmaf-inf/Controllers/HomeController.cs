using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mmaf_inf.Database;
using mmaf_inf.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Linq;

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

        //set httppost for contact form
        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(Person person)
        {

            ViewData["voornaam"] = person.FirstName;
            ViewData["achternaam"] = person.LastName;

            if (ModelState.IsValid)
            {
                return Redirect("/success");
            }
            return View(person);
        }

        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }

        //httppost for newsletter form
        [HttpPost]
        [Route("newsletter")]
        public IActionResult Newsletter(Newsletter newsletterEmail)
        {

            ViewData["voornaam"] = newsletterEmail;

            if (ModelState.IsValid)
            {
                return Redirect("/success");
            }
            return View(newsletterEmail);
        }


        [Route("collection")]
        public IActionResult Collection()
        {
            var Collection = GetFullCollection();
            return View(Collection);
        }

        //create new list for COLLECTION

        public List<Collection> GetFullCollection()
        {
            var rows = DatabaseConnector.GetRows("select * from collection");

            List<Collection> fullCollection = new List<Collection>();

            foreach (var row in rows)
            {
                Collection c = GetCollectionFromRow(row);

                fullCollection.Add(c);
            }
            return fullCollection;
        }

        [Route("collection/{id}")]
        public IActionResult CollectionDetails(int id)
        {
            var c = GetFullCollection(id);

            return View(c);
        }

        //define items in COLLECTION c
        private Collection GetCollectionFromRow(Dictionary<string, object> row)
        {
            Collection c = new Collection();

            c.Name = row["Name"].ToString();
            c.Year = Convert.ToInt32(row["Year"]);
            c.Description = row["Description"].ToString();
            c.Material = row["Material"].ToString();
            c.Dimensions = row["Dimensions"].ToString();
            c.Id = Convert.ToInt32(row["Id"]);
            c.Artist = row["Artist"].ToString();
            c.Image = row["Image"].ToString();

            return c;
        }

        public Collection GetFullCollection(int id)
        {
            var rows = DatabaseConnector.GetRows($"select * from collection where id = {id}");
            Collection c = GetCollectionFromRow(rows[0]);

            return c;
        }

        //generate (pseudo) random integer for collection spotlight id for every refresh (10/04/23: deleted some shit because it kept crashing)

        public class Random
        {
            Random rnd = new Random();
            //int collectionSpotlight = rnd.Next(1,38);     // creates a number between 0 and 37 (16/04/23: i can't use rnd grr)
        }

        //fuck me why can't i get this to work i'm giving up


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

        [Route("newsletter")]
        public IActionResult Newsletter()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        /*[Route("Error/{statuscode}")]
        public class ErrorPageController : Controller
            public IActionResult Index(int statuscode)

            switch(statuscode)
            {
                case 404:
                    ViewData["Error"] = "Page Not Found";
            break;
            default:
                break;
            }
        return View("Error");

        (14/04/23: ok why the fuck is NOTHING WORKING?? htaccess doesn't work either ugh)
        */
    }
}
