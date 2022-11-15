using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exampleee.Models;

namespace Exampleee.Controllers
{
    public class Test_DetailController : Controller
    {
        private VSEntities db = new VSEntities();

        // GET: Test_Detail
        public ActionResult Index()
        {
            return View(db.Test_Details.ToList());
        }

        // GET: Test_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Detail test_Detail = db.Test_Details.Find(id);
            if (test_Detail == null)
            {
                return HttpNotFound();
            }
            return View(test_Detail);
        }

        // GET: Test_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Sno,Name,DateofBirth,Age,Mobile")] Test_Detail test_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Test_Details.Add(test_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test_Detail);
        }

        // GET: Test_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Detail test_Detail = db.Test_Details.Find(id);
            if (test_Detail == null)
            {
                return HttpNotFound();
            }
            return View(test_Detail);
        }

        // POST: Test_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Sno,Name,DateofBirth,Age,Mobile")] Test_Detail test_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test_Detail);
        }

        // GET: Test_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Detail test_Detail = db.Test_Details.Find(id);
            if (test_Detail == null)
            {
                return HttpNotFound();
            }
            return View(test_Detail);
        }

        // POST: Test_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Detail test_Detail = db.Test_Details.Find(id);
            db.Test_Details.Remove(test_Detail);
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
