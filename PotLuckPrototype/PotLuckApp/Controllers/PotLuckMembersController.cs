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
    public class PotLuckMembersController : Controller
    {
        private PotLuckDatabaseEntities db = new PotLuckDatabaseEntities();

        // GET: PotLuckMembers
        public ActionResult Index()
        {
            return View(db.PotLuckMembers.ToList());
        }

        // GET: PotLuckMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotLuckMember potLuckMember = db.PotLuckMembers.Find(id);
            if (potLuckMember == null)
            {
                return HttpNotFound();
            }
            return View(potLuckMember);
        }

        // GET: PotLuckMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PotLuckMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastName,Authorised")] PotLuckMember potLuckMember)
        {
            if (ModelState.IsValid)
            {
                db.PotLuckMembers.Add(potLuckMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(potLuckMember);
        }

        // GET: PotLuckMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotLuckMember potLuckMember = db.PotLuckMembers.Find(id);
            if (potLuckMember == null)
            {
                return HttpNotFound();
            }
            return View(potLuckMember);
        }

        // POST: PotLuckMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastName,Authorised")] PotLuckMember potLuckMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potLuckMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potLuckMember);
        }

        // GET: PotLuckMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotLuckMember potLuckMember = db.PotLuckMembers.Find(id);
            if (potLuckMember == null)
            {
                return HttpNotFound();
            }
            return View(potLuckMember);
        }

        // POST: PotLuckMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PotLuckMember potLuckMember = db.PotLuckMembers.Find(id);
            db.PotLuckMembers.Remove(potLuckMember);
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
