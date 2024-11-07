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
    public class SlidesController : Controller
    {
        private ThucTapChuyenDe1Entities db = new ThucTapChuyenDe1Entities();

        // GET: Admin/Slides
        public ActionResult Index()
        {
            return View(db.Slide.ToList());
        }

        // GET: Admin/Slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide Slide = db.Slide.Find(id);
            if (Slide == null)
            {
                return HttpNotFound();
            }
            return View(Slide);
        }

        // GET: Admin/Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Img")] Slide Slide)
        {
            if (ModelState.IsValid)
            {
                db.Slide.Add(Slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Slide);
        }

        // GET: Admin/Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide Slide = db.Slide.Find(id);
            if (Slide == null)
            {
                return HttpNotFound();
            }
            return View(Slide);
        }

        // POST: Admin/Slides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Img")] Slide Slide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Slide);
        }

        // GET: Admin/Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide Slide = db.Slide.Find(id);
            if (Slide == null)
            {
                return HttpNotFound();
            }
            return View(Slide);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide Slide = db.Slide.Find(id);
            db.Slide.Remove(Slide);
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
