using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS_VIS.ViewModel;
using DBMS_VIS.Models;

namespace DBMS_VIS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AppAdminPanel aap)
        {
            string u = aap.Username;
            string p = aap.Password;
            if (ModelState.IsValid)
            {
                using (VISEntities ve = new VISEntities())
                {
                    
                    var log = ve.AdminLogins.Where(a => a.Username.Equals(u) && a.Password.Equals(p)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["username"] = log.Username;
                        return RedirectToAction("VehicleData", "VehicleData");
                    }
                    else if(aap.Password.Length <= 6)
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                }   
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("AdminLogin", "Admin");

        }
    }
}