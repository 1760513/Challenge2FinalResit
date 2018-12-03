using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PotLuckApp.Models;

namespace PotLuckApp.Controllers
{
    public class PotLuckDInnersController : Controller
    {
        private PotLuckDatabaseEntities db = new PotLuckDatabaseEntities();

        // GET: PotLuckDInners
        public ActionResult Index()
        {
            var potLuckDInners = db.PotLuckDInners.Include(p => p.PotLuckMember);
            return View(potLuckDInners.ToList());
        }

        public ActionResult FutureDinners()
        {
            var potLuckDInners = db.PotLuckDInners.Include(p => p.PotLuckMember);
            return View(potLuckDInners.ToList());
        }

        // GET: PotLuckDInners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotLuckDInner potLuckDInner = db.PotLuckDInners.Find(id);
            if (potLuckDInner == null)
            {
                return HttpNotFound();
            }
            return View(potLuckDInner);
        }

        // GET: PotLuckDInners/Create
        public ActionResult Create()
        {
            ViewBag.HostId = new SelectList(db.PotLuckMembers, "MemberId", "FirstName");
            return View();
        }

        // POST: PotLuckDInners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DinnerId,Time,Date,Venue,HostId,Host,AmountSpent,Cancelled")] PotLuckDInner potLuckDInner)
        {
            if (ModelState.IsValid)
            {
                db.PotLuckDInners.Add(potLuckDInner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HostId = new SelectList(db.PotLuckMembers, "MemberId", "FirstName", potLuckDInner.HostId);
            return View(potLuckDInner);
        }

        // GET: PotLuckDInners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotLuckDInner potLuckDInner = db.PotLuckDInners.Find(id);
            if (potLuckDInner == null)
            {
                return HttpNotFound();
            }
            ViewBag.HostId = new SelectList(db.PotLuckMembers, "MemberId", "FirstName", potLuckDInner.HostId);
            return View(potLuckDInner);
        }

        // POST: PotLuckDInners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DinnerId,Time,Date,Venue,HostId,Host,AmountSpent,Cancelled")] PotLuckDInner potLuckDInner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potLuckDInner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostId = new SelectList(db.PotLuckMembers, "MemberId", "FirstName", potLuckDInner.HostId);
            return View(potLuckDInner);
        }

        // GET: PotLuckDInners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotLuckDInner potLuckDInner = db.PotLuckDInners.Find(id);
            if (potLuckDInner == null)
            {
                return HttpNotFound();
            }
            return View(potLuckDInner);
        }

        // POST: PotLuckDInners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PotLuckDInner potLuckDInner = db.PotLuckDInners.Find(id);
            db.PotLuckDInners.Remove(potLuckDInner);
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
