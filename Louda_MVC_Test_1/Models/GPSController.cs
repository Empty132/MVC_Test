using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Louda_MVC_Test_1.Models
{
    public class GPSController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: GPS
        public ActionResult Index()
        {
            return View(db.GPS.ToList());
        }

        // GET: GPS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPS gPS = db.GPS.Find(id);
            if (gPS == null)
            {
                return HttpNotFound();
            }
            return View(gPS);
        }

        // GET: GPS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GPS/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,latitude,longitude")] GPS gPS)
        {
            if (ModelState.IsValid)
            {
                db.GPS.Add(gPS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gPS);
        }

        // GET: GPS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPS gPS = db.GPS.Find(id);
            if (gPS == null)
            {
                return HttpNotFound();
            }
            return View(gPS);
        }

        // POST: GPS/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,latitude,longitude")] GPS gPS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gPS);
        }

        // GET: GPS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPS gPS = db.GPS.Find(id);
            if (gPS == null)
            {
                return HttpNotFound();
            }
            return View(gPS);
        }

        // POST: GPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPS gPS = db.GPS.Find(id);
            db.GPS.Remove(gPS);
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
