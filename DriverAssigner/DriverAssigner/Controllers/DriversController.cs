using System.Collections.Generic;
using System.Web.Mvc;
using DriverAssigner.Domain;
using DriverAssigner.Models;

namespace DriverAssigner.Controllers {
    public class DriversController : Controller {
        public ActionResult Index() {
            List<Driver> drivers = new List<Driver>();
            drivers.Add(new Driver() { FirstName = "John", LastName = "Smith", LastAssignment = "Midland, TX" });
            return View(drivers);
        }

        //
        // GET: /Drivers/JohnSmith
        public ActionResult Details(string name) {
            Driver driver = new DriverRepository().Get(name);
            return View(driver);
        }

        public ActionResult New() {
            return View();
        }

        [HttpPost]
        public ActionResult New(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /Drivers/Edit/JohnSmith
        public ActionResult Edit(string name) {
            return View();
        }

        //
        // POST: /Drivers/Edit/JohnSmith
        [HttpPost]
        public ActionResult Edit(string name, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // POST: /Drivers/Delete/JohnSmith
        [HttpPost]
        public ActionResult Delete(string name) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
