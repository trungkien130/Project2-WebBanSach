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
    public class SachsController : Controller
    {
        private ThucTapChuyenDe1Entities db = new ThucTapChuyenDe1Entities();

        // GET: Admin/Sachs
        public ActionResult Index()
        {
            var sach = db.Sach.Include(s => s.DanhMucSach);
            return View(sach.ToList());
        }

        // GET: Admin/Sachs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/Sachs/Create
        public ActionResult Create()
        {
            ViewBag.IdDM = new SelectList(db.DanhMucSach, "Id", "TenDanhMuc");
            return View();
        }

        // POST: Admin/Sachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,IdDM,SoLuong,DonGia,Img,TacGia,MoTa")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Sach.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDM = new SelectList(db.DanhMucSach, "Id", "TenDanhMuc", sach.IdDM);
            return View(sach);
        }

        // GET: Admin/Sachs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDM = new SelectList(db.DanhMucSach, "Id", "TenDanhMuc", sach.IdDM);
            return View(sach);
        }

        // POST: Admin/Sachs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,IdDM,SoLuong,DonGia,Img,TacGia,MoTa")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDM = new SelectList(db.DanhMucSach, "Id", "TenDanhMuc", sach.IdDM);
            return View(sach);
        }

        // GET: Admin/Sachs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/Sachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Sach.Find(id);
            db.Sach.Remove(sach);
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
