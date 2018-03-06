using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetMVC.Models;

namespace PetMVC.Controllers
{
    public class PetModelsController : Controller
    {
        private PetMVCContext db = new PetMVCContext();

        // GET: PetModels
        public ActionResult Index()
        {
            return View(db.PetModels.ToList());
        }

        // GET: PetModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetModel petModel = db.PetModels.Find(id);
            if (petModel == null)
            {
                return HttpNotFound();
            }
            return View(petModel);
        }

        // GET: PetModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,PetName,Age")] PetModel petModel)
        {
            if (ModelState.IsValid)
            {
                db.PetModels.Add(petModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(petModel);
        }

        // GET: PetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetModel petModel = db.PetModels.Find(id);
            if (petModel == null)
            {
                return HttpNotFound();
            }
            return View(petModel);
        }

        // POST: PetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,PetName,Age")] PetModel petModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petModel);
        }

        // GET: PetModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetModel petModel = db.PetModels.Find(id);
            if (petModel == null)
            {
                return HttpNotFound();
            }
            return View(petModel);
        }

        // POST: PetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetModel petModel = db.PetModels.Find(id);
            db.PetModels.Remove(petModel);
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
