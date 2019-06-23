using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballLeague;

namespace FootballLeague.Controllers
{
    public class tbl_newsController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: tbl_news
        public ActionResult Index()
        {
            return View(db.tbl_news.ToList());
        }

        // GET: tbl_news/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_news tbl_news = db.tbl_news.Find(id);
            if (tbl_news == null)
            {
                return HttpNotFound();
            }
            return View(tbl_news);
        }

        // GET: tbl_news/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_news/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,Content,Images")] tbl_news tbl_news)
        {
            if (ModelState.IsValid)
            {
                db.tbl_news.Add(tbl_news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_news);
        }

        // GET: tbl_news/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_news tbl_news = db.tbl_news.Find(id);
            if (tbl_news == null)
            {
                return HttpNotFound();
            }
            return View(tbl_news);
        }

        // POST: tbl_news/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,Content,Images")] tbl_news tbl_news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_news);
        }

        // GET: tbl_news/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_news tbl_news = db.tbl_news.Find(id);
            if (tbl_news == null)
            {
                return HttpNotFound();
            }
            return View(tbl_news);
        }

        // POST: tbl_news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_news tbl_news = db.tbl_news.Find(id);
            db.tbl_news.Remove(tbl_news);
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
