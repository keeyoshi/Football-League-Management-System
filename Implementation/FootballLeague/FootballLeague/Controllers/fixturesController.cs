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
    public class fixturesController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: fixtures
        public ActionResult Index()
        {
            var fixtures = db.fixtures.Include(f => f.league);
            return View(fixtures.ToList());
        }

        // GET: fixtures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fixture fixture = db.fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // GET: fixtures/Create
        public ActionResult Create()
        {
            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name");
            return View();
        }

        // POST: fixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fixture_id,location,teamA,teamB,score,league_id")] fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.fixtures.Add(fixture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name", fixture.league_id);
            return View(fixture);
        }

        // GET: fixtures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fixture fixture = db.fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name", fixture.league_id);
            return View(fixture);
        }

        // POST: fixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fixture_id,location,teamA,teamB,score,league_id")] fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name", fixture.league_id);
            return View(fixture);
        }

        // GET: fixtures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fixture fixture = db.fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fixture fixture = db.fixtures.Find(id);
            db.fixtures.Remove(fixture);
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
