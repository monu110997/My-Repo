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
    public class Login_RegisterController : Controller
    {
        private BookEvent2 db = new BookEvent2();

        // GET: Login_Register
        public ActionResult Index()
        {
            return View(db.Login_Register.ToList());
        }

        // GET: Login_Register/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_Register login_Register = db.Login_Register.Find(id);
            if (login_Register == null)
            {
                return HttpNotFound();
            }
            return View(login_Register);
        }

        // GET: Login_Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login_Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Full_Name,E_mail,Password")] Login_Register login_Register)
        {
            if (ModelState.IsValid)
            {
                db.Login_Register.Add(login_Register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login_Register);
        }

        // GET: Login_Register/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_Register login_Register = db.Login_Register.Find(id);
            if (login_Register == null)
            {
                return HttpNotFound();
            }
            return View(login_Register);
        }

        // POST: Login_Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Full_Name,E_mail,Password")] Login_Register login_Register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login_Register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login_Register);
        }

        // GET: Login_Register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_Register login_Register = db.Login_Register.Find(id);
            if (login_Register == null)
            {
                return HttpNotFound();
            }
            return View(login_Register);
        }

        // POST: Login_Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login_Register login_Register = db.Login_Register.Find(id);
            db.Login_Register.Remove(login_Register);
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
