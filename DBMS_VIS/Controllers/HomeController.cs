using DBMS_VIS.Models;
using DBMS_VIS.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_VIS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {     
            return View();
        }
        public ActionResult Search(string searchBy, string search)
        {
            if (searchBy == "RegistrationNumber" && search != "")
            {
                    HomeViewModel hvm = new HomeViewModel();
                    List<AppData> ad = hvm.GetRecordByRegistrationNumber(search);
                    return View(ad);

            }
            else if(searchBy == "OwnerName" && search != "")
            {
                HomeViewModel hvm = new HomeViewModel();
                List<AppData> ad = hvm.GetRecordByOwnerName(search);
                return View(ad);
            }
            else
            {
                return View();
            }
  
        }
    }
}