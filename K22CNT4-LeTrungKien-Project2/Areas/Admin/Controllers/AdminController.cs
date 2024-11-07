using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_thuc_tap_chuyen_de_1.Models;
namespace Web_thuc_tap_chuyen_de_1.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private ThucTapChuyenDe1Entities db = new ThucTapChuyenDe1Entities();

        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = new DashboardViewModel()
            {
                KhachHang = db.KhachHang.Count(),
                DanhMucSach = db.DanhMucSach.Count(),
                GioHang = db.Cart.Count(),
                Sach = db.Sach.Count(),
                Slide = db.Slide.Count()
            };

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}