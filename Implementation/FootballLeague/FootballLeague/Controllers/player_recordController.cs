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
    public class player_recordController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: player_record
        public ActionResult Index()
        {
            var player_record = db.player_record.Include(p => p.player);
            return View(player_record.ToList());
        }

        // GET: player_record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_record player_record = db.player_record.Find(id);
            if (player_record == null)
            {
                return HttpNotFound();
            }
            return View(player_record);
        }

        // GET: player_record/Create
        public ActionResult Create()
        {
            ViewBag.player_id = new SelectList(db.players, "player_id", "player_fullname");
            return View();
        }

        // POST: player_record/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "record_id,player_id,goal_scored,goal_assist")] player_record player_record)
        {
            if (ModelState.IsValid)
            {
                db.player_record.Add(player_record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.player_id = new SelectList(db.players, "player_id", "player_fullname", player_record.player_id);
            return View(player_record);
        }

        // GET: player_record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_record player_record = db.player_record.Find(id);
            if (player_record == null)
            {
                return HttpNotFound();
            }
            ViewBag.player_id = new SelectList(db.players, "player_id", "player_fullname", player_record.player_id);
            return View(player_record);
        }

        // POST: player_record/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "record_id,player_id,goal_scored,goal_assist")] player_record player_record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player_record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.player_id = new SelectList(db.players, "player_id", "player_fullname", player_record.player_id);
            return View(player_record);
        }

        // GET: player_record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_record player_record = db.player_record.Find(id);
            if (player_record == null)
            {
                return HttpNotFound();
            }
            return View(player_record);
        }

        // POST: player_record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            player_record player_record = db.player_record.Find(id);
            db.player_record.Remove(player_record);
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
