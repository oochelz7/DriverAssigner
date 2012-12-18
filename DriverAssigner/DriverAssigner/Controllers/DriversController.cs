using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DriverAssigner.Domain;
using DriverAssigner.Models;

namespace DriverAssigner.Controllers {
    public class DriversController : Controller {
        public ActionResult Index() {
            return View(new DriverRepository().GetAll());
        }

        public ActionResult New() {
            return View(new Driver());
        }

        [HttpPost]
        public ActionResult New(Driver driver) {
            try {
                driver.LastAssignment = "";
                new DriverRepository().Push(driver);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
