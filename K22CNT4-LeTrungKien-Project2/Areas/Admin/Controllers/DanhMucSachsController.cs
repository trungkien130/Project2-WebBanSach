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
    public class DanhMucSachsController : Controller
    {
        private ThucTapChuyenDe1Entities db = new ThucTapChuyenDe1Entities();

        // GET: Admin/DanhMucSachs
        public ActionResult Index()
        {
            return View(db.DanhMucSach.ToList());
        }

        // GET: Admin/DanhMucSachs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSach danhMucSach = db.DanhMucSach.Find(id);
            if (danhMucSach == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSach);
        }

        // GET: Admin/DanhMucSachs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucSachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenDanhMuc,TrangThai")] DanhMucSach danhMucSach)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucSach.Add(danhMucSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucSach);
        }

        // GET: Admin/DanhMucSachs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSach danhMucSach = db.DanhMucSach.Find(id);
            if (danhMucSach == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSach);
        }

        // POST: Admin/DanhMucSachs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenDanhMuc,TrangThai")] DanhMucSach danhMucSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucSach);
        }

        // GET: Admin/DanhMucSachs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSach danhMucSach = db.DanhMucSach.Find(id);
            if (danhMucSach == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSach);
        }

        // POST: Admin/DanhMucSachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucSach danhMucSach = db.DanhMucSach.Find(id);
            db.DanhMucSach.Remove(danhMucSach);
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
