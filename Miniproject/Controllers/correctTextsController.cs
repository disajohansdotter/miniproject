using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Miniproject.DataAccess;
using Miniproject.Models;

namespace Miniproject.Controllers
{
    public class correctTextsController : Controller
    {
        private MPContext db = new MPContext();

        // GET: correctTexts
        public ActionResult Index()
        {
            //return View(db.correctTexts.ToList());
            //correctText t = new correctText() { correctTextID = 0, cText = "Hej* världen*", punctuation = "Hej, världen!" };
            return View();
        }

        public JsonResult GetChallenges()
        {
            correctText t = new correctText() { correctTextID = 0, punctuation = "Hej* världen*", cText = "Hej, världen!" };
            return Json(db.correctTexts.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: correctTexts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            correctText correctText = db.correctTexts.Find(id);
            if (correctText == null)
            {
                return HttpNotFound();
            }
            return View(correctText);
        }

        // GET: correctTexts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: correctTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "correctTextID,cText,punctuation")] correctText correctText)
        {
            if (ModelState.IsValid)
            {
                db.correctTexts.Add(correctText);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(correctText);
        }

        // GET: correctTexts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            correctText correctText = db.correctTexts.Find(id);
            if (correctText == null)
            {
                return HttpNotFound();
            }
            return View(correctText);
        }

        // POST: correctTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correctTextID,cText,punctuation")] correctText correctText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(correctText).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(correctText);
        }

        // GET: correctTexts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            correctText correctText = db.correctTexts.Find(id);
            if (correctText == null)
            {
                return HttpNotFound();
            }
            return View(correctText);
        }

        // POST: correctTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            correctText correctText = db.correctTexts.Find(id);
            db.correctTexts.Remove(correctText);
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
