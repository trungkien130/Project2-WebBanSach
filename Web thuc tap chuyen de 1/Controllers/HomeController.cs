using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Web_thuc_tap_chuyen_de_1.Models;

namespace Web_thuc_tap_chuyen_de_1.Controllers
{
    public class HomeController : Controller
    {
        private ThucTapChuyenDe1Entities db = new ThucTapChuyenDe1Entities();

        private class Admin
        {
            public string Tk { get; set; } = "Admin";
            public string Password { get; set; } = "admin";
        }

        public class HomeViewModel
        {
            public List<Sach> Books { get; set; }
            public List<Slide> Slides { get; set; }
            public int IdSach { get; set; }
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Books = db.Sach.ToList(),
                Slides = db.Slide.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.NgayDangKy = DateTime.Now;
                khachHang.TrangThai = true;
                db.KhachHang.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string SDT, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.KhachHang.Where(s => s.SDT.Equals(SDT) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["FullName"] = data.FirstOrDefault().HoTen;
                    Session["SDT"] = data.FirstOrDefault().SDT;
                    Session["idUser"] = data.FirstOrDefault().MaKH;
                    return RedirectToAction("Index");
                }
                var adminUser = new Admin();
                if (SDT == adminUser.Tk && password == adminUser.Password)
                {
                    Session["FullName"] = "Admin";
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult CustomDetail(int id)
        {
            var customer = db.KhachHang.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult DetailEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var customer = db.KhachHang.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult BookDetail(int id)
        {
            var book = db.Sach.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Cart(int id, int? quantity)
        {
            var userId = (int?)Session["idUser"];
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var khachHang = db.KhachHang.Find(userId.Value);
            if (khachHang == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }

            if (!quantity.HasValue || quantity.Value <= 0)
            {
                quantity = 1; 
            }

            var existingCartItem = db.Cart
                .FirstOrDefault(c => c.IdKH == khachHang.MaKH && c.IdSach == sach.MaSach);

            if (existingCartItem != null)
            {
                existingCartItem.SoLuong += quantity.Value;
                existingCartItem.Tong = existingCartItem.DonGia * existingCartItem.SoLuong;
                db.Entry(existingCartItem).State = EntityState.Modified;
            }
            else
            {
                // Create a new cart item
                var cartItem = new Cart
                {
                    IdKH = khachHang.MaKH,
                    IdSach = sach.MaSach,
                    SoLuong = quantity.Value,
                    DonGia = sach.DonGia,
                    Tong = sach.DonGia * quantity.Value
                };
                db.Cart.Add(cartItem);
            }

            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            var userId = (int?)Session["idUser"];
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var cartItems = db.Cart.Where(c => c.IdKH == userId.Value).ToList();
            return View(cartItems);
        }
        [HttpPost]
[ValidateAntiForgeryToken]
public ActionResult DeleteFromCart(int id)
{
    var userId = (int?)Session["idUser"];
    if (!userId.HasValue)
    {
        return RedirectToAction("Login", "Home");
    }

    // Find the cart item to delete
    var cartItem = db.Cart.Find(id);
    if (cartItem != null && cartItem.IdKH == userId.Value)
    {
        db.Cart.Remove(cartItem);
        db.SaveChanges();
    }

    return RedirectToAction("Cart");
}

    }
}
