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
    public class usersController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.role).Include(u => u.league);
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name");
            ViewBag.favorite_league = new SelectList(db.leagues, "league_id", "league_name");
            createcombo();
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_fullname,email,location,password,gender,favorite_league,u_status,u_roleID,username")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name", user.u_roleID);
            ViewBag.favorite_league = new SelectList(db.leagues, "league_id", "league_name", user.favorite_league);
            return View(user);
        }
        private void createcombo()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Active", Value = "1" });
            li.Add(new SelectListItem() { Text = "In-active", Value = "0" });
            ViewBag.abc = new SelectList(li, "Value", "Text");
        }
        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            createcombo();
           
            role role = db.roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name", user.u_roleID);
            ViewBag.favorite_league = new SelectList(db.leagues, "league_id", "league_name", user.favorite_league);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_fullname,email,location,password,gender,favorite_league,u_status,u_roleID,username")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name", user.u_roleID);
            ViewBag.favorite_league = new SelectList(db.leagues, "league_id", "league_name", user.favorite_league);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
