using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Areas.Identity.Data;
using Project.Models;
using System.Data.Entity;
using System.Web;
using System.Dynamic;
using Project.Data;
using System.Data.Common;

namespace Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private ApplicationContext dbContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Vehicles = dbContext.Vehicles.ToList();
            mymodel.VehicleParts = dbContext.VehiclesParts.ToList();
            return View(mymodel);
        }
        [HttpGet]
        public ActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(Vehicle newVehicle)
        {
            dbContext.Vehicles.Add(newVehicle);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult AddVehiclePart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehiclePart(VehiclePart newVehiclePart)
        {
            dbContext.VehiclesParts.Add(newVehiclePart);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
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
