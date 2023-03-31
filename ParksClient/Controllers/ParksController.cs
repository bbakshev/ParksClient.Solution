using Microsoft.AspNetCore.Mvc;
using ParksClient.Models;

namespace ParksClient.Controllers
{
    public class ParksController : Controller
    {
        public IActionResult Index()
        {
            List<Park> allParks = Park.GetParks();
            return View(allParks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Park park)
        {
            Park.Post(park);
            return RedirectToAction("Index");
        }
    }
}