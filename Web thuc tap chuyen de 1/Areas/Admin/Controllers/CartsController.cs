using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_thuc_tap_chuyen_de_1.Models;

namespace Web_thuc_tap_chuyen_de_1.Areas.Admin.Controllers
{
    public class CartsController : Controller
    {
        private ThucTapChuyenDe1Entities db = new ThucTapChuyenDe1Entities();

        // GET: Admin/Carts
        public ActionResult Index()
        {
            var cart = db.Cart.Include(c => c.KhachHang).Include(c => c.Sach);
            return View(cart.ToList());
        }

        // GET: Admin/Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Admin/Carts/Create
        public ActionResult Create()
        {
            ViewBag.IdKH = new SelectList(db.KhachHang, "MaKH", "HoTen");
            ViewBag.IdSach = new SelectList(db.Sach, "MaSach", "TenSach");
            return View();
        }

        // POST: Admin/Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSach,SoLuong,DonGia,Img,Tong,IdKH")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Cart.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKH = new SelectList(db.KhachHang, "MaKH", "HoTen", cart.IdKH);
            ViewBag.IdSach = new SelectList(db.Sach, "MaSach", "TenSach", cart.IdSach);
            return View(cart);
        }

        // GET: Admin/Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKH = new SelectList(db.KhachHang, "MaKH", "HoTen", cart.IdKH);
            ViewBag.IdSach = new SelectList(db.Sach, "MaSach", "TenSach", cart.IdSach);
            return View(cart);
        }

        // POST: Admin/Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSach,SoLuong,Img ,DonGia,Tong,IdKH")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKH = new SelectList(db.KhachHang, "MaKH", "HoTen", cart.IdKH);
            ViewBag.IdSach = new SelectList(db.Sach, "MaSach", "TenSach", cart.IdSach);
            return View(cart);
        }

        // GET: Admin/Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Admin/Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Cart.Find(id);
            db.Cart.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
