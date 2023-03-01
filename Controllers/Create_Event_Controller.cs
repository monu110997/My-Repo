using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookEvent.Models;

namespace BookEvent.Controllers
{
    public class Create_Event_Controller : Controller
    {
        private BookEvent2 db = new BookEvent2();

        // GET: Create_Event_
        public ActionResult Index()
        {
            return View(db.Create_Event_.ToList());
        }

        // GET: Create_Event_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Create_Event_ create_Event_ = db.Create_Event_.Find(id);
            if (create_Event_ == null)
            {
                return HttpNotFound();
            }
            return View(create_Event_);
        }

        // GET: Create_Event_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create_Event_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Location,Start_Time,Type_public_private_,Duration_in_hours,Description,Other_Deatils,Invite_by_Email")] Create_Event_ create_Event_)
        {
            if (ModelState.IsValid)
            {
                db.Create_Event_.Add(create_Event_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(create_Event_);
        }

        // GET: Create_Event_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Create_Event_ create_Event_ = db.Create_Event_.Find(id);
            if (create_Event_ == null)
            {
                return HttpNotFound();
            }
            return View(create_Event_);
        }

        // POST: Create_Event_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Location,Start_Time,Type_public_private_,Duration_in_hours,Description,Other_Deatils,Invite_by_Email")] Create_Event_ create_Event_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(create_Event_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(create_Event_);
        }

        // GET: Create_Event_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Create_Event_ create_Event_ = db.Create_Event_.Find(id);
            if (create_Event_ == null)
            {
                return HttpNotFound();
            }
            return View(create_Event_);
        }

        // POST: Create_Event_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Create_Event_ create_Event_ = db.Create_Event_.Find(id);
            db.Create_Event_.Remove(create_Event_);
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
