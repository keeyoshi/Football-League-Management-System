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
    public class league_teamController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: league_team
        public ActionResult Index()
        {
            var league_team = db.league_team.Include(l => l.league).Include(l => l.team);
            return View(league_team.ToList());
        }

        // GET: league_team/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            league_team league_team = db.league_team.Find(id);
            if (league_team == null)
            {
                return HttpNotFound();
            }
            return View(league_team);
        }

        // GET: league_team/Create
        public ActionResult Create()
        {
            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name");
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name");
            return View();
        }

        // POST: league_team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "league_id,team_id,match_played,win,loss,ties,points")] league_team league_team)
        {
            if (ModelState.IsValid)
            {
                db.league_team.Add(league_team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name", league_team.league_id);
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name", league_team.team_id);
            return View(league_team);
        }

        // GET: league_team/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            league_team league_team = db.league_team.Find(id);
            if (league_team == null)
            {
                return HttpNotFound();
            }
            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name", league_team.league_id);
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name", league_team.team_id);
            return View(league_team);
        }

        // POST: league_team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "league_id,team_id,match_played,win,loss,ties,points")] league_team league_team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(league_team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.league_id = new SelectList(db.leagues, "league_id", "league_name", league_team.league_id);
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name", league_team.team_id);
            return View(league_team);
        }

        // GET: league_team/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            league_team league_team = db.league_team.Find(id);
            if (league_team == null)
            {
                return HttpNotFound();
            }
            return View(league_team);
        }

        // POST: league_team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            league_team league_team = db.league_team.Find(id);
            db.league_team.Remove(league_team);
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
