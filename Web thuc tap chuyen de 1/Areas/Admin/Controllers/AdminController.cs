using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_thuc_tap_chuyen_de_1.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            // Clear the session
            Session.Clear();
            Session.Abandon(); // Optional: Completely end the session

            // Redirect to the Index action
            return RedirectToAction("Index","Home");
        }

    }
}