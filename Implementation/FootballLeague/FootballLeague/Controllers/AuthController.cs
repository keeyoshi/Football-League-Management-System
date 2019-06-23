using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            DBConnection db= new DBConnection();
            var data = db.st_getLoginDetails(u.username, u.password);
            foreach(var item in data)
            {
                if(item.username==u.username && item.password==u.password)
                {

                    string r = db.st_gettRolesWRTuser(u.username).Single();
                    Session["role"] = r;
                    Session["name"] = u.username;
                    return RedirectToAction("Main");
                }
                else
                {

                }
            }
            return View();
        }
        public ActionResult Main()
        {
            if(Session["name"]==null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("name");
            Session.Remove("role");
            return View("Index");
        }
    }
}