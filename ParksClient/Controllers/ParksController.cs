using Microsoft.AspNetCore.Mvc;
using ParksClient.Models;

namespace ParksClient.Controllers;
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

        public ActionResult Details(int id)
        {
            Park park = Park.GetDetails(id);
            return View(park);
        }

        public ActionResult Edit(int id)
        {
            Park park = Park.GetDetails(id);
            return View(park);
        }
        [HttpPost]
        public ActionResult Edit(Park park)
        {
            Park.Put(park);
            return RedirectToAction("Index", new { id = park.ParkId });
        }

        public ActionResult Delete(int id)
        {
            Park park = Park.GetDetails(id);
            return View(park);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Park.Delete(id);
            return RedirectToAction("Index");
        }
    }