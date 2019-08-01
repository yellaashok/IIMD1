using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class ActingsController : Controller
    {
        private DBModel db = new DBModel();

        
        public ActionResult Index()
        {
            return View(db.Actings.ToList());
        }

        // GET: Actings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acting acting = db.Actings.Find(id);
            if (acting == null)
            {
                return HttpNotFound();
            }
            return View(acting);
        }

        // GET: Actings/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,DOB,Bio")] Acting acting)
        {
            if (ModelState.IsValid)
            {
                db.Actings.Add(acting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acting);
        }

        // GET: Actings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acting acting = db.Actings.Find(id);
            if (acting == null)
            {
                return HttpNotFound();
            }
            return View(acting);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,DOB,Bio")] Acting acting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acting);
        }

        // GET: Actings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acting acting = db.Actings.Find(id);
            if (acting == null)
            {
                return HttpNotFound();
            }
            return View(acting);
        }

        // POST: Actings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acting acting = db.Actings.Find(id);
            db.Actings.Remove(acting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
